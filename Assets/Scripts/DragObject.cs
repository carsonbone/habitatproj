using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour
{


    private GameObject obj; //the object we are touching
    private Color objcolor; //the color of the object we are touching
    public GameObject handler;
    public GameObject testDelete;
    public GameObject testRotate;
    public Grid grid; //the game grid layout



    //stuff for spawning objects
    private GameObject spawnedObj;
    private bool JustSpawned;
    private UIObject uiscript;

    // Start is called before the first frame update
   
    void Start()
    {
        JustSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        


        if(Input.touchCount > 0) //where 0 means no fingers on the phone, 1 means one finger etc
        {
            Touch touch = Input.GetTouch(0); // the touch input being made, specifically the most recent one

            switch (touch.phase) // the "phase" of the touch, like if it just started, if its ending etc
            {
                case TouchPhase.Began: //The touch started


                    PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
                    eventDataCurrentPosition.position = new Vector2(touch.position.x, touch.position.y);
                    List<RaycastResult> results = new List<RaycastResult>();
                    EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

                    if(results.Count > 0)
                    {
                        if (results[0].gameObject.CompareTag("UIButton"))
                        {
                            Debug.Log("touching UI button");
                            results[0].gameObject.GetComponent<UIButtons>().FlipEnable();
                        }
                        if (results[0].gameObject.CompareTag("ObjectUI"))
                        {
                            Debug.Log("touch ui OBJECT"); //we are hitting a placeableobject in the ui
                            Debug.Log(results[0].gameObject.name);
                            GameObject tempobj = GameObject.Find(results[0].gameObject.name);
                            uiscript = tempobj.GetComponent<UIObject>();
                            spawnedObj = uiscript.GiveObj();
                            JustSpawned = true;
                            obj = spawnedObj;
                            
                        }
                    }


                    RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    //Make a raycast onto where our finger is touching, relative to the Camera

                    GameObject deleteButton = GameObject.Find("DeleteButton");
                    GameObject rotateButton = GameObject.Find("RotateButton");
                    ///running finds every frame can be bad for performance
                    
                    if (hitInfo || JustSpawned ) //we are touching something, don't know what
                        //OR, we just spawned an object with this touch

                    {
                        GameObject objcheck = null;
                        if(!JustSpawned)//if this object already existed
                        {

                            objcheck = hitInfo.transform.gameObject;
                        }
                        else
                        {
                            objcheck = obj;
                        }

                        Debug.Log(objcheck.name);
                        if (objcheck.CompareTag("PlaceableObject"))  //We are touching an object that is meant to be moved
                            //ie, not a player or ground tile
                        {
                            if (!JustSpawned) { obj = hitInfo.transform.gameObject; } //Now, set this variable to the GameObject we are touching
                            JustSpawned = false; //the object now exists, we dont need this bool anymore
                            Debug.Log(obj.name);
                            Debug.Log("obj found");
                            objcolor = obj.GetComponent<SpriteRenderer>().material.color;  //change the color of the object

                            obj.GetComponent<SpriteRenderer>().material.color = new Color(0, 150, 150); //just a temp color
                            //will evantually change this to a specific material, something that highlights the object and makes it
                            //slightly transparent instead of just changing the whole color

                            obj.GetComponent<BoxCollider2D>().enabled = false; //turn off the collider while we are moving the object

                        }
                        if(objcheck.name == "DeleteButton"){
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

                    Vector3 touchedPos = Camera.main.ScreenToWorldPoint(touch.position); //basically the position of our finger
                    //instead of relative to the camera it makes it relative to the game world

                    obj.transform.position = new Vector3(touchedPos.x,touchedPos.y,0);  //make the object we are touching follow our finger
                    break;

                case TouchPhase.Ended: //The touch has ended, ie the finger lifted off the phone

                    Vector3Int cellPosition = grid.WorldToCell(obj.transform.position);  //Get the position of the closest cell the object is in
                    obj.transform.position = grid.GetCellCenterWorld(cellPosition); //Place the object in the center of that cell
                    Vector3 deletePosition = obj.transform.position + new Vector3(1f,1f,0f);
                    deleteButton = Instantiate(testDelete, deletePosition, Quaternion.identity, obj.transform);
                    deleteButton.name = "DeleteButton";
                    Vector3 rotatePosition = obj.transform.position + new Vector3(-1f,1.1f,0f);
                    rotateButton = Instantiate(testRotate, rotatePosition, Quaternion.identity, obj.transform);
                    rotateButton.name = "RotateButton";

                    obj.GetComponent<SpriteRenderer>().material.color = objcolor; //return the object to its normal color

                    obj.GetComponent<BoxCollider2D>().enabled = true; //turn back on the box collider, as the object is placed now

                    obj = null; //clear the obj variable, so it can be set to a new object on the next touch


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
