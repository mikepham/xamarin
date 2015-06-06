namespace NativeCode.Mobile.Controls.MaterialDesign.Dialogs
{
    using System;

    /// <summary>
    /// Provides access to a dialog.
    /// </summary>
    public abstract class DialogHandle : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether this instance is showing.
        /// </summary>
        public abstract bool IsShowing { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="DialogHandle"/> is disposed.
        /// </summary>
        protected bool Disposed { get; private set; }

        /// <summary>
        /// Dismisses this instance.
        /// </summary>
        public abstract void Dismiss();

        /// <summary>
        /// Dismisses this instance.
        /// </summary>
        /// <param name="dispose">if set to <c>true</c> dialog will be disposed.</param>
        public abstract void Dismiss(bool dispose);

        /// <summary>
        /// Shows this instance.
        /// </summary>
        public abstract void Show();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !this.Disposed)
            {
                this.Disposed = true;
            }
        }
    }
}