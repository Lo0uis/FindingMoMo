using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class NPC_Dialog : MonoBehaviour {
	public string[] answerButtons;
	public string[] Questions;
	bool DisplayDialog = false;
	bool ActivateQuest = false;
	public GameObject movejoistick, camerajoistick;
	public int num=0;
	int check=0, casecheck=0,check2=0;
	Vector3 movepos, camerapos;
	public GameObject[] resource;
	public GameObject[] items;
	public GameObject player;
	public GameObject blackhole;
	public int fontsz;
	int jumpside=0, attackside = 0;
	public GameObject image2;
	public AudioClip button_sound;

	void Start () {
		int i = 0;
		image2.SetActive (false);
		for (i = 0; i < 8; i++)
			resource [i].SetActive (false);
		for (i = 0; i < 5; i++)
			items [i].SetActive (false);
		blackhole.SetActive (false);
	}
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if(check!=2)
			movepos = movejoistick.transform.position;
		if (check == 3 && casecheck == 0) {
			camerapos = camerajoistick.transform.position;
			casecheck = 1;
		}
		if (movejoistick.transform.position!=movepos && check == 2 && num == 3) {
			num++;
		}
		if (camerajoistick.transform.position!=camerapos && check == 3 && num == 5) {
			num++;
		}
		if (player.tag == "jump" && jumpside == 0) {
			num++;
			jumpside = 1;
		}
		if (player.tag == "attack" && attackside == 0) {
			num++;
			attackside = 1;
		}
		if (num == 24)
			blackhole.SetActive (true);
	}


	void OnGUI(){
		GUI.skin.label.fontSize = fontsz;
		GUI.skin.button.fontSize = fontsz;
		GUILayout.BeginArea (new Rect (100, 100, 1000, 1000));
		if (check == 0) {
			GUILayout.Label (Questions [14]);
		}
		if (DisplayDialog && num == 0) {
			check = 1;
			GUILayout.Label (Questions [0]);
			if (GUILayout.Button (answerButtons [4])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);
				num = 1;
			}
			if (GUILayout.Button (answerButtons [5])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);
				DisplayDialog = false;
				num = 0;
			}
		} 
		else if (DisplayDialog && num == 1) {
			GUILayout.Label (Questions [1]);
			GUILayout.Label (Questions [36]);
			if (GUILayout.Button (answerButtons [0])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				num = 2;
			}
			if (GUILayout.Button (answerButtons [1])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				DisplayDialog = false;
				num = 1;
			}
			if (GUILayout.Button (answerButtons [3])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				DisplayDialog = false;
				num = 23;
			}

		} else if (DisplayDialog && num == 2) {
			GUILayout.Label (Questions [2]);
			GUILayout.Label (Questions [3]);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				check = 2;
				num = 3;
				DisplayDialog = false;
			}

		} else if (num == 3) {
			GUILayout.Label (Questions [15]);
			GUILayout.Label (Questions [16]);
		} else if (num == 4) {
			GUILayout.Label (Questions [17]);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				num++;
			}
		} else if (num == 5) {
			GUILayout.Label (Questions [18]);
			GUILayout.Label (Questions [16]);
			resource [0].SetActive (true);
			check = 3;
		} else if (num == 6) {
			GUILayout.Label (Questions [17]);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				num++;
			}
		} else if (num == 7) {
			GUILayout.Label (Questions [19]);
			GUILayout.Label (Questions [11]);
			resource [2].SetActive (true);
		} else if (num == 8) {
			GUILayout.Label (Questions [17]);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				num++;
			}
		} else if (num == 9) {
			GUILayout.Label (Questions [4]);
			GUILayout.Label (Questions [10]);
			resource [1].SetActive (true);
		} else if (num == 10) {
			GUILayout.Label (Questions [17]);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				num++;
			}
		} else if (num == 11) {
			GUILayout.Label (Questions [5]);
			GUILayout.Label (Questions [6]);
			int i = 0;
			for (i = 3; i < 8; i++)
				resource [i].SetActive (true);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				num++;
			}
		} else if (!DisplayDialog && num == 12 && check2 == 0) {
			GUILayout.Label (Questions [17]);
			GUILayout.Label (Questions [7]);
		} else if (DisplayDialog && num == 12) {
			GUILayout.Label (Questions [8]);
			GUILayout.Label (Questions [9]);
			player.tag = "Player";
			if (GUILayout.Button (answerButtons [0])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				DisplayDialog = false;
				num = 13;
			}
			if (GUILayout.Button (answerButtons [1])) {
				DisplayDialog = false;
				num = 12;
				check2 = 1;
			}
		} else if (num == 13) {
			GUILayout.Label (Questions [12]);
			GUILayout.Label (Questions [13]);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				items [0].SetActive (true);
				num++;
			}
		} else if (num == 14 && items [0].activeSelf == false) {
			GUILayout.Label (Questions [20]);
			GUILayout.Label (Questions [21]);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				num++;
			}
		}else if (num == 15) {
			GUILayout.Label (Questions [22]);
			if (GUILayout.Button (answerButtons [2])) {
				items [1].SetActive (true);
				num++;
			}
		}  else if (num == 16 && items [1].activeSelf == false) {
			GUILayout.Label (Questions [23]);
			GUILayout.Label (Questions [24]);
			GUILayout.Label (Questions [25]);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				num++;
			}
		}else if (num == 17) {
			GUILayout.Label (Questions [22]);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				items [2].SetActive (true);
				num++;
			}
		}else if (num == 18 && items [2].activeSelf == false) {
			GUILayout.Label (Questions [26]);
			GUILayout.Label (Questions [27]);
			GUILayout.Label (Questions [28]);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				num++;
			}
		}else if (num == 19) {
			GUILayout.Label (Questions [22]);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				items [3].SetActive (true);
				num++;
			}
		}else if (num == 20 && items [3].activeSelf == false) {
			GUILayout.Label (Questions [23]);
			GUILayout.Label (Questions [29]);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				num++;
			}
		}
		else if (num == 21) {
			resource [6].SetActive (false);
			GUILayout.Label (Questions [32]);
			GUILayout.Label (Questions [22]);

			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				items [4].SetActive (true);
				num++;
			}
		}else if (num == 22 && items [4].activeSelf == false) {
			GUILayout.Label (Questions [30]);
			GUILayout.Label (Questions [31]);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				num++;
			}
		}else if (num == 23) {
			GUILayout.Label (Questions [33]);
			GUILayout.Label (Questions [34]);
			GUILayout.Label (Questions [35]);
			if (GUILayout.Button (answerButtons [2])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				num++;
			}
		}

			
		GUILayout.EndArea ();

	}

	void OnTriggerEnter(){
		DisplayDialog = true;

	}
	void OnTriggerExit(){
		DisplayDialog = false;
	}

}