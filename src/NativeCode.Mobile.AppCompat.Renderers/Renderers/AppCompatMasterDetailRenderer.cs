using NativeCode.Mobile.AppCompat.Renderers.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(AppCompatMasterDetailRenderer))]

namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    public class AppCompatMasterDetailRenderer : MasterDetailRenderer
    {
        protected override void OnElementChanged(VisualElement oldElement, VisualElement newElement)
        {
            if (oldElement == null && newElement != null)
            {
                this.SetFitsSystemWindows(true);
            }

            base.OnElementChanged(oldElement, newElement);
        }
    }
}