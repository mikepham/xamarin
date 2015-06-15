namespace Demo
{
    using Demo.Views;

    using Xamarin.Forms;

    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.MainPage = new MasterDetailPage { Detail = new MainView(), Master = new MenuView(), MasterBehavior = MasterBehavior.Popover };
        }

        public static void ChangeDetailPage(Page page)
        {
            var master = (MasterDetailPage)Current.MainPage;
            master.Detail = page;
        }
    }
}