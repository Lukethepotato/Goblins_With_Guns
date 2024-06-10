using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class randomBulletSpread : MonoBehaviour
{
    public GameObject mainPlayer;
    public PlayerInput input;
    public Player_SO[] playSO;
    public MainSO mainSO;
    public Transform[] guns;
    public Transform[] shotty;
    public Transform[] smg;
    public float timeTillReset;
    public float spreadIncrease;
    public float spreadMultipler;
    public float maxSpread;
    

    public Vector2 bulletSpread;
    public float turnSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        input = gameObject.GetComponentInParent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletSpread = playSO[input.playerIndex].BulletSpread;

        if (playSO[input.playerIndex].bulletSpread && guns[playSO[input.playerIndex].gunChosen] != null)
        {
            guns[playSO[input.playerIndex].gunChosen].localEulerAngles = new Vector3(guns[playSO[input.playerIndex].gunChosen].localEulerAngles.x, guns[playSO[input.playerIndex].gunChosen].localEulerAngles.y, Random.Range(bulletSpread.x / spreadMultipler, bulletSpread.y * spreadMultipler));

            if (spreadMultipler < maxSpread) 
            {
                spreadMultipler *= spreadIncrease;
            }

            StartCoroutine(IncreaseBulletSpread());
            playSO[input.playerIndex].bulletSpread = false;
        }
        else if (playSO[input.playerIndex].gunChosen == 1 && playSO[input.playerIndex].bulletSpread)
        {
            shotty[0].localEulerAngles = new Vector3(shotty[0].localEulerAngles.x, shotty[0].localEulerAngles.y, Random.Range(bulletSpread.x / spreadMultipler, bulletSpread.y * spreadMultipler));
            shotty[1].localEulerAngles = new Vector3(shotty[1].localEulerAngles.x, shotty[1].localEulerAngles.y, Random.Range(bulletSpread.x / spreadMultipler, bulletSpread.y * spreadMultipler));
            shotty[2].localEulerAngles = new Vector3(shotty[2].localEulerAngles.x, shotty[2].localEulerAngles.y, Random.Range(bulletSpread.x / spreadMultipler, bulletSpread.y * spreadMultipler));
            shotty[3].localEulerAngles = new Vector3(shotty[3].localEulerAngles.x, shotty[3].localEulerAngles.y, Random.Range(bulletSpread.x / spreadMultipler, bulletSpread.y * spreadMultipler));
        }
    }

    IEnumerator IncreaseBulletSpread()
    {
        yield return new WaitForSeconds(timeTillReset);
        if (playSO[input.playerIndex].bulletSpread == false)
        spreadMultipler = 1;
        
    }
}
