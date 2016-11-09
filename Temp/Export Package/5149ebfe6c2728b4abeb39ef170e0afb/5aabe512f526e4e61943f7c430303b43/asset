//
//  PVRManager.h
//  IPVRSDK
//
//  Created by Peiwen.Liu on 16/6/22.
//  Copyright © 2016年 PivoVR. All rights reserved.
//

#import "PVREye.h"
#import "PVREnum.h"
#import "PVRSingleton.h"
#import "PVRGLNativeRender.h"
#import <GLKit/GLKit.h>


@interface PVRManager : NSObject

singleton_interface(PVRManager)

#pragma mark Base SDK
@property (nonatomic, assign) PVRLensType lensType;

@property (nonatomic, assign, getter=isNative) BOOL native;

@property (nonatomic, assign, getter = isChromaticAberration) BOOL chromaticAberration;

@property (nonatomic, strong) PVRGLNativeRender *nativeRender;

- (void)setupRender;

- (void)updateRender;

- (void)renderNative:(GLKMatrix4)headview;

- (void)renderBase:(GLKMatrix4)headview;

- (void)shutdownRender;

- (PVREye *)eyeWithType:(PVREyeType)eyetype;

- (float)eyeFov;

- (float)sepration;

- (void)startTracking:(UIInterfaceOrientation)orientation;

- (void)resetTracking;

- (void)stopTracking;

- (void)updateDeviceOrientation:(UIInterfaceOrientation)orientation;

- (GLKMatrix4)lastHeadView;
@end
