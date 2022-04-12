using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Janice Xiong
 * 4/12/22
 * Invoke Repeat the laser beam
 */

public class LaserSpawn : MonoBehaviour
{
    [Header("Projectile Variables")]
    public bool goingLeft;

    [Header("Spawner Variables")]
    public GameObject projectilePrefab;
    public float timeBetweenShots;
    public float startDelay;

    // Start is called before the first frame update
    void Start()
    {
        //repeat the laser beam 
        InvokeRepeating("SpawnProjectile", startDelay, timeBetweenShots);
    }


    public void SpawnProjectile()
    {
        //get laser prefab's tranform and check if the laser goes left
        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        if (projectile.GetComponent<Laser>())
        {
            projectile.GetComponent<Laser>().goingLeft = goingLeft;
        }
    }
}
