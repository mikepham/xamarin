namespace Demo.ViewModels
{
    using System.Windows.Input;

    using PropertyChanged;

    using Xamarin.Forms;

    public class MainViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.ShowSnackBar = new Command(HandleShowSnackBar);
            this.Title = "Main";
        }

        /// <summary>
        /// Gets the show snack bar command.
        /// </summary>
        [DoNotNotify]
        public ICommand ShowSnackBar { get; private set; }

        private static void HandleShowSnackBar()
        {
        }
    }
}