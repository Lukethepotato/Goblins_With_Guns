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
    private bool firePointNeg;
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
            if (firePointNeg && firePoint != null)
            {
                firePoint.transform.localPosition = new Vector2(firePoint.transform.localPosition.x, -firePoint.transform.localPosition.y);
                firePointNeg = false;
            }
        }
        else
        {
            SR.flipY=true;
            if (firePointNeg == false && firePoint != null)
            {
                firePoint.transform.localPosition = new Vector2(firePoint.transform.localPosition.x, -firePoint.transform.localPosition.y);
                firePointNeg= true;
            }
        }
    }
}
