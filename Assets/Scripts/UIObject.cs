using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObject : MonoBehaviour
{

    public GameObject objPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GiveObj()
    {
        Vector3 templocation = this.transform.position;
        GameObject temp = Instantiate(objPrefab,templocation, Quaternion.identity);
        return temp;
    }
    public int TestMethod()
    {
        return 2;
    }
}
