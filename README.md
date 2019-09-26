<div align="center">

<h1>Salem</h1>
<h4>A highly configurable logger written entirely in C# and .Net Standard 2.0</h4>
<h5>(more about the supported platforms below)</h5>

[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)

</div>

<div align="center">

![Nuget](https://img.shields.io/nuget/v/Salem?style=for-the-badge&logo=nuget)

</div>

## Status:

| Branch | Build | Tests | Code Quality |
|--------|-------|-------|--------------|
| Master | ![Travis (.org) master](https://img.shields.io/travis/KernelErr0r/Salem/master?style=for-the-badge&logo=travis) | ![Azure DevOps tests](https://img.shields.io/azure-devops/tests/villainkernelerror/salem/1?style=for-the-badge&logo=azuredevops) | ![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/KernelErr0r/Salem/master?style=for-the-badge) |
|  Dev   | ![Travis (.org) dev](https://img.shields.io/travis/KernelErr0r/Salem/dev?style=for-the-badge&logo=travis)       | | ![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/KernelErr0r/Salem/dev?style=for-the-badge)    |

## Supported platforms:

* .Net Core 2.0 and above
* .Net Framework 4.6.1 and above
* Mono 5.4 and above
* Xamarin.iOS 10.14 and above
* Xamarin.Mac 3.8 and above
* Xamarin.Android 8.0 and above
* UWP 10.0.16299 and above
* <img width="24" height="24" align="center" src="http://simpleicons.org/icons/unity.svg"> 2018.1 and above

## Usage

### The simplest usage

```csharp
using Salem;

var logger = new Logger();

//The first parameter - log level (for example: info, warning or error) (Not case-sensitive)
//The second parameter - our message (string or any object)
//The third parameter - scope (no need to specify if the same as scope in the constructor or empty)
logger.Log("Info", "Files have been loaded successfully");
logger.Log("Warning", "Aliens have arrived");
logger.Log("Error", "World is going to be destroyed by the aliens");
```

![Screenshot](Assets/screenshot1.png)

### Formatters

#### Lists and dictionaries

<details>

<summary>Without a scope</summary>

```csharp
using Salem;
using System.Collections.Generic;

var logger = new Logger();
var list = new List<string>() { "one", "two", "three" };

logger.Log("info", list);
```

![Screenshot](Assets/screenshot2.png)

```csharp
using Salem;
using System.Collections.Generic;

var logger = new Logger();
var dict = new Dictionary<string, string>() { { "1", "first" }, { "2", "second" }, { "3", "third" } };

logger.Log("info", dict);
```

![Screenshot](Assets/screenshot4.png)

</details>

<details>

<summary>With a scope</summary>

```csharp
using Salem;
using System.Collections.Generic;

var logger = new Logger("Scope");
var list = new List<string>() { "one", "two", "three" };

logger.Log("info", list);
```

![Screenshot](Assets/screenshot3.png)

```csharp
using Salem;
using System.Collections.Generic;

var logger = new Logger("Scope");
var dict = new Dictionary<string, string>() { { "1", "first" }, { "2", "second" }, { "3", "third" } };

logger.Log("info", dict);
```

![Screenshot](Assets/screenshot5.png)
	
</details>
