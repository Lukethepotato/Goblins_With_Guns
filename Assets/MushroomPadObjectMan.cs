using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPadObjectMan : MonoBehaviour
{
    public float timeTillPropell;
    public GameObject propellColl;
    Collider2D coll2d;

    // Start is called before the first frame update
    void Start()
    {
        coll2d = gameObject.gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(MushroomPush());
        }
    }

    IEnumerator MushroomPush()
    {
        coll2d.isTrigger= true;
        yield return new WaitForSeconds(timeTillPropell);
        propellColl.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        propellColl.SetActive(false);
        coll2d.isTrigger = false;
    }
}
