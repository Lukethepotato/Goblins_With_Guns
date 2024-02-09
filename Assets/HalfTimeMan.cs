using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class HalfTimeMan : MonoBehaviour
{
    public MainSO mainSO;
    public TriviaSO[] triviaSOs;
    public float timeTillTextDisplay;
    public float inputTimeLimit;
    public float closureTime;
    public GameObject children;
    public GameObject answers;

    // Start is called before the first frame update
    void Start()
    {
        children.SetActive(false);
        mainSO.chosenTrivia = triviaSOs[Random.Range(0, triviaSOs.Length)];
        mainSO.chosenTrivia.winnerEffected = RandomBool();
        if (mainSO.chosenTrivia.winnerEffected == true)
        {
            mainSO.chosenTrivia.WinnerEffect = Random.Range(0, mainSO.chosenTrivia.WinnerEffect);
        }
        else
        {
            mainSO.chosenTrivia.LoserEffect = Random.Range(0, mainSO.chosenTrivia.LoserEffect);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (mainSO.currentTimer <= mainSO.startingTimer / 2 && mainSO.halfTimeCount < mainSO.maxHalfTimes && mainSO.halfTimeEnabled) 
        {
            StartCoroutine(TimeTillHalfTime());
            mainSO.halfTimeCount++;
        } 
        
    }

    IEnumerator TimeTillHalfTime()
    {
        children.SetActive(true);
        mainSO.inHalfTime = true;
        yield return new WaitForSeconds(timeTillTextDisplay);
        answers.SetActive(true);
        mainSO.displayHalfTimeInput= true;
        yield return new WaitForSeconds(mainSO.chosenTrivia.timeLimit);
        mainSO.displayHalfTimeInput = false;
        yield return new WaitForSeconds(closureTime);
        children.SetActive(false);
        answers.SetActive(false);
    }

    private bool RandomBool()
    {
        if (Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }

}
