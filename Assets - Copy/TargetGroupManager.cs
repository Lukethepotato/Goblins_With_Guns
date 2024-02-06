using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using System.Linq;

public class TargetGroupManager : MonoBehaviour
{
    CinemachineTargetGroup cineTargGroup;
    public GameObject[] playerFollowers;
    public PlayerInputManager playManager;
    public GameObject playManObject;
    public List<GameObject> players;
    // Start is called before the first frame update
    void Start()
    {
        cineTargGroup = gameObject.GetComponent<CinemachineTargetGroup>();
        playManager = playManObject.GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I < playManager.playerCount; ++I)
        {
            players.Add(playerFollowers[I]);
        }
        
        cineTargGroup.m_Targets.AddRange(players);
    }
}
