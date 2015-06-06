namespace NativeCode.Mobile.Controls.MaterialDesign
{
    using Xamarin.Forms;

    public class CheckBox : View
    {
        /// <summary>
        /// Checked property binding.
        /// </summary>
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create<CheckBox, bool>(x => x.Checked, default(bool));

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CheckBox"/> is checked.
        /// </summary>
        public bool Checked
        {
            get { return (bool)this.GetValue(CheckedProperty); }
            set { this.SetValue(CheckedProperty, value); }
        }
    }
}