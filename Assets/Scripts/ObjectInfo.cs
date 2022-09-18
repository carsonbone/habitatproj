using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    // Start is called before the first frame update

    public int length;
    public int width;

    void Start()
    {
        
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
}
