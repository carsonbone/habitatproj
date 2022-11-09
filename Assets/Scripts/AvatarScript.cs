using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarScript : MonoBehaviour
{

    public GameObject[] F_bases;
    public GameObject[] F_eyes;
    public GameObject[] F_outfits;
    public GameObject[] F_hair;

    public Color[] colors;

    public  static int[] CharArray;

    public  int    BaseChoice;
    public  int    EyeChoice;
    public  int    OutfitChoice;
    public  int    HairChoice;
    public int HairColor;

   // public ArrayList Arraylistcolors;

    public Joystick joystick;
    // Start is called before the first frame update
    void Awake()
    {


        //Here we will plug in the values from the app, which stores the avatar array

        //so this right here vvv is temp

   //     Arraylistcolors = new ArrayList()

     //   {
       //     new Color[] { Color.Red, Color.Blue, Color.Green, Color.Purple, Color.Black, Color.Aqua }
        //};


        if(SceneManager.GetActiveScene().name == "CharCreateScene")
        {
            if (CharArray == null || CharArray.Length == 0)
            {
                CharArray = new int[] { 0, 0, 0, 0, 0 };
            }

            BaseChoice = CharArray[0];
            EyeChoice = CharArray[1];
            OutfitChoice = CharArray[2];
            HairChoice = CharArray[3];
            HairColor = CharArray[4];


            //note: we will also need to store the color of the hair damn whata bummer thats gunna suck


            GameObject base1 = Instantiate(F_bases[BaseChoice], this.gameObject.transform);

            Instantiate(F_eyes[EyeChoice], base1.transform);
            Instantiate(F_outfits[OutfitChoice], base1.transform);
            GameObject temphair = Instantiate(F_hair[HairChoice], base1.transform);
            temphair.GetComponent<SpriteRenderer>().color = colors[HairColor];
        }
        




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateValues(int[] temp)
    {
        CharArray[0] = temp[0];
        CharArray[1] = temp[1];
        CharArray[2] = temp[2];
        CharArray[3] = temp[3];
        CharArray[4] = temp[4];
    }
    // a function used by the character creator scene
    public void spawn()
    {
        if (CharArray == null || CharArray.Length == 0)
        {
            CharArray = new int[] { 0, 0, 0, 0, 0 };
        }

        BaseChoice = CharArray[0];
        EyeChoice = CharArray[1];
        OutfitChoice = CharArray[2];
        HairChoice = CharArray[3];
        HairColor = CharArray[4];

        GameObject base1 = Instantiate(F_bases[BaseChoice], this.gameObject.transform);

        Instantiate(F_eyes[EyeChoice], base1.transform);
        Instantiate(F_outfits[OutfitChoice], base1.transform);
        GameObject temphair = Instantiate(F_hair[HairChoice], base1.transform);
        temphair.GetComponent<SpriteRenderer>().color = colors[HairColor];

    }
    public void ChangeAvatar(int type, int index){

        Debug.Log("Trying to change avatar");
        GameObject current = this.gameObject.transform.GetChild(0).gameObject;

        Destroy(current);


        //for type, 0=base, 1=eyes, 2=outfit, 3=hair , 4 = hair color

        GameObject base2 = null;
        GameObject hairbase = null;
        if(type == 0){base2 = Instantiate(F_bases[index],this.gameObject.transform);
        BaseChoice = index;
        CharArray[0] = index;
        }
        else{base2 = Instantiate(F_bases[BaseChoice],this.gameObject.transform);}

        if(type == 1){Instantiate(F_eyes[index], base2.transform);
            Debug.Log("Trying to change eyes");
        EyeChoice = index;
            CharArray[1] = index;
        }
        else{Instantiate(F_eyes[EyeChoice], base2.transform);}

        if(type == 2){Instantiate(F_outfits[index], base2.transform);
        OutfitChoice = index;
            CharArray[2] = index;
        }
        else{Instantiate(F_outfits[OutfitChoice], base2.transform);}

       if(type == 3){hairbase = Instantiate(F_hair[index], base2.transform);
       HairChoice = index;
            CharArray[3] = index;
        }
        else{hairbase = Instantiate(F_hair[HairChoice], base2.transform);}

       if(type == 4)
        {
            hairbase.GetComponent<SpriteRenderer>().color = colors[index];
            HairColor = index;
            CharArray[4] = index;
        }
        else { hairbase.GetComponent<SpriteRenderer>().color = colors[HairColor]; }

        base2.GetComponent<PlayerController2D>().joystick = joystick;




        //animation idea but it didnt really work so w/e

        PlayerController2D animscript = base2.GetComponent<PlayerController2D>();
        if(animscript != null ){
            Debug.Log("we found it");
            animscript.BeHappy();
        }

    }
}
