using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolleteWheelMan : MonoBehaviour
{
    AnimationManager animMan;
    public GameObject bag;
    public GameObject bagLoco;
    private bool payingOut = false;
    private bool gambling = false;
    public MainSO mainSO;
    public int unliklyNess;
    private int startingUN;
    public float consistecy;
    // Start is called before the first frame update
    void Start()
    {
        animMan = gameObject.GetComponent<AnimationManager>();
        startingUN = unliklyNess;
    }

    // Update is called once per frame
    void Update()
    {
        if (gambling == false && mainSO.setUpOver)
        {
            StartCoroutine(Gambling());
        }
    }

    IEnumerator Gambling()
    {
        gambling= true;
        yield return new WaitForSeconds(consistecy);
        int output = Random.Range(0, unliklyNess);
        if (output == 0 && payingOut == false)
        {
            StartCoroutine(PayOut());
            unliklyNess = startingUN;
        }
        else if (payingOut == false)
        {
            unliklyNess -= 2;
        }
        gambling= false;
    }

    IEnumerator PayOut()
    {
        payingOut = true;
        animMan.ChangeAnimationState("RW_PayOut");
        yield return new WaitForSeconds(1.1f);
        Instantiate(bag, bagLoco.transform.position, Quaternion.identity);
        animMan.ChangeAnimationState("RW_Idle");
        payingOut = false;
    }
}
