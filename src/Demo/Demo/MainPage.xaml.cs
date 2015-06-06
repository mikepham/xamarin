namespace Demo
{
    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }
    }
}