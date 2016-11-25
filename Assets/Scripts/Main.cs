using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    public static int level = 2;
    private float timer = 3.0f;
    private float wallTimer = 1.0f;
    public static bool wallDeactive = false;
    public static GameObject wt;

    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {

            timer -= Time.deltaTime;

            if (timer <= 0) SceneManager.LoadScene(1);
        }

        if(wallDeactive == true )
        {
            wallTimer -= Time.deltaTime;
            if (wallTimer <= 0)
            {
                wt.transform.position = new Vector3(wt.transform.position.x, 0.12f, wt.transform.position.z);
                wallTimer = 1.0f;
                wallDeactive = false;
            }
        }

    }

    public static void NextLevel()
    {
        level += 1;
        SceneManager.LoadScene(level);
    }

    public static void NextLevel(int scene)
    {
        SceneManager.LoadScene(1);
    }

    public static void deactivateWall()
    {
        wt = GameObject.FindWithTag("WallTrigger");
        wt.transform.position = new Vector3(wt.transform.position.x, -1.0f, wt.transform.position.z);
        wallDeactive = true;
    }

}
