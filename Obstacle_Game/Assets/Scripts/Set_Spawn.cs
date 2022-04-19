using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: Janice Xiong
 * 4/18/22
 * Spawning when go into next level
 * 
 */

public class Set_Spawn : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //Spawner when enter to a next level
        GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;


    }


}
