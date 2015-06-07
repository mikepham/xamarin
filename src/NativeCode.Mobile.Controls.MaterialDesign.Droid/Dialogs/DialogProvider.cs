using NativeCode.Mobile.Controls.MaterialDesign.Droid.Dialogs;

using Xamarin.Forms;

[assembly: Dependency(typeof(DialogProvider))]

namespace NativeCode.Mobile.Controls.MaterialDesign.Droid.Dialogs
{
    using System;

    using NativeCode.Mobile.Controls.MaterialDesign.Dialogs;
    using NativeCode.Mobile.Controls.MaterialDesign.Droid.Extensions;

    public class DialogProvider : IDialogProvider
    {
        private static readonly object DismissableLock = new object();

        private static DialogHandle dismissable;

        public DialogHandle CreateDismissableDialog(string message, string action, Action<DialogHandle> callback)
        {
            return this.CreateDismissableDialog(message, action, callback, false);
        }

        public DialogHandle CreateDismissableDialog(string message, string action, Action<DialogHandle> callback, bool allowMultiple)
        {
            if (allowMultiple)
            {
                return new SnackBarDialog(message, action, callback);
            }

            lock (DismissableLock)
            {
                if (dismissable == null)
                {
                    return dismissable = new SnackBarDialog(message, action, HandleSingletonDismissable);
                }

                return dismissable;
            }
        }

        public DialogHandle CreateNotificationDialog(string message, DialogDuration duration)
        {
            return new SnackBarDialog(message, duration);
        }

        public DialogHandle CreateNotificationDialog(string message, TimeSpan duration)
        {
            return new SnackBarDialog(message, duration);
        }

        public void ShowDismissableDialog(string message, string action, Action<DialogHandle> callback)
        {
            this.CreateDismissableDialog(message, action, callback).Show();
        }

        public void ShowNotificationDialog(string message, DialogDuration duration)
        {
            this.ShowNotificationDialog(message, duration.ToTimeSpan());
        }

        public void ShowNotificationDialog(string message, TimeSpan duration)
        {
            using (var handle = new SnackBarDialog(message, duration))
            {
                handle.Show();
            }
        }

        private static void HandleSingletonDismissable(DialogHandle dialog)
        {
            lock (DismissableLock)
            {
                if (!dialog.IsShowing)
                {
                    dismissable = null;
                }
            }
        }
    }
}