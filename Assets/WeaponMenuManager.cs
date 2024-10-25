using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponMenuManager : MonoBehaviour
{
    public Player_SO[] playSO;
    public GameObject player;
    public PlayerInput playInput;
    public GameObject gunParent;
    public GunPerkValueTeaks gunValTweaks;
    // Start is called before the first frame update
    void Start()
    {
        playInput= player.GetComponent<PlayerInput>();
        gunValTweaks = gunParent.GetComponent<GunPerkValueTeaks>();
    }

    public void GunSelection(int gunSelected)
    {
        //gunValTweaks.SetGunsBackToNormal();
        playSO[playInput.playerIndex].gunChosen= gunSelected;
        GameObject.Find("UI").GetComponent<AudioManager>().Play("ClickSound2");
        //gunValTweaks.ApplyPerkGunStats(false);
    }
}
