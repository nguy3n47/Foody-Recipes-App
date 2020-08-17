using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodRecipes
{
    /// <summary>
    /// Interaction logic for UserControlRecipesDetail.xaml
    /// </summary>
    
    public partial class UserControlRecipesDetail : UserControl
    {
        //public Recipes NewRecipesInfo { get; set; } = null;
        private Recipes _data;
        BindingList<Recipes> _list;
        BindingList<Recipes> _listphoto;
        ObservableCollection<string> listImages = new ObservableCollection<string>();
        string nameTest;
        public UserControlRecipesDetail(Recipes r)
        {
            InitializeComponent();
            _data = r;
            nameTest = _data.Title;
        }
        int i = 4, j = 1;
        string step = "Bước";
        public string NameTest { get => nameTest; set => nameTest = value; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _data;
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var colorpicker = $"{folder}Color.txt";
            var c = File.ReadAllLines(colorpicker);
            var _color = new ChangeColor()
            {
                ColorTopBar = c[0],
            };
            Title.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
            Photos.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
            _list = new BindingList<Recipes>();
            PreviewPhoto.ItemsSource = _list;
            dataComboBox.ItemsSource = _list;
            //_listphoto = new BindingList<Recipes>();
            PreviewPhoto.ItemsSource = _list;
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            appStartPath = appStartPath + $"\\ListFoodRecipes\\{NameTest}\\";
            string fileTxt = appStartPath + $"{NameTest}.txt";
            var readTest = File.ReadAllLines(fileTxt);

            //Discription.Text = readTest[1];
            //link.Text = readTest[2];
            //ImageSource imageSource = new BitmapImage(new Uri(appStartPath + readTest[3]));
            //img.ImageSource = imageSource;

            while (i < readTest.Length)
            {
                var g = new Recipes()
                {
                    Step = "",
                    StepDescription = "",
                    Imagesss = new BindingList<string>(),
                    Colorrrrrr = c[0]
                };
                ObservableCollection<string> listImages = new ObservableCollection<string>();
                if (step + " " + j.ToString() == readTest[i])
                {

                    g.Step = readTest[i].Replace("Bước ","");
                    g.StepDescription = readTest[i + 1];
                    i += 2;
                    for (int k = i, temp = j + 1; ; k++)
                    {
                        if (k >= readTest.Length)
                        {
                            i = k;
                            j++;
                            break;
                        }

                        if (step + " " + temp.ToString() == readTest[k] && k < readTest.Length)
                        {
                            i = k;
                            j++;
                            break;
                        }
                        g.Imagesss.Add(appStartPath + readTest[k]);
                    }
                    _list.Add(g);
                }
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            string html = "<html><head>";
            html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
            html += "<iframe id='video' src= 'https://www.youtube.com/embed/{0}' frameborder='0' height='265' width='460' allowfullscreen></iframe>";
            html += "</body></html>";
            this.dimg.Visibility = Visibility.Collapsed;
            this.Play.Visibility = Visibility.Collapsed;
            this.webBrowser.Visibility = Visibility.Visible;         
            this.webBrowser.NavigateToString(string.Format(html, _data.Youtube.Split('=')[1]));
        }        
    }
}
