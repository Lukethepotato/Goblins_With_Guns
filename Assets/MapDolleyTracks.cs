using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDolleyTracks : MonoBehaviour
{
    public Vector2[] wayPoints;
    CinemachineSmoothPath trolleyPath;
    // Start is called before the first frame update
    void Start()
    {
        trolleyPath = gameObject.GetComponent<CinemachineSmoothPath>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
