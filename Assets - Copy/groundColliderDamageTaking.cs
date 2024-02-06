using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class groundColliderDamageTaking : MonoBehaviour
{
    public Player_SO[] playSO;
    public GameObject mainObject;
    public PlayerInput playInput;
    BoxCollider2D boxCollider;
    private bool gate = false;
    public float coytoteJumpTime = .2f;
    public bool checkIfTouchingSewage = true;
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
        playInput= mainObject.GetComponent<PlayerInput>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].health > 0)
        {
            playSO[playInput.playerIndex].touchingSewage = false;
            gate = true;
        }

        if (playSO[playInput.playerIndex].health < 1)
        {
            gate = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ToxicSewage") && playSO[playInput.playerIndex].invincble == false && playSO[playInput.playerIndex].health > 0 && checkIfTouchingSewage && mainSO.freezeAllPlayer ==false)
        {
            playSO[playInput.playerIndex].health -= 100;
            playSO[playInput.playerIndex].touchingSewage = true;
            print("shouldDie");
        }
        else if (other.gameObject.CompareTag("ToxicSewage") && playSO[playInput.playerIndex].invincble == false && playSO[playInput.playerIndex].health > 0 && checkIfTouchingSewage == false)
        {
            StartCoroutine(CoytoeJump());
        }
        else if (checkIfTouchingSewage == false)
        {
            playSO[playInput.playerIndex].touchingSewage = false;
        }
    }

    IEnumerator CoytoeJump()
    {
        print("bhfbhf");
        boxCollider.enabled = false;
        checkIfTouchingSewage = false;
        yield return new WaitForSeconds(coytoteJumpTime);
        checkIfTouchingSewage = true;
        boxCollider.enabled = true;
        yield return new WaitForSeconds(1);
        if (playSO[playInput.playerIndex].touchingSewage == false)
        {
            checkIfTouchingSewage = false;
        }
    }
}
