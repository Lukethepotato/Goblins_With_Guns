using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HalfTimePromptDisplay : MonoBehaviour
{
    public MainSO mainSO;
    public TextMeshProUGUI prompt;
    public GameObject textChild;
    // Start is called before the first frame update
    void Start()
    {
        prompt = textChild.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        prompt.text = mainSO.chosenTrivia.prompt;
    }
}
