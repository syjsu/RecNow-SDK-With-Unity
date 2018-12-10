using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace aipai {
	public class RecNow : MonoBehaviour {
		public class RecNowBase {
			
			/**
			 * Check RecNow usable.
			 * 
			 * @return true RecNow initialize completed and device supported,
			 *         false RecNow initialize uncompleted or device not supoorted.
			 */
			public virtual bool IsEnable() {
				return false;
			}
			
			/**
			 * Set video quality
			 * 
			 * @param videoQuality 
			 * 		  1 FLUENCY
			 * 		  2 STANDARD
			 * 		  3 HIGH
			 *        4 SUPER
			 */
			public virtual void SetVideoQuality(int videoQuality) {}
		
			/**
			 * Get current recording video path
			 * 
			 * @return video path
			 */
			public virtual string GetVideoPath() {
				return "";
			}
		
			/**
			 * Get current recording video times
			 * 
			 * @return video times
			 */
			public virtual long GetVideoTimesMs() {
				return 0;
			}
				
			/**
			 * Start record. 
			 * 
			 * @return Started successfully if return 0  else failed
			 */
			public virtual int StartRecord() {
				return 0;		
			}
			
			public virtual void StopRecord() {}
		
			public virtual void PauseRecord() {}
			
			public virtual void ResumeRecord() {}
			
			public virtual void TakeScreenshot() {}
			
			public virtual void ShowVideoStore() {}
			
			public virtual void ShowToolbar() {}
				
			public virtual void HideToolbar() {}
	
			/**
			 * Delete last recording video file
			 * 
			 * @param path video path
			 */
			public virtual void DeleteVideo(string path) {}
				
			/**
			 * Play last recording video file
			 * 
			 * @param video path
			 */
			public virtual void Playback(string path) {}
				
			/**
			 * Share last recording video, and open share center
			 * 
			 * @param video path
			 */
			public virtual void FastShare(string path) {}
				
			public virtual void ShowPlayerClub() {}
				
			public virtual void ShowWelfareCenter() {}
			
			public virtual void EnableToolbar() {}
			public virtual void DisableToolbar() {}

			public virtual void SetUploadInfo(string info) {}
			public virtual void FastUpload(string info) {}
			
			public virtual bool IsRecording() {
				return false;
			}
			
			public virtual bool IsPaused() {
				return false;
			}
		}
	
		private static RecNowBase impl_;
	
		private static RecNowBase _GetImpl() {
			if (impl_ == null) {
				if (Application.platform == RuntimePlatform.Android) {
					impl_ = new RecNowAndroidJava();
				}
				else {
					impl_ = new RecNowBase();
				}
			}
			return impl_;
		}
	
		public static bool IsEnable() {
			return _GetImpl().IsEnable();
		}
		
		public static void SetVideoQuality(int videoQuality) {
			_GetImpl().SetVideoQuality(videoQuality);
		}
		
		public static string GetVideoPath() {
			return _GetImpl().GetVideoPath();
		}
		
		public static long GetVideoTimesMs() {
			return _GetImpl().GetVideoTimesMs();
		}
		
		public static int StartRecord() {
			return _GetImpl().StartRecord();	
		}
			
		public static void StopRecord() {
			_GetImpl().StopRecord();
		}
		
		public static void PauseRecord() {
			_GetImpl().PauseRecord();
		}
			
		public static void ResumeRecord() {
			_GetImpl().ResumeRecord();
		}
			
		public static void TakeScreenshot() {
			_GetImpl().TakeScreenshot();
		}
		
		public static void ShowVideoStore() {
			_GetImpl().ShowVideoStore();
		}
		
		public static void ShowToolbar() {
			_GetImpl().ShowToolbar();
		}
			
		public static void HideToolbar() {
			_GetImpl().HideToolbar();
		}

		public static void DeleteVideo(string path) {
			_GetImpl().DeleteVideo(path);
		}
			
		public static void Playback(string path) {
			_GetImpl().Playback(path);
		}
			
		public static void FastShare(string path) {
			_GetImpl().FastShare(path);
		}
			
		public static void ShowPlayerClub() {
			_GetImpl().ShowPlayerClub();
		}
			
		public static void ShowWelfareCenter() {
			_GetImpl().ShowWelfareCenter();
		}
		
		public static void EnableToolbar() {
			_GetImpl().EnableToolbar();
		}
			
		public static void DisableToolbar() {
			_GetImpl().DisableToolbar();
		}

		public static void SetUploadInfo(string info) {
			_GetImpl().SetUploadInfo(info);
		}
        
        public static void FastUpload(string info) {
			_GetImpl().FastUpload(info);
		}
		
		public static bool IsRecording() {
			return _GetImpl().IsRecording();
		}
		
		public static bool IsPaused() {
			return _GetImpl().IsPaused();
		}
	}
}
