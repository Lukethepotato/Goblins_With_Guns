using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnockBackPlayerMan : MonoBehaviour
{
    public float velocThreshold;
    Rigidbody2D RB;
    PlayerInput playInput;
    public Player_SO[] playSO;
    public GameObject effect;
    private float velocXY;
    public float knockBackMult;
    public float damagMult;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocXY = RB.velocity.x + RB.velocity.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && velocThreshold < velocXY)
        {
            playSO[collision.gameObject.GetComponent<PlayerInput>().playerIndex].health -= velocXY * damagMult;
            Instantiate(effect, collision.gameObject.transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(RB.velocity * knockBackMult * Time.deltaTime);
        }
    }
}
