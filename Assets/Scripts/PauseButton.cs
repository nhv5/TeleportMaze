using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

    public Button pause;

    void Start()
    {
        Button b = pause.GetComponent<Button>();
        b.onClick.AddListener(WhichLevel);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

    void WhichLevel()
    {
        SceneManager.LoadScene(2);
    }
}
