using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private float topSpeed = 3f;
    public static int level = 0;
    private Vector3 spawn;
    public GameObject tele;

    private float wallTimer = 1.2f;
    public static bool wallDeactive = false;
    public static GameObject wt;

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

        if (wallDeactive == true)
        {
            wallTimer -= Time.deltaTime;
            if (wallTimer <= 0)
            {
                wt.transform.position = new Vector3(wt.transform.position.x, 0.12f, wt.transform.position.z);
                wallTimer = 1.0f;
                wallDeactive = false;
            }
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("WallParticle")) Teleport();

        if (other.gameObject.CompareTag("Barrier"))
        {
            other.gameObject.SetActive(false);
            Teleport();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            if(SceneManager.GetActiveScene().buildIndex == 6)
            {
                Main.NextLevel(6);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 10)
            {
                Main.NextLevel(10);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 14)
            {
                Main.NextLevel(14);
            }
            else
            {
                Main.NextLevel();
            }
            
        }

        if (other.gameObject.CompareTag("TimePad"))
        {
            deactivateWall();
        }

        if (other.gameObject.CompareTag("Up")) Teleport("up");

        if (other.gameObject.CompareTag("Down")) Teleport("down");

        if (other.gameObject.CompareTag("Left")) Teleport("left");

        if (other.gameObject.CompareTag("Right")) Teleport("right");

        if (other.gameObject.CompareTag("Portal")) Teleport("portal");

        if (other.gameObject.CompareTag("Portal3")) Teleport("portal3");

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

        if (direction.Equals("portal3"))
        {
            Instantiate(tele, transform.position, Quaternion.identity);
            transform.position = new Vector3(GameObject.FindGameObjectWithTag("Portal4").transform.position.x, 0.1f, GameObject.FindGameObjectWithTag("Portal4").transform.position.z);
        }
    }

    void Teleport()
    {
        Instantiate(tele, transform.position, Quaternion.identity);
        transform.position = spawn;
    }

    public static void deactivateWall()
    {
        wt = GameObject.FindWithTag("WallTrigger");
        wt.transform.position = new Vector3(wt.transform.position.x, -1.0f, wt.transform.position.z);
        wallDeactive = true;
    }

}
