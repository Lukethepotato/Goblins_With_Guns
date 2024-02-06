using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEmptyOnOff : MonoBehaviour
{
    public Player_SO[] playSO;
    SpriteRenderer SR;
    BoxCollider2D boxCollider;
    public MainSO mainSO;
    public float timeTillExplode;
    public GameObject explosion;
    public GameObject exploRange;
    public TurretActivation activation;
    public GameObject turnerEmpty;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        boxCollider= GetComponent<BoxCollider2D>();
        activation = turnerEmpty.GetComponent<TurretActivation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[0].isTurret || playSO[1].isTurret || playSO[2].isTurret || playSO[3].isTurret)
        {
            SR.color = new Color(1, 1, 1, 0);
            boxCollider.enabled = false;
        }
        else
        {
            SR.color = new Color(1, 1, 1, 1);
            boxCollider.enabled = true;
        }

        if (mainSO.turretHealth < 0 || mainSO.turretHealth == 0)
        {
            StartCoroutine(Explosion());
            print("turretExplode");
        }
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(timeTillExplode);
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Instantiate(exploRange, gameObject.transform.position, Quaternion.identity);
        playSO[0].isTurret = false;
        playSO[1].isTurret = false;
        playSO[2].isTurret = false;
        playSO[3].isTurret = false;
        activation.ResetTurners();
    }
}
