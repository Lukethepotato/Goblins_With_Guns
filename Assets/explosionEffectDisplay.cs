using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionEffectDisplay : MonoBehaviour
{
    public float timeTillExplode;
    public LineRenderer lineRenderer;
    public int sides = 5;
    public float radius = 3;
    private float finalRadius;
    public float leenTweenSpeed;
    public ParticleSystem lowerOne;
    ParticleSystem thisOne;
    public GrenadeExplosionEffectMan grenadeEffectMan;
    public GameObject lowerObject;
    private bool draw = false;
    // Start is called before the first frame update
    void Start()
    {
        lowerOne = lowerObject.GetComponent<ParticleSystem>();
        thisOne = gameObject.GetComponent<ParticleSystem>();
        grenadeEffectMan = gameObject.GetComponent<GrenadeExplosionEffectMan>();
        finalRadius = radius;
        radius = 0;

        lowerOne.Stop();
        thisOne.Stop();

        var particleMainSettings = thisOne.main;
        particleMainSettings.startDelay = timeTillExplode;

        var particleBelowSettings = lowerOne.main;
        particleBelowSettings.startDelay = timeTillExplode;

        lowerOne.Play();
        thisOne.Play();

        StartCoroutine(Explode());
    }

    // Update is called once per frame

    private void Update()
    {
        if (draw)
        {
            DrawLooped();
        }
    }

    void DrawLooped()
    {
        lineRenderer.positionCount = sides;
        float TAU = 2 * Mathf.PI;

        for (int currentPoint = 0; currentPoint < sides; currentPoint++)
        {
            float currentRadian = ((float)currentPoint / sides) * TAU;
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
        print("didTHeThing");
        draw = true;
        LeanTween.value(gameObject, 0, finalRadius, leenTweenSpeed).setEasePunch().setOnUpdate(RadiusSetting);
        yield return new WaitForSeconds(timeTillExplode);
        grenadeEffectMan.ready= true;
    }

}
