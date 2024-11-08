using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverButtonsScript : MonoBehaviour
{
    public MainSO MainSO;
    public Player_SO[] playSO;
    public PlayerInputManager playerInputManager;
    public GameObject inputMan;
    public GameObject gameOverUI;
    private bool courtineRunning = false;
    public void Start()
    {
         playerInputManager = inputMan.GetComponent<PlayerInputManager>();
    }

    private void Update()
    {
        if (gameOverUI.activeSelf == false)
        {
            StartCoroutine(waitTime());
        }
    }

    public void Rematch()
    {
        MainSO.rematchSelected = true;
        MainSO.gameIsOver = false;
        MainSO.winner = 0;
        MainSO.playersDead = 0;

        playSO[0].rematchSetUpComplete = false;
        playSO[1].rematchSetUpComplete = false;
        playSO[2].rematchSetUpComplete = false;
        playSO[3].rematchSetUpComplete = false;
        print("rematch");
        if (courtineRunning == false)
        {
            StartCoroutine(waitTime());
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator waitTime()
    {
        courtineRunning= true;
        yield return new WaitForSeconds(1f);
        MainSO.rematchSelected = false;
        courtineRunning = false;
    }
}
