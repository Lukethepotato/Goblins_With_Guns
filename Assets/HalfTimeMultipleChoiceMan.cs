using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HalfTimeMultipleChoiceMan : MonoBehaviour
{
    public MainSO mainSO;
    public GameObject[] options;
    // Start is called before the first frame update
    void Start()
    {
        for (int I = 0; I < mainSO.chosenTrivia.MultipleChoiceOptions.Length; I++)
        {
            options[I].GetComponentInChildren<TextMeshProUGUI>().text = mainSO.chosenTrivia.MultipleChoiceOptions[I];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
