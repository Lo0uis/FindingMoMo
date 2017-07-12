using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinishDialogue : MonoBehaviour {public string[] answerButtons;
	public string[] Questions;
	public Text text;
	bool DisplayDialog = false;
	public int fontsz;
	public AudioClip button_sound;
	public AudioClip win_sound;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnGUI(){
		GUI.skin.label.fontSize = fontsz;
		GUI.skin.button.fontSize = fontsz;
		GUILayout.BeginArea (new Rect (100, 100, 1000, 1000));
		if (DisplayDialog) {
			AudioSource.PlayClipAtPoint (win_sound, transform.position);
			GUILayout.Label (Questions [0]);
			GUILayout.Label (Questions [1]);
			if (GUILayout.Button (answerButtons [0])) {
				DisplayDialog = false;
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				Application.LoadLevel ("12");
			}
			if (GUILayout.Button (answerButtons [1])) {
				AudioSource.PlayClipAtPoint (button_sound, transform.position);

				DisplayDialog = false;
				Application.Quit();
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
