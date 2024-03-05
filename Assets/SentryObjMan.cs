using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryObjMan : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationModifier;
    public GameObject target;
    public Player_SO[] playSO;
    public bool turnBack = false;
    private int bestSoFar;
    public StationaryFirepoint_Data data;
    public GameObject parent;
    public ObjectHealthMan objectHeath;
    public float healthDecreRate;
    // Start is called before the first frame update
    void Start()
    {
        data = gameObject.GetComponentInParent<StationaryFirepoint_Data>();
        objectHeath = parent.GetComponent<ObjectHealthMan>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I <= 3; I++)
        {
            if (playSO[I].inGame && I != data.owner && playSO[I].touchingSewage == false)
            {
                turnBack = false;
                TargetAssgiment();
            }
            else if (I == 3 && playSO[data.owner].inGame)
            {
                turnBack = true;
                break;
            }
        }

        objectHeath.health -= healthDecreRate * Time.deltaTime;

        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }

    private void TargetAssgiment()
    {
        float bestSoFarDistance = -1;
        for (int player = 0; player <= 3; player++)
        {
            if (playSO[player].inGame && playSO[player].health > 0 && player != data.owner)
            {
                float distance = Vector3.Distance(gameObject.transform.position, GameObject.Find("player" + (player + 1).ToString()).transform.position);
                if (bestSoFarDistance == -1)
                {
                    bestSoFarDistance = distance;
                    bestSoFar = player;
                }
                else if (distance < bestSoFarDistance)
                {
                    bestSoFarDistance = distance;
                    bestSoFar = player;
                    print("MadeIyt");
                }
            }
            else if (turnBack)
            {
                bestSoFar = data.owner;
            }
        }

        target = GameObject.Find("player" + (bestSoFar + 1).ToString());
    }
}
