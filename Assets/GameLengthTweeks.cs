using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLengthTweeks : MonoBehaviour
{
    public GameObject startTimerTextObj;
    public TextMeshProUGUI textMeshTimer;
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
        textMeshTimer = startTimerTextObj.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayingTime(mainSO.startingTimer);
    }

    void DisplayingTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        textMeshTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
