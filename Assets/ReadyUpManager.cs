using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReadyUpManager : MonoBehaviour
{
    public MainSO mainSO;
    public PlayerInputManager inputManager;
    public GameObject inputManagerObject;
    public int cowntDown = 3;
    public int playerWhenCowntdownStarted;
    private bool inCowntDownMode = false;
    TextMeshProUGUI cowntDownText;
    public GameObject cowntDownTextObject;
    public GameObject setupObject;
    public GameObject scroll;
    MapMusicPlayer mapSong;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        inputManager= inputManagerObject.GetComponent<PlayerInputManager>();
        cowntDownText = GetComponentInChildren<TextMeshProUGUI>();
        mapSong = canvas.GetComponent<MapMusicPlayer>();
        mainSO.playersReadiedUp = 0;
    }

    // Update is called once per frame
    void Update()
    {

        cowntDownText.text = cowntDown.ToString();


        if (mainSO.playersReadiedUp == inputManager.playerCount && mainSO.playersReadiedUp > 0 && inCowntDownMode == false)
        {
            StartCoroutine(CowntDown());
            playerWhenCowntdownStarted = inputManager.playerCount;
            print("cowntdown");
        }

        if (playerWhenCowntdownStarted < inputManager.playerCount)
        {
            StopCoroutine(CowntDown());
            inCowntDownMode = false;
        }

        if (inCowntDownMode)
        {
            cowntDownTextObject.SetActive(true);
        }
        else
        {
            cowntDownTextObject.SetActive(false);
            cowntDown = 3;
        }

    }

    IEnumerator CowntDown()
    {
        cowntDown = 3;
        inCowntDownMode = true;
        yield return new WaitForSeconds(1);
        cowntDown--;
        yield return new WaitForSeconds(1);
        cowntDown--;
        yield return new WaitForSeconds(1);

        if(playerWhenCowntdownStarted == inputManager.playerCount)
        {
            print("setUpOver");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mapSong.PlayMapSong();
            mainSO.inStartUpMov = true;
            mainSO.inStartUpMov = false;
            mainSO.setUpOver = true;
            scroll.GetComponent<MainScene_Scroll>().PublicEnd();
            print("setUpOver");
            Destroy(setupObject);
        }
    }
}
