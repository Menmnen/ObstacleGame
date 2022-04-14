using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDrip : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //lava drip drop down and reach a y units and then destroy the drip
        if (GetComponent<Transform>().position.y < 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
