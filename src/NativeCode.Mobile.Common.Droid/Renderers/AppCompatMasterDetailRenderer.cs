namespace NativeCode.Mobile.Common.Droid.Renderers
{
    using Android;
    using Android.App;
    using Android.Support.V7.App;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    public class AppCompatMasterDetailRenderer : MasterDetailRenderer
    {
        protected override void OnElementChanged(VisualElement oldElement, VisualElement newElement)
        {
            base.OnElementChanged(oldElement, newElement);

            if (oldElement == null && newElement != null)
            {
                var activity = (Activity)this.Context;
                var toggle = new ActionBarDrawerToggle(activity, this, Resource.String.Ok, Resource.String.Ok);
                this.SetDrawerListener(toggle);
            }
        }
    }
}