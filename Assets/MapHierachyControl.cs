using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class MapHierachyControl : MonoBehaviour
{
    public MultiplayerEventSystem multEventSys;
    public GameObject eventSysObject;
    // Start is called before the first frame update
    void Start()
    {
        multEventSys = eventSysObject.GetComponent<MultiplayerEventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (multEventSys.currentSelectedGameObject == gameObject)
        {
            transform.SetAsLastSibling();
        }
    }
}
