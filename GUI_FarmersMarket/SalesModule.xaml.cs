using FarmersMarket_GUI.Models;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FarmersMarket_GUI
{
    /// <summary>
    /// Interaction logic for SalesModule.xaml
    /// </summary>
    public partial class SalesModule : Window
    {
        private static HttpClient httpClient;
        private DataTable productsTable;

        public SalesModule()
        {
            // Initialize HttpClient for REST API calls
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7113/Products");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            productsTable = new DataTable();
            InitializeComponent();
            LoadProductsData();
        }

        private void _return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
            this.Close();
        }

        private async void BuyBtn_Click(object sender, RoutedEventArgs e)
        {
            string customerName = search.Text;
            string message = $"Thank you, {customerName}. Your purchase was successfully processed.";

            List<Product> chosenProducts = new List<Product>();

            foreach (DataRow row in productsTable.Rows)
            {
                int productId = Convert.ToInt32(row["Id"]);
                int amountDesired = Convert.ToInt32(row["Amount_Desired"]);

                // Create a Product object and add it to the chosenProducts list
                Product product = new Product
                {
                    Id = productId,
                    Amount = amountDesired
                };
                chosenProducts.Add(product);
            }

            // Call the UpdateInventory API method for each chosen product
            foreach (Product product in chosenProducts)
            {
                var response = await httpClient.PutAsJsonAsync("UpdateInventory", product);
                if (response.IsSuccessStatusCode)
                {
                    // Inventory updated successfully for this product
                }
                else
                {
                    MessageBox.Show("Failed to update inventory for product with ID: " + product.Id);
                    return; // Exit the method if any update fails
                }
            }

            MessageBox.Show(message);

            // Clear the amount column in the data grid
            foreach (DataRow row in productsTable.Rows)
            {
                row["Amount_Desired"] = 0;
            }
            salesDataGrid.Items.Refresh();
            showTotal.Content = "$ 0.0 ";
        }


        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            double total = 0;
            foreach (DataRow row in productsTable.Rows)
            {
                double amount = Convert.ToDouble(row["Amount_Desired"]);
                double price = Convert.ToDouble(row["Price"]);
                total += amount * price;
            }
            showTotal.Content = "$ " + total.ToString("0.00");
        }

        public async void LoadProductsData()
        {
            try
            {
                // Send GET request to the API endpoint
                var response = await httpClient.GetAsync("GetAllProducts");
                response.EnsureSuccessStatusCode();

                // Deserialize the response content
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<Response>(responseContent);
                List<Product> products = responseObject.products;

                productsTable.Columns.Add("Id", typeof(int));
                productsTable.Columns.Add("Name", typeof(string));
                productsTable.Columns.Add("Price", typeof(float));
                productsTable.Columns.Add("Amount_Desired", typeof(int));

                productsTable.Rows.Clear();
                foreach (Product product in products)
                {
                    DataRow row = productsTable.NewRow();
                    row["Id"] = product.Id;
                    row["Name"] = product.Name;
                    row["Price"] = product.Price;
                    row["Amount_Desired"] = 0;
                    productsTable.Rows.Add(row);
                }

                salesDataGrid.ItemsSource = productsTable.DefaultView;

                // Set the "Id", "Name", and "Price" columns as read-only
                foreach (DataGridColumn column in salesDataGrid.Columns)
                {
                    if (column.Header.ToString() == "Id" || column.Header.ToString() == "Name" || column.Header.ToString() == "Price")
                    {
                        column.IsReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}

