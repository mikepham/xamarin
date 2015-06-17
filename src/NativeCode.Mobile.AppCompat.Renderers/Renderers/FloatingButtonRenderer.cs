using NativeCode.Mobile.AppCompat.Controls;
using NativeCode.Mobile.AppCompat.Renderers.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FloatingButton), typeof(FloatingButtonRenderer))]

namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System.ComponentModel;

    using Android.Support.Design.Widget;
    using Android.Views;

    using NativeCode.Mobile.AppCompat.Controls;
    using NativeCode.Mobile.AppCompat.EventListeners;
    using NativeCode.Mobile.AppCompat.Extensions;

    using Xamarin.Forms.Platform.Android;

    public class FloatingButtonRenderer : InflateViewRenderer<FloatingButton, FloatingActionButton>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<FloatingButton> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                var control = new FloatingActionButton(this.Context.GetAppCompatThemedContext());
                this.SetNativeControl(control);

                control.Clickable = true;
                control.SetOnClickListener(this.RegisterDisposable(new OnClickListener(this.HandleClickListener)));

                this.UpdateBackgroundColor();
                this.UpdateColor();
                this.UpdateIcon();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == FloatingButton.ButtonSizeProperty.PropertyName)
            {
                // TODO: Need to figure out how to change the button size besides from XML.
            }
            else if (e.PropertyName == FloatingButton.ColorProperty.PropertyName)
            {
                this.UpdateColor();
            }
            else if (e.PropertyName == FloatingButton.IconProperty.PropertyName)
            {
                this.UpdateIcon();
            }
        }

        private void HandleClickListener(View view)
        {
            if (this.Element.Command != null && this.Element.Command.CanExecute(this.Element.CommandParameter))
            {
                this.Element.Command.Execute(this.Element.CommandParameter);
            }
        }

        private void UpdateColor()
        {
            // TODO: Need to update the BackgroundTintList property.
        }

        private void UpdateIcon()
        {
            if (this.Element.Icon != null)
            {
                this.Control.SetImageDrawable(this.Element.Icon.ToBitmapDrawable());
            }
        }
    }
}