using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {
    Animator anim;
    GameObject interactable;
    FieldOfView fov;
    private Rigidbody2D rb;
    public Transform interactable_check;
    public bool can_move = true;
    public LayerMask what_is_interactable;
	// Use this for initialization
	void Start ()
    {
        interactable = GameObject.FindGameObjectWithTag("Interactable");
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        fov = this.GetComponent<FieldOfView>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement(can_move);
        Interact();
	}

    void Movement(bool can_move)
    {
        if (can_move)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetBool("isRunning", true);
                    transform.Translate(Vector2.right * 5 * Time.deltaTime / 2);
                    transform.eulerAngles = new Vector2(0, 0);
                }
                else
                {
                    anim.SetBool("isWalking", true);
                    transform.Translate(Vector2.right * 3 * Time.deltaTime / 2);
                    transform.eulerAngles = new Vector2(0, 0);
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetBool("isRunning", true);
                    transform.Translate(Vector2.right * 5 * Time.deltaTime / 2);
                    transform.eulerAngles = new Vector2(0, 180);
                }
                else
                {
                    anim.SetBool("isWalking", true);
                    transform.Translate(Vector2.right * 3 * Time.deltaTime / 2);
                    transform.eulerAngles = new Vector2(0, 180);
                }
            }
        }
    }

    public void Interact()
    {
        bool seeInteractable = (fov.visibleTargets.Contains(interactable.transform) ? true : false);
        if (Input.GetKeyDown(KeyCode.E) && seeInteractable)
        {
            interactable.GetComponent<Interactable>().Interact();
        }
    }
}
