namespace Demo
{
    using PropertyChanged;

    [ImplementPropertyChanged]
    public class MainPageViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        public bool IsBusy { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
    }
}