using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private float topSpeed = 3f;
    public static int level = 0;
    private Vector3 spawn;
    public GameObject tele;

    // Use this for initialization
    void Start () {

        spawn = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);

        if (GetComponent<Rigidbody>().velocity.magnitude < topSpeed) GetComponent<Rigidbody>().AddForce(movement * speed);

        if (transform.position.y < -3) Teleport();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            if(SceneManager.GetActiveScene().buildIndex == 5)
            {
                Main.NextLevel(5);
            }
            else
            {
                Main.NextLevel();
            }
            
        }

        if (other.gameObject.CompareTag("TimePad"))
        {
            Main.deactivateWall();
        }

        if (other.gameObject.CompareTag("Up")) Teleport("up");

        if (other.gameObject.CompareTag("Down")) Teleport("down");

        if (other.gameObject.CompareTag("Left")) Teleport("left");

        if (other.gameObject.CompareTag("Right")) Teleport("right");

        if (other.gameObject.CompareTag("Portal")) Teleport("portal");

        if (other.gameObject.CompareTag("WallTrigger")) Teleport();

    }

    void Teleport(string direction)
    {
        if (direction.Equals("up"))
        {
            Instantiate(tele, transform.position, Quaternion.identity);
            transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z + 2.0f);
        }

        if (direction.Equals("down"))
        {
            Instantiate(tele, transform.position, Quaternion.identity);
            transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z - 2.0f);
        }

        if (direction.Equals("left"))
        {
            Instantiate(tele, transform.position, Quaternion.identity);
            transform.position = new Vector3(transform.position.x - 2.0f, 0.1f, transform.position.z);
        }

        if (direction.Equals("right"))
        {
            Instantiate(tele, transform.position, Quaternion.identity);
            transform.position = new Vector3(transform.position.x + 2.0f, 0.1f, transform.position.z);
        }

        if (direction.Equals("portal"))
        {
            Instantiate(tele, transform.position, Quaternion.identity);
            transform.position = new Vector3(GameObject.FindGameObjectWithTag("Portal2").transform.position.x, 0.1f, GameObject.FindGameObjectWithTag("Portal2").transform.position.z);
        }
    }

    void Teleport()
    {
        Instantiate(tele, transform.position, Quaternion.identity);
        transform.position = spawn;
    }



}
