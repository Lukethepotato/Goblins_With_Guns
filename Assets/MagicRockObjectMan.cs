using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagicRockObjectMan : MonoBehaviour
{
    public Player_SO[] playSO;
    public MainSO mainSO;
    public float speed;
    public GameObject leader;
    public float timeBeforePlace;
    public bool unLeaderable = false;
    public float unleaderableTime;
    Rigidbody2D rb;
    public int currentCollection;
    BoxCollider2D boxColl2d;
    public float minDistance;
    public float maxSpeed;
    public float speedIncrease;
    public float startingSpeed;
    private float startingMass;
    public float startingDrag;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        boxColl2d = gameObject.GetComponent<BoxCollider2D>();
        boxColl2d.isTrigger= true;

        startingMass = rb.mass;
        startingDrag = rb.drag;

    }

    // Update is called once per frame
    void Update()
    {

        if (leader == null)
        {
            rb.drag = 100000000;
            rb.mass = 100000;
        }
        else
        {
            rb.drag = startingDrag;
            rb.mass = startingMass;
        }

        if (leader != null)
        {
            if (playSO[leader.GetComponent<PlayerInput>().playerIndex].health < 1 || mainSO.rematchSelected)
            {
                leader = null;
            }
        }

        if (mainSO.suddenDeathInitiated || mainSO.rematchSelected)
        {
            Destroy(gameObject);
        }

        if (leader != null)
        {
            if (Vector3.Distance(leader.transform.position, rb.transform.position) > minDistance && speed < maxSpeed)
            {
                speed += Time.deltaTime * speedIncrease;
            }        
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && unLeaderable == false && currentCollection != collision.gameObject.GetComponent<PlayerInput>().playerIndex)
        {
            leader = collision.gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (leader != null && mainSO.setUpOver && collision.gameObject.CompareTag("RockCollection") && collision.gameObject.GetComponent<RockCollectionMan>().owner == leader.GetComponent<PlayerInput>().playerIndex && unLeaderable == false)
        {
            currentCollection = collision.gameObject.GetComponent<RockCollectionMan>().owner;
            StartCoroutine(PlaceRock());
    
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RockCollection") && mainSO.setUpOver )
        {
            //playSO[collision.gameObject.GetComponent<RockCollectionMan>().owner].rocksCollected -= 1;
            StartCoroutine(NoCollectionAsign());
        }
    }

    public void LeaderAssigment(GameObject player)
    {
        if (unLeaderable == false && currentCollection != player.GetComponent<PlayerInput>().playerIndex)
        {
            leader = player;
        }
    }

    IEnumerator PlaceRock()
    {
        unLeaderable = true;

        yield return new WaitForSeconds(timeBeforePlace);
        playSO[leader.GetComponent<PlayerInput>().playerIndex].rocksCollected += 1;
        playSO[leader.GetComponent<PlayerInput>().playerIndex].magicRockMult += mainSO.rockMulptChange;
        leader = null;
        boxColl2d.isTrigger = true;
        yield return new WaitForSeconds(unleaderableTime);
        unLeaderable= false;
    }

    IEnumerator NoCollectionAsign()
    {
        yield return new WaitForSeconds(.1f);
        currentCollection = -1;
    }

    private void FixedUpdate()
    {
        if (leader != null)
        {
            Vector3 dir = (leader.transform.position - rb.transform.position).normalized;
            //Check if we need to follow object then do so 
            if (Vector3.Distance(leader.transform.position, rb.transform.position) > minDistance)
            {
                rb.MovePosition(rb.transform.position + dir * speed * Time.fixedDeltaTime);
            }
            else
            {
                speed = -startingSpeed/2;
            }
        }
    }

}
