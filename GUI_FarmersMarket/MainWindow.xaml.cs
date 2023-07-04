using FarmersMarket_GUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FarmersMarket_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient httpClient = new HttpClient();
        public MainWindow()
        {
            httpClient.BaseAddress = new Uri("https://localhost:7113/Products"); 
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
            showAsync();
        }

        public async Task showAsync()
        {
            var response = await httpClient.GetStringAsync("GetAllProducts");
            Response response_JSON = JsonConvert.DeserializeObject<Response>(response);
            ResponseLabel.Content = response_JSON.statusCode + " " + response_JSON.statusMessage;

            dataGrid.ItemsSource = response_JSON.products; // list of products
            DataContext = this;

            // Find the "products" column and hide it
            var productsColumn = dataGrid.Columns.FirstOrDefault(c => c.Header.ToString() == "products") as DataGridTextColumn;
            if (productsColumn != null)
            {
                productsColumn.Visibility = Visibility.Collapsed;
            }

            foreach (var column in dataGrid.Columns)
            {
                column.Width = new DataGridLength(80);
            }
        }


        private async void InsertSQL_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Name = InsertPName.Text;

            if (!string.IsNullOrEmpty(InsertID.Text))
                product.Id = int.Parse(InsertID.Text);

            if (!string.IsNullOrEmpty(InsertAmount.Text))
                product.Amount = int.Parse(InsertAmount.Text);

            if (!string.IsNullOrEmpty(InsertPrice.Text))
                product.Price = float.Parse(InsertPrice.Text);

            // Check if the ID already exists
            bool idExists = await CheckIfIdExists(product.Id);
            if (idExists)
            {
                MessageBox.Show("ID already exists. Please enter a unique ID.");
                return;
            }

            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("AddProduct", content);
            response.EnsureSuccessStatusCode();

            Response res = await response.Content.ReadFromJsonAsync<Response>();
            ResponseLabel.Content = res.statusCode + " " + res.statusMessage;

            await showAsync();
        }

        private async Task<bool> CheckIfIdExists(int id)
        {
            var response = await httpClient.GetStringAsync("GetProductByID/" + id);
            Response response_JSON = JsonConvert.DeserializeObject<Response>(response);

            return response_JSON.product != null;
        }



        private async void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var response = await httpClient.GetStringAsync("GetProductByID/" + int.Parse(searchProductID.Text));
            Response response_JSON = JsonConvert.DeserializeObject<Response>(response);

            ResponseLabel.Content = response_JSON.statusCode + " " + response_JSON.statusMessage;
            InsertID.Text = response_JSON.product.Id.ToString();
            InsertPName.Text = response_JSON.product.Name;
            InsertAmount.Text = response_JSON.product.Amount.ToString();
            InsertPrice.Text = response_JSON.product.Price.ToString();
        }

        private async void SelectSQL_Click(object sender, RoutedEventArgs e)
        {
            var response = await httpClient.GetStringAsync("GetAllProducts");
            Response response_JSON = JsonConvert.DeserializeObject<Response>(response);
            ResponseLabel.Content = response_JSON.statusCode + " " + response_JSON.statusMessage;

            dataGrid.ItemsSource = response_JSON.products; // list of products
            DataContext = this;
        }

        private async void UpdateSQL_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Id = int.Parse(InsertID.Text);

            if (!string.IsNullOrEmpty(InsertAmount.Text))
                product.Amount = int.Parse(InsertAmount.Text);

            if (!string.IsNullOrEmpty(InsertPrice.Text))
                product.Price = float.Parse(InsertPrice.Text);

            if (!string.IsNullOrEmpty(InsertPName.Text))
            {
                product.Name = InsertPName.Text;

                var json = JsonConvert.SerializeObject(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync("UpdateProduct", content);
                response.EnsureSuccessStatusCode();

                Response res = await response.Content.ReadFromJsonAsync<Response>();
                ResponseLabel.Content = res.statusCode + " " + res.statusMessage;
            }
            else
            {
                MessageBox.Show("Product name cannot be empty.");
            }

            await showAsync();
        }


        private async void DeleteSQL_Click(object sender, RoutedEventArgs e)
        {
            var response = await httpClient.DeleteAsync("DeleteProduct/" + int.Parse(InsertID.Text));
            ResponseLabel.Content = response.ToString();
            showAsync();
        }

        private void sales_Click(object sender, RoutedEventArgs e)
        {
            SalesModule newSale = new SalesModule();
            newSale.Show();
            this.Close();
        }
    }
}
