using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NameTagColorChange : MonoBehaviour
{
    public AnimationManager animMan;
    public PlayerInput playInput;
    public GameObject mainObject;
    public MainSO mainSO;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        animMan = gameObject.GetComponent<AnimationManager>();
        playInput = mainObject.GetComponent<PlayerInput>();
        anim= gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("NameTag_" + playInput.playerIndex.ToString());
    }
}
