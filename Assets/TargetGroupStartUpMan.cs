using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGroupStartUpMan : MonoBehaviour
{
    PlayerFollower targetGroup;
    public MainSO mainSO;
    public float speed;
    public GameObject parent;
    public TargetGroupStartUpSherif parentScript;
    // Start is called before the first frame update
    void Start()
    {
        targetGroup= gameObject.GetComponent<PlayerFollower>();
        parentScript = parent.GetComponent<TargetGroupStartUpSherif>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.setUpOver == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, parentScript.target, speed * Time.deltaTime);

            if ((parentScript.target == null || (Vector2)gameObject.transform.position == parentScript.target) && parentScript.teleport)
            {
                transform.position = parentScript.newLoca;
            }

            targetGroup.enabled = false;
        }
        else
        {
            targetGroup.enabled = true;
        }
    }
}
