using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicSettingTweaks : MonoBehaviour
{
    public Toggle[] GraphicButtons;
    public GameObject[] GraphicObjects;

    ToggleGroup toggleGroup;
    // Start is called before the first frame update
    public void Awake()
    {
        for (int i = 0; i < GraphicButtons.Length; i++)
        {
            GraphicButtons[i] = GraphicObjects[i].GetComponent<Toggle>();
        }
        toggleGroup = gameObject.GetComponent<ToggleGroup>();

        GraphicButtons[GameObject.Find("SaveManager").GetComponent<SaveDataMan>().loadInt("GraphicsLevel")].isOn = true;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I < GraphicButtons.Length; I++)
        {
            if (GraphicButtons[I].isOn)
            {
                GameObject.Find("SaveManager").GetComponent<SaveDataMan>().SaveInt("GraphicsLevel", I);
            }
        }

        QualitySettings.SetQualityLevel(GameObject.Find("SaveManager").GetComponent<SaveDataMan>().loadInt("GraphicsLevel"));

        print(GameObject.Find("SaveManager").GetComponent<SaveDataMan>().loadInt("GraphicsLevel"));
    }
}
