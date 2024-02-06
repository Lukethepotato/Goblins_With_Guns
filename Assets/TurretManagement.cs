using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurretManagement : MonoBehaviour
{
    SpriteRenderer SR;
    public Player_SO[] playSO;
    PlayerInput playInput;
    private bool gate = false;
    private bool gate2 = false;
    public GameObject[] guns;
    public string turretEmptyName;
    private bool touchingCollider = false;
    Rigidbody2D RB;
    BoxCollider2D coll2D;
    private bool collBig = false;
    private bool massSetToTurr = false;


    // Start is called before the first frame update
    void Start()
    {
        SR= gameObject.GetComponent<SpriteRenderer>();
        playInput = gameObject.GetComponent<PlayerInput>();
        RB = gameObject.GetComponent<Rigidbody2D>();
        coll2D= gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].isTurret)
        {
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            guns[3].SetActive(true);
            guns[4].SetActive(false);

            if (collBig == false)
            {
                coll2D.size *= 2;
                collBig = true;
            }

            SR.color = new Color(1, 1, 1, 0);
            gate2 = false;
        }
        else if (gate2 == false)
        {
            guns[3].SetActive(false);
            gate2 = true;
        }

        if (collBig && playSO[playInput.playerIndex].isTurret == false)
        {
            collBig = false;
            coll2D.size /= 2;
        }

        if (playSO[playInput.playerIndex].isTurret == false && touchingCollider) 
        {
            guns[3].SetActive(false);
            guns[playSO[playInput.playerIndex].gunChosen].SetActive(true);
        }

        if (playSO[playInput.playerIndex].isTurret && massSetToTurr == false)
        {
            RB.mass = 100000;
            massSetToTurr= true;
            
        }
        else if (playSO[playInput.playerIndex].isTurret == false && massSetToTurr)
        {
            RB.mass = 1;
            massSetToTurr= false;
        }

        if (playSO[playInput.playerIndex].health < 1 || playSO[playInput.playerIndex].hasDied)
        {
            playSO[playInput.playerIndex].isTurret = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Turret") && gate == false && playSO[playInput.playerIndex].turretDisabled == false)
        {
            playSO[playInput.playerIndex].isTurret = true;
            gate = true;
            gameObject.transform.position = GameObject.Find(turretEmptyName).transform.position;
            playSO[playInput.playerIndex].bulletsInChamber = 0;
        }else
        {
            gate = false;

        }

        if (other.gameObject.CompareTag("Turret"))
        {
            touchingCollider = true;
        }


    }
}
