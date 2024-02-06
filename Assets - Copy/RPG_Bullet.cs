using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG_Bullet : MonoBehaviour
{
    public GameObject explotionCollider;
    public GameObject explotionPrephab;
    //public float timeBeforeExplotion;
    // Start is called before the first frame update
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 7);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("portal") != true)
        {
            Instantiate(explotionCollider, transform.position, Quaternion.identity);
            Instantiate(explotionPrephab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
