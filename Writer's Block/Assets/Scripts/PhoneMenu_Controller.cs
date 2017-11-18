using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneMenu_Controller : MonoBehaviour
{
	public Animator anim;
	public AudioSource aud;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update()
	{
		//open the phone menu with the 'Tab' key
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			if(!anim.GetBool("IsOpen"))
			{
				//if the phone is not open, open it
				Debug.Log("Phone is Open");
				PhoneMenuOpen();
			}
			else if(anim.GetBool("IsOpen"))
			{
				//if the phone is open, close it
				Debug.Log("Phone is Closed");
				PhoneMenuClose();
			}
		}
	}

	public void PhoneMenuOpen()
	{
		anim.SetBool("IsOpen", true);
		aud.Play();
		anim.Play("PhoneMenu_Open");
	}

	public void PhoneMenuClose()
	{
		anim.SetBool("IsOpen", false);
		aud.Play();
		anim.Play("PhoneMenu_Close");
	}

	public void Quit()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
