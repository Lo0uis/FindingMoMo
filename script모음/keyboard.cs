using UnityEngine;
using System.Collections;

public class keyboard : MonoBehaviour {
    public int acc = 5;
    public float jumpSpeed = 5;  //jump value
    public float gravity = 9.8f;  //gravity value
	int jumpcheck=0;
	public GameObject player;
	//public virtualjoystick movestick;
    public Animator _playerAnim;
    CharacterController controller;
    Renderer rend;
    Vector3 currentMovement, reset_pos;
	public AudioClip button_sound;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        _playerAnim = gameObject.GetComponent<Animator>();
        
        reset_pos = transform.position;
        //rend = GetComponent<Renderer> () ;
        //rend.material.color = Color.blue ;  //set cube color
    }

    // Update is called once per frame
    void Update()
    {
        //Any keyboard arrow is down, set moving direction.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * acc);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * acc);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * acc);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * acc);
        }
        //When space is pressed, jump
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
			currentMovement.y = jumpSpeed;
		}
        //set gravity
        if (!controller.isGrounded)
        {
            currentMovement -= new Vector3(0, gravity * Time.deltaTime, 0);
        }
        //move cube
        controller.Move(currentMovement * Time.deltaTime);
        //mouth move

		//if (movestick.InputDirection != Vector3.zero)	
		//{
		//	currentMovement = movestick.InputDirection;
		//}

	/*	if (Input.GetButtonDown ("Fire2")&&_playerAnim.GetBool("blend")==false)
        {
			_playerAnim.SetBool("mouth", true);
        }
        else
        {
            _playerAnim.SetBool("mouth", false);
        }
*/
    }

	public void jump()
	{
		AudioSource.PlayClipAtPoint (button_sound, transform.position);
		if (controller.isGrounded) 
		{
			currentMovement.y = jumpSpeed;
		}
		if(!controller.isGrounded)
		{
			currentMovement -= new Vector3(0, gravity * Time.deltaTime, 0);
		}
		controller.Move(currentMovement * Time.deltaTime);
		if (jumpcheck == 0) {
			player.tag = "jump";
			jumpcheck = 1;
			StartCoroutine ("Returntag");
		}
	}


	IEnumerator Returntag()
	{
		yield return new WaitForSeconds (1f);

		player.tag = "Player";
	}
    private void reset_object(Vector3 position)
    {
        transform.position = position;
        currentMovement = new Vector3(0, 0, 0);
    }

}