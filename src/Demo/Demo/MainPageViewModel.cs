namespace Demo
{
    using System.Windows.Input;

    using NativeCode.Mobile.Controls.MaterialDesign.Dialogs;

    using PropertyChanged;

    using Xamarin.Forms;

    [ImplementPropertyChanged]
    public class MainPageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel()
        {
            this.ShowSnackBar = new Command(HandleShowSnackBar);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        public bool IsBusy { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets the show snack bar command.
        /// </summary>
        [DoNotNotify]
        public ICommand ShowSnackBar { get; private set; }

        private static void HandleShowSnackBar()
        {
            var provider = DependencyService.Get<IDialogProvider>();
            provider.ShowDismissableDialog("Test", "OK", handle => { });
        }
    }
}