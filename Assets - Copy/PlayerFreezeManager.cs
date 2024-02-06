using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreezeManager : MonoBehaviour
{
    public MainSO mainSO;
    Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.freezeAllPlayer)
        {
            RB.drag = 100000000000;
        }
        else
        {
            RB.drag = 0;
        }
    }
}
