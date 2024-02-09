using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHalfTimeMan : MonoBehaviour
{
    public PlayerInput playInput;
    public Player_SO[] playSO;
    public GameObject playerObject;
    public GameObject canvasObject;
    public MainSO mainSO;

    // Start is called before the first frame update
    void Start()
    {
        canvasObject.SetActive(false);
        playInput = playerObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.displayHalfTimeInput)
        {
            canvasObject.SetActive(true);
        }
        else
        {
            canvasObject.SetActive(false);
        }
    }
}
