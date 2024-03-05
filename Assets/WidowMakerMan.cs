using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WidowMakerMan : MonoBehaviour
{
    public Player_SO[] playSO;
    public MainSO mainSO;
    PlayerInput playInput;
    private bool resetChamber = true;
    public float pastHealth;
    private bool gate = false;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].perkOwned == 3)
        {
            if (mainSO.setUpOver && resetChamber)
            {
                playSO[playInput.playerIndex].magazineSize = 1;
                playSO[playInput.playerIndex].bulletsInChamber = 1;
                pastHealth = playSO[playInput.playerIndex].health;
                resetChamber = false;
            }

            playSO[playInput.playerIndex].bulletReloadTime = (playSO[playInput.playerIndex].orinagalReloadSpeed * playSO[playInput.playerIndex].magazineSize) / playSO[playInput.playerIndex].orinagalChamberSize;

            if (playSO[playInput.playerIndex].health < pastHealth || mainSO.suddenDeathInitiated)
            {
                resetChamber = true;
                print("ResetChamber");
            }
        }
    }

    private void LateUpdate()
    {
    }
}
