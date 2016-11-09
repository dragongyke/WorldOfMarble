//
//  PVRSDKUnityPlugin.m
//  Unity-iPhone
//
//  Created by Nick on 16/7/12.
//
//

#include "MyRenderPlugin.h"
#import "PVRSDKUnityPlugin.h"
#import <OpenGLES/ES2/glext.h>
#import <GLKit/GLKit.h>
#import <PicoVRSDK/PicoVRSDK.h>

#define GlEventID  7001

void PVR_Init_Native ( ){
    [PVRManager shared].lensType = PVR_LENS_PICOVR_I;
    [[PVRManager shared] setupRender];
    [[PVRManager shared] startTracking:[[UIApplication sharedApplication] statusBarOrientation]];
}

float PVR_FOV_Native(){
    return [[PVRManager shared] eyeFov];
}

float PVR_Separation_Native(){
    return [[PVRManager shared] sepration];
}

void PVR_RenderTexturenSize_Native (int &width, int &height){
    width = 1024;
    height = 1024;
}

void PVR_UpdateRenderParams_Native(float* renderParams,float zNear, float zFar){
    GLKMatrix4 matrix = [[PVRManager shared] lastHeadView];
    
    for(int i = 0;i <16; i++){
        renderParams[i] = matrix.m[i];
    }
}

int PVR_HeadWearType_Native (){
    return [PVRManager shared].lensType;
}

void PVR_ChangeHeadWearType_Native (int type){
    [PVRManager shared].lensType = (PVRLensType)type;
}

void PVR_SetRenderTextureID_Native (int eye, int texID){
    PVREye *oeye = [[PVRManager shared] eyeWithType:(PVREyeType)eye];
    oeye.texture = texID;
}

void PVR_StartHeadTrack_Native (){
    [[PVRManager shared] startTracking:[[UIApplication sharedApplication] statusBarOrientation]];
}

void PVR_ResetHeadTrack_Native (){
    
}

void PVR_StopHeadTrack_Native (){
    [[PVRManager shared] stopTracking];
}



void UnitySetGraphicsDevice(void* device, int deviceType, int eventType)
{
}



void UnityRenderEvent(int marker)
{
    NSLog( @"UnityRenderEvent %d", marker );
    if(marker == GlEventID){
        
        [[PVRManager shared] renderBase:GLKMatrix4Identity];
        [[PVRManager shared] updateRender];
    }else{
        
    }
}
