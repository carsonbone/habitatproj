using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform temp2 = player.transform;
        transform.position = new Vector3(temp2.position.x, temp2.position.y, -10); //just track onto the player
    }

    /*
    public void WhoLooking(Transform temp)
    {

        player = temp;
        Debug.Log("wholooking");
        
    }*/
}
