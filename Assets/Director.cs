using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationModifier;
    public GameObject target;
    public bool display = false;
    public SpriteRenderer SR;
    public float leanTweenTime;
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
        SR= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (display && mainSO.inSuddenDeath == false)
        {
            SR.enabled = true;

            Vector3 vectorToTarget = target.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }
        else
        {
            SR.enabled = false;
        }
    }

    public void Display(GameObject setTarget)
    {
        display = true;
        //Vector3 startingScale = gameObject.transform.localScale;
        //gameObject.transform.localScale = Vector2.zero;
        //LeanTween.scale(gameObject, startingScale, leanTweenTime).setEaseInOutElastic();
        target = setTarget;
    }
    public void UnDisplay()
    {
        //LeanTween.scale(gameObject, Vector2.zero, leanTweenTime).setEaseInBack();
        display = false;
        target = null;
    }
}
