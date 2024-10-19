using Pathfinding;
using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class SuddenDeathManager : MonoBehaviour
{
    public GameObject suddenDeathEmpty;
    public MainSO mainSO;
    public TextMeshProUGUI textMeshPro;
    public GameObject[] maps;
    public AnimationManager animMan;
    private bool courtineStarted = false;
    public PlayerInputManager playerManager;
    public GameObject playerManObject;
    public GameObject camObject;
    public PostProcessVolume PPVolume;
    public PostProcessProfile Profile;
    public GameObject scroll;
    public MainScene_Scroll scrollScript;

    // Start is called before the first frame update
    void Start()
    {
        PPVolume = camObject.GetComponent<PostProcessVolume>();
        mainSO.currentTimer = mainSO.startingTimer;
        textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
        animMan = GetComponentInChildren<AnimationManager>();
        playerManager= playerManObject.GetComponent<PlayerInputManager>();
        scrollScript = scroll.GetComponent<MainScene_Scroll>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.gameIsOver == false && mainSO.setUpOver && mainSO.rematchSelected == false && scrollScript.inFootballStartUp == false)
        {
            mainSO.currentTimer -= Time.deltaTime;
        }else if (mainSO.rematchSelected)
        {
            maps[mainSO.map].SetActive(true);
            mainSO.currentTimer = mainSO.startingTimer;
            courtineStarted = false;
            if (GameObject.Find("SuddenDeath(Clone)") != null)
            {
                Destroy(GameObject.Find("SuddenDeath(Clone)"));
            }

        }

        if (mainSO.currentTimer < 1 && mainSO.suddenDeathInitiated == false && courtineStarted == false && (playerManager.playerCount - mainSO.playersDead) > 1)
        {
            StartCoroutine(SuddenDeath());
            courtineStarted= true;
        }
        DisplayingTime(mainSO.currentTimer);
    }

    void DisplayingTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        textMeshPro.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator SuddenDeath()
    {
        print("courtineStarted");
        animMan.ChangeAnimationState("SuddenDeathScreen");
        mainSO.freezeAllPlayer = true;
        yield return new WaitForSeconds(1.6f);
        maps[mainSO.map].SetActive(false);
        mainSO.suddenDeathInitiated = true;
        mainSO.inSuddenDeath = true;
        Instantiate(suddenDeathEmpty);
        PPVolume.profile = Profile;
        yield return new WaitForSeconds(2.6f);
        mainSO.freezeAllPlayer = false;
        mainSO.suddenDeathInitiated = false;
        animMan.ChangeAnimationState("SuddenDeathIdle");
    }
}
