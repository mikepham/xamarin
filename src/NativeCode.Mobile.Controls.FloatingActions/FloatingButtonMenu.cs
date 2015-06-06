namespace NativeCode.Mobile.Controls.FloatingActions
{
    using System.Collections.Generic;
    using System.Windows.Input;

    using global::Xamarin.Forms;

    [ContentProperty("Buttons")]
    public class FloatingButtonMenu : View
    {
        public static readonly BindableProperty ColorNormalProperty = BindableProperty.Create<FloatingButtonMenu, Color>(x => x.ColorNormal, Color.Green);

        public static readonly BindableProperty ColorPressedProperty = BindableProperty.Create<FloatingButtonMenu, Color>(x => x.ColorPressed, Color.Default);

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<FloatingButton, object>(
            x => x.CommandParameter,
            default(object));

        public static readonly BindableProperty CommandProperty = BindableProperty.Create<FloatingButton, ICommand>(x => x.Command, default(ICommand));

        public static readonly BindableProperty ImageProperty = BindableProperty.Create<FloatingButtonMenu, ImageSource>(x => x.Image, default(ImageSource));

        public static readonly BindableProperty ImageExpandedProperty = BindableProperty.Create<FloatingButtonMenu, ImageSource>(
            x => x.ImageExpanded,
            default(ImageSource));

        public static readonly BindableProperty LabelPositionProperty =
            BindableProperty.Create<FloatingButtonMenu, FloatingButtonLabelPosition>(x => x.LabelPosition, default(FloatingButtonLabelPosition));

        public static readonly BindableProperty MenuStateProperty = BindableProperty.Create<FloatingButtonMenu, FloatingButtonMenuState>(
            x => x.MenuState,
            default(FloatingButtonMenuState));

        public FloatingButtonMenu()
        {
            this.Buttons = new List<FloatingButton>();
        }

        public List<FloatingButton> Buttons { get; set; }

        public Color ColorNormal
        {
            get { return (Color)this.GetValue(ColorNormalProperty); }
            set { this.SetValue(ColorNormalProperty, value); }
        }

        public Color ColorPressed
        {
            get { return (Color)this.GetValue(ColorPressedProperty); }
            set { this.SetValue(ColorPressedProperty, value); }
        }

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

        public ImageSource ImageExpanded
        {
            get { return (ImageSource)this.GetValue(ImageExpandedProperty); }
            set { this.SetValue(ImageExpandedProperty, value); }
        }

        public FloatingButtonLabelPosition LabelPosition
        {
            get { return (FloatingButtonLabelPosition)this.GetValue(LabelPositionProperty); }
            set { this.SetValue(LabelPositionProperty, value); }
        }

        public FloatingButtonMenuState MenuState
        {
            get { return (FloatingButtonMenuState)this.GetValue(MenuStateProperty); }
            set { this.SetValue(MenuStateProperty, value); }
        }
    }
}