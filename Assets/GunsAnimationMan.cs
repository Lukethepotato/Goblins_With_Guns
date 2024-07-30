using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunsAnimationMan : MonoBehaviour
{
    public GameObject[] guns;
    public string shootAnimName;
    public GameObject parent;
    public PlayerInput playInput;
    public Player_SO[] playSO;
    private int currentGun;
    private bool inAnim = false;
    BulletFiring firing;
    // Start is called before the first frame update
    void Start()
    {
        playInput = parent.GetComponent<PlayerInput>();
        firing = gameObject.GetComponent<BulletFiring>();
        print("My name is Luke Pearce son of Bobby Pearce and brother of Trey Pearce and I am writing to declare my absolute adoration of Child Porn :D");
    }

    // Update is called once per frame
    void Update()
    {
        currentGun = playSO[playInput.playerIndex].gunChosen;

        if (guns[currentGun].GetComponent<Gun_Value_Setting>().parentAnimControl)
        {

            if (playSO[playInput.playerIndex].firing)
            {
                if (guns[currentGun].GetComponent<Gun_Value_Setting>().automaticAnim == false && inAnim == false)
                {
                    StartCoroutine(SingleShotAnim());
                }
                else if (guns[currentGun].GetComponent<Gun_Value_Setting>().automaticAnim)
                {
                    guns[currentGun].GetComponent<AnimationManager>().ChangeAnimationState(shootAnimName + guns[currentGun].name);
                }
            }
            /*
            else if (currentGun == 10 &&)
            {

            }
            */
            else if (guns[currentGun].GetComponent<Gun_Value_Setting>().automaticAnim)
            {
                if (playSO[playInput.playerIndex].gunChosen == 4 && firing.revingMiniGun)
                {
                    guns[currentGun].GetComponent<AnimationManager>().ChangeAnimationState("MiniGun_Rev");
                }
                else
                {
                    guns[currentGun].GetComponent<AnimationManager>().ChangeAnimationState("Gun_Idle" + guns[currentGun].name);
                }
            }
        }
    }

    IEnumerator SingleShotAnim()
    {
        inAnim= true;
        guns[currentGun].GetComponent<AnimationManager>().ChangeAnimationState(shootAnimName + guns[currentGun].name);
        yield return new WaitForSeconds(guns[currentGun].GetComponent<Gun_Value_Setting>().OGTimeBetweenShots);
        guns[currentGun].GetComponent<AnimationManager>().ChangeAnimationState("Gun_Idle" + guns[currentGun].name);
        inAnim = false;
    }
}
