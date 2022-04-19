using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: Jasmine Martinez
 * 4/18/22
 * Drippinglava
 * 
 */

public class DrippingLava : MonoBehaviour
{

    public GameObject lava_drip_prefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LavaDrip", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LavaDrip()
    {
        Instantiate(lava_drip_prefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
    }
}
