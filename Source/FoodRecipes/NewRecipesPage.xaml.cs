using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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

namespace FoodRecipes
{
    /// <summary>
    /// Interaction logic for NewRecipesPage.xaml
    /// </summary>
    public partial class NewRecipesPage : Page
    {

        public NewRecipesPage()
        {
            InitializeComponent();
        }

        int i = 1;
        int temp = -1;
        BindingList<Recipes> _list;
        ObservableCollection<string> listImages = new ObservableCollection<string>();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var colorpicker = $"{folder}Color.txt";
            var c = File.ReadAllLines(colorpicker);
            var _color = new ChangeColor()
            {
                ColorTopBar = c[0],
            };
            TopBar.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
            imgssstep.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
            addstepppp.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
            _list = new BindingList<Recipes>();
            dataListview.ItemsSource = _list;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            UserControlHome _home = new UserControlHome();
            NewRecipes.Children.Clear();
            NewRecipes.Children.Add(_home);
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();
            if (result == true)
            {
                var img = open.FileNames;
                ImageSource imgsource = new BitmapImage(new Uri(img[0].ToString()));
                ImageDescriptionOfRecipe.ImageSource = imgsource;
            }
        }

        private void addStep_Click(object sender, RoutedEventArgs e)
        {
            var item = new Recipes()
            {
                Step = "Bước " + i.ToString(),
                StepDescription = StepDescription.Text,
                Imagesss = new BindingList<string>()
            };
            foreach (string itemm in listImages)
            {
                item.Imagesss.Add(itemm);
            }
            _list.Add(item);
            StepDescription.Text ="";
            listImages.Clear();
            ImgStep.ItemsSource = listImages;
            i++;
        }

        private void imgStep_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();
            if (result == true)
            {
                if (open.FileNames.Length <= 10 && listImages.Count + open.FileNames.Length <= 10)
                {
                    foreach (string item in open.FileNames)
                    {
                        listImages.Add(item);
                    }
                    ImgStep.ItemsSource = listImages;
                }
                else
                {
                   MessageBox.Show("Maximum of only 10 images");
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            UserControlHome _home = new UserControlHome();
            NewRecipes.Children.Clear();
            NewRecipes.Children.Add(_home);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Title.Text.Trim() != "" && ImageDescriptionOfRecipe.ImageSource != null && Description.Text.Trim() != "")
            {
      
                MessageBoxResult result = MessageBox.Show("Do you want to save", "", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    // Luu ten, mo ta, hinh anh, youtube => xuat ra man hinh Home
                    var folder = AppDomain.CurrentDomain.BaseDirectory;
                    var avatar = $"{folder}Images";
                    var database = $"{folder}AllRecipes.txt";
                    var lines = File.ReadAllLines(database);
                    int count = int.Parse(lines[0]);
                    count++;
                    lines[0] = (count++).ToString();
                    File.WriteAllLines(database, lines);
                    using (StreamWriter sw = File.AppendText(database))
                    {
                        sw.WriteLine(Title.Text);
                        string imgdes = System.IO.Path.GetFileName(ImageDescriptionOfRecipe.ImageSource.ToString());
                        sw.WriteLine(imgdes);
                        sw.WriteLine(Description.Text);
                        sw.WriteLine(Youtube.Text);
                        sw.WriteLine("White");
                        sw.WriteLine("HeartOutline");
                    }
                    string imgdesr = System.IO.Path.GetFileName(ImageDescriptionOfRecipe.ImageSource.ToString());
                    var imgAv = ((BitmapImage)ImageDescriptionOfRecipe.ImageSource).UriSource.ToString().Remove(0, 8);
                    var appStartPath11 = String.Format(avatar + "\\" + imgdesr);
                    File.Copy(imgAv, appStartPath11, true);


                    BindingList<Recipes> t = _list;
                    String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                    appStartPath = appStartPath + "\\ListFoodRecipes";
                    string path2 = System.IO.Path.Combine(appStartPath, Title.Text);

                    if (!Directory.Exists(path2))
                    {
                        Directory.CreateDirectory(path2);
                        string path3 = path2 + $"\\{Title.Text}.txt";
                        if (File.Exists(path3))
                        {
                            File.Delete(path3);
                        }
                        using (StreamWriter sw = File.CreateText(path3))
                        {
                            // Lưu mô tả và hình ảnh đại diện cho món ăn
                            sw.WriteLine(Title.Text);
                            string imgdes = System.IO.Path.GetFileName(ImageDescriptionOfRecipe.ImageSource.ToString());
                            var imgdes2 = ((BitmapImage)ImageDescriptionOfRecipe.ImageSource).UriSource.ToString().Remove(0, 8);
                            sw.WriteLine(imgdes);
                            sw.WriteLine(Description.Text);
                            sw.WriteLine(Youtube.Text);
                            appStartPath = String.Format(path2 + "\\" + imgdes);
                            File.Copy(imgdes2, appStartPath, true);

                            // Lưu từng bước gồm hình ảnh, mô tả, link youtobe cho món ăn
                            for (int i = 0; i < t.Count; i++)
                            {
                                sw.WriteLine(t[i].Step);
                                sw.WriteLine(t[i].StepDescription);
                                foreach (string nameImg in t[i].Imagesss)
                                {
                                    string name = System.IO.Path.GetFileName(nameImg);
                                    sw.WriteLine(name);
                                    appStartPath = String.Format(path2 + "\\" + name);
                                    File.Copy(nameImg, appStartPath, true);
                                }
                            }
                        }
                    }
                    UserControlHome _home = new UserControlHome();
                    NewRecipes.Children.Clear();
                    NewRecipes.Children.Add(_home);
                }
            }
            else   
               MessageBox.Show("You did not enter the title, description or avatar image!!!");
        }
    }
}
