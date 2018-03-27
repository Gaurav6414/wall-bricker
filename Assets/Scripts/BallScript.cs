using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {


	public Rigidbody2D rb;

	public float ballForce;
	bool gamestarted = false;
	bool CurrentPlatformAndroid = false;

	void Awake ()
	{
		#if UNITY_ANDROID
		CurrentPlatformAndroid = true;

		#else
			CurrentPlatformAndroid = false;
		#endif
		}

	
	// Update is called once per frame
	void Update ()
	{
		if (CurrentPlatformAndroid == true) {
			//android code
			TouchStart ();
		} else {

			if (Input.GetKeyUp (KeyCode.Space) && gamestarted == false) {
				transform.SetParent (null);
				rb.isKinematic = false;
				gamestarted = true;
				rb.AddForce (new Vector2 (ballForce, ballForce));
			}
		}
	}
	void TouchStart ()
	{

			if (Input.GetTouch(0).phase == TouchPhase.Ended)
		{
		transform.SetParent (null);
				rb.isKinematic = false;
				gamestarted = true;
			rb.AddForce (new Vector2 (ballForce, ballForce));
		}
}
}