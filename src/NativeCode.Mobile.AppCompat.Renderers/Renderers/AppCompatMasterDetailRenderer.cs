using NativeCode.Mobile.AppCompat.Renderers.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(AppCompatMasterDetailRenderer))]

namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using Android.App;
    using Android.Support.V4.Widget;
    using Android.Support.V7.App;

    using NativeCode.Mobile.AppCompat.Extensions;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    using View = Android.Views.View;

    public class AppCompatMasterDetailRenderer : MasterDetailRenderer
    {
        protected override void OnElementChanged(VisualElement oldElement, VisualElement newElement)
        {
            base.OnElementChanged(oldElement, newElement);

            if (oldElement == null && newElement != null)
            {
                this.SetFitsSystemWindows(true);

                var activity = (Activity)this.Context;

                var toggle = new CustomActionBarDrawerToggle(activity, this, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close)
                {
                    DrawerIndicatorEnabled = true
                };

                this.SetDrawerListener(toggle);

                var actionbar = this.Context.GetAppCompatDelegate().SupportActionBar;
                actionbar.SetDisplayHomeAsUpEnabled(true);
                actionbar.SetHomeButtonEnabled(true);

                toggle.SyncState();
            }
        }

        private class CustomActionBarDrawerToggle : ActionBarDrawerToggle
        {
            public CustomActionBarDrawerToggle(Activity activity, DrawerLayout drawerLayout, int openDrawerContentDescRes, int closeDrawerContentDescRes)
                : base(activity, drawerLayout, openDrawerContentDescRes, closeDrawerContentDescRes)
            {
                this.AppCompatDelegate = activity.GetAppCompatDelegate();
            }

            private AppCompatDelegate AppCompatDelegate { get; set; }

            public override void OnDrawerClosed(View drawerView)
            {
                base.OnDrawerClosed(drawerView);
                this.AppCompatDelegate.InvalidateOptionsMenu();
            }

            public override void OnDrawerOpened(View drawerView)
            {
                base.OnDrawerOpened(drawerView);
                this.AppCompatDelegate.InvalidateOptionsMenu();
            }
        }
    }
}