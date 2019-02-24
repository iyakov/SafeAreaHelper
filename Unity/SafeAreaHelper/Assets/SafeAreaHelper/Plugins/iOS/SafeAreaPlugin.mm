//
//  SafeAreaHelper.m
//  SafeAreaHelper
//
//  Created by Yahor on 2/22/19.
//  Copyright © 2019 Yahor. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface SafeAreaPlugin : NSObject
{

}
@end

@implementation SafeAreaPlugin

static SafeAreaPlugin *sharedInstance;

+(SafeAreaPlugin*) sharedInstance
{
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, 
        ^{
            NSLog(@"================== get instance ===============");
            sharedInstance = [[SafeAreaPlugin alloc] init];
        }
    );
    return sharedInstance;
}

-(id)init
{
    self = [super init];
    if(self)
    {
        [self initHelper];
    }
    return self;
}

-(void)initHelper
{
    NSLog(@"================== plugin ctor ===============");
}

+(void)demoCall
{
    NSLog(@"================== DEMO CALL ===============");
}

@end

extern "C"
{
    void DemoCall1()
    {
        return [[SafeAreaPlugin sharedInstance] demoCall];
    }
    void DemoCall2()
    {
        return [SafeAreaPlugin demoCall];
    }
}