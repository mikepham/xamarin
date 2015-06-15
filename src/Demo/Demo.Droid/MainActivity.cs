namespace Demo.Droid
{
    using Android.App;
    using Android.OS;

    using NativeCode.Mobile.Common.Droid.FormsAppCompat;

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
        }
    }
}