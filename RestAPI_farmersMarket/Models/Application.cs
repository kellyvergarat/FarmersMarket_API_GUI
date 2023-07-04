using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace RestAPI_farmersMarket.Models
{
    
    public class Application
    {
        public Response GetAllProducts(NpgsqlConnection con)
        {
            // We need a data adapter
            string query = "SELECT * FROM products";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(query, con);   // Pass the query and the connection
                                                                                 // Now, we definitely need a DataTable
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            // The application is going to get the information from the database as a response message dump
            Response response = new Response();    // Instance of the response class
            List<Product> listOfProducts = new List<Product>();   // To store the response from the server, which is all the products (because of the query)

            // The following code will retrieve data from the remote server. This is directly going to execute on the remote side/server

            // This condition verifies if the DataTable (dt) has information, meaning if data is retrieved
            if (dt.Rows.Count > 0)
            {
                // Insert from all the rows to each product in the list
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // The information we are going to retrieve from the remote "products" table, we are going to follow
                    // the Product class structure, so we need to create an instance of the Product class.
                    Product product = new Product();

                    // Since information remains in JSON structure, we need to make type casts
                    product.Id = (int)dt.Rows[i]["id"];   // From row i, take the column named 'id'
                    product.Name = (string)dt.Rows[i]["product_name"];
                    product.Amount = (int)dt.Rows[i]["amount"];
                    product.Price = (float)dt.Rows[i]["price"];

                    listOfProducts.Add(product);
                }
            }

            // Now, in the following block, we are going to create the response message from our client side
            if (listOfProducts.Count > 0)  // This means our database has some entries and those are retrieved properly
            {
                response.statusCode = 200; // 200 statusCode represents a successful query
                response.statusMessage = "Data retrieval is successful";
                response.products = listOfProducts;
            }
            else
            {
                response.statusCode = 100; // 100 statusCode represents an unsuccessful query / no data represents
                response.statusMessage = "No data retrieved.";
                response.products = null;  // null value is assigned to show that no values are retrieved from the remote server
            }

            return response;
        }

        public Response GetProductByID(int id, NpgsqlConnection con) 
        {
            Response response = new Response();
            string Query = "Select * from products where id='" + id + "'"; 
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(Query, con);  

            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Product product = new Product();
                product.Id = (int)dt.Rows[0]["id"];   //Here since it is only one row, we use Rows[0]
                product.Name = (string)dt.Rows[0]["product_name"];
                product.Amount = (int)dt.Rows[0]["amount"];
                product.Price = (float)dt.Rows[0]["price"];
                response.statusCode = 200;
                response.statusMessage = "The data retrieved successfully.";
                response.product = product;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrieved";
                response.product = null;
            }

            return response;
        }

        public Response AddProduct(NpgsqlConnection con, Product product)
        {
            Response response = new Response();
            string query = "INSERT INTO products VALUES (" + product.Id + ", '" + product.Name + "', " + product.Amount + ", " + product.Price + ")";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.statusCode = 200; // Successful query
                response.statusMessage = "Data entry successfully recorded.";
                response.product = product;
            }
            else
            {
                response.statusCode = 100; // Not successful
                response.statusMessage = "Data entry could not be recorded.";
            }
            con.Close();
            return response;
        }


        public Response UpdateProduct(NpgsqlConnection con, Product product)
        {
            Response response = new Response();
            string query = "UPDATE products SET product_name = @ProductName, amount = @Amount, price = @Price WHERE id = @ID";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ProductName", NpgsqlDbType.Varchar, product.Name); // Set the NpgsqlDbType for the parameter
            cmd.Parameters.AddWithValue("@Amount", product.Amount);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@ID", product.Id);
            con.Open();

            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.statusCode = 200; //succesfull query
                response.statusMessage = "The data is updated perfectly.";
                response.product = product;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data updated properly.";
            }
            con.Close();
            return response;
        }

        public Response DeleteProduct(NpgsqlConnection con, int id)
        {
            Response response = new Response();
            string query = "delete from products where id='" + id + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.statusCode = 200; //Successfully deleted
                response.statusMessage = "The entry is deleted from Table";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "Delete couldnt be possible.";
            }
            con.Close();
            return response;
        }

        public Response UpdateInventory(NpgsqlConnection con, Product productToUpdate)
        {
            Response response = new Response();
            using (con)
            {
                try
                {
                    con.Open();

                    string selectQuery = "SELECT amount FROM products WHERE id = @ProductId";
                    int currentAmount;

                    using (NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, con))
                    {
                        NpgsqlParameter productIdParameter = selectCommand.Parameters.AddWithValue("@ProductId", productToUpdate.Id);

                        if (productIdParameter.Value == null)
                        {
                            response.statusCode = 100;
                            response.statusMessage = "Invalid product ID.";
                            return response;
                        }

                        currentAmount = Convert.ToInt32(selectCommand.ExecuteScalar());
                    }

                    int newAmount = currentAmount - productToUpdate.Amount;

                    string updateQuery = "UPDATE products SET amount = @NewAmount WHERE id = @ProductId";

                    using (NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, con))
                    {
                        NpgsqlParameter newAmountParameter = updateCommand.Parameters.AddWithValue("@NewAmount", newAmount);
                        NpgsqlParameter productIdParameter = updateCommand.Parameters.AddWithValue("@ProductId", productToUpdate.Id);

                        if (newAmountParameter.Value == null || productIdParameter.Value == null)
                        {
                            response.statusCode = 100;
                            response.statusMessage = "Invalid parameters.";
                            return response;
                        }

                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected <= 0)
                        {
                            response.statusCode = 100;
                            response.statusMessage = "Failed to update inventory.";
                            return response;
                        }
                    }

                    response.statusCode = 200;
                    response.statusMessage = "Inventory updated successfully.";
                    return response;
                }
                catch (Exception ex)
                {
                    response.statusCode = 500;
                    response.statusMessage = ex.Message;
                    return response;
                }
            }
        }




    }
}
