using NativeCode.Mobile.Controls.MaterialDesign;
using NativeCode.Mobile.Controls.MaterialDesign.Droid.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(CheckBox), typeof(CheckBoxRenderer))]

namespace NativeCode.Mobile.Controls.MaterialDesign.Droid.Renderers
{
    using System.ComponentModel;

    using NativeCode.Mobile.Common.Droid;
    using NativeCode.Mobile.Controls.MaterialDesign;

    using Xamarin.Forms.Platform.Android;

    using NativeMaterialCheckBox = NativeCode.Bindings.MaterialDesign.Views.CheckBox;

    public class CheckBoxRenderer : InflateViewRenderer<CheckBox, NativeMaterialCheckBox>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CheckBox> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                this.SetNativeControl(this.InflateNativeControl(Resource.Layout.checkbox_view));
                this.Control.SetChecked(this.Element.Checked);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CheckBox.CheckedProperty.PropertyName)
            {
                this.Control.SetChecked(this.Element.Checked);
            }
        }
    }
}