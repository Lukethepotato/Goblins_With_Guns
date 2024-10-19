using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerParent : MonoBehaviour
{
    private static AudioManagerParent instance;
    public GameObject[] OnesToDisableOnStart;
    public MainSO mainSO;
    private bool gate = false;
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
