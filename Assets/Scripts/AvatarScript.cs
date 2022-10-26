using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarScript : MonoBehaviour
{

    public GameObject[] F_bases;
    public GameObject[] F_eyes;
    public GameObject[] F_outfits;
    public GameObject[] F_hair;


    // Start is called before the first frame update
    void Awake()
    {





        GameObject base1 = Instantiate(F_bases[0],this.gameObject.transform);

        Instantiate(F_eyes[0], base1.transform);
        Instantiate(F_outfits[0], base1.transform);
        Instantiate(F_hair[0], base1.transform);




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
