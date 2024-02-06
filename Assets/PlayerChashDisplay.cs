using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerChashDisplay : MonoBehaviour
{
    public Player_SO playerSO;
    TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "Cash: " + playerSO.money.ToString();
    }
}
