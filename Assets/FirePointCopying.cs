using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointCopying : MonoBehaviour
{
    public GameObject copyFP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (copyFP != null)
        {
            copyFP.transform.position = gameObject.transform.position;
            copyFP.transform.rotation = gameObject.transform.rotation;
            copyFP.transform.rotation = gameObject.transform.rotation;
        }
    }
}
