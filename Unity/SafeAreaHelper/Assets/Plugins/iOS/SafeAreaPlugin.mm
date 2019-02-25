#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

extern "C"
{
    bool GetIsInitialized()
    {
        return true;
    }
    
	// Returns device screen scale factor
    float GetScaleFactor() 
    {
        return [[UIScreen mainScreen] scale];
    }

    float GetNotchTop()
    {
        if (@available(iOS 11.0, *)) 
        {
            UIWindow *window = UIApplication.sharedApplication.keyWindow;
            return window.safeAreaInsets.top;
        }
        
        return 0;
    }

    float GetNotchRight()
    {
        if (@available(iOS 11.0, *)) 
        {
            UIWindow *window = UIApplication.sharedApplication.keyWindow;
            return window.safeAreaInsets.right;
        }
        
        return 0;
    }

    float GetNotchBottom()
    {
        if (@available(iOS 11.0, *)) 
        {
            UIWindow *window = UIApplication.sharedApplication.keyWindow;
            return window.safeAreaInsets.bottom;
        }
        
        return 0;
    }

    float GetNotchLeft()
    {
        if (@available(iOS 11.0, *)) 
        {
            UIWindow *window = UIApplication.sharedApplication.keyWindow;
            return window.safeAreaInsets.left;
        }
        
        return 0;
    }
}