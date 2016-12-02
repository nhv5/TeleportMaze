using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButton : MonoBehaviour {

    public Button main;

    void Start()
    {
        Button b = main.GetComponent<Button>();
        b.onClick.AddListener(WhichLevel);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

    void WhichLevel()
    {
        SceneManager.LoadScene(1);
    }
}
