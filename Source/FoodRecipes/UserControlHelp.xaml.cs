using System;
using System.Collections.Generic;
using System.IO;
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

namespace FoodRecipes
{
    /// <summary>
    /// Interaction logic for UserControlHelp.xaml
    /// </summary>
    public partial class UserControlHelp : UserControl
    {
        public UserControlHelp()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var colorpicker = $"{folder}Color.txt";
            var c = File.ReadAllLines(colorpicker);
            var _color = new ChangeColor()
            {
                ColorTopBar = c[0],
            };
            textHelp.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
        }
    }
}
