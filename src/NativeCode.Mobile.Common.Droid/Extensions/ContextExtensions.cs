namespace NativeCode.Mobile.Common.Droid.Extensions
{
    using System;

    using Android.Content;
    using Android.Support.V7.App;

    using NativeCode.Mobile.Common.Droid.FormsAppCompat;

    public static class ContextExtensions
    {
        public static AppCompatDelegate GetAppCompatDelegate(this Context context)
        {
            return context.GetAppCompatDelegateProvider().AppCompatDelegate;
        }

        public static IAppCompatDelegateProvider GetAppCompatDelegateProvider(this Context context)
        {
            var provider = context as IAppCompatDelegateProvider;

            if (provider == null)
            {
                throw new InvalidOperationException("Could cast IAppCompatDelegateProvider interface from the provided context.");
            }

            return provider;
        }

        public static Context GetAppCompatThemedContext(this Context context)
        {
            return context.GetAppCompatDelegate().SupportActionBar.ThemedContext;
        }
    }
}