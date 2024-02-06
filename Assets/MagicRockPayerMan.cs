using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagicRockPayerMan : MonoBehaviour
{
    public Player_SO[] playSO;
    public PlayerInput playInput;
    public MainSO mainSO;
    public float baseRockAmount;
    public float baseMult;
    public float increaseAmount;
    private int priorMagicRocks;
    // Start is called before the first frame update
    void Start()
    {
        playSO[playInput.playerIndex].rocksCollected = (int)baseRockAmount;
        priorMagicRocks = (int)baseRockAmount;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (mainSO.map == 7)
        {
            for (int I = 0; I <= playSO[playInput.playerIndex].rocksCollected; I++)
            {
                if (I == 0)
                {
                    //priorMagicRocks = playSO[playInput.playerIndex].rocksCollected;
                    if (playSO[playInput.playerIndex].rocksCollected < baseRockAmount)
                    {
                        playSO[playInput.playerIndex].magicRockMult = baseMult;

                    }
                    else if (playSO[playInput.playerIndex].rocksCollected >= baseRockAmount)
                    {
                        playSO[playInput.playerIndex].magicRockMult = 1;
                    }

                }
                else
                {
                    playSO[playInput.playerIndex].magicRockMult += increaseAmount;
                    print("increase");
                }
            }
        }
        */


        if (mainSO.map != 7 || mainSO.rematchSelected)
        {
            playSO[playInput.playerIndex].magicRockMult = 1;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MagicRock") && collision.gameObject.GetComponent<MagicRockObjectMan>().currentCollection != playInput.playerIndex)
        {
            collision.gameObject.GetComponent<Collider2D>().isTrigger = false;
            playSO[collision.gameObject.GetComponent<MagicRockObjectMan>().currentCollection].rocksCollected -= 1;
            playSO[collision.gameObject.GetComponent<MagicRockObjectMan>().currentCollection].magicRockMult -= mainSO.rockMulptChange;
            print("remove magic rock");

            collision.gameObject.GetComponent<MagicRockObjectMan>().LeaderAssigment(gameObject);
        }
    }
}


