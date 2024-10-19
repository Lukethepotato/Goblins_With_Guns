using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissleMan : MonoBehaviour
{
    AIPath AIpath;
    public float timeUntillHome;
    public AIDestinationSetter targetScript;
    public BulletData bulletData;
    public Player_SO[] playSO;
    private int bestSoFar = 0;
    private bool turnBack = false;
    public MainSO mainSO;

    // Start is called before the first frame update
    void Start()
    {
        AIpath = gameObject.GetComponent<AIPath>();
        StartCoroutine(Wait());
        targetScript = gameObject.GetComponent<AIDestinationSetter>();
        bulletData = gameObject.GetComponent<BulletData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[bestSoFar].health <= 0) 
        {
            TargetAssgiment();
        }

        for (int I = 0; I <= 3; I++)
        {
            if (playSO[I].inGame && I != bulletData.owner && playSO[I].touchingSewage == false)
            {
                turnBack = false;
                break;
            }else if (I == 3 && playSO[bulletData.owner].inGame)
            {
                turnBack= true;
                TargetAssgiment();
            }
        }
    }

    IEnumerator Wait()
    {
        AIpath.canMove = false;
        yield return new WaitForSeconds(timeUntillHome);
        AIpath.canMove = true;
        TargetAssgiment();
    }

    private void TargetAssgiment()
    {
        float bestSoFarDistance = -1;
        for (int player = 0; player <= mainSO.playersReadiedUp -1; player++) 
        {
            if (playSO[player].inGame && playSO[player].health > 0 && player != bulletData.owner)
            {
                float distance = Vector3.Distance(gameObject.transform.position, GameObject.Find("player" + (player + 1).ToString()).transform.position);
                if (bestSoFarDistance == -1)
                {
                    bestSoFarDistance = distance;
                    bestSoFar = player;
                }else if (distance < bestSoFarDistance)
                {
                    bestSoFarDistance = distance;
                    bestSoFar = player;
                    print("MadeIyt");
                }
            }else if (turnBack)
            {
                bestSoFar = bulletData.owner;
            }
        }

        targetScript.target = GameObject.Find("player" + (bestSoFar + 1).ToString()).transform;
    }
}
