using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialougeManager : MonoBehaviour {
    public Text nameText; 
    public Text dialougeText;
    public Player_Controller player;
    public Animator anim;
    public static bool end = false;

    private Queue<string> sentences;

	void Start () {
        sentences = new Queue<string>();
	}

    public void StartDialouge(Dialouge dialouge)
    {
        end = false;
        // Open Dialouge Box
        anim.SetBool("IsOpen", true);
        // Name of the NPC or Interactable object
        nameText.text = dialouge.guy;
        // Clear old sentences so old sentences are never displayed
        sentences.Clear();

        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialouge();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    // This coroutine makes sentences display letter by letter
    IEnumerator TypeSentence(string sentence)
    {
        dialougeText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialougeText.text += letter;
            yield return null;
        }
    }

    void EndDialouge()
    {
            anim.SetBool("IsOpen", false);
            end = true;
            return;
    }
}
