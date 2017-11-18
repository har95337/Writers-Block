using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Renderer rend;
    public GameObject player;
    FieldOfView fov;

    private bool follow = false;
    void Start()
    {
        rend = GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        fov = this.GetComponent<FieldOfView>();
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayMonster();
        Behaviour(follow);
    }

    private void DisplayMonster()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rend.enabled = true;
            Debug.Log("Q Pressed");
            follow = true;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            rend.enabled = false;
            Debug.Log("Z Pressed");
            follow = false;
        }
    }

    private void Behaviour(bool follow)
    {
        bool seePlayer = (fov.visibleTargets.Contains(player.transform) ? true : false);

        if(seePlayer && follow)
        {
            transform.Translate(Vector2.right * 3 * Time.deltaTime / 2);
            Debug.Log(seePlayer);
            Debug.Log("Attempting to follow player");
        }
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
		{
			Debug.Log("Colided with player");
			GameObject.Find("FadeImage").GetComponent<Fade>().FadeMe();
			StartCoroutine(Wait());  
    	}
	}

	//waits for fade and then destroys monster and 'kills' the friend
	IEnumerator Wait()
	{
		yield return new WaitForSecondsRealtime(1.0f);
		Destroy(gameObject);
		Transform trans = GameObject.Find("BestBud").GetComponent<Transform>();
		trans.Rotate(0, 0, 90);
		trans.position = new Vector3(trans.position.x, trans.position.y - 0.3f, trans.position.z);
	}
}
