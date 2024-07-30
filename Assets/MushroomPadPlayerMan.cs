using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class MushroomPadPlayerMan : MonoBehaviour
{
    public Vector3 explosionLoca;
    public Player_SO[] playSO;
    public PlayerInput playInput;
    Rigidbody2D RB;
    public float bounceInputControl;
    private float boucePower;
    public float startingPower;
    public float endingPower;
    private bool boucning = false;
    public float bounceTime;
    public float timeBeforePush;

    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (boucning)
        {
            Vector2 heading = explosionLoca - gameObject.transform.position;
            float distance = Vector3.Distance(gameObject.transform.position, explosionLoca);

            Vector2 explosionDirection = heading / distance;

            Vector2 moveInput;
            Vector2 moveBias;

            if (playSO[playInput.playerIndex].moveInput != Vector2.zero)
            {
                moveInput = playSO[playInput.playerIndex].moveInput;
            }
            else
            {
                moveInput = Vector2.one;
            }

            if (playSO[playInput.playerIndex].ActiveMoveInput != Vector2.zero)
            {
                moveBias = playSO[playInput.playerIndex].ActiveMoveInput;
            }
            else
            {
                moveBias = Vector2.one;
            }

            RB.AddForce((-explosionDirection + (moveBias * bounceInputControl)) * (boucePower - distance), ForceMode2D.Force);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MushroomPropel" && boucning == false)
        {
            StartCoroutine(MushroomPropel());
            collision.gameObject.GetComponent<MushCollScript>().PlayBunce();
            explosionLoca = collision.transform.position;
            print("propel");
        }
    }

    private void LengthSetting(float value)
    {
        boucePower = value;
    }

    IEnumerator MushroomPropel()
    {
        //yield return new WaitForSeconds(timeBeforePush);
        LeanTween.value(gameObject, startingPower, endingPower, bounceTime).setEaseInBack().setOnUpdate(LengthSetting);
        boucning = true;
        yield return new WaitForSeconds(bounceTime);
        boucning = false;

    }
}
