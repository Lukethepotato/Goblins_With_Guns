using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoneyBagMan : MonoBehaviour
{
    public Player_SO[] playSO;
    PlayerInput playInput;
    public GameObject moneyBag;
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].money > 0 && playSO[playInput.playerIndex].health <= 0 && mainSO.map == 10) 
        { 
            GameObject instatedBag = Instantiate(moneyBag, gameObject.transform.position, Quaternion.identity);
            instatedBag.GetComponent<MoneyBagMan>().moneyStored = playSO[playInput.playerIndex].money;

            playSO[playInput.playerIndex].money = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("moneyBag"))
        {
            playSO[playInput.playerIndex].money += collision.gameObject.GetComponent<MoneyBagMan>().moneyStored;

            collision.gameObject.GetComponent<MoneyBagMan>().collected();
        }
    }
}
