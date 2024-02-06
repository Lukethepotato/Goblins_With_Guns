using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RockCollectionMan : MonoBehaviour
{
    public Player_SO[] playSO;
    public int owner;
    public GameObject magicRock;
    public Vector2[] spawnCations;
    public int rocksToSpawn = 3;
    private bool rocksSpawned = false;


    // Start is called before the first frame update
    void Start()
    {
        if (rocksSpawned == false)
        {
            rocksSpawned = true;
            for (int I = 0; I < 3; I++)
            {
                GameObject localMagicRock = Instantiate(magicRock, spawnCations[I], Quaternion.identity);
                localMagicRock.GetComponent<MagicRockObjectMan>().currentCollection = owner;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RematchRocks()
    {
        if (rocksSpawned)
        {
            for (int I = 0; I < 3; I++)
            {
                GameObject localMagicRock = Instantiate(magicRock, spawnCations[I], Quaternion.identity);
                localMagicRock.GetComponent<MagicRockObjectMan>().currentCollection = owner;
            }
            rocksSpawned = false;
            StartCoroutine(thing());
            print("ROCKS");
        }
    }

    IEnumerator thing()
    {
        yield return new WaitForSeconds(1);
        rocksSpawned = true;
    }
}
