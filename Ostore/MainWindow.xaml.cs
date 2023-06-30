using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Ostore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Product>? products;



        public List<Product>? Products
        {
            get { return products; }
            set
            {
                products = value;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Products = new List<Product>() {
                new Product {Name="Cola",Price=10,ImageUrl="Cola.jpg",Description="Zerodu eladi bombadi zad"},
                new Product {Name="Pepsi",Price=11,ImageUrl="Cola.jpg",Description="Zerodu eladi bombadi zad"},
                new Product {Name="Cola",Price=12, ImageUrl = "Cola.jpg",Description="Zerodu eladi bombadi zad"},
                new Product {Name="Cola",Price=1.20m, ImageUrl = "Cola.jpg",Description="Zerodu eladi bombadi zad"},
                new Product {Name="Cola",Price=1.20m, ImageUrl = "Cola.jpg",Description="Zerodu eladi bombadi zad"},
                new Product {Name="Cola",Price=1.20m, ImageUrl = "Cola.jpg",Description="Zerodu eladi bombadi zad"},
                new Product {Name="Cola",Price=1.20m, ImageUrl = "Cola.jpg",Description="Zerodu eladi bombadi zad"},
                new Product {Name="Pepsi",Price=12, ImageUrl = "https://bravomarket.online/upload/iblock/c3e/c3ea169ad9f831df2d729a8852a66bce.jpg",Description="pEPSI SUPERDI QAQAW"},
            };
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Button? button = sender as Button;
                StackPanel? sp = button?.FindName("Product_SP") as StackPanel;
                Grid? grid = sp.Children[0] as Grid;
                TextBlock? ProductID = grid?.FindName("Product_ID") as TextBlock;
                //MessageBox.Show((products[Convert.ToInt32(ProductID?.Text.ToString()) - 1].Id.ToString()));
                for (int i = 0; i < products?.Count; i++)
                {
                    if (products[i].Id == Convert.ToInt32(ProductID.Text))
                    {
                        Product ProductResource = (Product)FindResource("ProductResource");
                        ProductResource.Name = products[i].Name;
                        ProductResource.Id = products[i].Id;
                        ProductResource.Price = products[i].Price;
                        ProductResource.ImageUrl = products[i].ImageUrl;
                        ProductResource.Description = products[i].Description;
                        ProductPanel SelectedProductPanel = new ProductPanel();
                        SelectedProductPanel.Show();
                        return;

                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void New_Product_Button(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button?.Content.ToString() == "New Product") { button.Content = "Close"; }
            else button.Content = "New Product";
            if (New_Product_SP.Visibility == Visibility.Visible) New_Product_SP.Visibility = Visibility.Hidden;
            else { New_Product_SP.Visibility = Visibility.Visible; }
        }

        private void Save_NewProduct_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (P_Name_TB.Text == "") throw new Exception("Fill the Product Name");
                if (P_Price_TB.Text == "") throw new Exception("Fill the Price");
                Product newProduct = new Product
                {
                    Name = P_Name_TB.Text,
                    Price = Convert.ToDecimal(P_Price_TB.Text.ToString()),
                    ImageUrl = P_URL_TB.Text,
                    Description=Description_TextBox.Text,
                };
                Product_ItemTemplate.ItemsSource = null;
                Products?.Add(newProduct);
                Product_ItemTemplate.ItemsSource = Products;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
