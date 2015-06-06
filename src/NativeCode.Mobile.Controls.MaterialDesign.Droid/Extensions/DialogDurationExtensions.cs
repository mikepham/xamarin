namespace NativeCode.Mobile.Controls.MaterialDesign.Droid.Extensions
{
    using System;

    using NativeCode.Mobile.Controls.MaterialDesign.Dialogs;

    public static class DialogDurationExtensions
    {
        public const int DefaultLongDuration = 5000;

        public const int DefaultShortDuration = 3000;

        /// <summary>
        /// Converts a <see cref="DialogDuration"/> to an <see cref="int"/>.
        /// </summary>
        /// <param name="duration">The duration.</param>
        /// <returns>Returns a <see cref="int"/>.</returns>
        public static int ToInt(this DialogDuration duration)
        {
            switch (duration)
            {
                case DialogDuration.Long:
                    return 5000;

                case DialogDuration.Short:
                    return 3000;

                default:
                    return 0;
            }
        }

        /// <summary>
        /// Converts a <see cref="DialogDuration"/> to a <see cref="long"/>.
        /// </summary>
        /// <param name="duration">The duration.</param>
        /// <returns>Returns a <see cref="long"/>.</returns>
        public static long ToLong(this DialogDuration duration)
        {
            return duration.ToInt();
        }

        /// <summary>
        /// Converts a <see cref="DialogDuration"/> to a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="duration">The duration.</param>
        /// <returns>Returns a <see cref="TimeSpan"/>.</returns>
        public static TimeSpan ToTimeSpan(this DialogDuration duration)
        {
            return TimeSpan.FromMilliseconds(duration.ToLong());
        }
    }
}