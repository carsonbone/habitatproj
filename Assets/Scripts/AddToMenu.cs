using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToMenu : MonoBehaviour
{
    public GameObject UISkull;
    public GameObject UIBench;
    public GameObject UIFountain;
    public GameObject UIDoor;
    public GameObject UIBush;
    public GameObject UIDogHouse;
    public GameObject UIFence;
    public GameObject UIFern;
    public GameObject UIFlag;
    public GameObject UIFruitBox;
    public GameObject UIHouse;
    public GameObject UILog;
    public GameObject UIRock;
    public GameObject UISign;
    public GameObject UIStand;
    public GameObject UIStatue;
    public GameObject UIStool;
    public GameObject UIStump;
    public GameObject UITable;
    public GameObject UITombstone;
    public GameObject UITower;
    public GameObject UITree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToMenu(string objectName){
        GameObject temp = null;
        if(objectName.Equals("skull")){
            Instantiate(UISkull, this.transform);
        } else if(objectName.Equals("bench")){
            Instantiate(UIBench, this.transform);
        } else if(objectName.Equals("fountain")){
            Instantiate(UIFountain, this.transform);
        } else if(objectName.Equals("door")){
            Instantiate(UIDoor, this.transform);
        } else if(objectName.Equals("bush")){
            Instantiate(UIBush, this.transform);
        } else if(objectName.Equals("doghouse")){
            Instantiate(UIDogHouse, this.transform);
        } else if(objectName.Equals("fence")){
            Instantiate(UIFence, this.transform);
        } else if(objectName.Equals("fern")){
            Instantiate(UIFern, this.transform);
        } else if(objectName.Equals("flag")){
            Instantiate(UIFlag, this.transform);
        } else if(objectName.Equals("fruitbox")){
            Instantiate(UIFruitBox, this.transform);
        }  else if(objectName.Equals("house")){
            Instantiate(UIHouse, this.transform);
        } else if(objectName.Equals("log")){
            Instantiate(UILog, this.transform);
        } else if(objectName.Equals("rock")){
            Instantiate(UIRock, this.transform);
        }  else if(objectName.Equals("sign")){
            Instantiate(UISign, this.transform);
        } else if(objectName.Equals("stand")){
            Instantiate(UIStand, this.transform);
        } else if(objectName.Equals("statue")){
            Instantiate(UIStatue, this.transform);
        } else if(objectName.Equals("stool")){
            Instantiate(UIStool, this.transform);
        } else if(objectName.Equals("stump")){
            Instantiate(UIStump, this.transform);
        } else if(objectName.Equals("table")){
            Instantiate(UITable, this.transform);
        } else if(objectName.Equals("tombstone")){
            Instantiate(UITombstone, this.transform);
        } else if(objectName.Equals("tower")){
            Instantiate(UITower, this.transform);
        } else if(objectName.Equals("tree")){
            Instantiate(UITree, this.transform);
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
            } else if(child.name.Equals("BushMenuObject(Clone)")){
            objectList = objectList + "null null bush null,";
        } else if(child.name.Equals("DogHouseMenuObject(Clone)")){
            objectList = objectList + "null null doghouse null,";
        } else if(child.name.Equals("FenceMenuObject(Clone)")){
            objectList = objectList + "null null fence null,";
        } else if(child.name.Equals("FernMenuObject(Clone)")){
            objectList = objectList + "null null fern null,";
        } else if(child.name.Equals("FlagMenuObject(Clone)")){
            objectList = objectList + "null null flag null,";
        } else if(child.name.Equals("FruitBoxMenuObject(Clone)")){
            objectList = objectList + "null null fruitbox null,";
        }  else if(child.name.Equals("HouseMenuObject(Clone)")){
            objectList = objectList + "null null house null,";
        } else if(child.name.Equals("LogMenuObject(Clone)")){
            objectList = objectList + "null null log null,";
        } else if(child.name.Equals("RockMenuObject(Clone)")){
            objectList = objectList + "null null rock null,";
        }  else if(child.name.Equals("SignMenuObject(Clone)")){
            objectList = objectList + "null null sign null,";
        } else if(child.name.Equals("StandMenuObject(Clone)")){
            objectList = objectList + "null null stand null,";
        } else if(child.name.Equals("StatueMenuObject(Clone)")){
            objectList = objectList + "null null statue null,";
        } else if(child.name.Equals("StoolMenuObject(Clone)")){
            objectList = objectList + "null null stool null,";
        } else if(child.name.Equals("StumpMenuObject(Clone)")){
            objectList = objectList + "null null stump null,";
        } else if(child.name.Equals("TableMenuObject(Clone)")){
            objectList = objectList + "null null table null,";
        } else if(child.name.Equals("TombstoneMenuObject(Clone)")){
            objectList = objectList + "null null tombstone null,";
        } else if(child.name.Equals("TowerMenuObject(Clone)")){
            objectList = objectList + "null null tower null,";
        } else if(child.name.Equals("TreeMenuObject(Clone)")){
            objectList = objectList + "null null tree null,";
        }
        }
        return objectList;
    }
}
