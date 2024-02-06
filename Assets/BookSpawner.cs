using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawner : MonoBehaviour
{
    public MainSO mainSO;
    public GameObject bookEmpty;
    private bool gate = false;
    private bool gate2 = false;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bookEmpty);
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.rematchSelected && gate == false)
        {
            StartCoroutine(Instantiate());
        }

        
    }

    IEnumerator Instantiate()
    {
        gate = true;
        Destroy(GameObject.Find("books"));
        Destroy(GameObject.Find("MagicBook"));
        Destroy(GameObject.Find("MagicBook 1"));
        Destroy(GameObject.Find("MagicBook 2"));
        Destroy(GameObject.Find("MagicBook 3"));
        Instantiate(bookEmpty);
        yield return new WaitForSeconds(5);
        gate= false;
    }

}
