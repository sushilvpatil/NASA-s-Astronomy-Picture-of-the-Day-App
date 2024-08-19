# NASA-s-Astronomy-Picture-of-the-Day-App
# Build tool Microsfot visual Studio 2022 versin 17.10.6
# steps to run : 
you have to install microsoft visual studio 2022 or later version and .net sdk
Install Required Tools
Visual Studio:
Download and install Visual Studio with Xamarin support from the Visual Studio website. Choose the “Mobile development with .NET” workload during installation.
Android SDK and Emulator (for Android development):
These are usually included with Visual Studio installation. Ensure that you have the latest SDK and tools installed via the Visual Studio Installer.
Xcode (for iOS development, macOS only):

Install Xcode from the Mac App Store. Ensure you have the latest version compatible with your version of Visual Studio for Mac.
2. Create a New Xamarin.Forms Project
Open Visual Studio:
open the clone project in visual studio

Solution Explorer:

The solution will include three main projects:
YourAppName (shared code in Xamarin.Forms)
YourAppName.iOS (iOS-specific code)
YourAppName.Droid (Android-specific code)
Shared Code:

The shared code in the .NET Standard project is where you will write your Xamarin.Forms application code (UI, business logic).
4. Build and Run the Application
Set Startup Project:

Right-click on the YourAppName.iOS or YourAppName.Droid project in Solution Explorer and select Set as Startup Project.
Build Solution:

Go to Build > Build Solution to compile the code and ensure there are no errors.
Run the Application:

For Android:

Select an Android Emulator or a connected Android device from the target device dropdown in Visual Studio.
Click the green Run button (or press F5) to deploy and run the app on the selected Android device.
For iOS:

You must have a Mac connected or set up for remote build.
Select an iOS Simulator or a connected iOS device from the target device dropdown.
Click the green Run button (or press F5) to deploy and run the app on the selected iOS device.

# how long time has spend 
 approx 4 hour

# point to remember 
there is MVVM application development Pattern is Used.
