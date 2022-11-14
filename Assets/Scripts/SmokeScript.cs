using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
}
