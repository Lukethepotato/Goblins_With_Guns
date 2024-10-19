using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunFireSFX : MonoBehaviour
{
    public GameObject player;
    public PlayerInput playInput;
    public Player_SO[] playSO;
    public MainSO mainSO;
    BulletFiring bulletFiring;
    public string[] gunSFXNames;
    private string lastSoundPlayed = "";
    public bool[] attomaticGuns;
    public string[] chargeGuns;
    public string miniGunRevSFXName;
    private int oldGunNum;
    public bool charging = false;
    private bool chargeSoundPlaying = false;
    public string turretChargeName;
    public string turretShootName;

    // Start is called before the first frame update
    void Start()
    {
        playInput = player.GetComponent<PlayerInput>();
        bulletFiring = gameObject.GetComponent<BulletFiring>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attomaticGuns[playSO[playInput.playerIndex].gunChosen])
        {
            if (playSO[playInput.playerIndex].firing && GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().StillPlaying(gunSFXNames[playSO[playInput.playerIndex].gunChosen]) == false)
            {
                GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().Play(gunSFXNames[playSO[playInput.playerIndex].gunChosen]);
                oldGunNum = playSO[playInput.playerIndex].gunChosen;
            }
            else if (playSO[playInput.playerIndex].firing == false)
            {
                GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().StopPlaying(gunSFXNames[playSO[playInput.playerIndex].gunChosen]);
            }
        }

        if (chargeGuns[playSO[playInput.playerIndex].gunChosen] != "" || playSO[playInput.playerIndex].isTurret)
        {
            if (charging && playSO[playInput.playerIndex].isTurret == false && chargeSoundPlaying == false)
            {
                GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().Play(chargeGuns[playSO[playInput.playerIndex].gunChosen]);
                oldGunNum = playSO[playInput.playerIndex].gunChosen;
                chargeSoundPlaying = true;
            }
            else if (charging && chargeSoundPlaying == false && playSO[playInput.playerIndex].isTurret)
            {
                GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().Play(turretChargeName);
                chargeSoundPlaying = true;

            }
            else if (charging == false)
            {
                GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().StopPlaying(chargeGuns[playSO[playInput.playerIndex].gunChosen]);
                GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().StopPlaying(turretChargeName);
                chargeSoundPlaying = false;
            }
        }
        if (playSO[playInput.playerIndex].isTurret == false)
        {
            GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().StopPlaying(turretChargeName);
        }

        if (bulletFiring.revingMiniGun && GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().StillPlaying(miniGunRevSFXName) == false)
        {
            GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().Play(miniGunRevSFXName);
        }
        else if (bulletFiring.revingMiniGun == false)
        {
            GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().StopPlaying(miniGunRevSFXName);
        }

        if (playSO[playInput.playerIndex].gunChosen != oldGunNum)
        {
            GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().StopPlaying(gunSFXNames[oldGunNum]);
        }

        if ((bulletFiring.charging || (playSO[playInput.playerIndex].gunChosen == 6 && bulletFiring.chargingBow)) && playSO[playInput.playerIndex].firing == false)
        {
            charging = true;
        }
        else
        {
            charging = false;
        }


    }

    public void OneBulletFired()
    {
        if (attomaticGuns[playSO[playInput.playerIndex].gunChosen] == false && playSO[playInput.playerIndex].isTurret == false)
        {
            lastSoundPlayed = gunSFXNames[playSO[playInput.playerIndex].gunChosen];
            GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().PlayOneShot(gunSFXNames[playSO[playInput.playerIndex].gunChosen]);
        }
        else if (playSO[playInput.playerIndex].isTurret)
        {
            lastSoundPlayed = turretShootName;
            GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().PlayOneShot(turretShootName);
        }
    }
}
