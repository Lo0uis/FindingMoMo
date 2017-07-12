using UnityEngine;
using System.Collections;

public class freecamera2 : MonoBehaviour {

	public virtualjoystick cameraJoystick;

	public Transform lookAt;

	private float distance =10.0f;
	private float currentX=0.0f;
	private float currentY=0.0f;
	private float deltaY=0.0f;
	private float deltaX=0.0f;
	private float sensivityX=3.0f;
	private float sensivityY=0.1f;
	int check = 0;
	float mHdg = 0F;
	float mPitch = 0F;
	Vector3 dir ;
	private void Start()
	{
		dir = new Vector3 (0, 0, -distance);
		RenderSettings.fogColor = Camera.main.backgroundColor;
		RenderSettings.fogDensity = 0.07F;
		RenderSettings.fog = true;
	}
	private void Update()
	{
		deltaX = cameraJoystick.InputDirection.x * sensivityX;
		deltaY = cameraJoystick.InputDirection.z * sensivityY;

		if (deltaX != 0 && deltaY != 0) {
			mHdg += deltaX;


			transform.localEulerAngles = new Vector3 (mPitch, mHdg, 0);


			if (transform.position.y > -53F) {
				check = 1;
				if (deltaY < 0F)
					check = 0;
			}
			if (transform.position.y < -56F) {
				check = 1;
				if (deltaY > 0F)
					check = 0;
			}

			if (check == 0) {
				transform.position += deltaY * Vector3.up;
				transform.localEulerAngles = new Vector3 (mPitch, mHdg, 0);
			}

		}


	}


}
