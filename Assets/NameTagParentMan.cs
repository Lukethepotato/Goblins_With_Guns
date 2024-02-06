using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NameTagParentMan : MonoBehaviour
{
    public MainSO mainSO;
    public GameObject mainObject;
    public PlayerInput playInput;
    public Player_SO[] playSO;
    public GameObject container;
    private bool Display = true;
    // Start is called before the first frame update
    void Start()
    {
        playInput = mainObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].health <= 0)
        {
            Display= false;
        }
        else
        {
            Display= true;
        }

        if (Display)
        {
            container.SetActive(true);
        }
        else
        {
            container.SetActive(false);
        }
    }
}
