namespace NativeCode.Mobile.Common.Droid.Fonts
{
    using System.Collections.Generic;

    using Android.Graphics;

    public static class TypefaceCache
    {
        private static ITypefaceCache sharedCache;

        public static ITypefaceCache SharedCache
        {
            get { return sharedCache ?? (sharedCache = new DefaultTypefaceCache()); }

            set
            {
                if (sharedCache != null && sharedCache.GetType() == typeof(DefaultTypefaceCache))
                {
                    ((DefaultTypefaceCache)sharedCache).PurgeCache();
                }

                sharedCache = value;
            }
        }

        internal class DefaultTypefaceCache : ITypefaceCache
        {
            private Dictionary<string, Typeface> cache;

            public DefaultTypefaceCache()
            {
                this.cache = new Dictionary<string, Typeface>();
            }

            public Typeface RetrieveTypeface(string key)
            {
                return this.cache.ContainsKey(key) ? this.cache[key] : null;
            }

            public void StoreTypeface(string key, Typeface typeface)
            {
                this.cache[key] = typeface;
            }

            public void RemoveTypeface(string key)
            {
                this.cache.Remove(key);
            }

            public void PurgeCache()
            {
                this.cache = new Dictionary<string, Typeface>();
            }
        }
    }
}