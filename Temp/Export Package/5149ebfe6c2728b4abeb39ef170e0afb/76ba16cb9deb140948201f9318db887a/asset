//
//  PVR3DObjectRender.h
//  IPVRSDK
//
//  Created by Peiwen.Liu on 16/7/12.
//  Copyright © 2016年 PivoVR. All rights reserved.
//

#import "PVREye.h"
#import <GLKit/GLKit.h>

@interface PVR3DObjectRender : NSObject

@property (nonatomic, assign, getter=isHidden)  BOOL hidden;
@property (nonatomic, assign, getter=isReady)  BOOL ready;
@property (nonatomic, assign, getter=isDeleted) BOOL deleted;

- (void)setupRender;

- (void)drawEye:(PVREye *)eye headViewMatrix:(GLKMatrix4)headViewMatrix;

- (void)shutdownRender;

@end
