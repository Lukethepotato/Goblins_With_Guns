using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DirectorDisplay : MonoBehaviour
{
    public PlayerInput playInput;
    public Player_SO[] playSO;
    public Director director;
    public MainSO mainSO;
    public GameObject directObject;
    // Start is called before the first frame update
    void Start()
    {
        director = directObject.GetComponent<Director>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].money > 99 && playSO[playInput.playerIndex].health > 0 && mainSO.map == 10 && playSO[playInput.playerIndex].state == 0 && mainSO.suddenDeathInitiated == false)
        {
            director.Display(GameObject.Find("TargetCasino"));
        }
        else if (playSO[playInput.playerIndex].magicBooksHeld > 3 && playSO[playInput.playerIndex].health > 0 && mainSO.map == 6 && playSO[playInput.playerIndex].state == 0 && mainSO.suddenDeathInitiated == false)
        {
            director.Display(GameObject.Find("TargetCastleInside"));
        }
        else if (director.display == true)
        {
            director.UnDisplay();
        }
    }
}
