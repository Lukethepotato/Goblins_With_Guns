using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerParent : MonoBehaviour
{
    private static AudioManagerParent instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

        // Update is called once per frame
    void Update()
    {
        
    }
}
