using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMagicBookManager : MonoBehaviour
{
    public Player_SO[] playSO;
    PlayerInput playInput;
    SpriteRenderer SR;
    BoxCollider2D coll;
    public GameObject groundColl;
    public GameObject[] guns;
    public MainSO mainSO;
    public bool canFire = true;
    public float activationTime;
    public float cantFireTime = 1.5f;
    public float strikeAnimation;
    public bool redHeld;
    public bool purpleHeld;
    public bool greenHeld;
    public bool blueHeld;
    AnimationManager animMan;
    private bool gate = false;
    private Vector2 fireLocation;
    public GameObject lightningTrig;
    private bool inDropCoroutine = false;
    private Vector2 lecternLocation;
    public GameObject[] books;
    public float timeUntilBooksDrop;
    public float timeuntillDisable;
    public LightingHandsSR handsSR;
    public float targetSpeed;
    private bool free = false;
    public GameObject instanBooks;
    public float lightiningStartUp;
    public string prompt = "to fire lightning!";
    public InputDecection inputDectect;
    
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        SR = gameObject.GetComponent<SpriteRenderer>();
        coll = gameObject.GetComponent<BoxCollider2D>();
        animMan = gameObject.GetComponent<AnimationManager>();
        inputDectect = gameObject.GetComponent<InputDecection>();
        StartCoroutine(WeirdBugStopping());
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].canMove == false && playSO[playInput.playerIndex].lightingGoblin) 
        {
            gameObject.transform.position = fireLocation;
        }

        if (playSO[playInput.playerIndex].health < 1 && inDropCoroutine == false)
        {
            if (playSO[playInput.playerIndex].magicBooksHeld > 0)
            {
                StartCoroutine(bookDropping());
            }
            playSO[playInput.playerIndex].magicBooksHeld = 0;

        }

        if (mainSO.playerInLightning)
        {
            playSO[playInput.playerIndex].magicBooksHeld = 0;
        }

    }

    public void MagicBookPickedUp(int bookId)
    {
        if (playSO[playInput.playerIndex].health > 0)
        {
            playSO[playInput.playerIndex].magicBooksHeld += 1;

            if (bookId == 0)
            {
                redHeld = true;
            }
            else if (bookId == 1)
            {
                purpleHeld = true;
            }
            else if (bookId == 2)
            {
                greenHeld = true;
            }
            else if (bookId == 3)
            {
                blueHeld = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playSO[playInput.playerIndex].magicBooksHeld > 3 && playSO[playInput.playerIndex].lightingGoblin == false) 
        {
            if (collision.gameObject.CompareTag("Lectern") && gate == false)
            {
                collision.gameObject.GetComponent<LecternManager>().lecternActivate();
                StartCoroutine(Activation());
                lecternLocation= gameObject.transform.position;
                gate = true;
                print("godMode");
            }
            print("godMode");
        }
    }

    public void Strike()
    {
        if (free)
        {
            if (canFire && playSO[playInput.playerIndex].lightingGoblin)
            {
                StartCoroutine(Fire());
            }
        }
    }

    IEnumerator Fire()
    {
        handsSR.LightingFireIntiated = true;
        fireLocation = gameObject.transform.position;
        canFire= false;
        playSO[playInput.playerIndex].movementSpeed = mainSO.lightingFireingSpeed;
        animMan.ChangeAnimationState("Target_strike");
        yield return new WaitForSeconds(lightiningStartUp);
        lightningTrig.SetActive(true);
        yield return new WaitForSeconds(strikeAnimation);
        handsSR.LightingFireIntiated = false;
        lightningTrig.SetActive(false);
        playSO[playInput.playerIndex].movementSpeed = targetSpeed;
        animMan.ChangeAnimationState("Target_Idle");
        yield return new WaitForSeconds(cantFireTime);
        canFire = true;
    }

    IEnumerator Activation()
    {
        mainSO.playerInLightning= true;
        groundColl.SetActive(false);
        playInput.DeactivateInput();
        coll.enabled = false;
        SR.enabled= false;
        playSO[playInput.playerIndex].lightingGoblin = true;
        yield return new WaitForSeconds(activationTime);
        //lightningTrig.SetActive(true);
        GameObject.Find("MainCanvas").GetComponent<CanvasButtonPrompts>().prompt = prompt;
        GameObject.Find("MainCanvas").GetComponent<CanvasButtonPrompts>().DisplayTheText("fire", inputDectect.GetControlType());
        SR.enabled = true;
        handsSR.playerGoneWizard = true;
        SR.sortingLayerName = "foreGround";
        SR.sortingOrder = 10;
        playInput.ActivateInput();
        animMan.ChangeAnimationState("Target_Idle");
        StartCoroutine(timeTillDisable());
        playSO[playInput.playerIndex].movementSpeed = targetSpeed;
    }

    IEnumerator timeTillDisable()
    {
        yield return new WaitForSeconds(timeuntillDisable);
        mainSO.playerInLightning = false;
        DisableLightning();
    }

    public void DisableLightning()
    {
        handsSR.playerGoneWizard = false;
        playSO[playInput.playerIndex].lightingGoblin = false;
        coll.enabled = true;
        SR.sortingLayerName = "player";
        playSO[playInput.playerIndex].movementSpeed = playSO[playInput.playerIndex].basePlayerSpeed;
        playSO[playInput.playerIndex].magicBooksHeld = 0;
        groundColl.SetActive(true);
        transform.position = lecternLocation;
        gate = false;
        handsSR.startUpAnimationPlayed = false;
        Instantiate(instanBooks, new Vector2(0, 0), Quaternion.identity);
        mainSO.playerInLightning = false;
        lightningTrig.SetActive(false);

    }

    public void DisableLightning2()
    {
        playSO[playInput.playerIndex].magicBooksHeld = 0;
        handsSR.playerGoneWizard = false; 
        playSO[playInput.playerIndex].lightingGoblin = false;
        coll.enabled = true;
        SR.sortingLayerName = "player";
        playSO[playInput.playerIndex].movementSpeed = playSO[playInput.playerIndex].basePlayerSpeed;
        groundColl.SetActive(true);
        gate = false;
        handsSR.startUpAnimationPlayed = false;
        mainSO.playerInLightning = false;
    }

    IEnumerator bookDropping()
    {
        inDropCoroutine = true;
        yield return new WaitForSeconds(.5f);
        if (redHeld)
        {
            Instantiate(books[0], new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y + 1), Quaternion.identity);
        }
        if (purpleHeld)
        {
            Instantiate(books[1], new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y + 1.5f), Quaternion.identity);
        }
        if (greenHeld)
        {
            Instantiate(books[2], new Vector2(gameObject.transform.position.x - 1.5f, gameObject.transform.position.y + 1), Quaternion.identity);
        }
        if (blueHeld)
        {
            Instantiate(books[3], new Vector2(gameObject.transform.position.x + 1.5f, gameObject.transform.position.y - 1), Quaternion.identity);
        }

        yield return new WaitForSeconds(timeUntilBooksDrop);
        redHeld = false;
        purpleHeld = false;
        greenHeld = false;
        blueHeld = false;
        inDropCoroutine = false;
    }
    
    IEnumerator WeirdBugStopping()
    {
        yield return new WaitForSeconds(1f);
        free = true;
    }
}
