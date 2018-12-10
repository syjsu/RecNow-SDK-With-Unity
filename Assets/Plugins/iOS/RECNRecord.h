//
//  RECNRecord.h
//  RecNow
//
//  Created by Lightning on 15/10/13.
//  Copyright © 2015年 AiPai. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_CLASS_AVAILABLE_IOS(9_0)
@interface RECNRecord : NSObject
/**
 *  初始化录屏单例
 *
 *  @return 返回单例
 */

+ (instancetype)shareRecord;

/**
 *  该方法是判断设备是否支持RecNow,
 *  SDK支持的芯片至少为A7,对应设备最低为iPhone5S
 *  录屏功能支持的系统为ios9
 *  调用其它接口前，调用该接口进行判断
 *  @return 返回是否支持该设备
 */
+ (BOOL)isSupport;

/*
 *  初始化上传设置(必须)
 *  @attention 请保证在主线程中调用此函数
 *  @param AppKey 爱拍RecNowSDK接入ID
 */

+ (void) resetAppKey:(NSString *)AppKey;

/**
 *  是否创建浮标UI
 *
 *  @param isShow YES为创建，NO为不创建
 */
+ (void)showAssistiveControl:(BOOL)isShow;


/**
 *  该方法需要在showAssistiveControl:YES
 *  AssistiveControl已经创建的情况下才生效。
 *
 *  @param isHidden YES为隐藏
 */
+ (void)setupAssistiveControlHidden:(BOOL)isHidden;



/**
 *  初始化分享设置
 *  @param QQKey  QQ第三方分享KEY(集成分享必须)
 *  @param WeiXinKey 微信第三方分享KEY(集成分享必须)
 *  @param title  第三方分享视频标题（游戏视频标题）
 */
+ (void) resetShareQQKey:(NSString *)QQKey
           WeiXinKey:(NSString *)WeiXinKey
           shareTitle:(NSString *)title;

/**
 * @return 返回作品展示页面
 */
+ (UIViewController *) getWorkerPageViewController;

/**
 * @return 分享完成app回调(集成分享必须，application:openURL:options:中调用)
 */
+ (BOOL) handleOpenURL:(NSURL *)url;


/**
 *  开始录屏，第一次开始录屏，会弹出授权提示框，让用户进行选择
 *
 *  @param microphoneEnabled 是否录制麦克风声音
 *  @param handler           录屏开始回调，error不为nil则开始录屏失败
 */
- (void)startRecordingWithMicrophoneEnabled:(BOOL)microphoneEnabled handler:(void(^)(NSError *  error))handler;


/**
 *  停止录屏
 *
 *  @param handler 停止录屏回调，error不为nil则停止录屏失败
 */
- (void)stopRecordingWithHandler:(void(^)( NSError * error))handler;
/**
 *  丢弃录制视频
 *
 *  @param handler 丢弃录屏回调
 */
- (void)discardRecordingWithHandler:(void(^)(void))handler;

/**
 *  显示recnow自带的视频管理界面
 */
- (void)showWorksView;

/**
 *  如果app只支持竖屏 需要在这里填入支持的方向
 *
 *  @param interfaceOrientation app支持的方向
 */
- (void)appSupportOrientation:(UIInterfaceOrientationMask)interfaceOrientation;


/**
 *  是否正在录屏
 */
@property (nonatomic, readonly) BOOL recording;
/**
 *  是否录制声音
 */
@property (nonatomic, readonly, getter=isMicrophoneEnabled) BOOL microphoneEnabled;
/**
 *  当前设备是否可用
 */
@property (nonatomic, readonly, getter=isAvailable) BOOL available;

/**
 *  该属性是针对工具条模式下，工具条的状态（yes为隐藏状态）
 */
@property (nonatomic, readonly) BOOL isAssistiveControlHidden;


@property (nonatomic, readonly) UIInterfaceOrientationMask supportOrientation;

@end

// Notification 弹出作品页和视频编辑界面的通知
extern NSString *const RNVideosPageViewWillAppearNotification;
extern NSString *const RNVideosPageViewDidAppearNotification;

extern NSString *const RNVideosPageViewWillDisappearNotification;
extern NSString *const RNVideosPageViewDidDisappearNotification;

extern NSString *const RNVideoEditingViewWillAppearNotification;
extern NSString *const RNVideoEditingViewDidAppearNotification;

extern NSString *const RNVideoEditingViewWillDisappearNotification;
extern NSString *const RNVideoEditingViewDidDisappearNotification;

