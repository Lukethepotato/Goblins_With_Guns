using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosionMan : MonoBehaviour
{
    public float exploDamage;
    public Vector2 size;
    public GameObject wandExplosion;
    public GameObject firepointStat;
    private bool explodeAnim = false;
    AnimationManager animMan;
    BulletData bulletData;
    public float timeBeforeExplo = .7f;
    public LineRenderer lineRenderer;
    public int sides;
    public float radius;
    public float width;
    private float finalRadius;
    public float leenTweenSpeed = .5f;

    // Start is called before the first frame update
    void Start()
    {
        animMan= gameObject.GetComponent<AnimationManager>();
        bulletData = gameObject.GetComponent<BulletData>();
        finalRadius = radius;
        radius = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (explodeAnim == false)
        {
            animMan.ChangeAnimationState("WandBulletIdle");
        }
        else
        {
            animMan.ChangeAnimationState("WandBulletExplode");
        }

        DrawLooped();

        lineRenderer.SetWidth(width, width);
    }

    public void Explode()
    {
        StartCoroutine(WandExplosion());
        print("recevied");
    }

    public void InstaniateExplosion()
    {
        GameObject prephab = Instantiate(wandExplosion, transform.position, Quaternion.identity);
        prephab.GetComponent<WandExplosionDamage>().damage = exploDamage;
        prephab.GetComponent<BulletData>().Asignment(bulletData.owner, bulletData.perk, 1);
        prephab.transform.localScale = size;

        GameObject firepoint = Instantiate(firepointStat, transform.position, gameObject.transform.rotation);
        firepoint.GetComponent<StationaryFirepoint_Data>().Assigment(bulletData.owner, bulletData.perk, 1);
        firepoint.GetComponent<StationaryFirepointWandSetting>().AssignWandAmount(size.x);
        print("recevied");
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
    void lengthSetting(float value)
    {
        radius = value;
    }

    IEnumerator WandExplosion()
    {
        LeanTween.value(gameObject, 0, finalRadius, leenTweenSpeed).setEaseInOutElastic().setOnUpdate(lengthSetting);
        yield return new WaitForSeconds(timeBeforeExplo);
        explodeAnim = true;
        yield return new WaitForSeconds(timeBeforeExplo);
        InstaniateExplosion();
        yield return new WaitForSeconds(.01f);
        Destroy(gameObject);
    }
}
