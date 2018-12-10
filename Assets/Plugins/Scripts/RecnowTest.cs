using UnityEngine;
using System.Collections;

public class  RecnowTest: MonoBehaviour {

	// Use this for initialization

	void Awake ()
	{
		DontDestroyOnLoad (gameObject);
		// let Recnow Initialize
		Recnow.Initialize ();
	}

	void Destroy ()
	{
		Recnow.didStart -= recordDidStart;
		Recnow.didStop -= recordDidStop;
		Recnow.didDiscard -= recordDidDiscard;
		Recnow.videosPageViewShowing -= testvideosPageViewShowing;
		Recnow.videosPageViewDisappear -= testvideosPageViewDisappear;
		Recnow.videoEditingPageShowing -= testvideoEditingshowing;
		Recnow.videoEditingPageDisappear -= testvideoEditingDisappear;
	}

	void Start () {
		Recnow.setupAppId ("2807");
		Recnow.setupShareKeys ("207799", "wx69c1efc9eb960a6c", "hello");

		Recnow.didStart += recordDidStart;
		Recnow.didStop += recordDidStop;
		Recnow.didDiscard += recordDidDiscard;

		Recnow.videosPageViewShowing += testvideosPageViewShowing;
		Recnow.videosPageViewDisappear += testvideosPageViewDisappear;

		// cancle
		Recnow.videoEditingPageShowing += testvideoEditingshowing;
		Recnow.videoEditingPageDisappear += testvideoEditingDisappear;
	}

	void OnGUI() {
		if (Recnow.isSupported()) {
			if (GUI.Button(new Rect(50, 50, 100, 100), "Start"))
			{
				Recnow.startRecording(true);
				Debug.Log("startrecord");
			}
			
			if (GUI.Button(new Rect(250, 50, 100, 100), "Stop"))
			{
				Recnow.stopRecording();
				Debug.Log("stoprecord");
			}
			
			if (GUI.Button(new Rect(430,50,100,100), "Videos"))
			{
				Recnow.showWorksView();
				Debug.Log("mywork");
			}
	    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void recordDidStart(string msg)
	{
		Debug.Log("did start");
	}

	private void recordDidStop(string msg)
	{
		Debug.Log("did stop");

	}

	private void recordDidDiscard(string msg)
	{
		Debug.Log("did discard");

	}

	private void testvideosPageViewShowing()
	{
		Debug.Log("videosPageViewShowing");

	}

	private void testvideosPageViewDisappear()
	{
		Debug.Log("videosPageViewDisappear");

	}

	private void testvideoEditingshowing()
	{
		Debug.Log("testvideoEditingshowing");
	}

	private void testvideoEditingDisappear()
	{
		Debug.Log("testvideoEditingDisappear");
	}

}
		