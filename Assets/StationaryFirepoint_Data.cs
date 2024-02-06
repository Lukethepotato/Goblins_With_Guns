using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryFirepoint_Data : MonoBehaviour
{
    public int owner;
    public int perkOwned;
    public float rockMult;
    // Start is called before the first frame update
    public void Assigment(int setOwner, int setPerk, int setRockMul)
    {
        owner = setOwner;
        perkOwned = setPerk;
        rockMult = setRockMul;
    }
}
