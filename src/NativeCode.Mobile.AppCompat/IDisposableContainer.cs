namespace NativeCode.Mobile.AppCompat
{
    using System;

    /// <summary>
    /// Provides a contract to manage <see cref="IDisposable" /> instances.
    /// </summary>
    public interface IDisposableContainer : IDisposable
    {
        /// <summary>
        /// Registers a <see cref="IDisposable" /> for later disposal.
        /// </summary>
        /// <param name="disposable">The disposable.</param>
        void RegisterDisposable(IDisposable disposable);

        /// <summary>
        /// Registers a <see cref="IDisposable" /> for later disposal.
        /// </summary>
        /// <typeparam name="T">The type that implements <see cref="IDisposable" />.</typeparam>
        /// <param name="disposable">The disposable.</param>
        /// <returns>Returns the instance passed in.</returns>
        T RegisterDisposable<T>(T disposable) where T : IDisposable;
    }
}