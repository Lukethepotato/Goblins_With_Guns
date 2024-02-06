using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class Gun : MonoBehaviour
{
    private bool fire;
    public GameObject target;
    public float rotationSpeed;
    public Aiming aimScript;

    public float rotationModifier;
    public int rocketMult;

    private void Start()
    {

    }

    private void Update()
    {
        if (gameObject.name == "JetPack")
        {
            rocketMult = -1;
        }
        else
        {
            rocketMult = 1;
        }
    }

    // Start is called before the first frame update

    private void FixedUpdate()
    {
        if (aimScript.isGamepad)
        {
            Vector3 vectorToTarget = target.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }
        else
        {
            Vector3 vectorToTarget = target.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }
    }
}


