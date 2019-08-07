<div align="center">

<h1>Salem</h1>
<h4>A highly configurable logger written entirely in C# and .Net Standard 2.0</h4>
<h5>(more about the supported platforms below)</h5>

[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/built-by-developers.svg)](https://forthebadge.com)

</div>

<div align="center">

![Nuget](https://img.shields.io/nuget/v/Salem?style=for-the-badge)
![Travis (.org)](https://img.shields.io/travis/KernelErr0r/Salem?style=for-the-badge)

</div>

<div align="center">

![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/KernelErr0r/Salem/master?style=for-the-badge)

</div>

## Supported platforms:

* .Net Core 2.0 and above
* .Net Framework 4.6.1 and above
* Mono 5.4 and above
* Xamarin.iOS 10.14 and above
* Xamarin.Mac 3.8 and above
* Xamarin.Android 8.0 and above
* UWP 10.0.16299 and above
* Unity 2018.1 and above

## Usage

### Default settings

```csharp
using Salem;

var logger = new Logger("");

//The first parameter - log level (for example: info, warning or error) (Not case-sensitive)
//The second parameter - our message (string or any object)
//The third parameter - scope (no need to specify if the same as scope in the constructor or empty)
logger.Log("Info", "Files have been loaded successfully");
logger.Log("Warning", "Aliens have arrived");
logger.Log("Error", "World is going to be destroyed by the aliens");
```

![Screenshot](Assets/screenshot1.png)