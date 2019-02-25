#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

extern "C"
{
    //
    // Shows if the plugin shows the valid data
    //
    bool GetIsInitialized()
    {
        //Note! The brand new iPadPro2018 may not initialize intents at the 
        // startup. I'm not sure how to check this behaviour yet. It might
        // be just a bad luck on my previous project.
        return true;
    }
    
    //
    // Returns device screen scale factor
    //
    float GetScaleFactor() 
    {
        return [[UIScreen mainScreen] scale];
    }
    
    // Marshaling structure
    typedef struct rect {
        float top;
        float right;
        float bottom;
        float left;
    } rect;
    
    //
    // Returns the device's notch insets
    //
    rect GetNotch()
    {
        rect result;
    
        if (@available(iOS 11.0, *)) 
        {
            UIWindow *window = UIApplication.sharedApplication.keyWindow;
            result.top = window.safeAreaInsets.top;
            result.bottom = window.safeAreaInsets.bottom;
            result.right = window.safeAreaInsets.right;
            result.left = window.safeAreaInsets.left;
        }
        
        return result;
    }
    
}
