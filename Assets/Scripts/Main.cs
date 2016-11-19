using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    public static int level = 0;

    public static void NextLevel()
    {

        level += 1;
        SceneManager.LoadScene(level);
    }

	
}
