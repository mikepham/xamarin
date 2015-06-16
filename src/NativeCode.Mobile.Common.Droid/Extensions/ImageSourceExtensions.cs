namespace NativeCode.Mobile.AppCompat.Extensions
{
    using System;
    using System.Threading.Tasks;

    using Android.Graphics;
    using Android.Graphics.Drawables;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    public static class ImageSourceExtensions
    {
        public static Bitmap Resize(this ImageSource source, int height, int width, bool filter = true)
        {
            return source.ResizeAsync(height, width, filter).GetAwaiter().GetResult();
        }

        public static Bitmap Resize(this ImageSource source, double factor, bool filter = true)
        {
            return source.ResizeAsync(factor, filter).GetAwaiter().GetResult();
        }

        public static async Task<Bitmap> ResizeAsync(this ImageSource source, int height, int width, bool filter = true)
        {
            using (var bitmap = await source.ToBitmapAsync().ConfigureAwait(false))
            {
                return Bitmap.CreateScaledBitmap(bitmap, width, height, filter);
            }
        }

        public static async Task<Bitmap> ResizeAsync(this ImageSource source, double factor, bool filter = true)
        {
            using (var bitmap = await source.ToBitmapAsync().ConfigureAwait(false))
            {
                var height = (int)Math.Abs(bitmap.Height * factor);
                var width = (int)Math.Abs(bitmap.Width * factor);

                return Bitmap.CreateScaledBitmap(bitmap, width, height, filter);
            }
        }

        public static Bitmap ResizeToFit(this ImageSource source, int height, int width, double factor = 1.0, bool filter = true)
        {
            return source.ResizeToFitAsync(height, width, factor, filter).GetAwaiter().GetResult();
        }

        public static async Task<Bitmap> ResizeToFitAsync(this ImageSource source, int height, int width, double factor = 1.0, bool filter = true)
        {
            var bitmap = await source.ToBitmapAsync().ConfigureAwait(false);
            {
                var factorY = (bitmap.Height > height ? height / (double)bitmap.Height : (double)bitmap.Height / height) + factor;
                var factorX = (bitmap.Width > width ? width / (double)bitmap.Width : (double)bitmap.Width / width) + factor;
                var h = (int)(bitmap.Height * factorY);
                var w = (int)(bitmap.Width * factorX);

                return Bitmap.CreateScaledBitmap(bitmap, w, h, filter);
            }
        }

        public static Task<Bitmap> ToBitmapAsync(this ImageSource source)
        {
            try
            {
                var handler = CreateImageSourceHandler(source);

                return handler.LoadImageAsync(source, Forms.Context);
            }
            catch (Exception ex)
            {
                throw new ImageSourceConversionException(ex);
            }
        }

        public static Bitmap ToBitmap(this ImageSource source)
        {
            return source.ToBitmapAsync().GetAwaiter().GetResult();
        }

        public static async Task<BitmapDrawable> ToBitmapDrawableAsync(this ImageSource source)
        {
            var bitmap = await source.ToBitmapAsync().ConfigureAwait(false);

            return new BitmapDrawable(bitmap);
        }

        public static BitmapDrawable ToBitmapDrawable(this ImageSource source)
        {
            return source.ToBitmapDrawableAsync().GetAwaiter().GetResult();
        }

        private static IImageSourceHandler CreateImageSourceHandler(ImageSource source)
        {
            if (source is StreamImageSource)
            {
                return new StreamImagesourceHandler();
            }

            if (source is UriImageSource)
            {
                return new ImageLoaderSourceHandler();
            }

            return new FileImageSourceHandler();
        }
    }
}