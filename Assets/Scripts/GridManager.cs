using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
    //A placeholder script that will hold info about the grid, not currently being used
{
    public GameObject waterTilePrefab;
    public GameObject groundTilePrefab;
    public GameObject groundGrid;
    public GameObject waterGrid;
    public Sprite[] sprites;
    public int[,] grid;
    private int columns = 49;
    private int rows = 49;

    private Tile[] tileArray;
    // Start is called before the first frame update
    void Start()
    {
        grid = new int[columns, rows];
        for(int i = 0; i < columns; i ++){
            for(int j = 0; j < rows; j ++){
                if(i >= 20 && j >= 20 && i <= 39 && j <= 39){
                    grid[i,j] = 1;
                } else{
                    grid[i,j] = 0;
                }
                
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
}