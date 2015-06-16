namespace NativeCode.Mobile.Common.Droid.Extensions
{
    using System;
    using System.Reflection;

    using Xamarin.Forms;

    public static class EntryExtensions
    {
        private const string EntrySendCompleted = "SendCompleted";

        public static void InvokeSendCompleted(this Entry entry)
        {
            var type = entry.GetType();
            var method = type.GetMethod(EntrySendCompleted, BindingFlags.Instance | BindingFlags.NonPublic);

            if (method == null)
            {
                throw new MissingMethodException(type.Name, EntrySendCompleted);
            }

            method.Invoke(entry, new object[0]);
        }
    }
}