using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunFlips : MonoBehaviour
{
    public SpriteRenderer SR;
    public Transform trans;
    public GameObject playerObject;
    public GameObject aimCircle;
    public Vector2 aim;
    public GameObject firePoint;
    public Vector2 firePointBaseLocation;
    // Start is called before the first frame update
    void Start()
    {
        SR= gameObject.GetComponent<SpriteRenderer>();
        trans = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if ((aimCircle.transform.position.x - gameObject.transform.position.x) > 0)
        {
            aim.x = 1;
        }
        else
        {
            aim.x = -1;
        }

        if ((aimCircle.transform.position.y - gameObject.transform.position.y) > 0)
        {
            aim.y = 1;
        }
        else
        {
            aim.y = -1;
        }

        if (aim.x ==1) 
        {
            SR.flipY =false;
            //firePoint.transform.position = firePointBaseLocation;
        }
        else
        {
            SR.flipY=true;
            //firePoint.transform.position = -firePointBaseLocation;
        }
    }
}
