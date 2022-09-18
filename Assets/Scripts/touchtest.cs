using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchtest : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        


        if( Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            

            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    this.GetComponent<SpriteRenderer>().material.color = new Color(0, 150, 150);
                    break;
            }

        }
    }
}
