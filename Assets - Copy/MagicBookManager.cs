using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBookManager : MonoBehaviour
{
    public int bookColor;
    AnimationManager animMan;
    public string[] colorAnims;
    // Start is called before the first frame update
    void Start()
    {
        animMan = gameObject.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        animMan.ChangeAnimationState(colorAnims[bookColor]);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<PlayerMagicBookManager>().MagicBookPickedUp(bookColor);
            Destroy(gameObject);
        }
    }
}
