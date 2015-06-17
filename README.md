# xamarin
Provides various libraries for making Xamarin.Forms development easier. Check out the [wiki](https://github.com/mikepham/xamarin/wiki) for more information.

Release
<a href="http://nativecode.no-ip.org:90/viewType.html?buildTypeId=xamarin_release&guest=1"><img src="http://nativecode.no-ip.org:90/app/rest/builds/buildType:(id:xamarin_release)/statusIcon"/></a>

Continuous
<a href="http://nativecode.no-ip.org:90/viewType.html?buildTypeId=xamarin_continuous&guest=1"><img src="http://nativecode.no-ip.org:90/app/rest/builds/buildType:(id:xamarin_continuous)/statusIcon"/></a>

## [AppCompat](https://www.nuget.org/packages/NativeCode.Mobile.AppCompat/)
Simply install the NuGet package into your Android project.

`Install-Package NativeCode.Mobile.AppCompat`

Once installed, you should replace your *FormsApplicationActivity* derived activities with *AppCompatFormsApplicationActivity*.

For instance:

```csharp
public class MainActivity : AppCompatFormsApplicationActivity
{
  protected override void OnCreate(Bundle savedInstanceState)
  {
    base.OnCreate(savedInstanceState);

    Forms.Init(this, savedInstanceState);

    this.LoadApplication(new App());
  }
}
```

You can then use the normal `Forms.Init` and `LoadApplication` methods to initialize your activities.

## [AppCompat Controls](https://www.nuget.org/packages/NativeCode.Mobile.AppCompat.Controls/)
Simply install the NuGet package into your PCL project that contains your UI.
NOTE: You must install the Renderers package into your Android project.

`Install-Package NativeCode.Mobile.AppCompat.Controls`

### Available controls
- FloatingButton ([FloatingActionButton](https://developer.android.com/reference/android/support/design/widget/FloatingActionButton.html))
- IUserNotifier ([Snackbar](https://developer.android.com/reference/android/support/design/widget/Snackbar.html))

## [AppCompat Renderers](https://www.nuget.org/packages/NativeCode.Mobile.AppCompat.Renderers/)
Simply install the NuGet package into your Android project.

`Install-Package NativeCode.Mobile.AppCompat.Renderers`

Once installed, the renderers will be registered to replace the existing Xamarin.Forms renderers with ones that use the AppCompat controls, giving you Material Design elements.

### Current Renderers
- Button ([AppCompatButton](http://developer.android.com/reference/android/support/v7/widget/AppCompatButton.html))
- Entry ([AppCompatEditText](http://developer.android.com/reference/android/support/v7/widget/AppCompatEditText.html))
- Switch ([SwitchCompat](http://developer.android.com/reference/android/support/v7/widget/SwitchCompat.html))

## Devices Tested

### Phones
- Nexus 5 (emulator)
- Samsung Galaxy S6

### Tablets
- Samsung Tab 7
- Nexus 7

## Screenshots

![screenshot](screenshots/screenshot.png)
![screenshot-masterdetail](screenshots/screenshot-masterdetail.png)
![screenshot-snackbar](screenshots/screenshot-snackbar.png)
![screenshot-moreactions](screenshots/screenshot-moreactions.png)
