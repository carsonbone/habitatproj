using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharObjPlacement : MonoBehaviour
{

    //This is just a test script to place new objects into the world
    //only spawns the testskull right now


    public Grid tilemap;
    int cooldown;
    public GameObject testSkull;

    public GameObject handler;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0;
        //Vector3 spawnpoint;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("space") && cooldown == 0)
        {

            Instantiate(testSkull, tilemap.GetCellCenterWorld(tilemap.WorldToCell(transform.position)), Quaternion.identity);
            cooldown = 10;
        }
        if( cooldown > 0)
        {
            cooldown--;
        }
    }
}
