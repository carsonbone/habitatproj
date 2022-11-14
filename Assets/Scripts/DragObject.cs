using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragObject : MonoBehaviour
{


    

    //if true, this is our place and we can touch stuff

    private GameObject obj; //the object we are touching
    private Color objcolor; //the color of the object we are touching
    public GameObject handler;
    public GameObject Container;
    public GameObject testDelete;
    public GameObject testRotate;
    public Grid grid; //the game grid layout

    public GameObject smoke;



    //stuff for spawning objects
    private GameObject tempObj; //the object in the scroll view
    private GameObject spawnedObj; //the new prefab that's been spawned
    private bool JustSpawned;
    private UIObject uiscript;
    private AddToMenu menuScript;

    public int myHouse;

    private bool touchingJoystick;

    private bool validCheck;
    // Start is called before the first frame update
   
    void Awake()
    {
        //myHouse = true;
    }
    void Start()
    {
        menuScript = Container.GetComponent<AddToMenu>();
        JustSpawned = false;
        validCheck = true;
        touchingJoystick = false;
        string CurName = SceneManager.GetActiveScene().name;
        Debug.Log(CurName);
        
    }

    // Update is called once per frame
    void Update()
    {

        touchingJoystick = false;

        if(Input.touchCount > 0 && myHouse == 1) //where 0 means no fingers on the phone, 1 means one finger etc
        {
            Touch touch = Input.GetTouch(0); // the touch input being made, specifically the most recent one

            switch (touch.phase) // the "phase" of the touch, like if it just started, if its ending etc
            {
                case TouchPhase.Began: //The touch started
                    Debug.Log("Touch Start");

                    PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
                    eventDataCurrentPosition.position = new Vector2(touch.position.x, touch.position.y);
                    List<RaycastResult> results = new List<RaycastResult>();
                    EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

                    
                    if(results.Count > 0)
                    {
                        if (results[0].gameObject.name.Equals("Handle"))
                        {
                            Debug.Log("touching joystick");
                            touchingJoystick = true;
                        }
                        if(results.Count >= 2)
                        {
                            if (results[1].gameObject.name.Equals("Handle"))
                            {
                                Debug.Log("touching joystick");
                                touchingJoystick = true;
                            }

                        }
                        if (results[0].gameObject.CompareTag("SceneDone"))
                        {
                            results[0].gameObject.GetComponent<SceneSwitch>().Switch();
                            Debug.Log("DragObject is calling switch");
                        }
                        if (results[0].gameObject.CompareTag("UIArrow"))
                        {
                            results[0].gameObject.GetComponent<ArrowScript>().Pressed();
                            Debug.Log("arrow press");
                        }
                        if (results[0].gameObject.CompareTag("UIButton"))
                        {
                            Debug.Log("touching UI button");
                            results[0].gameObject.GetComponent<UIButtons>().FlipEnable();
                        }
                        if (results[0].gameObject.CompareTag("ObjectUI"))
                        {
                            bool deselect = false; //if we are trying to deselect the object, this will be true

                            if (tempObj != null)
                            {
                                if (tempObj == GameObject.Find(results[0].gameObject.name))
                                {
                                    //we are choosing the same object again, so we probably want to deselect it
                                    deselect = true;
                                    JustSpawned = false;
                                }

                                uiscript = tempObj.GetComponent<UIObject>();
                                tempObj.GetComponent<Image>().color = Color.white;
                                tempObj = null;

                            }

                            if (!deselect) { 
                                Debug.Log("touch ui OBJECT"); //we are hitting a placeableobject in the ui
                                Debug.Log(results[0].gameObject.name);
                                tempObj = GameObject.Find(results[0].gameObject.name);

                                tempObj.GetComponent<Image>().color = Color.black;

                                JustSpawned = true;
                            }
                            
                        }
                    }


                    RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    //Make a raycast onto where our finger is touching, relative to the Camera

                    GameObject deleteButton = GameObject.Find("DeleteButton");
                    GameObject rotateButton = GameObject.Find("RotateButton");
                    ///running finds every frame can be bad for performance

                    if (!hitInfo && JustSpawned && results.Count == 0)
                    {
                        //we are not touching anything, and we want to spawn our object
                        Debug.Log("trying to spawn");
                        uiscript = tempObj.GetComponent<UIObject>();
                        spawnedObj = uiscript.GiveObj();
                        obj = spawnedObj;
                        tempObj.GetComponent<Image>().color = Color.white;
                        uiscript.DecreaseAmount();
                        tempObj = null;
                        uiscript = null;
                    }

                    if ((hitInfo || JustSpawned )&& !touchingJoystick) //we are touching something, don't know what
                        //OR, we just spawned an object with this touch

                    {
                        GameObject objcheck = null;

                        Debug.Log("Check: " + touchingJoystick);


                        if (!JustSpawned)//if this object already existed
                            {

                                objcheck = hitInfo.transform.gameObject;
                            }

                            if (JustSpawned == true)
                            {
                                objcheck = obj;
                                Vector3 touchedPos2 = Camera.main.ScreenToWorldPoint(touch.position);
                                obj.transform.position = new Vector3(touchedPos2.x, touchedPos2.y, 0);

                        }

                        


                        Debug.Log(objcheck.name);





                        if (objcheck.CompareTag("PlaceableObject"))  //We are touching an object that is meant to be moved
                            //ie, not a player or ground tile
                        {
                            if (!JustSpawned) { obj = hitInfo.transform.gameObject; } //Now, set this variable to the GameObject we are touching
                            JustSpawned = false; //the object now exists, we dont need this bool anymore
                            Debug.Log(obj.name);
                            Debug.Log("obj found");
                            Color tempred = new Color(1f, 0, 0);
                            if (obj.GetComponent<SpriteRenderer>().material.color != tempred)
                            {
                                objcolor = obj.GetComponent<SpriteRenderer>().material.color;  //change the color of the object
                            }
                            

                            obj.GetComponent<SpriteRenderer>().material.color = new Color(0, 150, 150); //just a temp color
                            //will evantually change this to a specific material, something that highlights the object and makes it
                            //slightly transparent instead of just changing the whole color
                            Component[] colliders;

                            colliders = obj.GetComponents(typeof(BoxCollider2D));

                            foreach (BoxCollider2D collider in colliders)
                            {
                                collider.isTrigger = true;
                            } //turn off the collider while we are moving the object
                            //just kidding, actually now we just set this as a trigger, meaning it wont physically collide
                            //but it still has the box to do checks on

                        }
                        if(objcheck.name == "DeleteButton"){

                            if (deleteButton.transform.parent.name.Equals("testskull(Clone)"))
                            {
                                menuScript.addToMenu("skull");
                            }
                            else if (deleteButton.transform.parent.name.Equals("TestFountain(Clone)"))
                            {
                                menuScript.addToMenu("fountain");
                            }
                            else if (deleteButton.transform.parent.name.Equals("testdoor(Clone)"))
                            {
                                menuScript.addToMenu("door");
                            }
                            else if (deleteButton.transform.parent.name.Equals("testBench(Clone)"))
                            {
                                menuScript.addToMenu("bench");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Bush(Clone)"))
                            {
                                menuScript.addToMenu("bush");
                            }
                            else if (deleteButton.transform.parent.name.Equals("DogHouse(Clone)"))
                            {
                                menuScript.addToMenu("doghouse");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Fence(Clone)"))
                            {
                                menuScript.addToMenu("fence");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Fern(Clone)"))
                            {
                                menuScript.addToMenu("fern");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Flag(Clone)"))
                            {
                                menuScript.addToMenu("flag");
                            }
                            else if (deleteButton.transform.parent.name.Equals("FruitBox(Clone)"))
                            {
                                menuScript.addToMenu("fruitbox");
                            }
                            else if (deleteButton.transform.parent.name.Equals("House(Clone)"))
                            {
                                menuScript.addToMenu("house");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Log(Clone)"))
                            {
                                menuScript.addToMenu("log");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Rock(Clone)"))
                            {
                                menuScript.addToMenu("rock");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Sign(Clone)"))
                            {
                                menuScript.addToMenu("sign");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Stand(Clone)"))
                            {
                                menuScript.addToMenu("stand");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Statue(Clone)"))
                            {
                                menuScript.addToMenu("statue");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Stool(Clone)"))
                            {
                                menuScript.addToMenu("stool");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Stump(Clone)"))
                            {
                                menuScript.addToMenu("stump");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Table(Clone)"))
                            {
                                menuScript.addToMenu("table");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Tombstone(Clone)"))
                            {
                                menuScript.addToMenu("tombstone");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Tower(Clone)"))
                            {
                                menuScript.addToMenu("tower");
                            }
                            else if (deleteButton.transform.parent.name.Equals("Tree(Clone)"))
                            {
                                menuScript.addToMenu("tree");
                            }





                            Destroy(deleteButton.transform.parent.gameObject);
                        }
                        if(objcheck.name == "RotateButton"){
                            Vector3 rotation = new Vector3(0, 0, -90);
                            Vector3 inverseRotation = new Vector3(0, 0, 90);
                            deleteButton.transform.parent.transform.Rotate(rotation);
                        }
                    }
                    if(deleteButton != null){
                        Destroy(deleteButton);
                    }
                    if(rotateButton != null){
                        Destroy(rotateButton);
                    }
                    break;

                case TouchPhase.Moved: //The touch is moving
                    Debug.Log("Touch Move");
                    Vector3 touchedPos = Camera.main.ScreenToWorldPoint(touch.position); //basically the position of our finger
                    //instead of relative to the camera it makes it relative to the game world

                   
                       // Debug.Log(obj.GetComponent<ObjectInfo>().isValid);

                        if(obj.GetComponent<ObjectInfo>().isValid == true)
                        {
                            obj.GetComponent<SpriteRenderer>().material.color = new Color(0, 150, 150);
                        }
                        if (obj.GetComponent<ObjectInfo>().isValid == false)
                        {
                            obj.GetComponent<SpriteRenderer>().material.color = new Color(1f, 0 , 0);
                        }
                        obj.transform.position = new Vector3(touchedPos.x, touchedPos.y, 0);  //make the object we are touching follow our finger
                    
                    break;

                case TouchPhase.Ended: //The touch has ended, ie the finger lifted off the phone

                    // this is if the location is NOT valid

                    if (obj.GetComponent<ObjectInfo>().isValid == false)
                    {
                        obj.GetComponent<SpriteRenderer>().material.color = new Color(1f, 0, 0);

                    }


                    else { 
                    
                        // this is if the location is valid
                        Vector3Int cellPosition = grid.WorldToCell(obj.transform.position);  //Get the position of the closest cell the object is in
                        obj.transform.position = grid.GetCellCenterWorld(cellPosition); //Place the object in the center of that cell
                        Renderer rend = obj.GetComponent<Renderer>();

                        Vector3 deletePosition = rend.bounds.max;
                        deleteButton = Instantiate(testDelete, deletePosition, Quaternion.identity, obj.transform);
                        deleteButton.name = "DeleteButton";
                        var trueScale = new Vector3(0.0463154f / obj.transform.lossyScale.x, 0.04247932f / obj.transform.lossyScale.y, 1 / obj.transform.lossyScale.z);
                        deleteButton.transform.localScale = trueScale;
                        Vector3 rotatePosition = new Vector3(rend.bounds.min.x, rend.bounds.max.y, rend.bounds.max.z) + new Vector3(-0.1f, 0.1f,0f);
                        rotateButton = Instantiate(testRotate, rotatePosition, Quaternion.identity, obj.transform);
                        trueScale = new Vector3(0.334176f / obj.transform.lossyScale.x, 0.3087065f / obj.transform.lossyScale.y, 1 / obj.transform.lossyScale.z);
                        rotateButton.transform.localScale = trueScale;
                        rotateButton.name = "RotateButton";

                        Instantiate(smoke, obj.transform.position, Quaternion.identity);

                        obj.GetComponent<SpriteRenderer>().material.color = objcolor; //return the object to its normal color

                        Component[] colliders;

                        colliders = obj.GetComponents(typeof(BoxCollider2D));

                        foreach (BoxCollider2D collider in colliders)
                        {
                            collider.isTrigger = false;
                        } //turn back on the box collider, as the object is placed now
                        //just kidding again, now we unset it as a trigger, so that it has actual collision

                        obj = null; //clear the obj variable, so it can be set to a new object on the next touch
                    }

                    //////////////
                    /////
                    ///
                    //Eventually this is where we will update the new position of the object into whatever 
                    //array or file we use to save
                    //object positions
                    //
                    break;
            }
            
        }
    }
}
