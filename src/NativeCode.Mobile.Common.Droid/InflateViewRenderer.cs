namespace NativeCode.Mobile.Common.Droid
{
    using Android.App;
    using Android.Views;

    using Xamarin.Forms.Platform.Android;

    using View = Xamarin.Forms.View;

    public abstract class InflateViewRenderer<TView, TNativeView> : ViewRenderer<TView, TNativeView>
        where TView : View where TNativeView : Android.Views.View
    {
        protected Activity Activity
        {
            get { return (Activity)this.Context; }
        }

        protected LayoutInflater LayoutInflater
        {
            get { return this.Activity.LayoutInflater; }
        }

        protected TNativeView InflateNativeControl(int id)
        {
            return (TNativeView)this.LayoutInflater.Inflate(id, null, false);
        }
    }
}