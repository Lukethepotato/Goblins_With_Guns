using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Reloading : MonoBehaviour
{
    public Player_SO[] playSO;
    public PlayerInput playInput;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playInput = player.GetComponent<PlayerInput>();
    }

    public void OnReload() 
    { 
        if (playSO[playInput.playerIndex].isReloading == false)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        playSO[playInput.playerIndex].isReloading = true;
        yield return new WaitForSeconds(playSO[playInput.playerIndex].bulletReloadTime);
        playSO[playInput.playerIndex].bulletsInChamber = playSO[playInput.playerIndex].magazineSize;
        playSO[playInput.playerIndex].isReloading = false;
    }
}
