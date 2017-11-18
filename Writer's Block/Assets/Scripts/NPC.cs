using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {
    public Dialouge dialouge;
    private bool started = false;


    public override void Interact()
    {
        DialougeManager currentDialouge = FindObjectOfType<DialougeManager>();
        if (started == false)
        {
            Debug.Log("Dialouge Has Started");
            currentDialouge.StartDialouge(dialouge);
            started = true;
        } else{
            if(DialougeManager.end == false)
            {
                currentDialouge.DisplayNextSentence();
                Debug.Log("Dialouge is Continuing");
            } else if(DialougeManager.end == true)
            {
                started = false; // reset dialouge
                Debug.Log("Dialouge is Ending");
            }
        }
    }
}
