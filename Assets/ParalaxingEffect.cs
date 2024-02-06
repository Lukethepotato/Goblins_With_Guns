using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParalaxingEffect : MonoBehaviour
{
    private float length, startpos, startposy;
    public GameObject cam;
    public float parallaxEffect;
    public float yParallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        startposy = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    private void Update()
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        float disty = (cam.transform.position.y * yParallaxEffect);

        transform.position = new Vector2(startpos + dist, startposy + disty);
    }
}