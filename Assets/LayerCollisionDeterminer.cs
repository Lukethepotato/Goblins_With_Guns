using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerCollisionDeterminer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(9, 9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
