using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VolumeSO", menuName = "VolumeSO")]
public class VolumePlaySO : ScriptableObject
{
    // volumes set by player, they shoud stay exactly the same unless changed by player
    public float[] setVolumes;

    // The actuall volumes used in game, can be changed for moments but always set back to player set one eventually
    public float[] activeVolumes;
    public bool activeVolLocked;

    // 0 = none;
    // 1 = Music,
    // 2 = SFX,
    // 3 = UI
    // 4 = Anouncers

    //The volume numbers should go from a min of 0 to a max of 1.5
}
