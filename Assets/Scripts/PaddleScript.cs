using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {

	public Rigidbody2D rb;

	public float speed;
	public float maxX;
	private Vector2 touchOrigin = -Vector2.one;
	// Use this for initialization

	bool CurrentPlatformAndroid = false;

	void Awake ()
	{
		#if UNITY_ANDROID
		CurrentPlatformAndroid = true;

		#else
			CurrentPlatformAndroid = false;
		#endif
		}
						 
	void Start ()
	{
		if (CurrentPlatformAndroid == true) {
			Debug.Log ("Android");
		}
		else {

		Debug.Log ("pc");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	if (CurrentPlatformAndroid == true) {
			//android code
			TouchMove ();

		} else {

			float x = Input.GetAxis ("Horizontal");

			if (x < 0) {
				MoveLeft ();
			}

			if (x > 0) {
				MoveRight ();
			}

			if (x == 0) {
				MoveStop ();
			}

			Vector3 pos = transform.position;
			pos.x = Mathf.Clamp (pos.x, -maxX, maxX);
			transform.position = pos;   
		}
	}

	void TouchMove ()
	{

		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch (0);

			float middle = Screen.width / 2;

			if (touch.position.x < middle && touch.phase == TouchPhase.Began) {
				MoveLeft ();
			} else if (touch.position.x > middle && touch.phase == TouchPhase.Began) {
				MoveRight ();
			}
		}
		else {
			MoveStop ();
		}
	}

		void MoveLeft(){
			rb.velocity = new Vector2 (-speed,0);
		}

		void MoveRight(){
		rb.velocity = new Vector2 (speed,0);
		}

		void MoveStop(){
		rb.velocity = Vector2.zero;
		}
	}
	
           