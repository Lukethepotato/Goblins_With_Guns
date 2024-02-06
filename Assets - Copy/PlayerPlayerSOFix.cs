using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayerSOFix : MonoBehaviour
{
    public float time;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(time);
        player.SetActive(true);
    }
}
