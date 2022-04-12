using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Janice Xiong
 * Date : 4/ 12/22
 * Program: Koopa head detect the player touch and destroy the Koopa
 *
 */



public class KoopaHead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // when the hit Koopa head the Koopa dies and disappear
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Destroy(transform.parent.gameObject);
        }
    }

}
