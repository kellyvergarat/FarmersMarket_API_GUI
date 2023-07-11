using NUnit.Framework;
using Npgsql;
using RestAPI_farmersMarket.Models;
using RestAPI_farmersMarket.Controllers;
using System.Configuration;
using Moq;
using System.Data;
using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace RestAPI_farmersMarket.Testing
{
    [TestFixture]
    public class Testing
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=farmersMarket;Username=postgres;Password=0000;";
        private Mock<IConfiguration> _configurationMock;
        private ProductsController _productsController;
        HttpClient httpClient;


        [SetUp]
        public void Setup()
        {
            // Create a mock configuration object
            _configurationMock = new Mock<IConfiguration>();

            // Create an instance of the ProductsController and pass the mock configuration object
            _productsController = new ProductsController(_configurationMock.Object);
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7113/Products");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        [Test]
        public void InsertDataUsingADO_Success()
        {
            // Arrange
            var product = new Product
            {
                Id = 15,
                Name = "Test Product",
                Amount = 10,
                Price = 9.99f
            };

            // Act
            var connection = new NpgsqlConnection(ConnectionString);

            var application = new Application();
                var response = application.AddProduct(connection, product);

                // Assert
                Assert.AreEqual(200, response.statusCode);

            // Retrieve the inserted data and assert its values
            var insertedProduct = RetrieveProductFromDatabase(connection, product.Id);
                Assert.AreEqual(product.Id, insertedProduct.Id);
                Assert.AreEqual(product.Name, insertedProduct.Name);
                Assert.AreEqual(product.Amount, insertedProduct.Amount);
                Assert.AreEqual(product.Price, insertedProduct.Price);
        }

        [Test]
        public async Task InsertDataUsingAPI_Success()
        {
            // Arrange
            var product = new Product
            {
                Id = 17,
                Name = "Test Product 2",
                Amount = 5,
                Price = 19.99f
            };

            // Act
            var response = await httpClient.PostAsJsonAsync("InsertProduct", product);
            Assert.IsTrue(response.IsSuccessStatusCode);

            // Assert
            var retrievedResponse = await httpClient.GetAsync($"GetProductByID/{product.Id}");
            Assert.IsTrue(retrievedResponse.IsSuccessStatusCode);

            var content = await retrievedResponse.Content.ReadAsStringAsync();
            var retrievedProduct = JsonSerializer.Deserialize<Product>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.AreEqual(product.Id, retrievedProduct.Id);
            Assert.AreEqual(product.Name, retrievedProduct.Name);
            Assert.AreEqual(product.Amount, retrievedProduct.Amount);
            Assert.AreEqual(product.Price, retrievedProduct.Price);
        }

       

        [Test]
        public async Task UpdateDataUsingADO_Success()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = "Updated Product",
                Amount = 15,
                Price = 14.99f
            };

            // Act
            var connection = new NpgsqlConnection(ConnectionString);
            

                var application = new Application();
                var response = application.UpdateProduct(connection, product);

                // Assert
                Assert.AreEqual(200, response.statusCode);

                // Retrieve the updated data and assert its values
                var updatedProduct = RetrieveProductFromDatabase(connection, product.Id);
                Assert.AreEqual(product.Id, updatedProduct.Id);
                Assert.AreEqual(product.Name, updatedProduct.Name);
                Assert.AreEqual(product.Amount, updatedProduct.Amount);
                Assert.AreEqual(product.Price, updatedProduct.Price);
            
        }


        [Test]
        public async Task UpdateDataUsingAPI_Success()
        {
            // Arrange
            var product = new Product
            {
                Id = 2,
                Name = "Updated Product 2",
                Amount = 8,
                Price = 24.99f
            };

            // Convert the product to JSON
            var jsonProduct = JsonConvert.SerializeObject(product);
            var httpContent = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

            // Set the content type header
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await httpClient.PutAsync("UpdateProduct", httpContent);
            var responseData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response>(responseData);

            // Assert
            Assert.AreEqual(200, (int)response.StatusCode);
            Assert.AreEqual(200, result.statusCode);

            // Retrieve the updated data using GET request and assert its values
            var retrievedResponse = _productsController.GetProductByID(product.Id);
            Assert.AreEqual(200, retrievedResponse.statusCode);
            Assert.AreEqual(product.Id, retrievedResponse.product.Id);
            Assert.AreEqual(product.Name, retrievedResponse.product.Name);
            Assert.AreEqual(product.Amount, retrievedResponse.product.Amount);
            Assert.AreEqual(product.Price, retrievedResponse.product.Price);
        }

        [Test]
        public void DeleteDataUsingADO_Success()
        {
            // Arrange
            var productId = 1;

            // Act
            var connection = new NpgsqlConnection(ConnectionString);
            

                var application = new Application();
                var response = application.DeleteProduct(connection, productId);

                // Assert
                Assert.AreEqual(200, response.statusCode);

                // Verify the non-existence of the deleted data using SELECT query
                var deletedProduct = RetrieveProductFromDatabase(connection, productId);
                Assert.IsNull(deletedProduct);
            
        }

        [Test]
        public async Task DeleteDataUsingAPI_Success()
        {
            // Arrange
            int productId = 2;

            // Act
            var response = await httpClient.DeleteAsync($"DeleteProduct/{productId}");
            var responseData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response>(responseData);

            // Assert
            Assert.AreEqual(200, (int)response.StatusCode);
            Assert.AreEqual(200, result.statusCode);

            // Verify the non-existence of the deleted data using GET request
            var retrievedResponse = await httpClient.GetAsync($"GetProductByID/{productId}");
            var retrievedData = await retrievedResponse.Content.ReadAsStringAsync();
            var retrievedResult = JsonConvert.DeserializeObject<Response>(retrievedData);

            Assert.AreEqual(100, (int)retrievedResponse.StatusCode);
            Assert.IsNull(retrievedResult.product);
        }



        private Product RetrieveProductFromDatabase(NpgsqlConnection connection, int productId)
        {
            var query = $"SELECT * FROM products WHERE id = {productId}";

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            using (var command = new NpgsqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var product = new Product
                        {
                            Id = (int)reader["id"],
                            Name = (string)reader["product_name"],
                            Amount = (int)reader["amount"],
                            Price = (float)reader["price"]
                        };

                        return product;
                    }
                }
            }

            return null;
        }



    }


}
