using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnlinePlayerSpawnerScript : MonoBehaviour
{
    public GameObject playerSpawn;
    public MainSO mainSO;
    //public PhotonView photonVeiw;
    public Vector2 spawnLocation;
    void Start()
    {
        PhotonNetwork.Instantiate(playerSpawn.name, spawnLocation, Quaternion.identity);
    }
}
