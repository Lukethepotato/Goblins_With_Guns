using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BorrowRollScipt : MonoBehaviour
{
    public Player_SO[] playSO;
    public MainSO mainSO;
    public bool rollInput = false;
    public float telaportationTime;
    public Vector2 decidedTelaportLocation;
    public float telaportLocationMult;
    public float postTeleportWaitTime;
    public float telaportDist;
    public GameObject teleportLocationCol;
    PlayerInput playInput;
    Rigidbody2D rb2d;
    AnimationManager animMan;

    private bool inCourtine = false;
    private bool mistyStepDisabled =false;
    public GameObject mistyStepEffectBack;
    
    

    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>(); 
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animMan = gameObject.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].perkOwned == 5)
        {
            if (rollInput && mistyStepDisabled == false)
            {
                rollInput = false;
                mistyStepDisabled = true;
                decidedTelaportLocation = (playSO[playInput.playerIndex].moveInput * telaportDist) + (Vector2)gameObject.transform.position;
                GameObject.Find("PlayerSFX").GetComponent<AudioManager>().Play("MistyStepIn");
                StartCoroutine(MistyStep());
            }

            if (mistyStepDisabled && rollInput)
            {
                rollInput = false;
            }

            if (inCourtine)
            {
                rb2d.drag = 100000000000000;
            }
        }
    }

    public void BorrowRoll()
    {
        rollInput = true;
    }

    IEnumerator MistyStep()
    {
        playSO[playInput.playerIndex].moveAnimsPlayable = false;
        inCourtine = true;
        //rb2d.drag = 100000000000000;
        Vector2 realTeleportLocation = Vector2.zero;


        mistyStepDisabled = true;
        GameObject prephab = Instantiate(teleportLocationCol, (Vector3)decidedTelaportLocation, Quaternion.identity);
        prephab.GetComponent<TeleportLocoColScript>().OnCreation(playInput.playerIndex);
        playSO[playInput.playerIndex].freeze = true;
        Instantiate(mistyStepEffectBack, gameObject.transform.position, Quaternion.identity);
        animMan.ChangeAnimationState("Goblin_Invisble");
        yield return new WaitForSeconds(telaportationTime/ 3);
        playSO[playInput.playerIndex].invincble = true;
        yield return new WaitForSeconds(telaportationTime - (telaportationTime/3));
        playSO[playInput.playerIndex].invincble = false;

        realTeleportLocation = (Vector2)prephab.transform.position;
        //Destroy(prephab);
        gameObject.transform.position = realTeleportLocation;
        playSO[playInput.playerIndex].freeze = false;
        rb2d.drag = 0;

        inCourtine = false;
        prephab.GetComponent<TeleportLocoColScript>().Explode();

        playSO[playInput.playerIndex].moveAnimsPlayable = true;
        yield return new WaitForSeconds(postTeleportWaitTime);

        mistyStepDisabled = false;
    }
}
