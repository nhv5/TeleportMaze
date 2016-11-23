using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    public static int level = 1;
    private float timer = 3.0f;

    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {

            timer -= Time.deltaTime;

            if (timer <= 0) SceneManager.LoadScene(1);
        }
    }

    public static void NextLevel()
    {
        level += 1;
        SceneManager.LoadScene(level);
    }

}
