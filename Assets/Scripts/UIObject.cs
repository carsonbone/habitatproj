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
    private RectTransform textTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void initializeObject(){
        objectNumber = 1;
        var objectCount = new GameObject();
        objectCount.transform.parent = this.transform;
        objectAmount = objectCount.AddComponent<TextMeshProUGUI>();
        objectAmount.text = "x" + objectNumber;
        objectAmount.font= orange;
        textTransform = objectAmount.GetComponent<RectTransform>();
        textTransform.anchorMax = new Vector2(1.0f, 0.0f);
        textTransform.anchorMin = new Vector2(1.0f, 0.0f);
        textTransform.anchoredPosition = new Vector3(25.0f, 0.0f, 0.0f);
        textTransform.sizeDelta = new Vector2(100, 50);
        textTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    public int returnAmount(){
        return objectNumber;
    }

    public void IncreaseAmount(){
        objectNumber++;
        objectAmount.text = "x" + objectNumber;
    }

    public bool DecreaseAmount(){
        if(objectNumber == 1){
            return true;
        } else {
            objectNumber--;
            objectAmount.text = "x" + objectNumber;
            return false;
        }
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
