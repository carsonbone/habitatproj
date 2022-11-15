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
    private UIObject objectScript;
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
        Debug.Log("Test");
        if(objectName.Equals("skull")){
            foreach(Transform child in transform){
                if(child.name.Equals("SkullMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UISkull, this.transform);
            objectScript = this.transform.Find("SkullMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("bench")){
            foreach(Transform child in transform){
                if(child.name.Equals("BenchMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIBench, this.transform);
            objectScript = this.transform.Find("BenchMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("fountain")){
            foreach(Transform child in transform){
                if(child.name.Equals("FountainMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIFountain, this.transform);
            objectScript = this.transform.Find("FountainMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("door")){
            foreach(Transform child in transform){
                if(child.name.Equals("DoorMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIDoor, this.transform);
            objectScript = this.transform.Find("DoorMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("bush")){
            foreach(Transform child in transform){
                if(child.name.Equals("BushMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIBush, this.transform);
            objectScript = this.transform.Find("BushMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("doghouse")){
            foreach(Transform child in transform){
                if(child.name.Equals("DogHouseMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIDogHouse, this.transform);
            objectScript = this.transform.Find("DogHouseMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("fence")){
            foreach(Transform child in transform){
                if(child.name.Equals("FenceMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIFence, this.transform);
            objectScript = this.transform.Find("FenceMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("fern")){
            foreach(Transform child in transform){
                if(child.name.Equals("FernMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIFern, this.transform);
            objectScript = this.transform.Find("FernMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("flag")){
            foreach(Transform child in transform){
                if(child.name.Equals("FlagMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIFlag, this.transform);
            objectScript = this.transform.Find("FlagMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("fruitbox")){
            foreach(Transform child in transform){
                if(child.name.Equals("FruitBoxMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIFruitBox, this.transform);
            objectScript = this.transform.Find("FruitBoxMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        }  else if(objectName.Equals("house")){
            foreach(Transform child in transform){
                if(child.name.Equals("HouseMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIHouse, this.transform);
            objectScript = this.transform.Find("HouseMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("log")){
            foreach(Transform child in transform){
                if(child.name.Equals("LogMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UILog, this.transform);
            objectScript = this.transform.Find("LogMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("rock")){
            foreach(Transform child in transform){
                if(child.name.Equals("RockMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIRock, this.transform);
            objectScript = this.transform.Find("RockMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        }  else if(objectName.Equals("sign")){
            foreach(Transform child in transform){
                if(child.name.Equals("SignMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UISign, this.transform);
            objectScript = this.transform.Find("SignMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("stand")){
            foreach(Transform child in transform){
                if(child.name.Equals("StandMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIStand, this.transform);
            objectScript = this.transform.Find("StandMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("statue")){
            foreach(Transform child in transform){
                if(child.name.Equals("StatueMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIStatue, this.transform);
            objectScript = this.transform.Find("StatueMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("stool")){
            foreach(Transform child in transform){
                if(child.name.Equals("StoolMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIStool, this.transform);
            objectScript = this.transform.Find("StoolMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("stump")){
            foreach(Transform child in transform){
                if(child.name.Equals("StumpMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UIStump, this.transform);
            objectScript = this.transform.Find("StumpMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("table")){
            foreach(Transform child in transform){
                if(child.name.Equals("TableMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UITable, this.transform);
            objectScript = this.transform.Find("TableMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("tombstone")){
            foreach(Transform child in transform){
                if(child.name.Equals("TombstoneMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UITombstone, this.transform);
            objectScript = this.transform.Find("TombstoneMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("tower")){
            foreach(Transform child in transform){
                if(child.name.Equals("TowerMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UITower, this.transform);
            objectScript = this.transform.Find("TowerMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        } else if(objectName.Equals("tree")){
            foreach(Transform child in transform){
                if(child.name.Equals("TreeMenuObject(Clone)")){
                    objectScript = child.GetComponent<UIObject>();
                    objectScript.IncreaseAmount();
                    return;
                }
            }
            Instantiate(UITree, this.transform);
            objectScript = this.transform.Find("TreeMenuObject(Clone)").GetComponent<UIObject>();
            objectScript.initializeObject();
        }
    }

    public string returnObjects(){
        string objectList = "";
        foreach(Transform child in transform){
            objectScript = child.GetComponent<UIObject>();
            for(int i = 0; i < objectScript.returnAmount(); i++){
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
            
        }
        return objectList;
    }
}
