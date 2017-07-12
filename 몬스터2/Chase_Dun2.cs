using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase_Dun2 : MonoBehaviour {

	FSM_DUN2 _FSM;
	bool pursuing = false;
	public Transform _player;
	public Transform _head;
	public NavMeshAgent A;
	int i = 0;
	public AudioClip Chase_sound;
	void Awake()
	{
		_FSM = GetComponent<FSM_DUN2> ();
	}

	public void StartChaseDes()
	{
		StopCoroutine ("Chasing");
		StartCoroutine ("Chasing");
	}

	IEnumerator Chasing()
	{
		while (_FSM._state == FSM_DUN2.STATE.CHASE) {
			Vector3 direction = _player.position - this.transform.position;
			direction.y = 0;
			float angle = Vector3.Angle (direction, _head.up);

			if (Vector3.Distance (_player.position, this.transform.position) < 10 && (angle < 30  || angle >330 || pursuing)) 
			{
				pursuing = true;

				this.transform.rotation = Quaternion.Slerp (this.transform.rotation, 
					Quaternion.LookRotation (direction), 0.1f);


				if (direction.magnitude > 5) {
					A.SetDestination (_player.position);
				} else {
					A.Stop ();
					_FSM._state = FSM_DUN2.STATE.ATTACK;
				}
			}
			else{
				pursuing = false;
				_FSM._state = FSM_DUN2.STATE.MOVE;
			}

			if (Vector3.Distance (_player.position, this.transform.position) < 20 && i>=5) 
			{
				AudioSource.PlayClipAtPoint (Chase_sound, transform.position);
				i = 0;
			}
			i++;
			yield return new WaitForSeconds(0.1f);
		}
	}
}
