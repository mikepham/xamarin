namespace Demo.Droid
{
    using Android.App;
    using Android.OS;
    using Android.Support.V4.Widget;
    using Android.Support.V7.Internal.Widget;
    using Android.Views;

    using NativeCode.Mobile.AppCompat.FormsAppCompat;

    using Xamarin.Forms;

    [Activity(MainLauncher = true, Theme = AppTheme)]
    public class MainActivity : AppCompatFormsApplicationActivity
    {
        private const string AppTheme = "@style/AppTheme";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Forms.Init(this, savedInstanceState);

            this.LoadApplication(new App());

            var container = this.FindViewById<ActionBarOverlayLayout>(Resource.Id.decor_content_parent);

            if (container != null)
            {
                var group1 = (ViewGroup)container.GetChildAt(0);
                var group2 = (ViewGroup)group1.GetChildAt(0);
                var group3 = (ViewGroup)group2.GetChildAt(0);
                var group4 = (DrawerLayout)group3.GetChildAt(0);
                group4.SetFitsSystemWindows(true);
            }
        }
    }
}