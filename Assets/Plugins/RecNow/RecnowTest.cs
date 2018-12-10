using UnityEngine;
using System.Collections;

public class RecnowTest : MonoBehaviour {

	private bool isRecording = false;
	private bool isPaused = false;
	private bool isEnable = false;

	private Texture2D texture = null;

	// Use this for initialization
	void Start () {
		if (null == texture) {
			//Debug.Log("load recnow-test-buttons");
			//texture =  (Texture2D) Resources.Load("Images/box", typeof(Texture2D)); 
			texture = new Texture2D(1, 1);
			texture.SetPixel(0, 0, new Color(0.5f, 0.5f, 0.5f, 0.2f));
			texture.Apply();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {

		int x = 10, y = 10;
		int w = 358, h = 118;

		if (null == texture) {
			return;
		}

		GUI.DrawTexture(new Rect(x, x, 364 + 10, 120 * 3), texture);

		x += 10;
		y += 10;

		GUIStyle myStyle = new GUIStyle(GUI.skin.button);
		myStyle.fontSize = 32;

		if (GUI.Button(new Rect(x, y, w, h), "RecNow", myStyle)) {
			aipai.RecNow.ShowVideoStore();
		}

		y += h + 6;

		if (!isEnable) {
			isEnable = aipai.RecNow.IsEnable();
		}
		if (!isEnable) {
			GUI.enabled = false;
		}
		if (!isRecording && GUI.Button(new Rect(x, y, w, h), "Start Recording", myStyle)) {
			aipai.RecNow.StartRecord();
			isRecording = true;
		}
		if (isRecording && GUI.Button(new Rect(x, y, w, h), "Stop Recording", myStyle)) {
			aipai.RecNow.StopRecord();
			isRecording = false;
			isPaused = false;
		}

		y += h + 6;
		GUI.enabled = true;

		if (!isRecording) {
			GUI.enabled = false;
		}
		if (!isPaused && GUI.Button(new Rect(x, y, w, h), "Pause Recording", myStyle)) {
			aipai.RecNow.PauseRecord();
			isPaused = true;
		}
		if (isPaused && GUI.Button(new Rect(x, y, w, h), "Resume Recording", myStyle)) {
			aipai.RecNow.ResumeRecord();
			isPaused = false;
		}

		//Debug.Log("is recording " + aipai.RecNow.IsRecording());
		//Debug.Log("is paused" + aipai.RecNow.IsPaused());
#if UNITY_EDITOR
		//Debug.Log("OnGUI");
#endif
	}

	
	void OnApplicationPause(bool pauseStatus) {
		Debug.Log("App pauseStatus: " + pauseStatus);
		//if (pauseStatus && isRecording && !isPaused) {
			//isPaused = true;
		//}
	}
}
