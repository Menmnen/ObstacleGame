using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
   //Movement variables 
    public float speed;
    private Rigidbody rigid_body;
    public float jump_force = 20;
    public bool isGrounded;

    //Have Win and Losing Text
    private int count;
    public Text livesText;
    public Text countText;
    public Text winText;
    public Text gameOverText;

    //Create a respawn function
    private Vector3 startPos;
    public int lives = 3;
    public int fallDepth;

    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody>();
        count = 0;
        startPos = transform.position;
        SetText();
        winText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
        //jump
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 2.0f))
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
    //Move with the w,a,s,d keys
    void move()
    {
        Vector3 add_position = Vector3.zero;
        
        if (Input.GetKey("a"))
        {
            add_position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey("d"))
        {
            add_position += Vector3.right * Time.deltaTime * speed;
        }
        if (Input.GetKey("w"))
        {
            add_position += Vector3.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey("s"))
        {
            add_position += Vector3.back * Time.deltaTime * speed;
        }
        //add to player
        GetComponent<Transform>().position += add_position;

        if (transform.position.y < fallDepth)
        {
            Respawn();
        }
    }
    //Respawn
    public void Respawn()
    {
        transform.position = startPos;
        StartCoroutine(Blink());
        lives--;
        SetText();

        if (lives <=0)
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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Coin"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetText();
        }

        if (other.tag == "Enemy")
        {
            Respawn();
        }
        if (other.tag == "Lava")
        {
            Respawn();
        }
    }
}
