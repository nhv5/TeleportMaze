using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopupButton : MonoBehaviour {

    public Button popup;

    void Start()
    {
        Button b = popup.GetComponent<Button>();
        b.onClick.AddListener(Close);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

    public void Close()
    {
        Destroy(GameObject.FindWithTag("Popup"));
    }

}
