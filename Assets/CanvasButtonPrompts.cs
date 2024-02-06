using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using InControl;
using UnityEngine.UI;
using static CanvasButtonPrompts;
using System.Linq;
using UnityEngine.InputSystem;
using System.Data;

public class CanvasButtonPrompts : MonoBehaviour
{
    public GameObject textObject;
    public TextMeshProUGUI text;
    public string prompt;
    public float timeTillDiplayGoAway;
    public float leenTweenSpeed;

    // Start is called before the first frame update
    void Start()
    {
        text = textObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LengthSetting(float value)
    {
        text.alpha = value;
    }


    public void DisplayTheText(string inputType, string controlType)
    {
        StartCoroutine(DisplayText(inputType, controlType));
    }


    IEnumerator DisplayText(string inputType, string controlType)
    {
        if (inputType == "interact")
        {
            text.text = "<sprite=" + "\"" + controlType + "\"" + " name=\"interact\">" + prompt;
        }
        else if (inputType == "fire")
        {
            text.text = "<sprite=" + "\"" + controlType + "\"" + " name=\"fire\">" + prompt;
        }
        else if (inputType == "reload")
        {
            text.text = "<sprite=" + "\"" + controlType + "\"" + " name=\"reload\">" + prompt;
        }
        else
        {
            text.text = "<sprite=" + "\"" + controlType + "\"" + " name=\"roll\">" + prompt;
        }
        print("Displayed");
        yield return new WaitForSeconds(timeTillDiplayGoAway);
        LeanTween.value(textObject, text.alpha, 0, leenTweenSpeed).setEaseInBack().setOnUpdate(LengthSetting);
    }
}
