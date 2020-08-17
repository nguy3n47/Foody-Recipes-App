using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace FoodRecipes
{
    /// <summary>
    /// Interaction logic for UserControlShoppingList.xaml
    /// </summary>
    public partial class UserControlShoppingList : UserControl
    {
        public UserControlShoppingList()
        {
            InitializeComponent();
        }

        string dataFile = "";
        string alllist = "";
        ObservableCollection<string> ingredients = new ObservableCollection<string>();
        ObservableCollection<string> shoppinglist = new ObservableCollection<string>();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            alllist = $"{folder}ShoppingList\\Alllist.txt";
            var items = File.ReadAllLines(alllist);

            foreach (var item in items)
            {
                shoppinglist.Add(item);
            }
            dataList.ItemsSource = shoppinglist;

            topText.Text = shoppinglist[0];
            dataFile = $"{folder}ShoppingList\\{topText.Text}.txt";
            var itemsss = File.ReadAllLines(dataFile);
            foreach (var item in itemsss)
            {
                ingredients.Add(item);
            }
            ingredientsListview.ItemsSource = ingredients;
        }

        private void addingredients_Click(object sender, RoutedEventArgs e)
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            dataFile = $"{folder}ShoppingList\\{topText.Text}.txt";
            var newItem = Addnew.Text.Trim();
            ObservableCollection<string> ingredientssssssssssssss = new ObservableCollection<string>();

            // Cập nhật lại dữ liệu ở nơi lưu trữ / Database

            //File.AppendAllText(dataFile, $"\r\n{newItem}");
            using (StreamWriter sw = File.AppendText(dataFile))
            {
                sw.WriteLine(newItem);
            }

            // Cập nhật lại đối tượng trên bộ nhớ 

            var items = File.ReadAllLines(dataFile);
            foreach (var item in items)
            {
                ingredientssssssssssssss.Add(item);
            }
            ingredientsListview.ItemsSource = ingredientssssssssssssss;

            // Reset lại ô nhập liệu, cập nhật lại giao diện
            Addnew.Text = "";

            //Thread thread = new Thread(delegate ()
            //{
            //    // Cập nhật UI
            //    Dispatcher.Invoke(() =>
            //    {
            //        ingredientsListview.ItemsSource = ingredientssssssssssssss;
            //    });
            //});

            //thread.Start();
        }

        private void dataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(ingredientsListview.ItemsSource);
            view.Refresh();
            var index = dataList.SelectedIndex;
            topText.Text = shoppinglist[index];
            ObservableCollection<string> ingredientsss = new ObservableCollection<string>();
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            dataFile = $"{folder}ShoppingList\\{shoppinglist[index]}.txt";
            var items = File.ReadAllLines(dataFile);
            foreach (var item in items)
            {
                ingredientsss.Add(item);
            }
            ingredientsListview.ItemsSource = ingredientsss;
        }

        private void newList_Click(object sender, RoutedEventArgs e)
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            dataFile = $"{folder}ShoppingList\\{Newshoppinglist.Text}.txt";
            using (FileStream fs = File.Create(dataFile))
            {
                
            }
            var newItem = Newshoppinglist.Text.Trim();

            if (shoppinglist.Contains(newItem))
            {
                MessageBox.Show($"TODO {newItem} already exists in LIST.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (newItem.Length == 0)
            {
                MessageBox.Show($"Cannot add spaces to TODO LIST.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Cập nhật lại dữ liệu ở nơi lưu trữ / Database

                using (StreamWriter sw = File.AppendText(alllist))
                {
                    sw.WriteLine(newItem);
                }    

                // Cập nhật lại đối tượng trên bộ nhớ 
                shoppinglist.Add(newItem);

                // Reset lại ô nhập liệu, cập nhật lại giao diện
                Newshoppinglist.Text = "";
            }
        }

        private void Addnew_MouseMove(object sender, MouseEventArgs e)
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var colorpicker = $"{folder}Color.txt";
            var c = File.ReadAllLines(colorpicker);
            var _color = new ChangeColor()
            {
                ColorTopBar = c[0],
            };
            Addnew.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
        }

        private void Addnew_MouseLeave(object sender, MouseEventArgs e)
        {
            Addnew.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF484848"));
        }
    }
}
