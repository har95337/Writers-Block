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
            if(FindObjectOfType<DialougeManager>().DisplayNextSentence() == true)
            {} else
            {
                started = false;
            }
        }
    }
}
