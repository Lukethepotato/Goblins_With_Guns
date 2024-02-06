using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class HealthDroneSpawner : MonoBehaviour
{
    public MainSO mainSO;
    public Vector2[] spawnPoints;
    public float constistency;
    public GameObject healingDrone;
    public int unliklyNess;
    private bool gambled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gambled == false && mainSO.setUpOver)
        {
            StartCoroutine(SpawnGamble());
            gambled = true;
        }

        if ((mainSO.gameIsOver || mainSO.suddenDeathInitiated) && GameObject.Find("HealingDrone(Clone)") != null)
        {
            Destroy(GameObject.Find("HealingDrone(Clone)"));
        }
    }

    IEnumerator SpawnGamble()
    {
        yield return new WaitForSeconds(constistency);
        int gambleOutput = Random.Range(0, mainSO.healingDroneSpawnChance * unliklyNess);
        if (gambleOutput == 0 && GameObject.Find("HealingDrone(Clone)") == null && mainSO.gameIsOver == false && mainSO.suddenDeathInitiated ==false)
        {
            Instantiate(healingDrone, spawnPoints[mainSO.map], Quaternion.identity);
        }
        gambled= false;
    }

}
