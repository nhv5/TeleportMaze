using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelThreeButton : MonoBehaviour {

    public Button level3;

    void Start()
    {
        Button b = level3.GetComponent<Button>();
        b.onClick.AddListener(WhichLevel);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

    void WhichLevel()
    {
        SceneManager.LoadScene(11);
    }
}
