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
            NSLog(@"[FGOL]================== get instance ===============");
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
    NSLog(@"[FGOL]================== plugin ctor ===============");
}

+(void)demoCall
{
    NSLog(@"[FGOL]================== DEMO CALL ===============");
}

@end

extern "C"
{
    void DemoCall1()
    {
        [[SafeAreaPlugin sharedInstance] initHelper];
    }
    void DemoCall2()
    {
        return [SafeAreaPlugin demoCall];
    }
}