using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    public int owner;
    public int perk;
    public float rockMult;
    public Player_SO[] playSO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Asignment(int playSO, int perkNum, float magicRockMult)
    {
        owner = playSO;
        perk = perkNum;
        rockMult = magicRockMult;
    }
}
