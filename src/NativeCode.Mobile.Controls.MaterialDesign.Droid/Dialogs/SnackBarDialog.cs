namespace NativeCode.Mobile.Controls.MaterialDesign.Droid.Dialogs
{
    using System;

    using Android.App;

    using NativeCode.Bindings.MaterialDesign.Widgets;
    using NativeCode.Mobile.Common.Droid.EventListeners;
    using NativeCode.Mobile.Controls.MaterialDesign.Dialogs;
    using NativeCode.Mobile.Controls.MaterialDesign.Droid.Extensions;

    using Xamarin.Forms;

    using View = Android.Views.View;

    public class SnackBarDialog : DialogHandle
    {
        private readonly Action<DialogHandle> callback;

        private OnClickListener onClickListener;

        private SnackBar snackBar;

        internal SnackBarDialog(string message, DialogDuration duration)
            : this(message, (TimeSpan)duration.ToTimeSpan())
        {
        }

        internal SnackBarDialog(string message, TimeSpan duration)
        {
            if (duration.TotalMilliseconds < DialogDurationExtensions.DefaultShortDuration)
            {
                throw new DialogProviderException(duration);
            }

            this.snackBar = new SnackBar((Activity)Forms.Context, message) { DismissTimer = (int)duration.TotalMilliseconds, Indeterminate = false };
        }

        internal SnackBarDialog(string message, string action, Action<DialogHandle> callback)
        {
            this.callback = callback;
            this.onClickListener = new OnClickListener(this.HandleClickListener);
            this.snackBar = new SnackBar((Activity)Forms.Context, message, action, this.onClickListener) { Indeterminate = true };
        }

        public override bool IsShowing
        {
            get { return this.snackBar != null && this.snackBar.IsShowing; }
        }

        public override void Dismiss()
        {
            if (this.snackBar.IsShowing)
            {
                this.snackBar.Hide();
            }
        }

        public override void Dismiss(bool dispose)
        {
            this.Dismiss();
            this.Dispose();
        }

        public override void Show()
        {
            if (this.snackBar.IsShowing)
            {
                return;
            }

            this.snackBar.Show();
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing || this.Disposed)
            {
                return;
            }

            base.Dispose(true);

            if (this.snackBar != null)
            {
                this.snackBar.Dispose();
                this.snackBar = null;
            }

            if (this.onClickListener != null)
            {
                this.onClickListener.Dispose();
                this.onClickListener = null;
            }
        }

        private void HandleClickListener(View obj)
        {
            if (this.callback != null)
            {
                this.callback(this);
            }
        }
    }
}