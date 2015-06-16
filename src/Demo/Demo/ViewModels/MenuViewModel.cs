namespace Demo.ViewModels
{
    using System.Windows.Input;

    using Demo.Views;

    using PropertyChanged;

    using Xamarin.Forms;

    public class MenuViewModel : ViewModel
    {
        public MenuViewModel()
        {
            this.HomeCommand = new Command(() => App.ChangeDetailPage(new MainView()));
            this.HomeText = "Home";
            this.Title = "Menu";
        }

        [DoNotNotify]
        public ICommand HomeCommand { get; private set; }

        public string HomeText { get; set; }
    }
}