using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WitchManager : MonoBehaviour
{
    public float timeLeft;
    public float maxTime;
    public int playersIn = 0;
    public bool disabled = false;
    private bool activated = false;
    public bool stirring = false;
    public float potionDropTime;
    public float startUptime;
    public float fallAsleepTime;
    public AnimationManager animationManager;
    public Slider slider;
    public GameObject potion;
    private bool done = false;
    public GameObject potionLocation;
    public float respawnTime;
    public MainSO mainSO;
    public bool off = false;
    // Start is called before the first frame update
    void Start()
    {
        animationManager = GetComponentInChildren<AnimationManager>();
        StartCoroutine(WitchReset());
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.rematchSelected)
        {
            StartCoroutine(WitchReset());
        }

        if (playersIn == 1 && disabled == false && activated == false)
        {
            StartCoroutine(StartUp());
            activated= true;
        }

        if (stirring && disabled == false && off == false)
        {
            timeLeft += Time.deltaTime;
        }

        if (stirring && playersIn != 1 && disabled == false) 
        { 
            stirring= false;
            disabled= true;
            StartCoroutine(FallAsleep());
        }

        slider.value = timeLeft;
        slider.maxValue = maxTime;

        if (done == false && stirring && timeLeft >= maxTime && disabled == false)
        {
            StartCoroutine(Done());
            done= true;
        }

        if (stirring && GameObject.Find("SFX").GetComponent<AudioManager>().StillPlaying("WitchStir") == false)
        {
            GameObject.Find("SFX").GetComponent<AudioManager>().Play("WitchStir");
        }else if (stirring == false)
        {
            GameObject.Find("SFX").GetComponent<AudioManager>().StopPlaying("WitchStir");
        }

    }

    IEnumerator StartUp()
    {
        if (off == false)
        {
            disabled = true;
            animationManager.ChangeAnimationState("witch_wakeup");
            yield return new WaitForSeconds(startUptime);
            animationManager.ChangeAnimationState("witch_stir");
            disabled = false;
            stirring = true;
        }
    }

    IEnumerator FallAsleep()
    {
        if (off == false)
        {
            animationManager.ChangeAnimationState("witch_fallasleep");
            yield return new WaitForSeconds(fallAsleepTime);
            animationManager.ChangeAnimationState("witch_sleep");
            disabled = false;
            activated = false;
        }
    }
    
    IEnumerator Done() 
    {
        if (off == false)
        {
            GameObject.Find("SFX").GetComponent<AudioManager>().Play("WitchEnd");
            animationManager.ChangeAnimationState("witch_done");
            off = true;
            yield return new WaitForSeconds(potionDropTime);
            animationManager.ChangeAnimationState("witch_none");
            timeLeft = 0;
            activated = false;
            Instantiate(potion, new Vector2(potionLocation.transform.position.x, potionLocation.transform.position.y), Quaternion.identity);
            StartCoroutine(TimeTillUnDisabled());
        }
    }

    IEnumerator TimeTillUnDisabled()
    {
        if (off)
        {
            yield return new WaitForSeconds(respawnTime);
            GameObject.Find("SFX").GetComponent<AudioManager>().Play("WitchSpawn");
            animationManager.ChangeAnimationState("Witch_Spawn");
            yield return new WaitForSeconds(.8f);
            animationManager.ChangeAnimationState("witch_sleep");
            done = false;
            off = false;
            stirring = false;
            activated = false;
            disabled= false;
        }
    }
    IEnumerator WitchReset()
    {
        GameObject.Find("SFX").GetComponent<AudioManager>().Play("WitchSpawn");
        animationManager.ChangeAnimationState("Witch_Spawn");
        yield return new WaitForSeconds(.8f);
        off = false;
        stirring = false;
        activated = false;
        animationManager.ChangeAnimationState("witch_sleep");
        done = false;
        timeLeft = 0;
        if (GameObject.Find("potion") != null)
        {
            Destroy(GameObject.Find("potion"));
        }
    }


}
