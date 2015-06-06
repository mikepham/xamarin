using NativeCode.Mobile.Controls.MaterialDesign.Droid.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Button), typeof(RectangleButtonRenderer))]

namespace NativeCode.Mobile.Controls.MaterialDesign.Droid.Renderers
{
    using NativeCode.Bindings.MaterialDesign.Views;
    using NativeCode.Mobile.Common.Droid;

    using Xamarin.Forms.Platform.Android;

    using Button = Xamarin.Forms.Button;

    public class RectangleButtonRenderer : InflateViewRenderer<Button, ButtonRectangle>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                this.SetNativeControl(this.InflateNativeControl(Resource.Layout.rectanglebutton_view));
                this.Control.Text = this.Element.Text ?? string.Empty;
            }
        }
    }
}