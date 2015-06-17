namespace Demo
{
    using Demo.Views;

    using Xamarin.Forms;

    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.MainPage = CreateMainPage();
        }

        internal static MasterDetailPage MasterDetail { get; private set; }

        internal static INavigation Navigation { get; private set; }

        private static Page CreateMainPage()
        {
            return CreateNavigationPage(CreateMasterDetailPage());
        }

        private static MasterDetailPage CreateMasterDetailPage()
        {
            MasterDetail = new MasterDetailPage
            {
                Detail = new MainView(),
                Master = new MenuView(),
                MasterBehavior = MasterBehavior.Popover
            };

            return MasterDetail;
        }

        private static NavigationPage CreateNavigationPage(Page page)
        {
            var navigation = new NavigationPage(page);

            navigation.Popped += (sender, args) => MasterDetail.IsPresented = false;
            navigation.PoppedToRoot += (sender, args) => MasterDetail.IsPresented = false;
            navigation.Pushed += (sender, args) => MasterDetail.IsPresented = false;

            Navigation = navigation.Navigation;

            return navigation;
        }
    }
}