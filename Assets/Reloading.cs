using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Reloading : MonoBehaviour
{
    public Player_SO[] playSO;
    public PlayerInput playInput;
    public GameObject player;
    public BulletFiring firingScript;
    public MainSO mainSO;

    // Start is called before the first frame update
    void Start()
    {
        firingScript = gameObject.GetComponent<BulletFiring>();
        playInput = player.GetComponent<PlayerInput>();
    }

    public void OnReload() 
    { 
        if (playSO[playInput.playerIndex].isReloading == false)
        {
            if (playSO[playInput.playerIndex].gunChosen != 8)
            {
                StartCoroutine(Reload());
            }else if (firingScript.spellOut == false)
            {
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        //playSO[playInput.playerIndex].movementSpeed = mainSO.reloadMoveSpeed;
        playSO[playInput.playerIndex].isReloading = true;
        yield return new WaitForSeconds(playSO[playInput.playerIndex].bulletReloadTime);
        playSO[playInput.playerIndex].bulletsInChamber = playSO[playInput.playerIndex].magazineSize;
        playSO[playInput.playerIndex].isReloading = false;
        playSO[playInput.playerIndex].movementSpeed = mainSO.baseMoveSpeed;
    }
}
