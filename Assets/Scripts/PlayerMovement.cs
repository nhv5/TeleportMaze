using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private float topSpeed = 4f;
    public static int level = 0;

    // Use this for initialization
    void Start () {

	}

    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);

        if (GetComponent<Rigidbody>().velocity.magnitude < topSpeed) GetComponent<Rigidbody>().AddForce(movement * speed);

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Up")) transform.position = new Vector3(0.0f, 0.0f, transform.position.z + 3.0f); ;

    }

    void OnTriggerEnter(Collider other)
    {
        level += level;
        if (other.gameObject.CompareTag("End")) SceneManager.LoadScene(level);
    }

}
