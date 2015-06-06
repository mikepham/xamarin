using NativeCode.Mobile.Controls.FloatingActions;
using NativeCode.Mobile.Controls.FloatingActions.Droid;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FloatingButtonMenu), typeof(FloatingButtonMenuRenderer))]

namespace NativeCode.Mobile.Controls.FloatingActions.Droid
{
    using System.ComponentModel;

    using NativeCode.Bindings.FloatingActions;
    using NativeCode.Mobile.Common.Droid.EventListeners;
    using NativeCode.Mobile.Common.Droid.Extensions;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    public class FloatingButtonMenuRenderer : ViewRenderer<FloatingButtonMenu, FloatingActionsMenu>, FloatingActionsMenu.IOnFloatingActionsMenuUpdateListener
    {
        protected FloatingActionButton PrimaryButton { get; private set; }

        public void OnMenuCollapsed()
        {
            if (this.Element.MenuState != FloatingButtonMenuState.Collapsed)
            {
                this.Element.MenuState = FloatingButtonMenuState.Collapsed;
            }
        }

        public void OnMenuExpanded()
        {
            if (this.Element.MenuState != FloatingButtonMenuState.Expanded)
            {
                this.Element.MenuState = FloatingButtonMenuState.Expanded;
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<FloatingButtonMenu> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                this.SetNativeControl(
                    this.Element.Image != null
                        ? new FloatingActionsMenu(this.Context, this.Element.Image.ToBitmapDrawable())
                        : new FloatingActionsMenu(this.Context));

                this.Control.SetAddButtonColorNormal(this.Element.ColorNormal.ToAndroid());
                this.Control.SetAddButtonColorPressed(this.GetColorPressed().ToAndroid());
                this.Control.SetOnClickListener(this);
                this.Control.SetOnFloatingActionsMenuUpdateListener(this);

                // This seems to be required to create a dummy button.
                this.CreatePrimaryButton();

                this.UpdateChildren();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == FloatingButtonMenu.MenuStateProperty.PropertyName)
            {
                this.Element.MenuState = this.Control.IsExpanded ? FloatingButtonMenuState.Expanded : FloatingButtonMenuState.Collapsed;
            }
        }

        private void CreatePrimaryButton()
        {
            this.PrimaryButton = new FloatingActionButton(this.Context);
            this.Control.AddButton(this.PrimaryButton);
        }

        private Color GetColorPressed()
        {
            return this.Element.ColorPressed == Color.Default ? this.Element.ColorNormal : this.Element.ColorPressed;
        }

        private void UpdateChildren()
        {
            foreach (var child in this.Element.Buttons)
            {
                var fab = new FloatingActionButton(this.Context);

                if (child.Image != null)
                {
                    var drawable = child.Image.ToBitmapDrawable();
                    fab.SetIconDrawable(drawable);
                }

                var button = child;
                fab.Clickable = true;
                fab.SetOnClickListener(new OnClickListener(x => this.HandleActionButtonClick(button)));

                this.Control.AddButton(fab);
            }
        }

        private void HandleActionButtonClick(FloatingButton button)
        {
            if (button.Command != null && button.Command.CanExecute(button.CommandParameter))
            {
                button.Command.Execute(button.CommandParameter);
            }

            if (this.Control.IsExpanded)
            {
                this.Control.Collapse();
            }
        }
    }
}