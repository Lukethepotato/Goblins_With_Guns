using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfTimeAnswerSelection : MonoBehaviour
{
    public GameObject[] types;
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
        types[mainSO.chosenTrivia.type].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
