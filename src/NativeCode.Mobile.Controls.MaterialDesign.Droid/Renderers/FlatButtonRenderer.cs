using NativeCode.Mobile.Controls.MaterialDesign;
using NativeCode.Mobile.Controls.MaterialDesign.Droid.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FlatButton), typeof(FlatButtonRenderer))]

namespace NativeCode.Mobile.Controls.MaterialDesign.Droid.Renderers
{
    using NativeCode.Bindings.MaterialDesign.Views;
    using NativeCode.Mobile.Common.Droid;

    using Xamarin.Forms.Platform.Android;

    public class FlatButtonRenderer : InflateViewRenderer<FlatButton, ButtonFlat>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<FlatButton> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                this.SetNativeControl(this.InflateNativeControl(Resource.Layout.flatbutton_view));
                this.Control.Text = this.Element.Text ?? string.Empty;
            }
        }
    }
}