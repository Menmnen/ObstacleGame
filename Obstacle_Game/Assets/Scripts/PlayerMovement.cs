using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rigid_body;
    //Have Win and Losing Text


    //Create a respawn function
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
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
    }
}
