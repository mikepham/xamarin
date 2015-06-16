namespace NativeCode.Mobile.AppCompat.Extensions
{
    using System;

    public class ImageSourceConversionException : Exception
    {
        public ImageSourceConversionException(Exception innerException) : base(CreateExceptionMessage(), innerException)
        {
        }

        private static string CreateExceptionMessage()
        {
            return "Failed to find an appropriate handler to manage the requested image source.";
        }
    }
}