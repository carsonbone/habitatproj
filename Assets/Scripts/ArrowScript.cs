using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    public AvatarScript Ascript;
    public ArrowScript OtherScript;

    public int type; 
    public int index;
    public bool incdec;
    //where true means increase

    // Start is called before the first frame update
    void Start()
    {
        
            if(type == 0){
                index = Ascript.BaseChoice;
            }
            if(type == 1){
                index = Ascript.EyeChoice;
            }
            if(type == 2){
                index = Ascript.OutfitChoice;
            }
            if(type == 3){
                index = Ascript.HairChoice;
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed(){

        Debug.Log(this.gameObject.name + " Has been pressed");
        if(incdec){
            if(type == 0){
                index = (index+1)%8;
                
            }
            if(type == 1){
                index = (index+1)%7;
            }
            if(type == 2){
                index = (index+1)%6;
            }
            if(type == 3){
                index = (index+1)%13;
            }
        }
        else{
            if(type == 0){
                index = (index-1)%8;
                if(index < 0) { index = 7; }
            }
            if(type == 1){
                index = (index-1)%7;
                if (index < 0) { index = 6; }
            }
            if(type == 2){
                index = (index-1)%6;
                if (index < 0) { index = 5; }
            }
            if(type == 3){
                index = (index-1)%13;
                if (index < 0) { index = 12; }
            }
        }


        OtherScript.index = index;
        Ascript.ChangeAvatar(type, index);
    }


    
}
