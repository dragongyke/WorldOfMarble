//
//  PVRSDKUnityPlugin.h
//  Unity-iPhone
//
//  Created by Nick on 16/7/12.
//
//

#ifndef PVRSDKUnityPlugin_h
#define PVRSDKUnityPlugin_h
extern "C"{
    void PVR_Init_Native ( );
    
    float PVR_FOV_Native();
    
    float PVR_Separation_Native();
    
    void PVR_RenderTexturenSize_Native (int &width,int &height);
    
    void PVR_UpdateRenderParams_Native(float* renderParams,float zNear, float zFar);
    
    int PVR_HeadWearType_Native ();
    
    void PVR_ChangeHeadWearType_Native (int type);
    
    void PVR_SetRenderTextureID_Native (int eye, int texID);
    
    void PVR_StartHeadTrack_Native ();
    
    void PVR_ResetHeadTrack_Native ();
    
    void PVR_StopHeadTrack_Native ();
    
    
    void UnitySetGraphicsDevice(void* device, int deviceType, int eventType);
    
    
    void UnityRenderEvent(int marker);
    

}

#endif /* PVRSDKUnityPlugin_h */
