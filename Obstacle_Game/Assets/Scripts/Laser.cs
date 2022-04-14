using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Janice Xiong
 * 4/12/22
 * Laser beam repeat invoke
 * 
 */

public class Laser : MonoBehaviour
{
    [Header("Projectile Variables")]
    public float speed;
    public bool goingLeft;


    // Update is called once per frame
    void Update()
    {
        //Laser is going left
        if (goingLeft == true)
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }
        else
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }
    }
}
