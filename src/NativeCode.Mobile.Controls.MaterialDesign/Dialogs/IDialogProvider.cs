namespace NativeCode.Mobile.Controls.MaterialDesign.Dialogs
{
    using System;

    /// <summary>
    /// Provides access to various native dialogs.
    /// </summary>
    public interface IDialogProvider
    {
        /// <summary>
        /// Creates a dialog that can be dismissed.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="action">The action.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>Returns a <see cref="DialogHandle"/>.</returns>
        DialogHandle CreateDismissableDialog(string message, string action, Action<DialogHandle> callback);

        /// <summary>
        /// Creates a dialog that can be dismissed.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="action">The action.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="allowMultiple">if set to <c>true</c> to allow multiple instances.</param>
        /// <returns>Returns a <see cref="DialogHandle" />.</returns>
        DialogHandle CreateDismissableDialog(string message, string action, Action<DialogHandle> callback, bool allowMultiple);

        /// <summary>
        /// Creates a notification dialog.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="duration">The duration.</param>
        /// <returns>Returns a <see cref="DialogHandle"/>.</returns>
        DialogHandle CreateNotificationDialog(string message, DialogDuration duration);

        /// <summary>
        /// Creates a notification dialog.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="duration">The duration.</param>
        /// <returns>Returns a <see cref="DialogHandle"/>.</returns>
        DialogHandle CreateNotificationDialog(string message, TimeSpan duration);

        /// <summary>
        /// Shows a dialog that can be dismissed.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="action">The action.</param>
        /// <param name="callback">The callback.</param>
        void ShowDismissableDialog(string message, string action, Action<DialogHandle> callback);

        /// <summary>
        /// Shows a notification dialog.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="duration">The duration.</param>
        void ShowNotificationDialog(string message, DialogDuration duration);

        /// <summary>
        /// Shows a notification dialog.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="duration">The duration.</param>
        void ShowNotificationDialog(string message, TimeSpan duration);
    }
}