﻿using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Markup;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Material")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Material")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

//In order to begin building localizable applications, set 
//<UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file
//inside a <PropertyGroup>.  For example, if you are using US english
//in your source files, set the <UICulture> to en-US.  Then uncomment
//the NeutralResourceLanguage attribute below.  Update the "en-US" in
//the line below to match the UICulture setting in the project file.

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


[assembly: ThemeInfo(
		ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
																		 //(used if a resource is not found in the page, 
																		 // or application resource dictionaries)
		ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
																							//(used if a resource is not found in the page, 
																							// app, or any theme specific resource dictionaries)
)]


// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material")]

[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Animation")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Animation.Templating")]

[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Controls")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Controls.Behaviors")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Controls.Documents")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Controls.Primitives")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Controls.Ripples")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Controls.Shadows")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Controls.Validation")]

[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Converters")]

[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Design")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Design.Descriptors")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Design.Providers")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Design.RelativeFontSize")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Design.Text")]

[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Markup")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Markup.Converters")]
[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Markup.MarkupExtensions")]

[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Media")]

[assembly: XmlnsDefinition(@"http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Material.Static")]