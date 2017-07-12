using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Dun1 : MonoBehaviour {

	FSM_DUN1 _FSM;
	static Animator _anim;
	public Transform _player;
	public Transform _head;
	public NavMeshAgent A;
	public GameObject Fish;
	public AudioClip Attack_sound;
	public AudioClip Hit_sound;
	public GameObject[] heart;
	public GameObject image;
	public GameObject image1;

	void Awake() {
		_FSM = GetComponent<FSM_DUN1> ();
		_anim = GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void StartAttackDes()
	{
		StopCoroutine ("Attacking");
		StartCoroutine ("Attacking");
	}

	IEnumerator Attacking()
	{
		while (_FSM._state == FSM_DUN1.STATE.ATTACK) {
			Vector3 direction = _player.position - this.transform.position;
			direction.y = 0;
			//float angle = Vector3.Angle (direction, _head.up);

			if (direction.magnitude < 5) {
				this.transform.rotation = Quaternion.Slerp (this.transform.rotation,
					Quaternion.LookRotation (direction), 0.1f);
				_anim.SetBool ("isWalking_Dun", false);
				_anim.SetBool ("isAttacking_Dun", true);
			} 

			yield return new WaitForSeconds(Time.deltaTime);
		}
	}

	public void AttackFish()
	{
		A.Resume ();
		if (heart [0].activeSelf == true) {
			heart [0].SetActive (false);
			AudioSource.PlayClipAtPoint (Hit_sound, transform.position);
			StartCoroutine ("hit");
		} else if (heart [1].activeSelf == true) {
			heart [1].SetActive (false);
			AudioSource.PlayClipAtPoint (Hit_sound, transform.position);
			StartCoroutine ("hit");
		} else if (heart [2].activeSelf == true) {
			heart [2].SetActive (false);
			AudioSource.PlayClipAtPoint (Hit_sound, transform.position);
			StartCoroutine ("hit");
		} else if (heart [3].activeSelf == true) {
			heart [3].SetActive (false);
			AudioSource.PlayClipAtPoint (Hit_sound, transform.position);
			StartCoroutine ("hit");
		}
		else {
			heart [4].SetActive (false);
			AudioSource.PlayClipAtPoint (Hit_sound, transform.position);
			StartCoroutine ("dead");
		}

		AudioSource.PlayClipAtPoint (Attack_sound, transform.position);
		_FSM._state = FSM_DUN1.STATE.MOVE;

	}

	IEnumerator hit(){
		image.SetActive (true);
		yield return new WaitForSeconds (1.0f);
		image.SetActive (false);

	}

	IEnumerator dead(){
		image1.SetActive (true);


		yield return new WaitForSeconds (1.0f);

		Application.LoadLevel ("gameover");

	}
}
