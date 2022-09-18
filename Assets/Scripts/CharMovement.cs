using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    private Rigidbody2D RB; //The rigidbody of our player, what actually is moving

    private Animator anim; //What animates our player sprite

    public Joystick joystick; //our joystick object

    [SerializeField] private float speed;



    //ints we use to find out where the joystick is going
    int horizontalMove = 0;
    int verticalMove = 0;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        

        //a lot of if statements,
        //which basically convert the joystick placement to ints describing player movement
        //ie if horimove and vertmove == 1, up right
        //if horimove == 1 and vertmove == -1, down right

        if (joystick.Horizontal >= .2f)
        {
            horizontalMove = 1;
        }
        if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = -1;
        }
        if (joystick.Vertical >= .2f)
        {
            verticalMove = 1;
        }
        if (joystick.Vertical <= -.2f)
        {
            verticalMove = -1;
        }
        if(Mathf.Abs(joystick.Vertical) <.2f)
        {
            verticalMove = 0;
        }
        if(Mathf.Abs(joystick.Horizontal) < .2f)
        {
            horizontalMove = 0;
        }


        //we then plug these variables into our rigidbody in order to move the player

        RB.velocity = new Vector2(horizontalMove, verticalMove) * speed * Time.deltaTime;


        //stuff for the animator to know which direction we are going in
        anim.SetFloat("MoveX", RB.velocity.x);
        anim.SetFloat("MoveY", RB.velocity.y);


        //an ugly if statement, just means we moved this frame
        if(horizontalMove == 1 || horizontalMove == -1 || verticalMove == 1 || verticalMove == -1)
        {

            //tells our animator the last direction we have moved in
            //so we know which way to face the player in idle
            anim.SetFloat("LastMoveX", horizontalMove);
            anim.SetFloat("LastMoveY", verticalMove);
        }

    }
}
