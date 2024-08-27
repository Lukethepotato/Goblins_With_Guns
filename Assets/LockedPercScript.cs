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

    PerkSpriteChange PerkSpriteChange;
    
    // Start is called before the first frame update
    void Start()
    {
        lockAnimMan = lockArt.GetComponent<AnimationManager>();
        perkButton = buttonObject.GetComponent<Button>();
        lockPerkMainScript = perksMain.GetComponent<LockedPercMain>();

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
        }
        else
        {
            lockPerkMainScript.lockedPerks[PerkSpriteChange.perkNum] = false;
            perkButton.enabled = true;
        }

        if (gameUnloackedAt == mainSO.gamesPlayed && inAnim == false)
        {
            inAnim= true;
            StartCoroutine(UnlockAnimation());

        }
        if (gameUnloackedAt > mainSO.gamesPlayed)
        {
            percLocked = true;
            lockArt.SetActive(true);
        }
        if (gameUnloackedAt < mainSO.gamesPlayed)
        {
            lockArt.SetActive(false);
            percLocked = false;
        }
    }

    public void WhenPressOnLocked()
    {
        StartCoroutine(LockedShake());
        GameObject.Find("SFX").GetComponent<AudioManager>().Play("LockedSound");
    }

    IEnumerator UnlockAnimation()
    {
        //lockAnimMan PLAY THE ANIMATION MR TICKLE MAN
        yield return new WaitForSeconds(UnlockAnimTime);
        lockArt.SetActive(false);
        percLocked = false;
    }

    IEnumerator LockedShake()
    {
        //lockAnimMan PLAY THE ANIMATION MR TICKLE MAN
        yield return new WaitForSeconds(UnlockAnimTime);
    }
}