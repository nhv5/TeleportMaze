using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    public float time = 0.0f;

    // Use this for initialization
    void Start () {

        Destroy(gameObject, time);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
