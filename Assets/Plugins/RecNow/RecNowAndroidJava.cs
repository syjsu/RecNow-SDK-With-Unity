using UnityEngine;
using System;

namespace aipai
{
	public class RecNowAndroidJava:RecNow.RecNowBase
	{
#if UNITY_ANDROID
		AndroidJavaClass jc = null;
		
		public RecNowAndroidJava ()
		{
			jc = new AndroidJavaClass("com.aipai.recnow.RecNow");
		}
		
		public override bool IsEnable() {
			if (null == jc) {
				return false;
			}
			bool res = jc.CallStatic<bool>("isEnabled");
			
			return res;
		}
		
		public override void SetVideoQuality(int videoQuality) {
			if (null == jc) {
				return;
			}
			jc.CallStatic("setVideoQuality", videoQuality);
		}
		
		public override string GetVideoPath() {
			if (null == jc) {
				return null;
			}
			
			string videoPath = jc.CallStatic<string>("getVideoPath");
			
			return videoPath;
		}
	
		public override long GetVideoTimesMs() {
			if (null == jc) {
				return 0;
			}
			
			long videoTimes = jc.CallStatic<long>("getVideoTimesMs");
			
			return videoTimes;
		}
		
		public override int StartRecord() {
			if (null == jc) {
				return -1;
			}
			
			int res = jc.CallStatic<int>("startRecord");
			
			return res;
		}
		
		public override void StopRecord() {
			if (null == jc) {
				return;
			}
			
			jc.CallStatic("stopRecord");
		}
		
		public override void PauseRecord() {
			if (null == jc) {
				return;
			}
			
			jc.CallStatic("pauseRecord");
		}
			
		public override void ResumeRecord() {
			if (null == jc) {
				return;
			}
			
			jc.CallStatic("resumeRecord");
		}
		
		public override void TakeScreenshot() {
			if (null == jc) {
				return;
			}
			
			jc.CallStatic("takeScreenshot");
		}
		
		public override void ShowVideoStore() {
			if (null == jc) {
				return;
			}
			
			jc.CallStatic("showVideoStore");
		}
		
		public override void ShowToolbar() {
			if (null == jc) {
				return;
			}
			
			jc.CallStatic("showToolbar");
		}

		public override void HideToolbar() {
			if (null == jc) {
				return;
			}
			
			jc.CallStatic("hideToolbar");
		}
		
		public override void DeleteVideo(string path) {
			if (null == jc) {
				return;
			}
			
			jc.CallStatic("deleteVideo", path);
		}
				
		public override void Playback(string path) {
			if (null == jc) {
				return;
			}
			
			jc.CallStatic("playback", path);
		}

		public override void FastShare(string path) {
			if (null == jc) {
				return;
			}
			
			jc.CallStatic("fastShare", path);
		}
			
		public override void ShowPlayerClub() {
			if (null == jc) {
				return;
			}
			
			jc.CallStatic("showPlayerClub");
		}
			
		public override void ShowWelfareCenter() {
			if (null == jc) {
				return;
			}
			
			jc.CallStatic("showWelfareCenter");
		}
		
		public override void EnableToolbar() {
			if (null == jc) {
				return;	
			}
			jc.CallStatic("enableToolbar");
		}
			
		public override void DisableToolbar() {
			if (null == jc) {
				return;	
			}
			jc.CallStatic("disableToolbar");
		}

		public override void SetUploadInfo(string info) {
			if (null == jc) {
				return;
			}
			jc.CallStatic("setUploadInfo", info);
		}

		public override void FastUpload(string info) {
			if (null == jc) {
				return;
			}
			jc.CallStatic("fastUpload", info);
		}
		
		public override bool IsRecording() {
			if (null == jc) {
				return false;
			}
			return jc.CallStatic<bool>("isRecording");
		}
		
		public override bool IsPaused() {
			if (null == jc) {
				return false;
			}
			return jc.CallStatic<bool>("isPaused");
		}
#endif
	}
}

