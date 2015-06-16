namespace NativeCode.Mobile.AppCompat.FormsAppCompat.Adapters
{
    using Android.App;

    using JavaObject = Java.Lang.Object;
    using SupportActionBar = Android.Support.V7.App.ActionBar;

    internal class MenuVisibilityListenerAdapter : JavaObject, SupportActionBar.IOnMenuVisibilityListener
    {
        private readonly ActionBar.IOnMenuVisibilityListener listener;

        public MenuVisibilityListenerAdapter(ActionBar.IOnMenuVisibilityListener listener)
        {
            this.listener = listener;
        }

        public void OnMenuVisibilityChanged(bool isVisible)
        {
            this.listener.OnMenuVisibilityChanged(isVisible);
        }
    }
}