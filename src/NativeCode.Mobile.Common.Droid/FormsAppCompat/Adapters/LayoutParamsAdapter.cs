namespace NativeCode.Mobile.Common.Droid.FormsAppCompat.Adapters
{
    using Android.App;

    using SupportActionBar = Android.Support.V7.App.ActionBar;

    internal class LayoutParamsAdapter : SupportActionBar.LayoutParams
    {
        public LayoutParamsAdapter(ActionBar.LayoutParams layoutParams) : base(layoutParams.Width, layoutParams.Height, (int)layoutParams.Gravity)
        {
        }
    }
}