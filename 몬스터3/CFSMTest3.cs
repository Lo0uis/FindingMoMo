using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CFSMTest3 : MonoBehaviour {

	public enum STATE{MOVE, ATTACK, CHASE};

	CMoveTest3 _move;
	chase3 _chase;
	Attack3 _attack;
	public GameObject Monster;
	public string Bar_num;
	public AudioClip Gethurt_sound;
	public AudioClip Dead_sound;


	public STATE _state = STATE.MOVE;
	public Image _Bar;
	void Awake()
	{
		_move = GetComponent<CMoveTest3> ();
		_chase = GetComponent<chase3> ();
		_attack = GetComponent<Attack3> ();
		_Bar = GameObject.Find(Bar_num).GetComponent<Image> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (_state) {
		case STATE.MOVE:
			_move.StartMoveDes ();
			break;

		case STATE.CHASE:
			_chase.StartChaseDes ();
			break;

		case STATE.ATTACK:
			_attack.StartAttackDes ();
			break;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag.Equals("Bullet"))
		{
			_Bar.fillAmount -= 0.05f;
			Destroy (col.gameObject);
			AudioSource.PlayClipAtPoint (Gethurt_sound, transform.position);

			if (_Bar.fillAmount == 0) {
				Monster.SetActive (false);
				AudioSource.PlayClipAtPoint (Dead_sound, transform.position);
			}
		}

	}
}
