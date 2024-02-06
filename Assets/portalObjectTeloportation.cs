using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalObjectTeloportation : MonoBehaviour
{
    public GameObject teloportLocation;
    public Vector2 difrence;
    private bool portalDisabled;

    private void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null && portalDisabled == false)
        {
            collision.gameObject.transform.position = new Vector2(teloportLocation.transform.position.x - difrence.x, teloportLocation.transform.position.y - difrence.y);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector2(teloportLocation.transform.position.x - difrence.x, teloportLocation.transform.position.y - difrence.y);
            collision.gameObject.GetComponent<PortalDampingPlayerManager>().telaport();
            StartCoroutine(PortalDisable());
        }
    }

    IEnumerator PortalDisable()
    {
        portalDisabled= true;
        yield return new WaitForSeconds(.5f);
        portalDisabled = false;
    }


}
