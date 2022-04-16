using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDrip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroy sphere when it hits two units
        if (GetComponent<Transform>().position.y < -2f)
        {
            Destroy(this.gameObject);
        }
    }
}