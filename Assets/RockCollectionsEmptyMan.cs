using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RockCollectionsEmptyMan : MonoBehaviour
{
    public PlayerInputManager playMan;
    public GameObject playManObject;
    public GameObject[] collections;
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
        playMan = playManObject.GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.setUpOver == false)
        {
            for (int I = 0; I <= playMan.playerCount - 1; I++)
            {
                collections[I].SetActive(true);
            }
        }

        if (mainSO.rematchSelected)
        {
            int I = 0;

            StartCoroutine(Thing());
        }
    }

    IEnumerator Thing()
    {
        yield return new WaitForSeconds(.01f);

        int I = 0;

        while (collections[I].activeSelf == true)
        {
            collections[I].GetComponent<RockCollectionMan>().RematchRocks();
            I++;
        }

    }
}
