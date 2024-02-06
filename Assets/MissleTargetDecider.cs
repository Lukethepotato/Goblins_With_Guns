using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MissleTargetDecider : MonoBehaviour
{
    public BoxCollider2D coll;
    public GameObject targetScriptObject;
    public AIDestinationSetter targetScript;
    public BulletData bulletData;
    // Start is called before the first frame update
    void Start()
    {
        coll = gameObject.GetComponent<BoxCollider2D>();
        targetScript = targetScriptObject.GetComponent<AIDestinationSetter>();
        bulletData = targetScriptObject.gameObject.GetComponent<BulletData>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TargetAssigment(GameObject target)
    {
        if (bulletData.owner != target.GetComponent<PlayerInput>().playerIndex && targetScript.target == null)     
        {
            targetScript.target = target.transform;
        }
    }
}
