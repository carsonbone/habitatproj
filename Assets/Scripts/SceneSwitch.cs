using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch()
    {

        string CurName = SceneManager.GetActiveScene().name;
        Debug.Log(CurName);
        Debug.Log("We are in Switch");
        if (CurName == "SampleScene")
        {
            Debug.Log("in the if statement");
            SceneManager.LoadScene("CharCreateScene");
        }
        if (CurName == "CharCreateScene")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
