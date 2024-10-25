using Photon.Pun.Demo.Asteroids;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using XInputDotNetPure;

public class PlayerGrappleScript : MonoBehaviour
{
    public GameObject hook;
    public LineRenderer LinRend;
    public Player_SO[] playSO;
    public PlayerInput playInput;
    public int grapplesAvible = 1;
    public float fireForce;
    public float leiusureTime;
    private GameObject currentHook;
    public Rigidbody2D RB2d;
    public float pullForce;
    public GameObject firePointCopy;
    public bool pull = false;
    public bool displayGrap = false;
    public float timeTillOveride;
    public int hookedPlayer = -1;
    private int hookNum = 0;
    public GameObject groundColl;
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        RB2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].perkOwned == 12)
        {
            int playIndex = playInput.playerIndex;

            if (currentHook == null)
            {
                LinRend.enabled = false;
                ResetPlayerHook();
            }
            else
            {
                LinRend.enabled = true;
            }

            if (playSO[playIndex].isReloading && grapplesAvible == 0)
            {
                if (grapplesAvible == 0)
                {
                    grapplesAvible = 1;
                }

                ResetPlayerHook();
            }

            if (playSO[playIndex].perkButPressed && grapplesAvible > 0 && playSO[playIndex].isReloading == false)
            {
                grapplesAvible = 0;
                currentHook = Instantiate(hook, firePointCopy.transform.position, firePointCopy.transform.rotation);
                currentHook.GetComponent<MainHookScript>().SetUp(playIndex);
                currentHook.GetComponent<Rigidbody2D>().AddForce(firePointCopy.transform.up * fireForce, ForceMode2D.Impulse);
                StartCoroutine(HookCourtine());
                GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().Play("GrappleShoot");
            }

            if (pull)
            {
                if (playSO[playInput.playerIndex].health < 1)
                {
                    ResetPlayerHook();
                }

                playSO[playInput.playerIndex].grappling = true;

                Vector2 direction = currentHook.transform.position - gameObject.transform.position;
                RB2d.AddForce(direction * pullForce * Time.deltaTime, ForceMode2D.Force);
                hookedPlayer = currentHook.GetComponent<MainHookScript>().PlayerHookedChecked();
            }

            if (displayGrap)
            {
                LinRend.useWorldSpace = true;
                LinRend.SetPosition(0, currentHook.transform.position);
                LinRend.SetPosition(1, gameObject.transform.position);
            }
            else
            {
                hookedPlayer = -1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hook")
        {
            if (pull)
            {
                ResetPlayerHook();
            }
        }
    }

    public void ResetPlayerHook()
    {

        GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().StopPlaying("GrappleFly");
        LinRend.enabled = false;
        StopCoroutine(HookCourtine());
        if (currentHook != null)
        {
            Destroy(currentHook);
        }
        pull = false;
        displayGrap = false;
        if (hookedPlayer != -1)
        {
            playSO[hookedPlayer].freeze = false;
        }
        playSO[playInput.playerIndex].grappling = false;
        LinRend.useWorldSpace = false;
        if (groundColl.activeSelf == false)
        {
            groundColl.SetActive(true);
        }
    }

    IEnumerator HookCourtine()
    {
        hookNum++;
        displayGrap = true;
        int localHookNum = hookNum;
        yield return new WaitForSeconds(leiusureTime);
        GameObject.Find("PlayerSFX_" + playInput.playerIndex.ToString()).GetComponent<AudioManager>().Play("GrappleFly");
        if (hookNum == localHookNum)
        {
            pull = true;
            groundColl.SetActive(false);
        }
        yield return new WaitForSeconds(timeTillOveride);
        if (hookNum == localHookNum)
        {
            ResetPlayerHook();
        }
    }
}