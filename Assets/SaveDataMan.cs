using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataMan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveInt(string Key, int num)
    {
        PlayerPrefs.SetInt(Key, num);
    }

    public void AddInt(string Key, int num)
    {
        PlayerPrefs.SetInt(Key, PlayerPrefs.GetInt(Key) + num);
    }

    public void SaveFloat(string Key, float num)
    {
        PlayerPrefs.SetFloat(Key, num);
    }

    public float loadFloat(string Key)
    {
        return PlayerPrefs.GetFloat(Key);
    }

    public int loadInt(string Key)
    {
        return PlayerPrefs.GetInt(Key);

    }

}
