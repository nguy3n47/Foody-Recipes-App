using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for UserControlFavorite.xaml
    /// </summary>
    public partial class UserControlFavorite : UserControl
    {
        //private Recipes _r;
        ObservableCollection<Recipes> _data;
        public Recipes _f;
        public UserControlFavorite()
        {
            InitializeComponent();
            
        }
        List<int> save = new List<int>();
        public void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //_data = new ObservableCollection<Recipes>()
            //{
            //    new Recipes() { Title = "Trứng rim mắm hành", Picture="c131708a-374a-48b7-8f79-9fa00f46ca4d.jpeg", Description = "Trứng Rim Mắm Hành, món ăn khá đơn giả nhưng lại cực kì hao cơm, với cách chế biến nhanh chóng là đã có ngay món trứng rim thơm ngon với lớp vỏ ngoài giòn dai, có màu nâu đẹp thấm đượm vị.", Youtube="https://www.youtube.com/watch?v=cuDG6KQg_OI" },
            //    new Recipes() { Title = "Cà Phê Bọt Biển", Picture="e8fd83b8-e7fe-4733-b782-96ab707c719f.jpeg", Description = "Dalgona Coffe - Cà Phê Bọt Biển món thức uống đình đám được pha chế khá mới lạ, độc đáo với mùi thơm đầy mê hoặc và hương vị cực ngon. Ngoài Nescafe, Cooky sử dụng cà phê G7 đến từ nhà Trung Nguyên nhé các bạn. Thưởng thức một ly Dalgona coffee hấp dẫn  không chỉ giúp bạn giải khát, mà còn khiến cho tâm hồn trở nên thư thái hơn vì thức uống đẹp mắt và hội tụ đủ hương vị độc đáo. ", Youtube="https://www.youtube.com/watch?v=kfbJbuMqeaw" },
            //    new Recipes() { Title = "Cơm cháy chả cá", Picture="cooky-recipe-cover-r50163.jpg", Description = "Cơm cháy chả cá là một món ăn vặt đang làm mưa làm gió hiện nay. Miếng cơm cháy giòn tan cùng chả cá dai dai, thơm ngọt chấm cùng nước mắm chua ngọt, đặc kẹo thật khó để có thể cưỡng lại được. Món ăn dân giã, giản dị với cách làm cũng cực kì đơn giản thôi.", Youtube="https://www.youtube.com/watch?v=hBZ_4cMhdNE" },
            //    new Recipes() { Title = "Cóc trộn trứng cút", Picture="cooky-recipe-cover-r52117.jpg", Description = "Cóc trộn trứng cút rau răm là món ăn kích thích vị giác mà bạn không thể bỏ qua, ai đã từng ăn qua món ăn này sẽ bị ghiền. ", Youtube="https://www.youtube.com/watch?v=Hjz2Eud753U" },
            //    new Recipes() { Title = "Bánh ngải", Picture="cooky-recipe-cover-r49947.jpg", Description = "Ngải cứu là một phương thuốc lâu đời của đông y, không chỉ thế đó còn là một thứ nguyên liệu cho món bánh nổi tiếng của người dân tộc Tày ở Lạng Sơn. Miếng bánh thơm lừng mùi ngải cứu, béo ngậy vì dừa cùng với cái bùi của đậu phộng và mè đen chắc chắn sẽ làm bạn ăn mãi không dừng được đấy! ", Youtube="https://www.youtube.com/watch?v=YgcDiVwZHSk" },
            //    new Recipes() { Title = "Bánh mì dân tổ", Picture="cooky-recipe-cover-r49793.jpg", Description = "Chỉ trong khoảng 1 tuần trở lại đây, bánh mì dân tổ bỗng nhiên sốt xình xịch, được rất nhiều người quan tâm và tìm đến mua, ăn thử. Bánh mì dân tổ là món ăn sáng khá ngon với cách chế biến mới từ những nguyên liệu quen thuộc như chả, trứng, pa tê, xúc xích...", Youtube="https://www.youtube.com/watch?v=dIdYLuGZHeY" },
            //    new Recipes() { Title = "Trứng chiếc thuyền", Picture="cooky-recipe-cover-r49931.jpg", Description = "Dùng lá chuối để nấu ăn không còn xa lạ với nhiều người, nhưng gấp lá chuối thành thuyền và nướng trứng trong đó hẳn sẽ là món ăn độc đáo và hấp dẫn với nhiều tín đồ ăn vặt. Với công thức món trứng nướng chiếc thuyền mới lạ dưới đây, món trứng với nhiều topping bắt mắt như khô bò xé, trứng muối, thanh cua sẽ cùng sốt chấm cay nồng hoàn hảo sẽ là một biến tấu mới cho bữa ăn của bạn.", Youtube="https://www.youtube.com/watch?v=JlhwCh-qGp4" },
            //    new Recipes() { Title = "Bánh tai yến", Picture="cooky-recipe-cover-r49880.jpg", Description = "Với hình dáng nhỏ nhắn, xinh xắn như những chiếc tổ yến, hương vị lại thơm ngon, giòn dai ngọt ngọt, bánh tai yến đã trở thành món “ruột” của rất nhiều người. Thay vì chạy vội ra tiệm để mua, tại sao bạn không thử tự tay làm bánh ở nhà.", Youtube="https://www.youtube.com/watch?v=owEudFsRFc4" },
            //    new Recipes() { Title = "Bún đỏ Buôn Mê Thuột", Picture="cooky-recipe-cover-r47378.jpg", Description = "Bún đỏ là một món ăn dân dã mà bạn có thể gặp bất cứ đâu ở vùng đất Buôn Mê Thuột. Sợi bún màu đỏ cam vừa lạ vừa thú vị, hòa quyện cùng nước dùng xương đậm đà và riêu cua thịt hấp dẫn. Món bún đỏ còn đặc biệt ở rau ăn kèm đó là rau cần nước và cải ngọt trụng chín. ", Youtube="https://www.youtube.com/watch?v=csRoEKN_9Og" },
            //    new Recipes() { Title = "Trứng muối nước", Picture="cooky-recipe-cover-r47321.jpg", Description = "Trứng tự muối thật ra chỉ hơi mất thời gian một chút, đoạn đợi trứng ngấm muối và “chín”, thường mất khoảng 4-6 tuần, còn lại thì cách làm cực kì đơn giản và cực dễ, hầu như không thể hỏng. Trứng muối đúng thì lòng đỏ sẽ lên màu đỏ cam, trong và cảm giác săn tròn lại rất đẹp. ", Youtube="https://www.youtube.com/watch?v=etVsY2PKrmg" }
            //};
            //_data.Add(_f);

            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var database = $"{folder}AllRecipes.txt";
            var lines = File.ReadAllLines(database);
            int count = int.Parse(lines[0]);
            _data = new ObservableCollection<Recipes>();
            for (int i = 0; i < count; i++)
            {

                var line1 = lines[i * 6 + 1];
                var line2 = lines[i * 6 + 2];
                var line3 = lines[i * 6 + 3];
                var line4 = lines[i * 6 + 4];
                var line5 = lines[i * 6 + 5];
                var line6 = lines[i * 6 + 6];

                var recipes = new Recipes()
                {
                    Title = line1,
                    Picture = line2,
                    Description = line3,
                    Youtube = line4,
                    UIHeartColor = line5,
                    UIHeartIcon = line6
                };
                if(recipes.UIHeartColor == "Red")
                {
                    save.Add(i);
                    _data.Add(recipes);
                }
            }

            if (_data.Count > 12)
            {
                this.Bot.Visibility = Visibility.Visible;
            }

            info.CurrentPage = 1;
            info.RowsPerPage = 12;
            info.Count = _data.Count;
            info.TotalPages = (info.Count / info.RowsPerPage) +
                (info.Count % info.RowsPerPage == 0 ? 0 : 1);

            Thread thread = new Thread(delegate ()
            {
                // Cập nhật UI
                Dispatcher.Invoke(() =>
                {
                    dataListview.ItemsSource = _data.Take(info.RowsPerPage);
                });
            });
            thread.Start();
        }

        private void dataListview_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as Recipes;
            if (item != null)
            {
                FoodFavorite.Children.Add(new UserControlRecipesDetail(item));
                Top.Visibility = Visibility.Collapsed;
            }
        }

        private void Page1_Click(object sender, RoutedEventArgs e)
        {
            info.CurrentPage = 1;
            dataListview.ItemsSource = _data.Take(12);
        }
        private void Page2_Click(object sender, RoutedEventArgs e)
        {
            info.CurrentPage = 2;
            dataListview.ItemsSource = _data.Skip((info.CurrentPage - 1) * info.RowsPerPage).Take(12);
        }
        private void Page3_Click(object sender, RoutedEventArgs e)
        {
            info.CurrentPage = 3;
            dataListview.ItemsSource = _data.Skip((info.CurrentPage - 1) * info.RowsPerPage).Take(12);
        }
        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (info.CurrentPage <= info.TotalPages)
            {
                info.CurrentPage--;
                dataListview.ItemsSource =
                _data
                    .Skip((info.CurrentPage - 1) * info.RowsPerPage)
                    .Take(info.RowsPerPage);
                if (info.CurrentPage <= 1)
                {
                    info.CurrentPage = 1;
                }
            }
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (info.CurrentPage < info.TotalPages)
            {
                info.CurrentPage++;
                dataListview.ItemsSource =
                _data
                    .Skip((info.CurrentPage - 1) * info.RowsPerPage)
                    .Take(info.RowsPerPage);
            }
        }

        PagingInfo info = new PagingInfo();
        class PagingInfo : INotifyPropertyChanged
        {
            public int TotalPages { get; set; }

            private int _currentPage = 0;
            public int CurrentPage
            {
                get => _currentPage;
                set
                {
                    _currentPage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentPage"));
                }
            }
            private int _page1 = 1;
            public int Page1
            {
                get => _page1;
                set
                {
                    _page1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Page1"));
                }
            }
            private int _page2 = 2;
            public int Page2
            {
                get => _page2;
                set
                {
                    _page2 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Page2"));
                }
            }
            private int _page3 = 3;
            public int Page3
            {
                get => _page3;
                set
                {
                    _page3 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Page3"));
                }
            }

            public int Count { get; set; }

            public int RowsPerPage { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;
        }
        private void ButtonFavorite_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            int index = dataListview.Items.IndexOf(item) + ((info.CurrentPage - 1) * info.RowsPerPage);
            if (_data[index].UIHeartColor == "Red" && _data[index].UIHeartIcon == "Heart")
            {
                //_data[index].UIHeartColor = "White";
                //_data[index].UIHeartIcon = "HeartOutline";
                var folder = AppDomain.CurrentDomain.BaseDirectory;
                var database = $"{folder}AllRecipes.txt";
                var lines = File.ReadAllLines(database);
                lines[save[index] * 6 + 5] = "White";
                lines[save[index] * 6 + 6] = "HeartOutline";
                save.RemoveAt(index);
                File.WriteAllLines(database, lines);
            }
            UserControl_Loaded(sender, e);
        }
    }
}
