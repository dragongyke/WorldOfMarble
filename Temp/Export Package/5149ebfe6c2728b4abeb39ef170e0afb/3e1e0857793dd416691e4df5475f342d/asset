//
//  PVRShaderHelper.h
//  IPVRSDK
//
//  Created by Peiwen.Liu on 16/6/23.
//  Copyright © 2016年 PivoVR. All rights reserved.
//

#import <GLKit/GLKit.h>

@interface PVRShaderHelper : NSObject

+ (GLint)createProgram;

+ (void)linkProgram:(GLint)program;

+ (GLuint)shaderWithSource:(NSString*)name type:(GLenum)type;

+ (GLuint)shaderWithFileName:(NSString*)name type:(GLenum)type;

+ (void)attachShader:(GLint)program vertexShader:(GLint)vertexShader fragmentShader:(GLint)fragmentShader;

+ (void)detachShader:(GLint)program vertexShader:(GLint)vertexShader fragmentShader:(GLint)fragmentShader;

@end
