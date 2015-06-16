namespace NativeCode.Mobile.Common.Droid.Renderers.Controls
{
    using System;

    using Android.Content;
    using Android.Support.V7.Widget;
    using Android.Views;

    public class AppCompatEntryEditText : AppCompatEditText
    {
        public AppCompatEntryEditText(Context context) : base(context)
        {
        }

        public event EventHandler OnKeyboardBackPressed;

        public override bool OnKeyPreIme(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back && e.Action == KeyEventActions.Down)
            {
                var handler = this.OnKeyboardBackPressed;

                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }

            return base.OnKeyPreIme(keyCode, e);
        }
    }
}