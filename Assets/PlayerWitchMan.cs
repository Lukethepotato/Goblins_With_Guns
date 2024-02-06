using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWitchMan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("radius_witch"))
        {
            collision.gameObject.GetComponent<WitchManager>().playersIn++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("radius_witch"))
        {
            collision.gameObject.GetComponent<WitchManager>().playersIn--;
        }
    }

}
