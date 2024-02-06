using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlungerBow_Manager : MonoBehaviour
{
    public Gun_Value_Setting valueSettings;
    public float speedIncreaseSpeed;
    public float timeUntilMax;
    public float baseSpeed;
    public GameObject bulletPrephab;
    public GameObject firePoint;
    // Start is called before the first frame update
    void Start()
    {
        valueSettings = gameObject.GetComponent<Gun_Value_Setting>();
    }

    // Update is called once per frame
    void Update()
    {
        valueSettings.bulletSpeed += speedIncreaseSpeed * Time.deltaTime;
    }

    public void OnPlungerHold(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            valueSettings.bulletSpeed = baseSpeed;
            StartCoroutine(speedIncreasing());
        }else if (context.canceled)
        {
            StopCoroutine(speedIncreasing());
            FireBullet();
            valueSettings.bulletSpeed = baseSpeed;
        }
    }
    public void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrephab, firePoint.transform.position, firePoint.transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.up * valueSettings.bulletSpeed, ForceMode2D.Impulse);
    }


    IEnumerator speedIncreasing()
    {
        valueSettings.bulletSpeed += speedIncreaseSpeed * Time.deltaTime;
        yield return new WaitForSeconds(timeUntilMax);
    }
}
