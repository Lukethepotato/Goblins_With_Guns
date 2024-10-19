using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CompleteInputDectection : MonoBehaviour
{
    public bool input = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<PlayerInput>().ActivateInput();
    }

    public void Input(InputAction.CallbackContext ctx)
    {
        StartCoroutine(InputExploitTime());
        print("YAHHHHHHHH");
    }

    IEnumerator InputExploitTime()
    {
        input = true;
        yield return new WaitForSeconds(2f);
        input= false;
    }

}
