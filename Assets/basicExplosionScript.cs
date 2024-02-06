using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class basicExplosionScript : MonoBehaviour
{
    public GameObject range;
    public float timeTillExplode;
    public LineRenderer lineRenderer;
    public int sides = 5;
    public float radius = 3;
    private float finalRadius;
    public float leenTweenSpeed;
    public ParticleSystem lowerOne;
    ParticleSystem thisOne;
    public GameObject lowerObject;
    // Start is called before the first frame update
    void Start()
    {
        lowerOne = lowerObject.GetComponent<ParticleSystem>();
        thisOne = gameObject.GetComponent<ParticleSystem>();
        finalRadius= radius;
        radius= 0;

        lowerOne.startDelay = timeTillExplode;
        thisOne.startDelay = timeTillExplode;

        Explode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawLooped()
    {
        lineRenderer.positionCount = sides;
        float TAU = 2 * Mathf.PI;

        for (int currentPoint = 0; currentPoint<sides; currentPoint++)
        {
            float currentRadian = ((float)currentPoint/ sides) * TAU;
            float x = (Mathf.Cos(currentRadian) * radius) + gameObject.transform.position.x;
            float y = (Mathf.Sin(currentRadian) * radius) + gameObject.transform.position.y;
            lineRenderer.SetPosition(currentPoint, new Vector3(x, y, 0));
        }
    }

    private void RadiusSetting(float Radius)
    {
        radius = Radius;
    }

    IEnumerator Explode()
    {
        DrawLooped();
        LeanTween.value(gameObject, 0, finalRadius, leenTweenSpeed).setEasePunch().setOnUpdate(RadiusSetting);
        yield return new WaitForSeconds(timeTillExplode);
        Instantiate(range);
        Destroy(gameObject);
    }
}
