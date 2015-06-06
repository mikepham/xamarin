using NativeCode.Mobile.Controls.FloatingActions;
using NativeCode.Mobile.Controls.FloatingActions.Droid;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FloatingButton), typeof(FloatingButtonRenderer))]

namespace NativeCode.Mobile.Controls.FloatingActions.Droid
{
    using System.ComponentModel;

    using NativeCode.Bindings.FloatingActions;
    using NativeCode.Mobile.Common.Droid.Extensions;

    using Xamarin.Forms.Platform.Android;

    public class FloatingButtonRenderer : ViewRenderer<FloatingButton, FloatingActionButton>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<FloatingButton> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                // TODO: Need to get this from XF colors. Might have to edit source and/or port to C# to achieve.
                this.SetNativeControl(new FloatingActionButton(this.Context));
                this.Control.SetColorNormalResId(Resource.Color.fab_normal);
                this.Control.SetColorPressedResId(Resource.Color.fab_pressed);

                this.Control.Clickable = true;
                this.Control.SetOnClickListener(this);

                this.UpdateImage();
                this.UpdateTitle();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == FloatingButton.TitleProperty.PropertyName)
            {
                this.UpdateTitle();
            }
            else if (e.PropertyName == FloatingButton.ImageProperty.PropertyName)
            {
                this.UpdateImage();
            }
        }

        protected virtual void UpdateImage()
        {
            var drawable = this.Element.Image != null ? this.Element.Image.ToBitmapDrawable() : null;
            this.Control.SetIconDrawable(drawable);
        }

        protected virtual void UpdateTitle()
        {
            this.Control.Title = this.Element.Title;
        }
    }
}