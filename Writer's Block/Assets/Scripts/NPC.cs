using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {
    public Dialouge dialouge;
    private bool started = false;

    public override void Interact()
    {
        Player_Controller player = FindObjectOfType<Player_Controller>();
        DialougeManager currentDialouge = FindObjectOfType<DialougeManager>();
        if (started == false)
        {
            Debug.Log("Dialouge Has Started");
            currentDialouge.StartDialouge(dialouge);
            player.can_move = false;
            started = true;
        } else
        {
            if (DialougeManager.end == false)
            {
                currentDialouge.DisplayNextSentence();
                Debug.Log("Dialouge is Continuing");
            }
            if (DialougeManager.end == true)
            {
                started = false; // reset dialouge
                player.can_move = true;
                Debug.Log("Dialouge is Ending");
            }
        }
    }
}
