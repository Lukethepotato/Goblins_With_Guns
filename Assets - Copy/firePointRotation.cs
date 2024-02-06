using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePointRotation : MonoBehaviour
{
    public SpriteRenderer SR;
    public Vector2 baseVector2;
    public GameObject Gun;
    // Start is called before the first frame update
    void Start()
    {
        SR = Gun.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SR.flipY == true)
        {
            gameObject.transform.localPosition= new Vector2(baseVector2.x,-baseVector2.y);
            
        }
        else
        {
            gameObject.transform.localPosition = baseVector2;
        }
    }
}
