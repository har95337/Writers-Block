using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {
    public Dialouge dialouge;
    private bool started = false;


    public override void Interact()
    {
        if(started == false)
        {
            FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
            started = true;
        } else{
            if(DialougeManager.end == false)
            {
                FindObjectOfType<DialougeManager>().DisplayNextSentence();
                Debug.Log("False Called");
            } else if(DialougeManager.end == true)
            {
                started = false; // reset dialouge
                Debug.Log("True Called");
            }
        }
    }
}
