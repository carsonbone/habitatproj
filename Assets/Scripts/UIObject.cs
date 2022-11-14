using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIObject : MonoBehaviour
{
    public int objectNumber;
    public TMP_Text objectAmount;
    public TMP_FontAsset orange;
    public GameObject objPrefab;

    // Start is called before the first frame update
    void Start()
    {

        var objectCount = new GameObject();
        objectCount.transform.parent = this.transform;
        objectAmount = objectCount.AddComponent<TextMeshProUGUI>();
        objectAmount.text = "x1";
        objectAmount.font= orange;
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
