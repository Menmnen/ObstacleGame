using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Author: Janice Xiong
 * Date: 4/12/22
 * Program: Make the Koopa move up and down
 * 
 */


public class Koopa : MonoBehaviour
{
    //initializing variables
    public GameObject upPoint;
    public GameObject downPoint;
    private Vector3 upPos;
    private Vector3 downPos;
    public bool goingDown = true;
    public int speed;



    // Start is called before the first frame update
    void Start()
    {
        upPos = upPoint.transform.position;
        downPos = downPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // if moving down -> check the boundary, add down vector
        if (goingDown)
        {
            if (transform.position.y <= downPos.y)
            {
                goingDown = false;
            }
            else
            {
                transform.position += Vector3.down * Time.deltaTime * speed;
            }

        }
        // else moving up -> check the boundary, add up vector
        else
        {
            if (transform.position.y >= upPos.y)
            {
                goingDown = true;
            }
            else
            {
                transform.position += Vector3.up * Time.deltaTime * speed;
            }

        }

    }
}
