#import <UIKit/UIKit.h>
#import <OpenGLES/ES2/glext.h>
#import "UnityAppController.h"
#import "MyRenderPlugin.h"
#import "PVRSDKUnityPlugin.h"


@interface MyAppController : UnityAppController
{
}
- (void)shouldAttachRenderDelegate;
@end

@implementation MyAppController

- (void)shouldAttachRenderDelegate;
{
    //self.renderDelegate = [[MyRenderPlugin alloc] init];
	UnityRegisterRenderingPlugin(&UnitySetGraphicsDevice, &UnityRenderEvent);
}

@end


IMPL_APP_CONTROLLER_SUBCLASS(MyAppController)

