using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    // Start is called before the first frame update

    public int length;
    public int width;

    public bool isValid;

    void Start()
    {
        isValid = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int[] AccessObjSize() //a method to call to find out the size of the object, not using rn
    {
        int[] size = new int[2];
        size[0] = length;
        size[1] = width;
        return size;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered");
        isValid = false;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        isValid = false;
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        isValid = true;

    }
}
