using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyJoinScript : MonoBehaviour
{
    public float textDisplayTime;
    public MainSO mainSO;
    // Start is called before the first frame update

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    void Start()
    {
        StartCoroutine(TimeToInplode());
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.setUpOver)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator TimeToInplode()
    {
        yield return new WaitForSeconds(textDisplayTime);
        //gameObject.SetActive(false);
    }
}
