using NativeCode.Mobile.Controls.MaterialDesign.Droid.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Switch), typeof(SwitchRenderer))]

namespace NativeCode.Mobile.Controls.MaterialDesign.Droid.Renderers
{
    using System.ComponentModel;

    using NativeCode.Mobile.Common.Droid;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    using NativeMaterialSwitch = NativeCode.Bindings.MaterialDesign.Views.Switch;

    public class SwitchRenderer : InflateViewRenderer<Switch, NativeMaterialSwitch>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                this.SetNativeControl(this.InflateNativeControl(Resource.Layout.switch_view));
                this.Control.SetChecked(this.Element.IsToggled);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Switch.IsToggledProperty.PropertyName)
            {
                this.Control.SetChecked(this.Element.IsToggled);
            }
        }
    }
}