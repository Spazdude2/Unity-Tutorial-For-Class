using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float Speed;
	public float sensitivity;
	CharacterController Player;
	public GameObject eyes;

	float MoveFB;
	float MoveLR;

	float rotX;
	float rotY;

	// Use this for initialization
	void Start () 
	{
		Player = GetComponent<CharacterController> ();
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () 
	{
		MoveFB = Input.GetAxis ("Vertical") * Speed;
		MoveLR = Input.GetAxis ("Horizontal") * Speed;

		rotX = Input.GetAxis ("Mouse X") * sensitivity;
		rotY = Input.GetAxis ("Mouse Y") * -sensitivity;

		Vector3 Movement = new Vector3 (MoveLR, 0, MoveFB);
		transform.Rotate (0, rotX, 0);
		eyes.transform.Rotate (rotY, 0, 0);

		Movement = transform.rotation * Movement;
		Player.Move (Movement * Time.deltaTime);

		if (Input.GetKeyDown("escape"))
		{
			Cursor.lockState = CursorLockMode.None;
		}

	}
}
