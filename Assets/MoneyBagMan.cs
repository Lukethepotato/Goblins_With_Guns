using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBagMan : MonoBehaviour
{
    AnimationManager animMan;
    public MainSO mainSO;
    public int moneyStored;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.inSuddenDeath)
        {
            Destroy(gameObject);
        }
    }

    public void collected()
    {
        Destroy(gameObject);
        GameObject.Find("SFX").GetComponent<AudioManager>().Play("BookCollect");
    }
}
