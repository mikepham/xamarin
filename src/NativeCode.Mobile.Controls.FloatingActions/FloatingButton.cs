namespace NativeCode.Mobile.Controls.FloatingActions
{
    using System.Windows.Input;

    using global::Xamarin.Forms;

    public class FloatingButton : View
    {
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<FloatingButton, object>(
            x => x.CommandParameter,
            default(object));

        public static readonly BindableProperty CommandProperty = BindableProperty.Create<FloatingButton, ICommand>(x => x.Command, default(ICommand));

        public static readonly BindableProperty ImageProperty = BindableProperty.Create<FloatingButton, ImageSource>(x => x.Image, default(ImageSource));

        public static readonly BindableProperty TitleProperty = BindableProperty.Create<FloatingButton, string>(x => x.Title, default(string));

        public object CommandParameter
        {
            get { return this.GetValue(CommandParameterProperty); }
            set { this.SetValue(CommandParameterProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        public ImageSource Image
        {
            get { return (ImageSource)this.GetValue(ImageProperty); }
            set { this.SetValue(ImageProperty, value); }
        }

        public string Title
        {
            get { return (string)this.GetValue(TitleProperty); }
            set { this.SetValue(TitleProperty, value); }
        }
    }
}