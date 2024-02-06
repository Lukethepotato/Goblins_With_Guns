using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTextDisplay : MonoBehaviour
{
    public Player_SO playerSO;
    TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh= gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = playerSO.playerName + " health:" + playerSO.health.ToString() +" Lives Left:" + playerSO.livesLeft.ToString() + " Bullets:" + playerSO.bulletsInChamber;
    }
}
