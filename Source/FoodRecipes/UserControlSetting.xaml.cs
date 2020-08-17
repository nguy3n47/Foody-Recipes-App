using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
    /// Interaction logic for UserControlSetting.xaml
    /// </summary>
    public partial class UserControlSetting : UserControl
    {
        List<string> dataColor = new List<string>()
        {
            "#d24400", "#ff8c00", "#e81123", "#d13438", "#ff4081", "#c30052", "#bf0077", "#9a0089", "#881798", "#744da9", "#4caf50", "#10893e", "#018574", "#03a9f4", "#304ffe", "#0063b1", "#6b69d6", "#8e8cd8", "#8764b8", "#038387", "#525e54", "#7e735f", "#9e9e9e", "#515c6b", "#000000"
        };
        public UserControlSetting()
        {
            InitializeComponent();  
        }

        private void dataListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            int index = dataListview.Items.IndexOf(item);
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var database = $"{folder}Color.txt";
            using (StreamWriter sw = File.CreateText(database))
            {
                sw.WriteLine(dataColor[index]);
            }
            //UserControlHome
        }
    }
}
