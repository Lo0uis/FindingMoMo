﻿using UnityEngine;
using System.Collections;

public class CMoveTest2 : MonoBehaviour {

	public Transform[] des;
	public NavMeshAgent A;
	public Transform _player;
	public Transform _head;
	static Animator _anim;
	public AudioClip Move_sound;
	public GameObject Fish;
	Transform TempDes;
	int index=0;
	int add = 1;
	int i = 0;
	CFSMTest2 _FSM;
	bool pursuing = false;

	void Awake()
	{
		_FSM = GetComponent<CFSMTest2> ();
		_anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {


	}

	public void StartMoveDes()
	{
		StopCoroutine ("MoveAround");
		StartCoroutine ("MoveAround");
	}

	IEnumerator MoveAround()
	{
		TempDes = des [index];
		A.SetDestination (TempDes.position);
		Vector3 direction = _player.position - this.transform.position;
		direction.y = 0;
		float angle = Vector3.Angle (direction, _head.up);

		while (_FSM._state == CFSMTest2.STATE.MOVE) {
			_anim.SetBool ("isWalking", true);
			_anim.SetBool ("isAttacking", false);
			_anim.SetBool ("isRunning",false);
			if(Vector3.Distance(this.transform.position, TempDes.position) < 2)
			{	
				if (index == des.Length - 1) {
					add = -1;
					index += add;
				}
				else if (index == 0) 
				{
					add = 1;
					index += add;
				}
				else 
				{
					index += add;
				}
			}

			TempDes = des [index];
			A.SetDestination (TempDes.position);	

			if (Vector3.Distance (_player.position, this.transform.position) < 10 && (angle < 30 || angle >330|| pursuing)&&Fish.tag.Equals("Player")) 
			{
				StopCoroutine ("MoveAround");
				_FSM._state = CFSMTest2.STATE.CHASE;
			}

			if (Vector3.Distance (_player.position, this.transform.position) < 20 && i>=10) 
			{
				AudioSource.PlayClipAtPoint (Move_sound, transform.position);
				i = 0;
			}
			i++;
			yield return new WaitForSeconds (Time.deltaTime);
		}
	}

}