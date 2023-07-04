using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RestAPI_farmersMarket.Models;

namespace RestAPI_farmersMarket.Controllers
{
    public class ProductsController: ControllerBase
    {
    
        //Create a connection state retriever, which will hold the connection information from the remote server
        private readonly IConfiguration _configuration;
        public ProductsController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet] 
        [Route("GetAllProducts")]
        public Response GetAllProducts()
        {
            //calling the connection retriever in the appsettings.json
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("ProductConnection").ToString()); 
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetAllProducts(connection); 
            return response;
        }

        [HttpGet]
        [Route("GetProductByID/{id}")]
        public Response GetProductByID(int id)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("ProductConnection").ToString()); 
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetProductByID(id, connection);  
            return response;
        }

        [HttpPost]
        [Route("AddProduct")]
        public Response AddProduct([FromBody]Product product)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("ProductConnection").ToString()); 
            Response response = new Response();
            Application apl = new Application();
            response = apl.AddProduct(connection, product);
            return response;
        }


        [HttpPut]
        [Route("UpdateProduct")]
        public Response UpdateProduct([FromBody] Product product)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("ProductConnection").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.UpdateProduct(connection, product);
            return response;
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public Response DeleteProduct(int id)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("ProductConnection").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.DeleteProduct(connection, id);
            return response;
        }

        [HttpPut]
        [Route("UpdateInventory")]
        public Response UpdateInventory([FromBody] Product productToUpdate)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("ProductConnection").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.UpdateInventory(connection, productToUpdate);
            return response;
        }

    }
}
