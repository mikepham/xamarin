namespace NativeCode.Mobile.Common.Droid
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;

    using Android.App;
    using Android.Views;

    using NativeCode.Mobile.Common.Droid.EventListeners;

    using Xamarin.Forms.Platform.Android;

    using View = Xamarin.Forms.View;

    /// <summary>
    /// Provides a renderer for controls that should be inflated from a resource.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TNativeView">The type of the native view.</typeparam>
    public abstract class InflateViewRenderer<TView, TNativeView> : ViewRenderer<TView, TNativeView>
        where TView : View where TNativeView : Android.Views.View
    {
        private readonly List<IDisposable> disposables = new List<IDisposable>();

        /// <summary>
        /// Gets the <see cref="Activity"/> instance.
        /// </summary>
        protected Activity Activity
        {
            get { return (Activity)this.Context; }
        }

        /// <summary>
        /// Gets the <see cref="LayoutInflater"/> instance.
        /// </summary>
        protected LayoutInflater LayoutInflater
        {
            get { return this.Activity.LayoutInflater; }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var disposable in this.disposables)
                {
                    disposable.Dispose();
                }

                this.disposables.Clear();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Handles the click state of a view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="command">The command.</param>
        /// <param name="parameter">The parameter.</param>
        protected virtual void HandleClickListener(TNativeView view, ICommand command, object parameter)
        {
            if (command != null && command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }
        }

        /// <summary>
        /// Inflates the native control from a resource.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns a <see cref="TNativeView"/> instance.</returns>
        protected TNativeView InflateNativeControl(int id)
        {
            return (TNativeView)this.LayoutInflater.Inflate(id, null, false);
        }

        /// <summary>
        /// Registers a <see cref="IDisposable" /> for later disposal.
        /// </summary>
        /// <param name="disposable">The disposable.</param>
        protected void RegisterDisposable(IDisposable disposable)
        {
            this.disposables.Add(disposable);
        }

        /// <summary>
        /// Setup click handle listener for the provided view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="command">The command.</param>
        /// <param name="parameter">The parameter.</param>
        protected void SetupClickable(TNativeView view, ICommand command, object parameter)
        {
            var listener = new OnClickListener(v => this.HandleClickListener(this.Control, command, parameter));
            this.RegisterDisposable(listener);

            view.Clickable = true;
            view.SetOnClickListener(listener);
        }
    }
}