using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerBullets : MonoBehaviour
{
    public float timeUnitilGone;
    public float alphaDecreaseSpeed;
    // float colorChangeSpeed;
    //public float sizeDecreaseSpeed;
    public float speedDecreaseSpeed;
    public Rigidbody2D RB;
    public SpriteRenderer SR;
    // Start is called before the first frame update
    void Start()
    {
        SR= gameObject.GetComponent<SpriteRenderer>();
        RB = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(TimeUnitDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        Color Alpha = SR.color;

        Alpha.a += alphaDecreaseSpeed* Time.deltaTime;
        SR.color = Alpha;

        RB.drag += speedDecreaseSpeed * Time.deltaTime;
        
    }

    IEnumerator TimeUnitDestroy()
    {
        yield return new WaitForSeconds(timeUnitilGone);
        Destroy(gameObject);
    }
}
