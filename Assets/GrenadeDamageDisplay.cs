using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GrenadeDamageDisplay : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float radius;
    public int sides;
    public float width;
    public float finalRadius;
    public float leenTweenSpeed;
    // Start is called before the first frame update
    void Start()
    {
        finalRadius = radius;

        lineRenderer = gameObject.GetComponent<LineRenderer>();
        StartCoroutine(RangeCourtine());
    }

    void lengthSetting(float value)
    {
        radius = value;
    }

    // Update is called once per frame
    void Update()
    {
        DrawLooped();

        lineRenderer.SetWidth(width, width);
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

    IEnumerator RangeCourtine()
    {
        LeanTween.value(gameObject, 0, finalRadius, leenTweenSpeed).setEaseInOutElastic().setOnUpdate(lengthSetting);
        yield return new WaitForSeconds(leenTweenSpeed);
        radius = finalRadius;
    }
}
