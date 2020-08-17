using MaterialDesignThemes.Wpf;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
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
    /// Interaction logic for UserControlHome.xaml
    /// </summary>
    
    public partial class UserControlHome : UserControl
    {
        public Recipes NewRecipesFavorite { get; set; } = null;
        public UserControlHome()
        {
            InitializeComponent();
            DataContext = this;
            Refresh();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void Refresh()
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var colorpicker = $"{folder}Color.txt";
            var c = File.ReadAllLines(colorpicker);
            var _color = new ChangeColor()
            {
                ColorTopBar = c[0],
            };
            TopBar.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
            GridCursor.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
            Prev.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
            Page1.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
            Page2.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
            Page3.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
            Next.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
        }

        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
            "đ",
            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
            "í","ì","ỉ","ĩ","ị",
            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
            "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "d",
            "e","e","e","e","e","e","e","e","e","e","e",
            "i","i","i","i","i",
            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
            "u","u","u","u","u","u","u","u","u","u","u",
            "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }

        ObservableCollection<Recipes> _recipes;
        public void Unit()
        {
            _recipes = new ObservableCollection<Recipes>()
            {
                new Recipes() { Title = "Bò cuộn hầm trái cây", Picture="cooky-recipe-cover-r53012.jpg", Description = "Bò cuộn hầm trái cây là món ăn vừa kết hợp chất dinh dưỡng từ thịt lẫn vitamin từ các loại trái cây.  Với những nguyên liệu dễ kiếm, cách làm đơn giản, chỉ cần bỏ chút thời gian là bạn có thể chế biến được một món ăn khá lạ miệng mà hấp dẫn. Từng miếng thịt bò như những bông hoa nở đều đẹp mắt, thơm mềm, thấm vị, hòa cùng trái cây đủ màu sắc khiến món ăn thêm phần ngon miệng.", Youtube="https://www.youtube.com/watch?v=Tgy7yMO0GSE" },
                new Recipes() { Title = "Lẩu lươn chua cay", Picture="cooky-recipe-cover-r53011.jpg", Description = "Lẩu Lươn Chua Cay là món ăn mang đặc trưng của miền sông nước. Vị nước dùng đậm đà, chua chua cay cay kết hợp với vị ngọt, dai của lươn hòa cùng vị thanh mát của các loại rau ăn kèm. Vừa thơm ngon lại bổ dưỡng, ai ăn một lần cũng nhớ mãi. Hãy chuẩn bị nguyên liệu và thực hiện theo cách bước sau nhé!", Youtube="https://www.youtube.com/watch?v=Od36uUcUKs4" },
                new Recipes() { Title = "Gà Hấp Mắm Nhĩ", Picture="f857e0cc-2a33-4d34-83e0-8945171be8f1.jpeg", Description = "Gà hấp mắm nhĩ- món ăn vừa dễ làm lại thơm ngon khó cưỡng, nước mắm nhĩ thơm phức được ướp với thịt gà ta, cộng thêm một ít  tỏi và tiêu xanh làm tăng thêm hương vị của món ăn, càng ăn càng ghiền, vị ngọt, dai trong từng thớ thịt gà ngấm đều vị ăn hoài không ngán. Chỉ cần bỏ chút thời gian là ta đã có ngay món ăn hấp dẫn này rồi.", Youtube="https://www.youtube.com/watch?v=0oHYYjCr76Q" },
                new Recipes() { Title = "Bánh mì caramel", Picture="9d179eb5-6149-4573-918f-b30fc5a8c492.jpeg", Description = "Món bánh mì caramel gần đây đang làm mưa làm gió trên mạng bởi độ ngọt ngào, giòn tan khó ai cưỡng lại được. ", Youtube="https://www.youtube.com/watch?v=a8ODGCcQ18M" },
                new Recipes() { Title = "Mứt mận Hà Nội", Picture="a7aba944-f155-4494-970f-d38ec7afd215.jpeg", Description = "Món mứt mận Hà Nội với hương vị thơm ngon, màu sắc hấp dẫn được rất nhiều bạn ưa chuộng mỗi khi mùa mận về.", Youtube="https://www.youtube.com/watch?v=mn1C0eY_A9E" },
                new Recipes() { Title = "Gỏi Sứa Xoài Xanh", Picture="ce5101e4-7333-4ac5-ad5c-4fb9633303de.jpeg", Description = "Gỏi sứa xoài xanh - món ăn thanh mát, giải nhiệt cho mùa hè nóng bức. Sứa giàu chất dinh dưỡng, dễ ăn dễ chế biến, ngon giòn sần sựt, kết hợp với vị xoài chua nhẹ đước rưới thêm nước sốt chua ngọt, tất cả hòa quyện vào nhau tạo nên món ăn thơm ngon lạ miệng chinh phục cả những người khó tính.", Youtube="https://www.youtube.com/watch?v=uszzG_hsLTo"},
                new Recipes() { Title = "Chè hạt đác", Picture="c2dfb767-537c-4d44-a129-46b339e632d1.jpeg", Description = "Món chè hạt đác chinh phục bất cứ ai khi thưởng thức nhờ cảm giác thích thú khi nhai những hạt đác giòn dai rất đặc trưng, có vị ngọt mát vừa phải, dễ chịu. Kết hợp hạt đác cùng các nguyên liệu trái cây như dâu tây, mít càng làm cho món chè thêm lôi cuốn khó cưỡng. ", Youtube="https://www.youtube.com/watch?v=a84Ok94wMUk" },
                new Recipes() { Title = "Ngan cháy tỏi", Picture="0b708df7-99b4-4909-b617-df71addc61b5.jpeg", Description = "Món ngan cháy tỏi là món ăn rất được yêu thích ở Hà Nội, điều đặc biệt của món ăn này chính là vị đậm đà của gia vị tẩm ướp vào thịt ngan, độ dai nhưng không bị khô chút nào. Được kết hợp cùng tỏi phi xém vàng, giòn thơm giúp món ăn càng ngon hơn và kích thích vị giác rất nhiều, cộng thêm nước mắm chua cay ăn kèm bún và rau sống cũng khá lạ miệng.", Youtube="https://www.youtube.com/watch?v=FN9juXfMtbI" },
                new Recipes() { Title = "Gà kho sả ớt", Picture="c0776402-4d50-47c5-b9d6-7416a15217b0.jpeg", Description = "Gà kho sả ớt là món ăn vô cùng phổ biến trong những bữa cơm của người Việt Nam.", Youtube="https://www.youtube.com/watch?v=fTqTdzJF9yE" },
                new Recipes() { Title = "Trà sen vàng", Picture="5312cb96-1b94-4288-90b9-7a4fbe4184c8.jpeg", Description = "Trà sen vàng từ lâu đã là thức uống hấp dẫn dành cho giới trẻ.  Sự kết hợp độc đáo giữa trà ô long thanh mát, hạt sen thơm bùi. Thêm vào chút sữa sẽ để vị thêm ngọt ngào.", Youtube="https://www.youtube.com/watch?v=9M3xr74YQw8" },
                new Recipes() { Title = "Nui chiên xốt tương ớt", Picture="fdf35125-b391-4b54-81db-d397a268c307.jpeg", Description = "Nui chiên xốt tương ớt là món ăn vặt vừa ngon miệng nhưng cực kì dễ làm, những bạnkhông rành về bếp núc cũng có thể làm được món ăn này. Nuichiên giòn rôm rốp được phủ bên ngoài lớp sốt tương ớt thấm đượmvị cay. Càng ăn càng ghiện,liệu bạn có kiềm chế được món ăn vặt thơm ngon này.", Youtube="https://www.youtube.com/watch?v=tUPAhhSTO4s"},
                new Recipes() { Title = "Mận lắc muối tôm", Picture="37870c12-9d41-4d47-9275-5970e92ece5d.jpeg", Description = "Mận hậu hay mận Hà Nội là cái tên để chỉ thứ quả tròn nhỏ màu đỏ, ăn vào giòn giòn, vị chua và chát. Mận hậu còn là món ăn được rất nhiều bạn trẻ yêu mến bởi cái vị ăn mãi rồi hóa thành nghiện. Hôm nay, Cooky sẽ thử kết hợp hai tuyệt phẩm khi đem quả Mận lắc với muối tôm Tây Ninh như bao món trái cây khác.", Youtube="https://www.youtube.com/watch?v=zcLwzbeMHJg" },
                new Recipes() { Title = "Tôm Nướng Phô Mai", Picture="1050fc9b-fae8-46ad-ba94-1ffa1dda0654.jpeg", Description = "Tôm là thực phẩm có chứa hàm lượng canxi, dinh dưỡng cao, vì thế đây là thực phẩm được nhiều người dùng để chế biến thành nhiều món ăn khác nhau. Đặc biệt là tôm nướng phô mai được rất nhiều người yêu thích bởi hương vị đậm đà, “lôi cuốn” của món ăn.", Youtube="https://www.youtube.com/watch?v=q3JUJOZArZ8" },
                new Recipes() { Title = "Gà giòn cay phô mai", Picture="d8afe934-1697-4b2f-ac4f-a02c6ac3d7b7.jpeg", Description = "Nếu bạn là một tín đồ của các món ăn chế biến từ gà, đặc biệt là gà rán thì với món gà giòn cay phô mai Hàn Quốc dưới đây sẽ khiến bạn phải thèm thuồng.",Youtube="https://www.youtube.com/watch?v=PSXCxihzwv0" },
                new Recipes() { Title = "Ba chỉ rim chao", Picture="cooky-recipe-cover-r52502.jpg", Description = "Ba chỉ rim chao với cách làm đơn giản, nguyên liệu lại không cầu kì nhưng lại là món ăn cực kì hao cơm. Beo béo của thịt ba chỉ cộng với vị bùi bùi của chao thêm vài lát ớt nữa tạo nên một món ăn siêu hấp dẫn để đãi gia đình.", Youtube="https://www.youtube.com/watch?v=7kHHNVQGpfo" },
                new Recipes() { Title = "Bún xì dầu", Picture="cooky-recipe-cover-r50135.jpg", Description = "Bún xì dầu là một món ăn bình dân gần gũi với nhiều người, nếu đã ăn một lần thì sẽ khó mà quên được hương vị thơm ngon quyến luyến mà món ăn này mang lại.", Youtube="https://www.youtube.com/watch?v=GNzJJM00jj8" },
                new Recipes() { Title = "Khô heo giả khô bò", Picture="cooky-recipe-cover-r51521.jpg", Description = "Miếng khô heo giả khô bò đậm vị, thơm lừng, dai ngọt lại cay cay. Đây hẳn là món ăn thú vị thích hợp để mời gia đình, bạn bè nhâm nhi thưởng thức trong những ngày lễ Tết. Bên cạnh đó phần lớn chị em lo lắng, nếu mua các món này ngoài hàng sẽ không đảm bảo vệ sinh an toàn thực phẩm.", Youtube="https://www.youtube.com/watch?v=1ysvL0mE1Pk" },
                new Recipes() { Title = "Trứng rim mắm hành", Picture="c131708a-374a-48b7-8f79-9fa00f46ca4d.jpeg", Description = "Trứng Rim Mắm Hành, món ăn khá đơn giả nhưng lại cực kì hao cơm, với cách chế biến nhanh chóng là đã có ngay món trứng rim thơm ngon với lớp vỏ ngoài giòn dai, có màu nâu đẹp thấm đượm vị.", Youtube="https://www.youtube.com/watch?v=cuDG6KQg_OI" },
                new Recipes() { Title = "Cà Phê Bọt Biển", Picture="e8fd83b8-e7fe-4733-b782-96ab707c719f.jpeg", Description = "Dalgona Coffe - Cà Phê Bọt Biển món thức uống đình đám được pha chế khá mới lạ, độc đáo với mùi thơm đầy mê hoặc và hương vị cực ngon. Ngoài Nescafe, Cooky sử dụng cà phê G7 đến từ nhà Trung Nguyên nhé các bạn. Thưởng thức một ly Dalgona coffee hấp dẫn  không chỉ giúp bạn giải khát, mà còn khiến cho tâm hồn trở nên thư thái hơn vì thức uống đẹp mắt và hội tụ đủ hương vị độc đáo. ", Youtube="https://www.youtube.com/watch?v=kfbJbuMqeaw" },
                new Recipes() { Title = "Cơm cháy chả cá", Picture="cooky-recipe-cover-r50163.jpg", Description = "Cơm cháy chả cá là một món ăn vặt đang làm mưa làm gió hiện nay. Miếng cơm cháy giòn tan cùng chả cá dai dai, thơm ngọt chấm cùng nước mắm chua ngọt, đặc kẹo thật khó để có thể cưỡng lại được. Món ăn dân giã, giản dị với cách làm cũng cực kì đơn giản thôi.", Youtube="https://www.youtube.com/watch?v=hBZ_4cMhdNE" },
                new Recipes() { Title = "Cóc trộn trứng cút", Picture="cooky-recipe-cover-r52117.jpg", Description = "Cóc trộn trứng cút rau răm là món ăn kích thích vị giác mà bạn không thể bỏ qua, ai đã từng ăn qua món ăn này sẽ bị ghiền. ", Youtube="https://www.youtube.com/watch?v=Hjz2Eud753U" },
                new Recipes() { Title = "Bánh ngải", Picture="cooky-recipe-cover-r49947.jpg", Description = "Ngải cứu là một phương thuốc lâu đời của đông y, không chỉ thế đó còn là một thứ nguyên liệu cho món bánh nổi tiếng của người dân tộc Tày ở Lạng Sơn. Miếng bánh thơm lừng mùi ngải cứu, béo ngậy vì dừa cùng với cái bùi của đậu phộng và mè đen chắc chắn sẽ làm bạn ăn mãi không dừng được đấy! ", Youtube="https://www.youtube.com/watch?v=YgcDiVwZHSk" },
                new Recipes() { Title = "Bánh mì dân tổ", Picture="cooky-recipe-cover-r49793.jpg", Description = "Chỉ trong khoảng 1 tuần trở lại đây, bánh mì dân tổ bỗng nhiên sốt xình xịch, được rất nhiều người quan tâm và tìm đến mua, ăn thử. Bánh mì dân tổ là món ăn sáng khá ngon với cách chế biến mới từ những nguyên liệu quen thuộc như chả, trứng, pa tê, xúc xích...", Youtube="https://www.youtube.com/watch?v=dIdYLuGZHeY" },
                new Recipes() { Title = "Trứng chiếc thuyền", Picture="cooky-recipe-cover-r49931.jpg", Description = "Dùng lá chuối để nấu ăn không còn xa lạ với nhiều người, nhưng gấp lá chuối thành thuyền và nướng trứng trong đó hẳn sẽ là món ăn độc đáo và hấp dẫn với nhiều tín đồ ăn vặt. Với công thức món trứng nướng chiếc thuyền mới lạ dưới đây, món trứng với nhiều topping bắt mắt như khô bò xé, trứng muối, thanh cua sẽ cùng sốt chấm cay nồng hoàn hảo sẽ là một biến tấu mới cho bữa ăn của bạn.", Youtube="https://www.youtube.com/watch?v=JlhwCh-qGp4" },
                new Recipes() { Title = "Bánh tai yến", Picture="cooky-recipe-cover-r49880.jpg", Description = "Với hình dáng nhỏ nhắn, xinh xắn như những chiếc tổ yến, hương vị lại thơm ngon, giòn dai ngọt ngọt, bánh tai yến đã trở thành món “ruột” của rất nhiều người. Thay vì chạy vội ra tiệm để mua, tại sao bạn không thử tự tay làm bánh ở nhà.", Youtube="https://www.youtube.com/watch?v=owEudFsRFc4" },
                new Recipes() { Title = "Bún đỏ Buôn Mê Thuột", Picture="cooky-recipe-cover-r47378.jpg", Description = "Bún đỏ là một món ăn dân dã mà bạn có thể gặp bất cứ đâu ở vùng đất Buôn Mê Thuột. Sợi bún màu đỏ cam vừa lạ vừa thú vị, hòa quyện cùng nước dùng xương đậm đà và riêu cua thịt hấp dẫn. Món bún đỏ còn đặc biệt ở rau ăn kèm đó là rau cần nước và cải ngọt trụng chín. ", Youtube="https://www.youtube.com/watch?v=csRoEKN_9Og" },
                new Recipes() { Title = "Trứng muối nước", Picture="cooky-recipe-cover-r47321.jpg", Description = "Trứng tự muối thật ra chỉ hơi mất thời gian một chút, đoạn đợi trứng ngấm muối và “chín”, thường mất khoảng 4-6 tuần, còn lại thì cách làm cực kì đơn giản và cực dễ, hầu như không thể hỏng. Trứng muối đúng thì lòng đỏ sẽ lên màu đỏ cam, trong và cảm giác săn tròn lại rất đẹp. ", Youtube="https://www.youtube.com/watch?v=etVsY2PKrmg" }

            };
        }


        ObservableCollection<Recipes> _data;
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
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Unit();
            //_data = new ObservableCollection<Recipes>()
            //{
            //    new Recipes() { Title = "Bò cuộn hầm trái cây", Picture="cooky-recipe-cover-r53012.jpg", Description = "Bò cuộn hầm trái cây là món ăn vừa kết hợp chất dinh dưỡng từ thịt lẫn vitamin từ các loại trái cây.  Với những nguyên liệu dễ kiếm, cách làm đơn giản, chỉ cần bỏ chút thời gian là bạn có thể chế biến được một món ăn khá lạ miệng mà hấp dẫn. Từng miếng thịt bò như những bông hoa nở đều đẹp mắt, thơm mềm, thấm vị, hòa cùng trái cây đủ màu sắc khiến món ăn thêm phần ngon miệng.", Youtube="https://www.youtube.com/watch?v=Tgy7yMO0GSE" },
            //    new Recipes() { Title = "Lẩu lươn chua cay", Picture="cooky-recipe-cover-r53011.jpg", Description = "Lẩu Lươn Chua Cay là món ăn mang đặc trưng của miền sông nước. Vị nước dùng đậm đà, chua chua cay cay kết hợp với vị ngọt, dai của lươn hòa cùng vị thanh mát của các loại rau ăn kèm. Vừa thơm ngon lại bổ dưỡng, ai ăn một lần cũng nhớ mãi. Hãy chuẩn bị nguyên liệu và thực hiện theo cách bước sau nhé!", Youtube="https://www.youtube.com/watch?v=Od36uUcUKs4" },
            //    new Recipes() { Title = "Gà Hấp Mắm Nhĩ", Picture="f857e0cc-2a33-4d34-83e0-8945171be8f1.jpeg", Description = "Gà hấp mắm nhĩ- món ăn vừa dễ làm lại thơm ngon khó cưỡng, nước mắm nhĩ thơm phức được ướp với thịt gà ta, cộng thêm một ít  tỏi và tiêu xanh làm tăng thêm hương vị của món ăn, càng ăn càng ghiền, vị ngọt, dai trong từng thớ thịt gà ngấm đều vị ăn hoài không ngán. Chỉ cần bỏ chút thời gian là ta đã có ngay món ăn hấp dẫn này rồi.", Youtube="https://www.youtube.com/watch?v=0oHYYjCr76Q" },
            //    new Recipes() { Title = "Bánh mì caramel", Picture="9d179eb5-6149-4573-918f-b30fc5a8c492.jpeg", Description = "Món bánh mì caramel gần đây đang làm mưa làm gió trên mạng bởi độ ngọt ngào, giòn tan khó ai cưỡng lại được. ", Youtube="https://www.youtube.com/watch?v=a8ODGCcQ18M" },
            //    new Recipes() { Title = "Mứt mận Hà Nội", Picture="a7aba944-f155-4494-970f-d38ec7afd215.jpeg", Description = "Món mứt mận Hà Nội với hương vị thơm ngon, màu sắc hấp dẫn được rất nhiều bạn ưa chuộng mỗi khi mùa mận về.", Youtube="https://www.youtube.com/watch?v=mn1C0eY_A9E" },
            //    new Recipes() { Title = "Gỏi Sứa Xoài Xanh", Picture="ce5101e4-7333-4ac5-ad5c-4fb9633303de.jpeg", Description = "Gỏi sứa xoài xanh - món ăn thanh mát, giải nhiệt cho mùa hè nóng bức. Sứa giàu chất dinh dưỡng, dễ ăn dễ chế biến, ngon giòn sần sựt, kết hợp với vị xoài chua nhẹ đước rưới thêm nước sốt chua ngọt, tất cả hòa quyện vào nhau tạo nên món ăn thơm ngon lạ miệng chinh phục cả những người khó tính.", Youtube="https://www.youtube.com/watch?v=uszzG_hsLTo"},
            //    new Recipes() { Title = "Chè hạt đác", Picture="c2dfb767-537c-4d44-a129-46b339e632d1.jpeg", Description = "Món chè hạt đác chinh phục bất cứ ai khi thưởng thức nhờ cảm giác thích thú khi nhai những hạt đác giòn dai rất đặc trưng, có vị ngọt mát vừa phải, dễ chịu. Kết hợp hạt đác cùng các nguyên liệu trái cây như dâu tây, mít càng làm cho món chè thêm lôi cuốn khó cưỡng. ", Youtube="https://www.youtube.com/watch?v=a84Ok94wMUk" },
            //    new Recipes() { Title = "Ngan cháy tỏi", Picture="0b708df7-99b4-4909-b617-df71addc61b5.jpeg", Description = "Món ngan cháy tỏi là món ăn rất được yêu thích ở Hà Nội, điều đặc biệt của món ăn này chính là vị đậm đà của gia vị tẩm ướp vào thịt ngan, độ dai nhưng không bị khô chút nào. Được kết hợp cùng tỏi phi xém vàng, giòn thơm giúp món ăn càng ngon hơn và kích thích vị giác rất nhiều, cộng thêm nước mắm chua cay ăn kèm bún và rau sống cũng khá lạ miệng.", Youtube="https://www.youtube.com/watch?v=FN9juXfMtbI" },
            //    new Recipes() { Title = "Gà kho sả ớt", Picture="c0776402-4d50-47c5-b9d6-7416a15217b0.jpeg", Description = "Gà kho sả ớt là món ăn vô cùng phổ biến trong những bữa cơm của người Việt Nam.", Youtube="https://www.youtube.com/watch?v=fTqTdzJF9yE" },
            //    new Recipes() { Title = "Trà sen vàng", Picture="5312cb96-1b94-4288-90b9-7a4fbe4184c8.jpeg", Description = "Trà sen vàng từ lâu đã là thức uống hấp dẫn dành cho giới trẻ.  Sự kết hợp độc đáo giữa trà ô long thanh mát, hạt sen thơm bùi. Thêm vào chút sữa sẽ để vị thêm ngọt ngào.", Youtube="https://www.youtube.com/watch?v=9M3xr74YQw8" },
            //    new Recipes() { Title = "Nui chiên xốt tương ớt", Picture="fdf35125-b391-4b54-81db-d397a268c307.jpeg", Description = "Nui chiên xốt tương ớt là món ăn vặt vừa ngon miệng nhưng cực kì dễ làm, những bạnkhông rành về bếp núc cũng có thể làm được món ăn này. Nuichiên giòn rôm rốp được phủ bên ngoài lớp sốt tương ớt thấm đượmvị cay. Càng ăn càng ghiện,liệu bạn có kiềm chế được món ăn vặt thơm ngon này.", Youtube="https://www.youtube.com/watch?v=tUPAhhSTO4s"},
            //    new Recipes() { Title = "Mận lắc muối tôm", Picture="37870c12-9d41-4d47-9275-5970e92ece5d.jpeg", Description = "Mận hậu hay mận Hà Nội là cái tên để chỉ thứ quả tròn nhỏ màu đỏ, ăn vào giòn giòn, vị chua và chát. Mận hậu còn là món ăn được rất nhiều bạn trẻ yêu mến bởi cái vị ăn mãi rồi hóa thành nghiện. Hôm nay, Cooky sẽ thử kết hợp hai tuyệt phẩm khi đem quả Mận lắc với muối tôm Tây Ninh như bao món trái cây khác.", Youtube="https://www.youtube.com/watch?v=zcLwzbeMHJg" },
            //    new Recipes() { Title = "Tôm Nướng Phô Mai", Picture="1050fc9b-fae8-46ad-ba94-1ffa1dda0654.jpeg", Description = "Tôm là thực phẩm có chứa hàm lượng canxi, dinh dưỡng cao, vì thế đây là thực phẩm được nhiều người dùng để chế biến thành nhiều món ăn khác nhau. Đặc biệt là tôm nướng phô mai được rất nhiều người yêu thích bởi hương vị đậm đà, “lôi cuốn” của món ăn.", Youtube="https://www.youtube.com/watch?v=q3JUJOZArZ8" },
            //    new Recipes() { Title = "Gà giòn cay phô mai", Picture="d8afe934-1697-4b2f-ac4f-a02c6ac3d7b7.jpeg", Description = "Nếu bạn là một tín đồ của các món ăn chế biến từ gà, đặc biệt là gà rán thì với món gà giòn cay phô mai Hàn Quốc dưới đây sẽ khiến bạn phải thèm thuồng.",Youtube="https://www.youtube.com/watch?v=PSXCxihzwv0" },
            //    new Recipes() { Title = "Ba chỉ rim chao", Picture="cooky-recipe-cover-r52502.jpg", Description = "Ba chỉ rim chao với cách làm đơn giản, nguyên liệu lại không cầu kì nhưng lại là món ăn cực kì hao cơm. Beo béo của thịt ba chỉ cộng với vị bùi bùi của chao thêm vài lát ớt nữa tạo nên một món ăn siêu hấp dẫn để đãi gia đình.", Youtube="https://www.youtube.com/watch?v=7kHHNVQGpfo" },
            //    new Recipes() { Title = "Bún xì dầu", Picture="cooky-recipe-cover-r50135.jpg", Description = "Bún xì dầu là một món ăn bình dân gần gũi với nhiều người, nếu đã ăn một lần thì sẽ khó mà quên được hương vị thơm ngon quyến luyến mà món ăn này mang lại.", Youtube="https://www.youtube.com/watch?v=GNzJJM00jj8" },
            //    new Recipes() { Title = "Khô heo giả khô bò", Picture="cooky-recipe-cover-r51521.jpg", Description = "Miếng khô heo giả khô bò đậm vị, thơm lừng, dai ngọt lại cay cay. Đây hẳn là món ăn thú vị thích hợp để mời gia đình, bạn bè nhâm nhi thưởng thức trong những ngày lễ Tết. Bên cạnh đó phần lớn chị em lo lắng, nếu mua các món này ngoài hàng sẽ không đảm bảo vệ sinh an toàn thực phẩm.", Youtube="https://www.youtube.com/watch?v=1ysvL0mE1Pk" },
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

            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var database = $"{folder}AllRecipes.txt";
            var colorpicker = $"{folder}Color.txt";
            var c = File.ReadAllLines(colorpicker);
            var _color = new ChangeColor()
            {
                ColorTopBar = c[0],
            };
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
                    UIHeartIcon = line6,
                    WidthFood = "266"
                };

                _data.Add(recipes);
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
                    TopBar.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
                    GridCursor.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
                    Prev.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
                    Page1.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
                    Page2.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
                    Page3.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
                    Next.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(_color.ColorTopBar));
                    dataListview.ItemsSource = _data.Take(info.RowsPerPage);
                });
            });

            thread.Start();
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

        private void itemMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            USHome.Children.Clear();
            USHome.Children.Add(new UserControlNew());
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void dataListview_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as Recipes;
            if (item != null)
            {
                Food.Children.Add(new UserControlRecipesDetail(item));
                Top.Visibility = Visibility.Collapsed;
                Bot.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonFavorite_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void dataListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            if (Menu.Width.ToString().Equals("60"))
            {
                Menu.Width = 240;
                for (int i = 0; i < _data.Count; i++)
                {
                    _data[i].WidthFood = "266";
                }
            }
            else
            {
                Menu.Width = 60;
                for (int j = 0; j < _data.Count; j++)
                {
                    _data[j].WidthFood = "310";
                }
            }
        }

        private void CloseUserControl()
        {
            // Remove current user control
            Food.Children.Clear();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            // Nếu ô tìm kiếm rỗng, thì lấy tất cả sản phẩm
            if (SearchTexbox.Text.Length == 0)
            {
                dataListview.ItemsSource = _data.Take(12);
                this.Bot.Visibility = Visibility.Visible;
            }
            // Nếu ô tìm kiếm có nội dung   
            else
            {
                // Tạo mới danh sách sản phẩm có tên chứa nội dung ô tìm kiếm
                ObservableCollection<Recipes> searchRecipes = new ObservableCollection<Recipes>();
                for (int i = 0; i < _data.Count; i++)
                {
                    if ((_data[i].Title).ToLower().Contains((SearchTexbox.Text).ToLower()) || (_data[i].Title).ToUpper().Contains((SearchTexbox.Text).ToUpper())) // Nếu tìm thấy tên phù hợp
                    {
                        searchRecipes.Add(_data[i]); // Thì thêm vào danh sách mới
                    }
                }

                // Nếu tìm thấy ít nhất 1 sản phẩm thì hiển thị, không thì thông báo
                if (searchRecipes.Count > 0)
                {
                    this.Bot.Visibility = Visibility.Collapsed;
                    dataListview.ItemsSource = searchRecipes.Take(12);             
                }
                //else if (searchRecipes.Count > 12)
                //{
                //    this.Bot.Visibility = Visibility.Collapsed;
                //    dataListview.ItemsSource = searchRecipes.Take(12);
                //}
                else
                {
                    MessageBox.Show("Not found");
                }

                // Làm trống ô tìm kiếm
                SearchTexbox.Text = "";
            }
        }

        private void ButtonHeart_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonShop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAbout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSetting_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (0 + (60 * index)), 0, 0);
        }

        private void itemMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int index = itemMenu.SelectedIndex;
            MoveCursorMenu(index);
            switch (index)
            {
                case 2:
                    Food.Children.Clear();
                    USHome.Children.Clear();
                    USHome.Children.Add(new UserControlNew());
                    break;
                case 3:
                    USHome.Children.Clear();
                    USHome.Children.Add(new UserControlHome());
                    break;
                case 4:
                    Food.Children.Clear();
                    Food.Children.Add(new UserControlFavorite());
                    this.Top.Visibility = Visibility.Collapsed;
                    this.Bot.Visibility = Visibility.Collapsed;
                    break;
                case 5:
                    Food.Children.Clear();
                    Food.Children.Add(new UserControlShoppingList());
                    this.Top.Visibility = Visibility.Collapsed;
                    this.Bot.Visibility = Visibility.Collapsed;
                    break;
                case 6:
                    Food.Children.Clear();
                    Food.Children.Add(new UserControlAbout());
                    this.Top.Visibility = Visibility.Collapsed;
                    this.Bot.Visibility = Visibility.Collapsed;
                    break;
                case 7:
                    Food.Children.Clear();
                    Food.Children.Add(new UserControlHelp());
                    this.Top.Visibility = Visibility.Collapsed;
                    this.Bot.Visibility = Visibility.Collapsed;
                    break;
                case 8:
                    Food.Children.Clear();
                    Food.Children.Add(new UserControlSetting());
                    this.Top.Visibility = Visibility.Collapsed;
                    this.Bot.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }

        private void dataListview_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ButtonFavorite_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            int index = dataListview.Items.IndexOf(item) + ((info.CurrentPage - 1) * info.RowsPerPage);
            if (_data[index].UIHeartColor == "Red" && _data[index].UIHeartIcon == "Heart")
            {
                _data[index].UIHeartColor = "White";
                _data[index].UIHeartIcon = "HeartOutline";
                var folder = AppDomain.CurrentDomain.BaseDirectory;
                var database = $"{folder}AllRecipes.txt";
                var lines = File.ReadAllLines(database);
                lines[index * 6 + 5] = "White";
                lines[index * 6 + 6] = "HeartOutline";
                File.WriteAllLines(database, lines);
                //Xu ly xoa
                //if (index == -1)
                //{

                //}
                //else
                //{
                //    var db = $"{folder}Favorite.txt";
                //    List<string> resline = File.ReadAllLines(db).ToList();
                //    var lnie = File.ReadAllLines(db);
                //    int count = int.Parse(lnie[0]);
                //    if (count > 0)
                //    {
                //        //count--;
                //        ////lnie[0] = (count--).ToString();
                //        //resline[0] = (count--).ToString();
                //        //resline.RemoveAt(index * 4 + 1);
                //        //resline.RemoveAt(index * 4 + 2);
                //        //resline.RemoveAt(index * 4 + 3);
                //        //resline.RemoveAt(index * 4 + 4);
                //        //File.WriteAllLines(db, resline.ToArray());
                //        ////_data.RemoveAt(index);

                //    }
                //}
            }
            else
            {
                _data[index].UIHeartColor = "Red";
                _data[index].UIHeartIcon = "Heart";
                NewRecipesFavorite = _data[index];
                var folder = AppDomain.CurrentDomain.BaseDirectory;
                var db = $"{folder}AllRecipes.txt";
                var lnie = File.ReadAllLines(db);
                lnie[index * 6 + 5] = "Red";
                lnie[index * 6 + 6] = "Heart";
                File.WriteAllLines(db, lnie);
                //var database = $"{folder}Favorite.txt";
                //var lines = File.ReadAllLines(database);
                //int count = int.Parse(lines[0]);
                //count++;
                //lines[0] = (count++).ToString();
                //File.WriteAllLines(database, lines);
                //using (StreamWriter sw = File.AppendText(database))
                //{
                //    sw.WriteLine(NewRecipesFavorite.Title);
                //    sw.WriteLine(NewRecipesFavorite.Picture);
                //    sw.WriteLine(NewRecipesFavorite.Description);
                //    sw.WriteLine(NewRecipesFavorite.Youtube);
                //}
                //UserControlFavorite f = new UserControlFavorite();
                //f._f = NewRecipesFavorite;
                //Food.Children.Add(f);
                //this.Top.Visibility = Visibility.Collapsed;
                //this.Bot.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
