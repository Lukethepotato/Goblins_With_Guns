using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDolleyWaypointSetting : MonoBehaviour
{
    public Vector2[] mapWaypoints;
    public Vector2[] mapLocas;
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mainSO.wayPoints = mapWaypoints;
        mainSO.possibleLocas = mapLocas;

    }
}
