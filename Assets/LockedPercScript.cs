using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedPercScript : MonoBehaviour
{
    public bool percLocked;
    public int orderUnlocked;
    public int gameUnloackedAt;
    public GameObject lockArt;
    public GameObject buttonObject;
    public Button perkButton;
    //public GameObject perkButton;
    //public Button perkButtonScript;
    public float UnlockAnimTime = .5f;
    public float LockedAnimTime = .5f;
    public AnimationManager lockAnimMan;
    public GameObject perksMain;
    public LockedPercMain lockPerkMainScript;
    public MainSO mainSO;
    private bool inAnim = false;
    public GameObject canvas;
    public PlayerSelectionCanvasMan selectionScript;

    PerkSpriteChange PerkSpriteChange;
    
    // Start is called before the first frame update
    void Start()
    {
        lockAnimMan = lockArt.GetComponent<AnimationManager>();
        perkButton = buttonObject.GetComponent<Button>();
        lockPerkMainScript = perksMain.GetComponent<LockedPercMain>();
        selectionScript = canvas.GetComponent<PlayerSelectionCanvasMan>();

        //perkButtonScript = perkButton.GetComponent<Button>();
        PerkSpriteChange = gameObject.GetComponent<PerkSpriteChange>();

        gameUnloackedAt = orderUnlocked * lockPerkMainScript.perkPerGamesInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (percLocked)
        {
            lockPerkMainScript.lockedPerks[PerkSpriteChange.perkNum] = true;
            perkButton.enabled = false;
            lockArt.SetActive(true);
        }
        else
        {
            lockPerkMainScript.lockedPerks[PerkSpriteChange.perkNum] = false;
            perkButton.enabled = true;
            lockArt.SetActive(false);
        }

        if (gameUnloackedAt == GameObject.Find("SaveManager").GetComponent<SaveDataMan>().loadInt("GamesPlayed") && inAnim == false && selectionScript.currentPannel == 2)
        {
            inAnim= true;
            StartCoroutine(UnlockAnimation());
            print("PlayUnlockAnim");
        }
        else if (gameUnloackedAt > GameObject.Find("SaveManager").GetComponent<SaveDataMan>().loadInt("GamesPlayed") && inAnim == false)
        {
            percLocked = true;
        }
        else if (gameUnloackedAt < GameObject.Find("SaveManager").GetComponent<SaveDataMan>().loadInt("GamesPlayed") && inAnim == false)
        {
            percLocked = false;
        }
    }
    IEnumerator UnlockAnimation()
    {
        lockAnimMan.ChangeAnimationState("Lock_unlock");
        //lockAnimMan PLAY THE ANIMATION MR TICKLE MAN
        print("Tickle my Pickle and Call me a Dickle and slap by Shickle and Fuck My Jickle");
        yield return new WaitForSeconds(UnlockAnimTime);
        lockArt.SetActive(false);
        percLocked = false;
        inAnim= false;
    }
}