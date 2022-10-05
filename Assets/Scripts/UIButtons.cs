using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{

    public GameObject ControlObj;
    private bool enabledcheck;

    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
        ControlObj.SetActive(enabledcheck);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipEnable()
    {

        Debug.Log("flipped");
        ControlObj.SetActive(enabledcheck);

        enabledcheck = !enabledcheck;
    }
}
