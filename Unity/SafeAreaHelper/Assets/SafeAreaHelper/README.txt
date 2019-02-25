//////////////////////////////////////////////////////////////
// Author:      YAHOR KLEBAN
// Created:     February 2019
// Name:        Safe area Helper
// Description: Allows to get info about device's intents
//////////////////////////////////////////////////////////////
//
//////////////////////////////////////////////////////////////
// How to build a Unity package for your project
//////////////////////////////////////////////////////////////
//
// Press 'Package Export Automation/Export project as Package' 
// to create a package with the given plugins.
//
// Output: Builds/SafeAreaHelper.xxx.unitypackage
//
/////////////////////////////////////////////////////////////
// How to use
/////////////////////////////////////////////////////////////
//
// Before you start, load SafeAreaHelper.xxx.unitypackage
// into your project.
//
// First, create a wrapper by calling:
//   new SafeAreaHelperFactory().Create()
//
// Then, use 'NotchSizes' property to access insets.
//
// You are all set!
//
// Please note, on some devices data may not be available
// right after the app is started. Please refer to propery
// 'IsInitialized' in this case.
//
// Please note, in such way this plugin is not really usable
// as far as it returns measurments in device's "points". But
// Unity expects values in "units". The corresponding TODO
// was placed in code with approx. implementation.
//
/////////////////////////////////////////////////////////////