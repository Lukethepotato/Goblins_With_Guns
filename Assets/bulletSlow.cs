using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSlow : MonoBehaviour
{
    Rigidbody2D rb;
    public float speedDecrease;
    public float maxTime;
    private float timeLeft = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.drag += speedDecrease * Time.deltaTime;

        float leDrag = rb.drag;
        timeLeft += Time.deltaTime;

        if (timeLeft > maxTime)
        {
            Destroy(gameObject);
        }
    }
}
