

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class Recnow : MonoBehaviour {
	[DllImport("__Internal")]
	private static extern bool RNisSupported();
	[DllImport("__Internal")]
	private static extern void RNinitRecNowRecord();
	[DllImport("__Internal")]
	private static extern void RNstartRecording(bool enableMicrophone);
	[DllImport("__Internal")]
	private static extern void RNstopRecording();
	[DllImport("__Internal")]
	private static extern void RNdiscardRecording();
	[DllImport("__Internal")]
	private static extern void RNshowWorksView();
	[DllImport("__Internal")]
	private static extern bool RNisRecording();
	[DllImport("__Internal")]
	private static extern bool RNisMicrophoned();

	[DllImport("__Internal")]
	private static extern void RNsetAppKey(string appId);

	[DllImport("__Internal")]
	private static extern void RNsetShareKeys(string QQKey,string WeiXinKey, string shareText);

	private static Recnow RecnowInstance = null;


	//开始录屏的回调，返回错误信息
	public delegate void startRecordingDelegate(string error);
	
	public static event startRecordingDelegate didStart;

	//停止录屏的回调，返回错误信息
	public delegate void stopRecordingDelegate(string error);
	
	public static event stopRecordingDelegate didStop;
	 
	//丢弃视频的回调
	public delegate void discardRecordingDelegate(string str);
	
	public static event discardRecordingDelegate didDiscard;

	//工具条模式  回调的方法 
	public delegate void VideosPageViewShowingDelegate();
	public static event VideosPageViewShowingDelegate videosPageViewShowing;

	public delegate void VideosPageViewDisappearDelegate();
	public static event VideosPageViewDisappearDelegate videosPageViewDisappear;

	public delegate void VideoEditingPageShowingDelegate();
	public static event VideoEditingPageShowingDelegate videoEditingPageShowing;

	public delegate void VideoEditingPageDisappearDelegate();
	public static event VideoEditingPageDisappearDelegate videoEditingPageDisappear;


	/**
	 *  该方法是判断设备是否支持RecNow,
	 *  SDK支持的芯片至少为A7,对应设备最低为iPhone5S
	 *  录屏功能支持的系统为ios9
	 *  调用其它接口前，必须调用该接口进行判断
	 *  @return 返回是否支持该设备
	 */ 
	public static bool isSupported(){
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
						return RNisSupported ();
				}
		return false;
	}

	/**
	 *  初始化录屏单例
	 *
	 */
	public static void Initialize(){
		if (Recnow.isSupported()) {
			if (RecnowInstance == null) {
				GameObject RecnowGameObject = new GameObject ("Recnow");
				if (RecnowGameObject != null) {
					RecnowInstance = RecnowGameObject.AddComponent<Recnow> ();
					DontDestroyOnLoad (RecnowGameObject);
				}

			}
		}
	}



	/**
	 *  开始录屏，第一次开始录屏，会弹出授权提示框，让用户进行选择
	 *
	 *  @param enableMicrophone 是否录制麦克风声音
	 */
	public static  void startRecording(bool enableMicrophone){
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			RNstartRecording (enableMicrophone);
		}

	}

	/**
	 *  停止录屏
	 *
	 */
	public static  void stopRecording(){
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			RNstopRecording ();
		}
	}

	/**
	 *  丢弃录制视频
	 *
	 */
	public static  void discardRecording(){
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
		 	RNdiscardRecording();
		}
	}

	/**
	 *  显示recnow自带的视频管理界面
	 */
	public static  void showWorksView(){
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
		 	RNshowWorksView();
		}
	}

	/**
	 *  是否正在录屏
	 */
	public static  bool isRecording(){
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
		   return RNisRecording();
			}
			return false;
	}

	/**
	 *  是否录制声音
	 */
	public static  bool isMicrophoned(){
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			return RNisMicrophoned ();
				}
		return false;
	}
	/* 初始化设置(必须)
		@param appId 爱拍RecNowSDK接入ID   
	*/
	public static void setupAppId(string appId) {
				if (Application.platform == RuntimePlatform.IPhonePlayer) {
						RNsetAppKey (appId);
				}
		}
	/*初始化分享设置(可选)
		@param QQKey  QQ第三方分享KEY(集成分享必须)
		@param WeiXinKey 微信第三方分享KEY(集成分享必须)
		@param text  第三方分享视频描述文案（游戏视频介绍）
	*/
	public static void setupShareKeys(string QQKey,string WeiXinKey, string shareText) {
				if (Application.platform == RuntimePlatform.IPhonePlayer) {
						RNsetShareKeys (QQKey, WeiXinKey, shareText);
				}
		}

	//录屏开始的回调
	public void OnRecordingStart(string msg){
		if (didStart != null) {
			didStart(msg);
			}
	}
	//录屏结束的回调 
	public void OnRecordingStop(string msg){

		if (didStop != null) {
			didStop(msg);
		}
	}

	//丢弃录屏的回调
	public void OnRecordingDiscarding(string msg){

		if (didDiscard != null) {
			didDiscard(msg);
		}
	}

	/*    工具条模式  回调的方法  */
	// 我的作品页出现的回调
	public void OnVideosListShowing(string msg){
		if (videosPageViewShowing != null) {
			videosPageViewShowing();
		}
	}

	// 我的作品页消失的回调 
	public void OnVideosListDisappear(string msg){
		if (videoEditingPageDisappear != null) {
			videoEditingPageDisappear();
		}
	}

	// 视频编辑界面出现
	public void OnVideoEditingPageShowing(string msg){
		if (videoEditingPageShowing != null) {
			videosPageViewShowing();
		}
	}

	// 视频界面消失的回调
	public void OnVideoEditingPageDisappear(string msg){
		if (videoEditingPageDisappear != null) {
			videoEditingPageDisappear();
		}
	}


}
