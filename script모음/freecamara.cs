﻿using UnityEngine;
using System.Collections;

public class freecamara : MonoBehaviour {

	public virtualjoystick cameraJoystick;

	public Transform lookAt;

	private float distance =10.0f;
	private float currentX=0.0f;
	private float currentY=0.0f;
	private float deltaY=0.0f;
	private float deltaX=0.0f;
	private float sensivityX=2.0f;
	private float sensivityY=1.0f;
	int check = 0;
	float mHdg = 0F;
	float mPitch = 0F;
	Vector3 dir ;
	private void Start()
	{
		dir = new Vector3 (0, 0, -distance);
	}
	private void Update()
	{
		deltaX = cameraJoystick.InputDirection.x * sensivityX;
		deltaY = cameraJoystick.InputDirection.z * sensivityY;

		if (deltaX != 0 && deltaY != 0) {
			mHdg += deltaX;


			transform.localEulerAngles = new Vector3 (mPitch, mHdg, 0);


			if (transform.position.y > -20F) {
				check = 1;
				if (deltaY < 0F)
					check = 0;
			}
			if (transform.position.y < -50F) {
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
