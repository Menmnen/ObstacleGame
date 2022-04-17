using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDripping : MonoBehaviour
{
    //inialiazing and calling/using the prefab
    public GameObject lava_drip_prefab;


    // Start is called before the first frame update
    void Start()
    {
        //repeating lava drips for 2 sec
        InvokeRepeating("LavaDrip", 0f, 3f);
    }

    /// geting the lavadrip prefab's transform aand rotation
    // Update is called once per frame
    void Update()
    {
        Instantiate(lava_drip_prefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);

    }
}
