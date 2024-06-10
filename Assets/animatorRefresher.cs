using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorRefresher : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<Animator>().Rebind();
        gameObject.GetComponent<Animator>().Update(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
