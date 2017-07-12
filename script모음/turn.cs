using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class turn : MonoBehaviour {
	public float speed = 5.0f;        // moving speed
	public float rotSpeed = 120.0f; // rotation speed
	public GameObject turret;      // fish object
	public GameObject []mouth;
	public Animator _playerAnim;
	public virtualjoystick movestick2;
	int attackcheck=0;
	float OriginSpeed;

	public int power = 2000;  // bullet speed power
	public Transform bullet;  // bullet object
	Transform myBullet;
	int bulletitem=0, familystate=0;
	static GameObject mother;
	static GameObject father;
	public AudioClip bullet_sound;
	public AudioClip button_sound;
	void Start(){
		OriginSpeed = speed;
		_playerAnim = gameObject.GetComponent<Animator>();
	}

	void Update()
	{
		float amtToMove = speed * Time.deltaTime; // moving distance per frame
		float amtToRot = rotSpeed * Time.deltaTime; // rotation angle per frame

		float front = Input.GetAxis("Vertical");         // moving front/back
		float ang = Input.GetAxis("Horizontal");      // moving left/right
		float ang2 = Input.GetAxis("MyFish");       // moving turret
		if (movestick2.InputDirection != Vector3.zero)	
		{

			front = movestick2.Vertical();
			ang = movestick2.Horizontal();
		}

		transform.Translate(Vector3.forward * front * amtToMove);  // moving front/back
		transform.Rotate(Vector3.up * ang * amtToRot);                        // moving left/right
		turret.transform.Rotate(Vector3.up * ang2 * amtToRot); // moving turret
	}

	public void BulletBoom()
	{
		bulletitem = 1;

		StartCoroutine ("ReturnBullet");
	}

	public void SpeedUp()
	{
		speed += 5;

		StartCoroutine ("ReturnSpeed");
	}

	public void Shadow()
	{
		gameObject.tag = "shadow";
		_playerAnim.SetTrigger ("blend");
		StartCoroutine ("ReturnShadow");
	}

	public void Family()
	{
		familystate = 1;
		StartCoroutine ("ReturnFamily");
	}

	IEnumerator ReturnSpeed()
	{
		yield return new WaitForSeconds (10f);

		speed = OriginSpeed;
	}

	IEnumerator ReturnBullet()
	{
		yield return new WaitForSeconds (10f);

		bulletitem = 0;
	}

	IEnumerator ReturnShadow()
	{
		yield return new WaitForSeconds (10f);
		gameObject.tag = "Player";
		_playerAnim.SetBool("blend", false);
	}

	IEnumerator ReturnFamily()
	{
		yield return new WaitForSeconds (10f);
		familystate = 0;
		Destroy (mother);
		Destroy (father);
	}

	public void mouthfunc()
	{AudioSource.PlayClipAtPoint (button_sound, transform.position);
		if (gameObject.tag != "shadow")
			_playerAnim.SetTrigger ("mouth");
		if (gameObject.tag != "shadow"&&bulletitem==1) {
			myBullet = (Transform)Instantiate (bullet, mouth[0].transform.position, mouth[0].transform.rotation);
			myBullet.GetComponent<Rigidbody>().AddForce (mouth[0].transform.forward * power);
			AudioSource.PlayClipAtPoint (bullet_sound, transform.position);

		}
		else if (familystate == 1) {
			if (gameObject.tag != "shadow") {
				myBullet = (Transform)Instantiate (bullet, mouth [0].transform.position, mouth [0].transform.rotation);
				myBullet.GetComponent<Rigidbody> ().AddForce (mouth [0].transform.forward * power);
				myBullet = (Transform)Instantiate (bullet, mouth [1].transform.position, mouth [1].transform.rotation);
				myBullet.GetComponent<Rigidbody> ().AddForce (mouth [1].transform.forward * power);
				myBullet = (Transform)Instantiate (bullet, mouth [2].transform.position, mouth [2].transform.rotation);
				myBullet.GetComponent<Rigidbody> ().AddForce (mouth [2].transform.forward * power);
				AudioSource.PlayClipAtPoint (bullet_sound, transform.position);
			}
		}
		if (attackcheck == 0){
			turret.tag = "attack";
			attackcheck = 1;
			StartCoroutine ("Returntag");
		}
	}
	IEnumerator Returntag()
	{
		yield return new WaitForSeconds (1f);

		turret.tag = "Player";
	}
}
