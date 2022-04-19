using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/* Name: Jasmine Martinez and Janice Xiong
 * 4/18/22
 * Player Move, Dies, Jump, Respawn, Display UI Text
 * 
 */
public class PlayerMovement : MonoBehaviour
{
    //Movement variables 
    public int speed;
    private Rigidbody rigid_body;
    public float jump_force = 20;
    public bool isGrounded;

    //Have Win and Losing Text
    public int count = 0;
    public Text livesText;
    public Text countText;
    public Text winText;
    public Text gameOverText;


    //Create a respawn function
    private Vector3 startPos;
    public int lives = 3;



    //Counting sceneNumbers
    public int sceneNumber = 1;

    //Laser Variables
    public float stunTimer;




    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rigid_body = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        SetText();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        move();

        //jump
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.5f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (Input.GetKey("space") && isGrounded)
        {
            rigid_body.AddForce(Vector3.up * jump_force);
        }
    }
    



    //Move with the w,a,s,d keys
    private void move()
    {
        
        float translation = Input.GetAxis("Vertical") * 10 * Time.deltaTime;
        float straffe = Input.GetAxis("Horizontal") * 10 * Time.deltaTime;

        //Translate to move.
        transform.Translate(straffe, 0, translation);

        //unlock cursor mouse out of the screen
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //Respawn
    public void Respawn()
    {
        transform.position = startPos ;
        StartCoroutine(Blink());
        lives--;
        SetText();

        if (lives <= 0)
        {
            this.enabled = false;
        }
        if(count == 5)
        {

            this.enabled = false;
        }

    }

    //Respawn blink
    public IEnumerator Blink()
    {
        for (int index = 0; index < 20; index++)
        {
            if (index % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(.1f);
        }
        GetComponent<MeshRenderer>().enabled = true;
    }

    


    //Colliding function - enemies and collectables
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Coin"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetText();
        }

        if (other.gameObject.tag == "Enemy")
        {
            Respawn();
        }
        if (other.gameObject.tag == "Spike")
        {
            Respawn();
        }
        if (other.gameObject.tag == "Lava")
        {
            Respawn();
        }
        if (other.gameObject.tag == "DrippingLava")
        {
            Respawn();
        }
        if (other.gameObject.CompareTag("Fall"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Koopa")
        {
            Respawn();
        }

        if (other.tag == "Laser")
        {
            StartCoroutine(Stun());
        }

        if (other.tag == "Exit")
        {
            Scene_Switch.instance.switchScene(sceneNumber);
            sceneNumber++;
        }
    }




    //Stun
    IEnumerator Stun()
    {
        int currentPlayerSpeed = speed;
        speed = 0;
        yield return new WaitForSeconds(stunTimer);
        speed = currentPlayerSpeed;
    }




    //Text
    void SetText()
    {
        countText.text = "Count:" + count.ToString();
        livesText.text = "Lives:" + lives.ToString();


        if (lives <= 0)
        {
            gameOverText.text = "Game Over";
        }
        if (count >= 5)
        {
            winText.text = "You win!";
        }
    }


}
