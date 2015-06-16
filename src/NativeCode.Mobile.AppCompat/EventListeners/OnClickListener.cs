namespace NativeCode.Mobile.AppCompat.EventListeners
{
    using System;

    using Android.Views;

    public class OnClickListener : EventListener, View.IOnClickListener
    {
        private readonly Action<View> callback;

        public OnClickListener(Action<View> callback)
        {
            this.callback = callback;
        }

        public void OnClick(View v)
        {
            this.callback(v);
        }
    }
}