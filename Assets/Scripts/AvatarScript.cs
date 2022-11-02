using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarScript : MonoBehaviour
{

    public GameObject[] F_bases;
    public GameObject[] F_eyes;
    public GameObject[] F_outfits;
    public GameObject[] F_hair;


    public int[] CharArray;

    public  int    BaseChoice;
    public  int    EyeChoice;
    public  int    OutfitChoice;
    public  int    HairChoice;

    public Joystick joystick;
    // Start is called before the first frame update
    void Awake()
    {


        //Here we will plug in the values from the app, which stores the avatar array

        //so this right here vvv is temp

        

        //note: we will also need to store the color of the hair damn whata bummer thats gunna suck


        GameObject base1 = Instantiate(F_bases[BaseChoice],this.gameObject.transform);

        Instantiate(F_eyes[EyeChoice], base1.transform);
        Instantiate(F_outfits[OutfitChoice], base1.transform);
        Instantiate(F_hair[HairChoice], base1.transform);




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // a function used by the character creator scene

    public void ChangeAvatar(int type, int index){

        Debug.Log("Trying to change avatar");
        GameObject current = this.gameObject.transform.GetChild(0).gameObject;

        Destroy(current);


        //for type, 0=base, 1=eyes, 2=outfit, 3=hair

        GameObject base2 = null;
        if(type == 0){base2 = Instantiate(F_bases[index],this.gameObject.transform);
        BaseChoice = index;}
        else{base2 = Instantiate(F_bases[BaseChoice],this.gameObject.transform);}

        if(type == 1){Instantiate(F_eyes[index], base2.transform);
            Debug.Log("Trying to change eyes");
        EyeChoice = index;}
        else{Instantiate(F_eyes[EyeChoice], base2.transform);}

        if(type == 2){Instantiate(F_outfits[index], base2.transform);
        OutfitChoice = index;}
        else{Instantiate(F_outfits[OutfitChoice], base2.transform);}

       if(type == 3){Instantiate(F_hair[index], base2.transform);
       HairChoice = index;}
        else{Instantiate(F_hair[HairChoice], base2.transform);}

        base2.GetComponent<PlayerController2D>().joystick = joystick;


        //animation idea but it didnt really work so w/e

        PlayerController2D animscript = base2.GetComponent<PlayerController2D>();
        if(animscript != null ){
            Debug.Log("we found it");
            animscript.BeHappy();
        }

    }
}
