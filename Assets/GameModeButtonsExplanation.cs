using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameModeButtonsExplanation : MonoBehaviour
{
    public int gameModeButtonHovered = 0;
    public GameObject[] explanationTiles;
    public int timesSameButtonPressed = 0;
    public Vector2 navigation;
    public int lastPannel;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        explanationTiles[lastPannel].SetActive(false);
        if (timesSameButtonPressed > 1) 
        {
            SceneManager.LoadScene(2);
        }
    }

    public void OnButtonClick(int buttonPressed)
    {
        StartCoroutine(ButtonClick(buttonPressed));
        lastPannel = buttonPressed;
    }

    IEnumerator ButtonClick(int buttonPressed)
    {
        if (gameModeButtonHovered == buttonPressed)
        {
            timesSameButtonPressed += 1;
        }
        else
        {
            timesSameButtonPressed = 0;
        }
        yield return new WaitForSeconds(0.01f);

        explanationTiles[gameModeButtonHovered].SetActive(true);

        gameModeButtonHovered = buttonPressed;
    }
}
