using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainHookScript : MonoBehaviour
{
    public bool touchingPlayer = false;
    public FixedJoint2D fixedJoint;
    public int parent = -1;
    private int playerHooked = -1;
    public Player_SO[] playSO;
    Rigidbody2D rb2d;
    private bool stickSoundPlayed = false;

    void Start()
    {
        fixedJoint = gameObject.GetComponent<FixedJoint2D>();
        fixedJoint.enabled = false;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void SetUp(int owner)
    {
        parent = owner;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (touchingPlayer && playSO[playerHooked].freeze == false)
        {
            playSO[playerHooked].freeze = true;

            if (stickSoundPlayed == false)
            {
                GameObject.Find("PlayerSFX_" + parent.ToString()).GetComponent<AudioManager>().Play("GrappleStick");
                stickSoundPlayed = true;
            }
        }

        if (touchingPlayer)
        {
            fixedJoint.enabled = true;
        }
        else
        {
            fixedJoint.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerInput>() != null)
        {
            touchingPlayer= true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInput>() != null && collision.gameObject.GetComponent<PlayerInput>().playerIndex != parent && touchingPlayer == false)
        {
            int playIndex = collision.gameObject.GetComponent<PlayerInput>().playerIndex;

            touchingPlayer = true;
            playerHooked = playIndex;
            fixedJoint.connectedAnchor = collision.gameObject.transform.position;


        }

        if (collision.gameObject.tag == "wall")
        {
            rb2d.freezeRotation = true;
            rb2d.drag = 1000000;

            if (stickSoundPlayed == false)
            {
                GameObject.Find("PlayerSFX_" + parent.ToString()).GetComponent<AudioManager>().Play("GrappleStick");
                stickSoundPlayed = true;
            }
            print("jfwufw");
        }
    }

    public int PlayerHookedChecked()
    {
        return playerHooked;
    }

}
