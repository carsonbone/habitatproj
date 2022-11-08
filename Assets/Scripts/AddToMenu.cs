using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToMenu : MonoBehaviour
{
    public GameObject UISkull;
    public GameObject UIBench;
    public GameObject UIFountain;
    public GameObject UIDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToMenu(string objectName){
        if(objectName.Equals("skull")){
            Instantiate(UISkull, this.transform);
        } else if(objectName.Equals("bench")){
            Instantiate(UIBench, this.transform);
        } else if(objectName.Equals("fountain")){
            Instantiate(UIFountain, this.transform);
        } else if(objectName.Equals("door")){
            Instantiate(UIDoor, this.transform);
        }  
    }

    public string returnObjects(){
        string objectList = "";
        foreach(Transform child in transform){
            if(child.name.Equals("SkullMenuObject(Clone)")){
                objectList = objectList + "null null skull null,";
            } else if(child.name.Equals("BenchMenuObject(Clone)")){
                objectList = objectList + "null null bench null,";
            } else if(child.name.Equals("FountainMenuObject(Clone)")){
                objectList = objectList + "null null fountain null,";
            } else if(child.name.Equals("DoorMenuObject(Clone)")){
                objectList = objectList + "null null door null,";
            }
        }
        return objectList;
    }
}
