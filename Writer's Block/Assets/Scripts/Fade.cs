using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
	public void FadeMe()
	{
		StartCoroutine(DoFade());
	}

	//fade screen to black
	IEnumerator DoFade()
	{
		CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
		while(canvasGroup.alpha < 1)
		{
			canvasGroup.alpha += 0.01f;
			yield return null; 
		}
		yield return new WaitForSeconds(1.2f);
		StartCoroutine(UndoFade());
		yield return null;
	}

	//return screen to normal
	IEnumerator UndoFade()
	{
		CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
		while(canvasGroup.alpha > 0)
		{
			canvasGroup.alpha -= 0.01f;
			yield return null; 
		}
		yield return null;
	}
}	
