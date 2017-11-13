using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	//prototype level designator
    public string startLevel;

	void Start()
	{

	}

    //start new game on prototype level
    public void NewGame()
    {
        SceneManager.LoadScene(startLevel);
    }

    //close game when in application mode
    public void QuitGame()
    {
        Application.Quit();
    }
}
