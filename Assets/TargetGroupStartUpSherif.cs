using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGroupStartUpSherif : MonoBehaviour
{
    public Vector2 target;
    public Vector2 newLoca;

    private Vector2 lastTarget;
    private Vector2 lastLoca;
    public MainSO mainSO;
    public GameObject follower;
    private int count = 0;
    public float timeOnEach;
    private float runtimeTime;
    public bool teleport;
    // Start is  nm mmjkkkmjkjkcalled before the first frame update
    void Start()
    {
        runtimeTime = timeOnEach;
    }

    // Update is called once per// frame
    void Update()
    {
        runtimeTime -= Time.deltaTime;
        if (runtimeTime <= 0 || target == null)
        {
            target = mainSO.wayPoints[count];
            //newLoca = mainSO.possibleLocas[count];
            count++;

            runtimeTime = timeOnEach;
            if (count >= mainSO.wayPoints.Length -1)
            {
                count = 0;
            }
        }
    }
}
