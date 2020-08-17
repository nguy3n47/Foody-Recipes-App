using FoodRecipes;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace FoodRecipes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// int page;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ObservableCollection<Recipes> _recipes;

        public void Unit()
        {
            _recipes = new ObservableCollection<Recipes>()
            {
                new Recipes() { Title = "Bò cuộn hầm trái cây", Picture="cooky-recipe-cover-r53012.jpg", Description = "Bò cuộn hầm trái cây là món ăn vừa kết hợp chất dinh dưỡng từ thịt lẫn vitamin từ các loại trái cây.  Với những nguyên liệu dễ kiếm, cách làm đơn giản, chỉ cần bỏ chút thời gian là bạn có thể chế biến được một món ăn khá lạ miệng mà hấp dẫn. Từng miếng thịt bò như những bông hoa nở đều đẹp mắt, thơm mềm, thấm vị, hòa cùng trái cây đủ màu sắc khiến món ăn thêm phần ngon miệng." },
                new Recipes() { Title = "Lẩu lươn chua cay", Picture="cooky-recipe-cover-r53011.jpg", Description = "Lẩu Lươn Chua Cay là món ăn mang đặc trưng của miền sông nước. Vị nước dùng đậm đà, chua chua cay cay kết hợp với vị ngọt, dai của lươn hòa cùng vị thanh mát của các loại rau ăn kèm. Vừa thơm ngon lại bổ dưỡng, ai ăn một lần cũng nhớ mãi. Hãy chuẩn bị nguyên liệu và thực hiện theo cách bước sau nhé!" },
                new Recipes() { Title = "Gà Hấp Mắm Nhĩ", Picture="f857e0cc-2a33-4d34-83e0-8945171be8f1.jpeg", Description = "Gà hấp mắm nhĩ- món ăn vừa dễ làm lại thơm ngon khó cưỡng, nước mắm nhĩ thơm phức được ướp với thịt gà ta, cộng thêm một ít  tỏi và tiêu xanh làm tăng thêm hương vị của món ăn, càng ăn càng ghiền, vị ngọt, dai trong từng thớ thịt gà ngấm đều vị ăn hoài không ngán. Chỉ cần bỏ chút thời gian là ta đã có ngay món ăn hấp dẫn này rồi." },
                new Recipes() { Title = "Bánh mì caramel", Picture="9d179eb5-6149-4573-918f-b30fc5a8c492.jpeg", Description = "Món bánh mì caramel gần đây đang làm mưa làm gió trên mạng bởi độ ngọt ngào, giòn tan khó ai cưỡng lại được. " },
                new Recipes() { Title = "Mứt mận Hà Nội", Picture="a7aba944-f155-4494-970f-d38ec7afd215.jpeg", Description = "Món mứt mận Hà Nội với hương vị thơm ngon, màu sắc hấp dẫn được rất nhiều bạn ưa chuộng mỗi khi mùa mận về." },
                new Recipes() { Title = "Gỏi Sứa Xoài Xanh", Picture="ce5101e4-7333-4ac5-ad5c-4fb9633303de.jpeg", Description = "Gỏi sứa xoài xanh - món ăn thanh mát, giải nhiệt cho mùa hè nóng bức. Sứa giàu chất dinh dưỡng, dễ ăn dễ chế biến, ngon giòn sần sựt, kết hợp với vị xoài chua nhẹ đước rưới thêm nước sốt chua ngọt, tất cả hòa quyện vào nhau tạo nên món ăn thơm ngon lạ miệng chinh phục cả những người khó tính."},
                new Recipes() { Title = "Chè hạt đác", Picture="c2dfb767-537c-4d44-a129-46b339e632d1.jpeg", Description = "Món chè hạt đác chinh phục bất cứ ai khi thưởng thức nhờ cảm giác thích thú khi nhai những hạt đác giòn dai rất đặc trưng, có vị ngọt mát vừa phải, dễ chịu. Kết hợp hạt đác cùng các nguyên liệu trái cây như dâu tây, mít càng làm cho món chè thêm lôi cuốn khó cưỡng. " },
                new Recipes() { Title = "Ngan cháy tỏi", Picture="0b708df7-99b4-4909-b617-df71addc61b5.jpeg", Description = "Món ngan cháy tỏi là món ăn rất được yêu thích ở Hà Nội, điều đặc biệt của món ăn này chính là vị đậm đà của gia vị tẩm ướp vào thịt ngan, độ dai nhưng không bị khô chút nào. Được kết hợp cùng tỏi phi xém vàng, giòn thơm giúp món ăn càng ngon hơn và kích thích vị giác rất nhiều, cộng thêm nước mắm chua cay ăn kèm bún và rau sống cũng khá lạ miệng." },
                new Recipes() { Title = "Gà kho sả ớt", Picture="c0776402-4d50-47c5-b9d6-7416a15217b0.jpeg", Description = "Gà kho sả ớt là món ăn vô cùng phổ biến trong những bữa cơm của người Việt Nam." },
                new Recipes() { Title = "Trà sen vàng", Picture="5312cb96-1b94-4288-90b9-7a4fbe4184c8.jpeg", Description = "Trà sen vàng từ lâu đã là thức uống hấp dẫn dành cho giới trẻ.  Sự kết hợp độc đáo giữa trà ô long thanh mát, hạt sen thơm bùi. Thêm vào chút sữa sẽ để vị thêm ngọt ngào." },
                new Recipes() { Title = "Nui chiên xốt tương ớt", Picture="fdf35125-b391-4b54-81db-d397a268c307.jpeg", Description = "Nui chiên xốt tương ớt là món ăn vặt vừa ngon miệng nhưng cực kì dễ làm, những bạnkhông rành về bếp núc cũng có thể làm được món ăn này. Nuichiên giòn rôm rốp được phủ bên ngoài lớp sốt tương ớt thấm đượmvị cay. Càng ăn càng ghiện,liệu bạn có kiềm chế được món ăn vặt thơm ngon này."},
                new Recipes() { Title = "Mận lắc muối tôm", Picture="37870c12-9d41-4d47-9275-5970e92ece5d.jpeg", Description = "Mận hậu hay mận Hà Nội là cái tên để chỉ thứ quả tròn nhỏ màu đỏ, ăn vào giòn giòn, vị chua và chát. Mận hậu còn là món ăn được rất nhiều bạn trẻ yêu mến bởi cái vị ăn mãi rồi hóa thành nghiện. Hôm nay, Cooky sẽ thử kết hợp hai tuyệt phẩm khi đem quả Mận lắc với muối tôm Tây Ninh như bao món trái cây khác." },
                new Recipes() { Title = "Tôm Nướng Phô Mai", Picture="1050fc9b-fae8-46ad-ba94-1ffa1dda0654.jpeg", Description = "Tôm là thực phẩm có chứa hàm lượng canxi, dinh dưỡng cao, vì thế đây là thực phẩm được nhiều người dùng để chế biến thành nhiều món ăn khác nhau. Đặc biệt là tôm nướng phô mai được rất nhiều người yêu thích bởi hương vị đậm đà, “lôi cuốn” của món ăn." },
                new Recipes() { Title = "Gà giòn cay phô mai", Picture="d8afe934-1697-4b2f-ac4f-a02c6ac3d7b7.jpeg", Description = "Nếu bạn là một tín đồ của các món ăn chế biến từ gà, đặc biệt là gà rán thì với món gà giòn cay phô mai Hàn Quốc dưới đây sẽ khiến bạn phải thèm thuồng." },
                new Recipes() { Title = "Ba chỉ rim chao", Picture="cooky-recipe-cover-r52502.jpg", Description = "Ba chỉ rim chao với cách làm đơn giản, nguyên liệu lại không cầu kì nhưng lại là món ăn cực kì hao cơm. Beo béo của thịt ba chỉ cộng với vị bùi bùi của chao thêm vài lát ớt nữa tạo nên một món ăn siêu hấp dẫn để đãi gia đình." },
                new Recipes() { Title = "Bún xì dầu", Picture="cooky-recipe-cover-r50135.jpg", Description = "Bún xì dầu là một món ăn bình dân gần gũi với nhiều người, nếu đã ăn một lần thì sẽ khó mà quên được hương vị thơm ngon quyến luyến mà món ăn này mang lại." },
                new Recipes() { Title = "Khô heo giả khô bò", Picture="cooky-recipe-cover-r51521.jpg", Description = "Miếng khô heo giả khô bò đậm vị, thơm lừng, dai ngọt lại cay cay. Đây hẳn là món ăn thú vị thích hợp để mời gia đình, bạn bè nhâm nhi thưởng thức trong những ngày lễ Tết. Bên cạnh đó phần lớn chị em lo lắng, nếu mua các món này ngoài hàng sẽ không đảm bảo vệ sinh an toàn thực phẩm." },
                new Recipes() { Title = "Trứng rim mắm hành", Picture="c131708a-374a-48b7-8f79-9fa00f46ca4d.jpeg", Description = "Trứng Rim Mắm Hành, món ăn khá đơn giả nhưng lại cực kì hao cơm, với cách chế biến nhanh chóng là đã có ngay món trứng rim thơm ngon với lớp vỏ ngoài giòn dai, có màu nâu đẹp thấm đượm vị." },
                new Recipes() { Title = "Cà Phê Bọt Biển", Picture="e8fd83b8-e7fe-4733-b782-96ab707c719f.jpeg", Description = "Dalgona Coffe - Cà Phê Bọt Biển món thức uống đình đám được pha chế khá mới lạ, độc đáo với mùi thơm đầy mê hoặc và hương vị cực ngon. Ngoài Nescafe, Cooky sử dụng cà phê G7 đến từ nhà Trung Nguyên nhé các bạn. Thưởng thức một ly Dalgona coffee hấp dẫn  không chỉ giúp bạn giải khát, mà còn khiến cho tâm hồn trở nên thư thái hơn vì thức uống đẹp mắt và hội tụ đủ hương vị độc đáo. " },
                new Recipes() { Title = "Cơm cháy chả cá", Picture="cooky-recipe-cover-r50163.jpg", Description = "Cơm cháy chả cá là một món ăn vặt đang làm mưa làm gió hiện nay. Miếng cơm cháy giòn tan cùng chả cá dai dai, thơm ngọt chấm cùng nước mắm chua ngọt, đặc kẹo thật khó để có thể cưỡng lại được. Món ăn dân giã, giản dị với cách làm cũng cực kì đơn giản thôi." },
                new Recipes() { Title = "Cóc trộn trứng cút", Picture="cooky-recipe-cover-r52117.jpg", Description = "Cóc trộn trứng cút rau răm là món ăn kích thích vị giác mà bạn không thể bỏ qua, ai đã từng ăn qua món ăn này sẽ bị ghiền. " },
                new Recipes() { Title = "Bánh ngải", Picture="cooky-recipe-cover-r49947.jpg", Description = "Ngải cứu là một phương thuốc lâu đời của đông y, không chỉ thế đó còn là một thứ nguyên liệu cho món bánh nổi tiếng của người dân tộc Tày ở Lạng Sơn. Miếng bánh thơm lừng mùi ngải cứu, béo ngậy vì dừa cùng với cái bùi của đậu phộng và mè đen chắc chắn sẽ làm bạn ăn mãi không dừng được đấy! " },
                new Recipes() { Title = "Bánh mì dân tổ", Picture="cooky-recipe-cover-r49793.jpg", Description = "Chỉ trong khoảng 1 tuần trở lại đây, bánh mì dân tổ bỗng nhiên sốt xình xịch, được rất nhiều người quan tâm và tìm đến mua, ăn thử. Bánh mì dân tổ là món ăn sáng khá ngon với cách chế biến mới từ những nguyên liệu quen thuộc như chả, trứng, pa tê, xúc xích..." },
                new Recipes() { Title = "Trứng chiếc thuyền", Picture="cooky-recipe-cover-r49931.jpg", Description = "Dùng lá chuối để nấu ăn không còn xa lạ với nhiều người, nhưng gấp lá chuối thành thuyền và nướng trứng trong đó hẳn sẽ là món ăn độc đáo và hấp dẫn với nhiều tín đồ ăn vặt. Với công thức món trứng nướng chiếc thuyền mới lạ dưới đây, món trứng với nhiều topping bắt mắt như khô bò xé, trứng muối, thanh cua sẽ cùng sốt chấm cay nồng hoàn hảo sẽ là một biến tấu mới cho bữa ăn của bạn." },
                new Recipes() { Title = "Bánh tai yến", Picture="cooky-recipe-cover-r49880.jpg", Description = "Với hình dáng nhỏ nhắn, xinh xắn như những chiếc tổ yến, hương vị lại thơm ngon, giòn dai ngọt ngọt, bánh tai yến đã trở thành món “ruột” của rất nhiều người. Thay vì chạy vội ra tiệm để mua, tại sao bạn không thử tự tay làm bánh ở nhà." },
                new Recipes() { Title = "Bún đỏ Buôn Mê Thuột", Picture="cooky-recipe-cover-r47378.jpg", Description = "Bún đỏ là một món ăn dân dã mà bạn có thể gặp bất cứ đâu ở vùng đất Buôn Mê Thuột. Sợi bún màu đỏ cam vừa lạ vừa thú vị, hòa quyện cùng nước dùng xương đậm đà và riêu cua thịt hấp dẫn. Món bún đỏ còn đặc biệt ở rau ăn kèm đó là rau cần nước và cải ngọt trụng chín. " },
                new Recipes() { Title = "Trứng muối nước", Picture="cooky-recipe-cover-r47321.jpg", Description = "Trứng tự muối thật ra chỉ hơi mất thời gian một chút, đoạn đợi trứng ngấm muối và “chín”, thường mất khoảng 4-6 tuần, còn lại thì cách làm cực kì đơn giản và cực dễ, hầu như không thể hỏng. Trứng muối đúng thì lòng đỏ sẽ lên màu đỏ cam, trong và cảm giác săn tròn lại rất đẹp. " }

            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Unit();
            UserControlHome h = new UserControlHome();
            Food.Children.Add(h);
        }

        private void Fx_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
