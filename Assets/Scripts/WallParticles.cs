using UnityEngine;
using System.Collections;

public class WallParticles : MonoBehaviour {

    public Transform[] movementPositions;

    public float speed;
    private int current;

    // Use this for initialization
    void Start () {

        transform.position = movementPositions[0].position;
        current = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position == movementPositions[current].position) current++;

        if (current >= movementPositions.Length) current = 0;

        transform.position = Vector3.MoveTowards(transform.position, movementPositions[current].position, speed * Time.deltaTime);
    }

}
