using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenOnlineButton : MonoBehaviour
{
    public void loadServerLoader()
    {
        SceneManager.LoadScene("ConnectToServer");
    }
}
