using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialougeManager : MonoBehaviour {
    public Text nameText;
    public Text dialougeText;
    public Player_Controller player;
    public Animator anim;

    private Queue<string> sentences;

	void Start () {
        sentences = new Queue<string>();
	}

    public void StartDialouge(Dialouge dialouge)
    {
        anim.SetBool("IsOpen", true);
        nameText.text = dialouge.guy;
        sentences.Clear();

        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public bool DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialouge();
            return false;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        return true;
    }
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
            Debug.Log("End of Conversation");
    }
}
