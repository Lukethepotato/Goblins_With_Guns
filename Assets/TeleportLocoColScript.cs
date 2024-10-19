using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLocoColScript : MonoBehaviour
{
    Collider2D coll;
    public int playIndex;
    public float exploLength;
    public GameObject exploTrigger;
    AnimationManager animMan;
    public Player_SO[] playSO;
    // Start is called before the first frame update
    void Start()
    {
        coll= gameObject.GetComponent<Collider2D>();
        animMan= gameObject.GetComponent<AnimationManager>();
        StartCoroutine(lateUpdate());
        //GameObject.Find("PlayerSFX").GetComponent<AudioManager>().Play("MistyTelegraph");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision != null)
        {
            //gameObject.transform.position -= collision.transform.position;
        }
    }

    public void OnCreation(int PlaySO)
    {
        playIndex =PlaySO;
    }

    public void Explode()
    {
        StartCoroutine(Explosion());
    }

    IEnumerator Explosion()
    {
        animMan.ChangeAnimationState("Blink_explode");
        GameObject.Find("SFX").GetComponent<AudioManager>().Play("MistyStepExplo");
        //GameObject triggerPrephab = Instantiate(exploTrigger, gameObject.transform.position, Quaternion.identity);
        //triggerPrephab.GetComponent<BulletData>().Asignment(playIndex, playSO[playIndex].perkOwned, 0);
        exploTrigger.SetActive(true);
        exploTrigger.GetComponent<BulletData>().Asignment(playIndex, playSO[playIndex].perkOwned, 0);
        yield return new WaitForSeconds(exploLength);
        //Destroy(triggerPrephab);
        Destroy(gameObject);
    }

    IEnumerator lateUpdate()
    {
        yield return new WaitForSeconds(.1f);
        coll.enabled = false;
    }
}
