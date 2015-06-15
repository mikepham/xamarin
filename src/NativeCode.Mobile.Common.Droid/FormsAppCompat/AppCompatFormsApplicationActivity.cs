namespace NativeCode.Mobile.Common.Droid.FormsAppCompat
{
    using Android.Content.Res;
    using Android.Graphics;
    using Android.OS;
    using Android.Support.V7.App;
    using Android.Views;

    using Java.Lang;

    using NativeCode.Mobile.Common.Droid.FormsAppCompat.Adapters;

    using Xamarin.Forms.Platform.Android;

    using ActionBar = Android.App.ActionBar;
    using ActionMode = Android.Support.V7.View.ActionMode;

    public class AppCompatFormsApplicationActivity : FormsApplicationActivity, IAppCompatCallback, IAppCompatDelegateProvider
    {
        public const string CompatTheme = "@style/Theme.AppCompat";

        public const string CompatThemeLight = "@style/Theme.AppCompat.Light";

        public const string CompatThemeLightDarkActionBar = "@style/Theme.AppCompat.Light.DarkActionBar";

        private ActionBarAdapter actionBarAdapter;

        private AppCompatDelegate appCompatDelegate;

        private WindowAdapter windowAdapter;

        public override ActionBar ActionBar
        {
            get { return this.actionBarAdapter ?? (this.actionBarAdapter = new ActionBarAdapter(this)); }
        }

        public AppCompatDelegate AppCompatDelegate
        {
            get { return this.appCompatDelegate ?? (this.appCompatDelegate = AppCompatDelegate.Create(this, this)); }
        }

        public override MenuInflater MenuInflater
        {
            get { return this.AppCompatDelegate.MenuInflater; }
        }

        public override Window Window
        {
            get { return this.windowAdapter ?? (this.windowAdapter = new WindowAdapter(base.Window, this)); }
        }

        public override void AddContentView(View view, ViewGroup.LayoutParams @params)
        {
            this.AppCompatDelegate.AddContentView(view, @params);
        }

        public override void InvalidateOptionsMenu()
        {
            base.InvalidateOptionsMenu();
            this.AppCompatDelegate.InvalidateOptionsMenu();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            this.AppCompatDelegate.OnConfigurationChanged(newConfig);
        }

        public virtual void OnSupportActionModeFinished(ActionMode mode)
        {
        }

        public virtual void OnSupportActionModeStarted(ActionMode mode)
        {
        }

        public override void SetContentView(View view)
        {
            this.AppCompatDelegate.SetContentView(view);
        }

        public override void SetContentView(View view, ViewGroup.LayoutParams @params)
        {
            this.AppCompatDelegate.SetContentView(view, @params);
        }

        public override void SetContentView(int layoutResId)
        {
            this.AppCompatDelegate.SetContentView(layoutResId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.actionBarAdapter != null)
                {
                    this.actionBarAdapter.Dispose();
                    this.actionBarAdapter = null;
                }

                if (this.windowAdapter != null)
                {
                    this.windowAdapter.Dispose();
                    this.windowAdapter = null;
                }

                if (this.appCompatDelegate != null)
                {
                    this.appCompatDelegate.Dispose();
                    this.appCompatDelegate = null;
                }
            }

            base.Dispose(disposing);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            this.AppCompatDelegate.InstallViewFactory();
            this.AppCompatDelegate.OnCreate(savedInstanceState);

            base.OnCreate(savedInstanceState);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            this.AppCompatDelegate.OnDestroy();
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            this.AppCompatDelegate.OnPostCreate(savedInstanceState);
        }

        protected override void OnPostResume()
        {
            base.OnPostResume();
            this.AppCompatDelegate.OnPostResume();
        }

        protected override void OnTitleChanged(ICharSequence title, Color color)
        {
            base.OnTitleChanged(title, color);
            this.AppCompatDelegate.SetTitle(title);
        }
    }
}