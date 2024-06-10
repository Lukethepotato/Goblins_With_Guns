using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingDroneManager : MonoBehaviour
{
    public AnimationManager droneAnim;
    public AnimationManager landingZoneAnim;
    public GameObject landZone;
    public int playersInLandingZone;
    public MainSO mainSO;
    public BoxCollider2D boxCollider;
    private bool cowntdownStarted = false;
    public bool droneDeployed = false;
    public bool healthReceived = false;
    public bool goingDown = false;
    public AIPath aiPath;
    AIDestinationSetter destinationSetter;
    public GameObject Target;
    public Player_SO[] playSO;
    // Start is called before the first frame update
    void Start()
    {
        droneAnim = gameObject.GetComponent<AnimationManager>();
        landingZoneAnim = landZone.GetComponent<AnimationManager>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        aiPath = gameObject.GetComponent<AIPath>();
        destinationSetter = gameObject.GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = mainSO.playersReadiedUp - 1; I >= 0; I--)
        {
            if (playSO[mainSO.rankings[I]].hasDied == false)
            {
                Target.transform.position = GameObject.Find("player" + (mainSO.rankings[I] + 1).ToString()).transform.position;
                I = -1;
                print("newTarget");
            }
            else
            {
                print("notDecided");
            }
            
        }


        if (playersInLandingZone == 1 && droneDeployed == false && cowntdownStarted == false)
        {
            StartCoroutine(Cowntdown());
            cowntdownStarted =true;
        }
        if  (playersInLandingZone > 1 && droneDeployed == false && goingDown == false)
        {
            landingZoneAnim.ChangeAnimationState("Land_Cancel");
            StopCoroutine(Cowntdown());
            StopAllCoroutines();
            cowntdownStarted = false;
        }
        if (droneDeployed == false && playersInLandingZone == 0 && goingDown == false)
        {
            landingZoneAnim.ChangeAnimationState("Land_Idle");
            droneAnim.ChangeAnimationState("Heal_Idle");
            StopAllCoroutines();
        }

        if (healthReceived)
        {
            Destroy(gameObject);
        }

        if (playersInLandingZone == 0 && droneDeployed == false && goingDown == false)
        {
            StopAllCoroutines();
            landingZoneAnim.ChangeAnimationState("Land_Idle");
            cowntdownStarted= false;
        }
    }

    IEnumerator Cowntdown()
    {
        landingZoneAnim.ChangeAnimationState("Land_Cowntdown");
        yield return new WaitForSeconds(3);
        if (droneDeployed == false && playersInLandingZone == 1)
        {
            droneAnim.ChangeAnimationState("Heal_Deploy");
            goingDown = true;
            aiPath.enabled = false;
        }
        yield return new WaitForSeconds(.83f);
        if (goingDown == true)
        {
            boxCollider.enabled = true;
            droneDeployed = true;
            droneAnim.ChangeAnimationState("Heal_Ground");
        }
        yield return new WaitForSeconds(.1f);
    }
}
