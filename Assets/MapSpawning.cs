using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawning : MonoBehaviour
{
    public GameObject[] maps;
    public MainSO mainSO;

    public Vector2[] barrelTownSpawnPoints;
    public Vector2[] sewageStationSpawnPoints;
    public Vector2[] splitStatesSpawnPoints;
    public Vector2[] TurretMapSpawnPoints;
    public Vector2[] CastleMap1SpawnPoints;
    public Vector2[] CourtYardMap1SpawnPoints;
    public Vector2[] CastleInside1SpawnPoints;
    public Vector2[] test1;
    public Vector2[] test2;
    public Vector2[] test3;
    public Vector2[] test4;
    public Vector2[] swamp;
    // Start is called before the first frame update

    private void Update()
    {
        maps[mainSO.map].SetActive(true);
        for (int I = 0; I < maps.Length; I++)
        {
            if (maps[I].activeSelf == true && I != mainSO.map)
            {
                maps[I].SetActive(false);
            }else if (mainSO.inSuddenDeath)
            {
                maps[I].SetActive(false);
            }
        }


        if (mainSO.inSuddenDeath ==false)
        {
            if (mainSO.map == 0)
            {
                mainSO.playersSpawnLocations = barrelTownSpawnPoints;
            }
            else if (mainSO.map == 1)
            {
                mainSO.playersSpawnLocations = sewageStationSpawnPoints;
            }
            else if (mainSO.map == 2)
            {
                mainSO.playersSpawnLocations = splitStatesSpawnPoints;
            }
            else if (mainSO.map == 3)
            {
                mainSO.playersSpawnLocations = TurretMapSpawnPoints;
            }
            else if (mainSO.map == 4)
            {
                mainSO.playersSpawnLocations = CastleMap1SpawnPoints;
            }
            else if (mainSO.map == 5)
            {
                mainSO.playersSpawnLocations = CourtYardMap1SpawnPoints;
            }
            else if (mainSO.map == 6)
            {
                mainSO.playersSpawnLocations = CastleInside1SpawnPoints;
            }
            else if (mainSO.map == 7)
            {
                mainSO.playersSpawnLocations = test1;
            }
            else if (mainSO.map == 8)
            {
                mainSO.playersSpawnLocations = test2;
            }
            else if (mainSO.map == 9)
            {
                mainSO.playersSpawnLocations = test3;
            }
            else if (mainSO.map == 10)
            {
                mainSO.playersSpawnLocations = test4;
            }
            else if (mainSO.map == 11)
            {
                mainSO.playersSpawnLocations = swamp;
            }
        }
    }
}
