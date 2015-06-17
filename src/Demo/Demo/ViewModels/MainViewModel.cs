namespace Demo.ViewModels
{
    using System.Windows.Input;

    using NativeCode.Mobile.AppCompat.Controls.Platforms;

    using PropertyChanged;

    using Xamarin.Forms;

    public class MainViewModel : ViewModel
    {
        private int counter;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.FloatingButtonCommand = new Command(this.HandleFloatingButtonCommand);
            this.ShowSnackBar = new Command(this.HandleShowSnackBar);
            this.Title = "Main";
        }

        [DoNotNotify]
        public ICommand FloatingButtonCommand { get; private set; }

        [DoNotNotify]
        public ICommand ShowSnackBar { get; private set; }

        private void HandleFloatingButtonCommand()
        {
            this.Title = string.Format("Clicked {0} times.", ++this.counter);
        }

        private void HandleShowSnackBar()
        {
            var notifier = DependencyService.Get<IUserNotifier>();
            notifier.NotifyShort("Sample message.");
        }
    }
}