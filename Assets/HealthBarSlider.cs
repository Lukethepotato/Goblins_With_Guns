using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class HealthBarSlider : MonoBehaviour
{
    public Slider slider;
    public GameObject mainObject;
    public PlayerInput playInput;
    public Player_SO[] playSO;
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        playInput = mainObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playSO[playInput.playerIndex].health;
    }
}
