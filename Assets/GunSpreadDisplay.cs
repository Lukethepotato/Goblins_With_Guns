using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunSpreadDisplay : MonoBehaviour
{
    public int sides = 3;
    public float raidus = 3;
    public LineRenderer polygonRenderer;
    public int extraSteps = 2;
    public bool isLooped;
    public float width;
    public Player_SO[] playSO;
    public Transform[] points;
    public PlayerInput playInput;
    public float length;
    private float finalLength;
    public float timeTillFireCheck = .2f;
    private bool startCorotine = false;
    public float leenTweenSpeed = .5f;
    private bool inCourtine = false;
    private bool leenTweenOut = false;
    private bool leenTweenIn = false;
    public bool alwaysShow = false;
    // Start is called before the first frame update
    // Update is called once per frame

    private void Start()
    {
        playInput = GetComponentInParent<PlayerInput>();
        finalLength = length;

        if (alwaysShow == false)
        {
            length = 0;
        }
    }
    void Update()
    {
        polygonRenderer.SetWidth(width, width);

        points[0].eulerAngles = new Vector3(0, 0, playSO[playInput.playerIndex].BulletSpread.x);
        points[1].eulerAngles = new Vector3(0, 0, playSO[playInput.playerIndex].BulletSpread.y);

        points[0].transform.localPosition = points[0].transform.right * length;
        points[1].transform.localPosition = points[1].transform.right * length;


        //float TAU = 2 * Mathf.PI;
        for (int I = 0; I < points.Length; I++)
        {
            polygonRenderer.SetPosition(I, points[I].position);
        }

        polygonRenderer.positionCount = points.Length;


        if (alwaysShow == false)
        {
            if (playSO[playInput.playerIndex].bulletsInChamber > 0)
            {
                if (length == 0)
                {
                    LeanTween.value(gameObject, 0, finalLength, leenTweenSpeed).setEaseOutElastic().setOnUpdate(lengthSetting);
                }
            }
            else if (playSO[playInput.playerIndex].bulletsInChamber == 0)
            {
                if (length == finalLength)
                {
                    LeanTween.value(gameObject, length, 0, leenTweenSpeed).setEaseOutElastic().setOnUpdate(lengthSetting);
                }
            }
        }

        if (playSO[playInput.playerIndex].health <= 0 || playSO[playInput.playerIndex].inRollState)
        {
            polygonRenderer.enabled = false;
        }
        else
        {
            polygonRenderer.enabled = true;
        }

    }

    void lengthSetting(float value)
    {
        length = value;
    }
}
