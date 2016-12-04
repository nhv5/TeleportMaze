using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    private float time = 60.0f;

    public Text countdown;
	
	// Update is called once per frame
	void Update () {

        time -= Time.deltaTime;
        countdown.text = "Timer: " + Mathf.Round(time);

        if(time <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	
	}
}
