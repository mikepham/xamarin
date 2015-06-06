namespace NativeCode.Mobile.Controls.MaterialDesign.Dialogs
{
    using System;

    public class DialogProviderException : Exception
    {
        public DialogProviderException(DialogDuration duration)
            : base(CreateExceptionMessage(duration))
        {
        }

        public DialogProviderException(TimeSpan duration)
            : base(CreateExceptionMessage(duration))
        {
        }

        private static string CreateExceptionMessage(DialogDuration duration)
        {
            return string.Format("Dialog does not support {0} duration.", duration);
        }

        private static string CreateExceptionMessage(TimeSpan duration)
        {
            return string.Format("Dialog does not support a duration of {0}.", duration.TotalMilliseconds);
        }
    }
}