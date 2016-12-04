using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    public static int level = 3;
    private float timer = 3.0f;
    public static int previousScene = 0;
    public static int currentScene = 0;

    void Start()
    {
        previousScene = currentScene;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        
    }

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
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            level = 4;
        }

        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            level = 8;
        }

        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            level = 12;
        }
        SceneManager.LoadScene(level);
    }

    public static void NextLevel(int scene)
    {
        SceneManager.LoadScene(1);
    }

    public static int getCurrentLevel()
    {
        int s = previousScene;
        return s;
    }

}
