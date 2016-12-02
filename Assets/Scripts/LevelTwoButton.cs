using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTwoButton : MonoBehaviour {

    public Button level2;

    void Start()
    {
        Button b = level2.GetComponent<Button>();
        b.onClick.AddListener(WhichLevel);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

    void WhichLevel()
    {
        SceneManager.LoadScene(7);
    }
}
