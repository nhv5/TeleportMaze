using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour {

    public Button play;

    void Start()
    {
        Button b = play.GetComponent<Button>();
        b.onClick.AddListener(WhichLevel);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

    void WhichLevel()
    {
        int current = Main.getCurrentLevel();
        SceneManager.LoadScene(current);
    }
}
