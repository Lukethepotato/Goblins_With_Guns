using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIButtonPromptTextDisplay : MonoBehaviour
{
    [TextArea]
    public string beforeText;
    [Header("interact, fire, reload")]
    public string inputType;
    [TextArea]
    public string afterText;
    public GameObject mainPlayer;
    public InputDecection inputDectection;
    public TextMeshProUGUI textMesh;
    public GameObject titText;
    // Start is called before the first frame update
    void Start()
    {
        inputDectection= mainPlayer.GetComponent<InputDecection>();
        textMesh = titText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = beforeText + inputDectection.DisplayButton(inputType) + afterText;
    }
}
