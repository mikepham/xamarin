namespace NativeCode.Mobile.AppCompat.Fonts
{
    using Android.Graphics;

    public interface ITypefaceCache
    {
        void RemoveTypeface(string key);

        Typeface RetrieveTypeface(string key);

        void StoreTypeface(string key, Typeface typeface);
    }
}