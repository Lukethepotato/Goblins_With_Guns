using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEmptyOnOff : MonoBehaviour
{
    public Player_SO[] playSO;
    SpriteRenderer SR;
    BoxCollider2D boxCollider;
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        boxCollider= GetComponent<BoxCollider2D>();
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

        
    }
}
