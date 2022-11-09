using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
    //A placeholder script that will hold info about the grid, not currently being used
{
    private AndroidJavaObject activity;
    public GameObject Container;
    public GameObject waterTilePrefab;
    public GameObject groundTilePrefab;
    public GameObject groundGrid;
    public GameObject waterGrid;
    public GameObject testSkull;
    public GameObject testBench;
    public GameObject testDoor;
    public GameObject testFountain;

    public AvatarScript avaScript;
    public Sprite[] sprites;
    public int[,] grid;
    public int[,] rotationGrid;
    public string[,] furnitureGrid;
    private AddToMenu menuScript;
    private int columns = 50;
    private int rows = 50;

    private Tile[] tileArray;
    // Start is called before the first frame update
    void Start()
    {
        menuScript = Container.GetComponent<AddToMenu>();
        //This block is for when it's connected to the android app
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        InvokeRepeating("SavePositions", 15.0f, 15.0f);
        InvokeRepeating("SaveAvatar", 15.0f, 15.0f);
#if UNITY_ANDROID
            activity.CallStatic("unityReady", new object[] {"Unity Ready"});
#endif

        //This block is specifically for testing without android input, activate if not connected to the app
        // grid = new int[columns, rows];
        // for(int i = 0; i < columns; i ++){
        //     for(int j = 0; j < rows; j ++){
        //         if(i >= 15 && j >= 15 && i <= 34 && j <= 34){
        //             grid[i,j] = 1;
        //         } else{
        //             grid[i,j] = 0;
        //         }

        //     } 
        // }
        // InvokeRepeating("SavePositions", 15.0f, 15.0f);
        // for(int i = 0; i < columns; i ++){
        //     for(int j = 0; j < rows; j ++){
        //         if(i > 0 && j > 0 && i < (rows - 1) && j < (columns - 1) && grid[i,j] > 0){
        //             grid[i,j] = IsEdge(i,j);
        //         } 
        //         spawnTile(i, j);
        //     } 
        // } 
        // furnitureGrid = new string[columns, rows];
        // rotationGrid = new int[columns, rows];
        // for(int i = 0; i < columns; i ++){
        //     for(int j = 0; j < rows; j ++){
        //         furnitureGrid[i,j] = " ";
        //         rotationGrid[i,j] = 0;
        //     } 
        // }
        // furnitureGrid[20,20] = "skull";
        // rotationGrid[20,20] = 2;
        // furnitureGrid[30,30] = "fountain";
        // rotationGrid[30,30] = 0;
        // furnitureGrid[20,30] = "bench";
        // rotationGrid[20,30] = 3;
        // furnitureGrid[30,20] = "door";
        // rotationGrid[30,20] = 1;
        // spawnFurniture("25 25 fountain 0,null null skull null");
        // for(int i = 0; i < columns; i ++){
        //     for(int j = 0; j < rows; j ++){
        //         if(furnitureGrid[i,j].Equals("skull")){
        //             Instantiate(testSkull, new Vector3(i+0.5f, j+0.5f), Quaternion.Euler(0, 0, 90*rotationGrid[i,j]));
        //         } else if(furnitureGrid[i,j].Equals("fountain")){
        //             Instantiate(testFountain, new Vector3(i+0.5f, j+0.5f), Quaternion.Euler(0, 0, 90*rotationGrid[i,j]));
        //         } else if(furnitureGrid[i,j].Equals("bench")){
        //             Instantiate(testBench, new Vector3(i+0.5f, j+0.5f), Quaternion.Euler(0, 0, 90*rotationGrid[i,j]));
        //         } else if(furnitureGrid[i,j].Equals("door")){
        //             Instantiate(testDoor, new Vector3(i+0.5f, j+0.5f), Quaternion.Euler(0, 0, 90*rotationGrid[i,j]));
        //         } //Add the rest of the furniture here
        //     } 
        // }
        // menuScript.addToMenu("fountain");
    }
    
    private void SavePositions(){
        var furnitureList = GameObject.FindGameObjectsWithTag("PlaceableObject");
        string furnitureInformation = "";
        var objectCount = furnitureList.Length;
        foreach(var furniture in furnitureList){
            furnitureInformation = furnitureInformation + (furniture.transform.position.x - 0.5f) + " ";
            furnitureInformation = furnitureInformation + (furniture.transform.position.y - 0.5f) + " ";
            Debug.Log(furniture.name);
            if(furniture.name.Equals("testskull(Clone)")){
                furnitureInformation = furnitureInformation + "skull" + " ";
            } else if(furniture.name.Equals("testdoor(Clone)")){
                furnitureInformation = furnitureInformation + "door" + " ";
            } else if(furniture.name.Equals("testBench(Clone)")){
                furnitureInformation = furnitureInformation + "bench" + " ";
            } else if(furniture.name.Equals("TestFountain(Clone)")){
                furnitureInformation = furnitureInformation + "fountain" + " ";
            }
            furnitureInformation = furnitureInformation + (furniture.transform.rotation.eulerAngles.z/90) + ",";
        }
        furnitureInformation = furnitureInformation + menuScript.returnObjects();
        Debug.Log(furnitureInformation);
        #if UNITY_ANDROID
            activity.CallStatic("savePositions", new object[] {furnitureInformation});
        #endif
    }
    public void SpawnAvatar(string avaValues)
    {
        string[] splitAvaValues = avaValues.Split(" ");
        int[] returnValues = new int[splitAvaValues.Length];
        for(int i= 0; i < splitAvaValues.Length; i++)
        {
            returnValues[i] = Int32.Parse(splitAvaValues[i]);
        }
        avaScript.updateValues(returnValues);
        avaScript.spawn();
    }
    public void SaveAvatar()
    {
        int[] temp = AvatarScript.CharArray;
        string avaInfo = "";

        for( int i = 0; i < temp.Length; i++)
        {
            avaInfo = avaInfo + temp[i].ToString() + " ";
        }

        #if UNITY_ANDROID
            activity.CallStatic("saveAvatar", new object[] {avaInfo});
        #endif 


    }
    public void spawnMap(string gridValues){

        grid = new int[columns, rows];
        string[] splitGridValues = gridValues.Split(",");
        for(int i = 0; i < splitGridValues.Length; i++){
            string[] splitValues = splitGridValues[i].Split(" ");
            for(int j = 0; j < splitValues.Length; j++){
                grid[Int32.Parse(splitValues[0]), Int32.Parse(splitValues[1])] = Int32.Parse(splitValues[2]);
            }
        }
        for(int i = 0; i < columns; i ++){
            for(int j = 0; j < rows; j ++){
                if(i > 0 && j > 0 && i < (rows - 1) && j < (columns - 1) && grid[i,j] > 0){
                    grid[i,j] = IsEdge(i,j);
                } 
                spawnTile(i, j);
            } 
        }
        
         activity.CallStatic("mapSpawned", new object[] {"Map Spawned"});
    }

    public void spawnFurniture(string furnitureValues){
        furnitureGrid = new string[columns, rows];
        rotationGrid = new int[columns, rows];
        string[] splitGridValues = furnitureValues.Split(",");
        for(int i = 0; i < columns; i ++){
            for(int j = 0; j < rows; j ++){
                furnitureGrid[i,j] = " ";
                rotationGrid[i,j] = 0;
            } 
        }
        for(int i = 0; i < splitGridValues.Length; i++){
            Debug.Log(splitGridValues[i]);
            string[] splitValues = splitGridValues[i].Split(" ");
            Debug.Log(splitValues[0]);
            Debug.Log(splitValues[1]);
            Debug.Log(splitValues[2]);
            Debug.Log(splitValues[3]);
            if(!splitValues[0].Equals("null") && !splitValues[1].Equals("null")){
                furnitureGrid[Int32.Parse(splitValues[0]), Int32.Parse(splitValues[1])] = splitValues[2];
                rotationGrid[Int32.Parse(splitValues[0]), Int32.Parse(splitValues[1])] = Int32.Parse(splitValues[3]);
            } else {
                menuScript.addToMenu(splitValues[2]);
            }
        }
        for(int i = 0; i < columns; i ++){
            for(int j = 0; j < rows; j ++){
                if(furnitureGrid[i,j].Equals("skull")){
                    Instantiate(testSkull, new Vector3(i+0.5f, j+0.5f), Quaternion.Euler(0, 0, 90*rotationGrid[i,j]));
                } else if(furnitureGrid[i,j].Equals("fountain")){
                    Instantiate(testFountain, new Vector3(i+0.5f, j+0.5f), Quaternion.Euler(0, 0, 90*rotationGrid[i,j]));
                } else if(furnitureGrid[i,j].Equals("bench")){
                    Instantiate(testBench, new Vector3(i+0.5f, j+0.5f), Quaternion.Euler(0, 0, 90*rotationGrid[i,j]));
                } else if(furnitureGrid[i,j].Equals("door")){
                    Instantiate(testDoor, new Vector3(i+0.5f, j+0.5f), Quaternion.Euler(0, 0, 90*rotationGrid[i,j]));
                } //Add the rest of the furniture here
            } 
        }
        activity.CallStatic("furnitureSpawned", new object[] { "Furniture Spawned" });
    }

    // Update is called once per frame
    private void spawnTile(int x, int y)
    {
        SpriteRenderer sr = new SpriteRenderer();
        if(grid[x,y] > 0){
            sr = Instantiate(groundTilePrefab, new Vector3(x+0.5f, y+0.5f), Quaternion.identity,groundGrid.transform).GetComponent<SpriteRenderer>();
            sr.name = ("X: " + x + "Y: " + y);
            sr.sprite = sprites[grid[x,y]];
        } else{
            sr = Instantiate(waterTilePrefab, new Vector3(x+0.5f, y+0.5f), Quaternion.identity,waterGrid.transform).GetComponent<SpriteRenderer>();
            sr.name = ("X: " + x + "Y: " + y);
        }
        
        
    }

    private int IsEdge(int x, int y){
        Debug.Log(grid[x + 1,y] == 0 && grid[x,y+1] > 0 && grid[x-1, y] > 0 && grid[x,y-1] > 0);
        if(grid[x + 1,y] > 0 && grid[x,y+1] > 0 && grid[x-1, y] > 0 && grid[x,y-1] > 0 && grid[x + 1,y + 1] > 0 && grid[x - 1,y - 1] > 0 && grid[x-1, y+1] > 0 && grid[x + 1,y-1] > 0){
            return 1;
        } else if(grid[x + 1,y] > 0 && grid[x,y+1] > 0 && grid[x-1, y] > 0 && grid[x,y-1] > 0 && grid[x + 1,y + 1] > 0 && grid[x - 1,y - 1] > 0 && grid[x-1, y+1] == 0 && grid[x + 1,y-1] > 0){
            return 2;
        } else if(grid[x + 1,y] > 0 && grid[x,y+1] == 0 && grid[x-1, y] > 0 && grid[x,y-1] > 0){
            return 3;
        } else if(grid[x + 1,y] > 0 && grid[x,y+1] > 0 && grid[x-1, y] > 0 && grid[x,y-1] > 0 && grid[x + 1,y + 1] == 0 && grid[x - 1,y - 1] > 0 && grid[x-1, y+1] > 0 && grid[x + 1,y-1] > 0){
            return 4;
        } else if(grid[x + 1,y] == 0 && grid[x,y+1] > 0 && grid[x-1, y] > 0 && grid[x,y-1] > 0){
            return 5;
        } else if(grid[x + 1,y] > 0 && grid[x,y+1] > 0 && grid[x-1, y] > 0 && grid[x,y-1] > 0 && grid[x + 1,y + 1] > 0 && grid[x - 1,y - 1] > 0 && grid[x-1, y+1] > 0 && grid[x + 1,y-1] == 0){
            return 6;
        } else if(grid[x + 1,y] > 0 && grid[x,y+1] > 0 && grid[x-1, y] > 0 && grid[x,y-1] == 0){
            return 7;
        } else if(grid[x + 1,y] > 0 && grid[x,y+1] > 0 && grid[x-1, y] > 0 && grid[x,y-1] > 0 && grid[x + 1,y + 1] > 0 && grid[x - 1,y - 1] == 0 && grid[x-1, y+1] > 0 && grid[x + 1,y-1] > 0){
            return 8;
        } else if(grid[x + 1,y] > 0 && grid[x,y+1] > 0 && grid[x-1, y] == 0 && grid[x,y-1] > 0){
            return 9;
        } else if(grid[x + 1,y] > 0 && grid[x,y+1] == 0 && grid[x-1, y] == 0 && grid[x,y-1] > 0 && grid[x-1, y+1] == 0 && grid[x + 1,y-1] > 0){
            return 10;
        } else if(grid[x + 1,y] == 0 && grid[x,y+1] == 0 && grid[x-1, y] > 0 && grid[x,y-1] > 0 && grid[x + 1,y + 1] == 0 && grid[x - 1,y - 1] > 0){
            return 11;
        } else if(grid[x + 1,y] == 0 && grid[x,y+1] > 0 && grid[x-1, y] > 0 && grid[x,y-1] == 0 && grid[x-1, y+1] > 0 && grid[x + 1,y-1] == 0){
            return 12;
        } else if(grid[x + 1,y] > 0 && grid[x,y+1] > 0 && grid[x-1, y] == 0 && grid[x,y-1] == 0 && grid[x + 1,y + 1] > 0 && grid[x - 1,y - 1] == 0){
            return 13;
        }
    return 1;
    }

    public void reloadTest(string temp)
    {
        Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name); 
    }
    public void quitTest(string temp)
    {
        Application.Quit();
    }
}