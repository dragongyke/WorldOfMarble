//
//  PVREye.h
//  IPVRSDK
//
//  Created by Peiwen.Liu on 16/6/27.
//  Copyright © 2016年 PivoVR. All rights reserved.
//

#import "PVREnum.h"
#import <GLKit/GLKit.h>

@interface PVREye : NSObject

@property (nonatomic, assign) float fov;

@property (nonatomic, assign) GLuint texture;

@property (nonatomic, assign) PVREyeType eyeType;

@property (nonatomic, assign) GLKMatrix4 translation;

- (GLKMatrix4)perspectiveWithNear:(float)near andFar:(float)far;

@end
