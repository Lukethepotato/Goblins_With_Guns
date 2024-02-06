using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletTargetScript : MonoBehaviour
{
    public GameObject targetObject;
    public float travelSpeed;
    Rigidbody2D RB;
    public GameObject followVector;
    enum BulletPaternType {basic, inOut, maintainShape}
    [SerializeField] private BulletPaternType bulletPattern;

    [Header("Basic Atributes")]
    public float speedIncrease;
    public float firePointSpeed;
    public float rotationModifier;
    public float rotationSpeed;

    [Header("maintain Shape atributes")]
    public Vector2 firePointFiredAt;


    [Header("InOut Atributes")]
    private float speed;
    public float maxDistanceTime;
    private Vector2 localFollowVector = Vector2.zero;
    private int direction = 1;
    public float startingSpeed;
    public float EndingSpeed;
    public float distanceSubtract;
    public float distanceSubtractIncrease;
    private float lowDistanceTime;
    private bool inCourtine = false;
    private Vector2 conversionPoint;
    private Vector2 orginalPath;

    private float fuckBalls;
    private bool gate = false;

    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
        LeanTween.init(999999999);
        conversionPoint = gameObject.transform.position;
        orginalPath = gameObject.transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletPattern == BulletPaternType.basic && bulletPattern != BulletPaternType.maintainShape)
        {

            if (targetObject != null)
            followVector.transform.position = targetObject.transform.position;

            Vector3 vectorToTarget = followVector.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 20);
            /*
                        Vector2 heading = followVector.transform.position - gameObject.transform.position;
                        float distance = Vector3.Distance(gameObject.transform.position, followVector.transform.position);

                        Vector3 directionOfTravel = heading / distance;

                        Vector3 CurrentPosition = gameObject.transform.position;

                        RB.MovePosition(CurrentPosition + (directionOfTravel * travelSpeed) + ((Vector3)orginalPath * firePointSpeed) * Time.deltaTime);
            */

            RB.MovePosition(gameObject.transform.position + transform.up * travelSpeed * Time.deltaTime);

            //travelSpeed += speedIncrease * Time.deltaTime;

        }
        else if (bulletPattern == BulletPaternType.maintainShape)
        {
            Vector3 vectorToTarget;

            vectorToTarget = (firePointFiredAt * 100000 + (Vector2)gameObject.transform.position);

            
            followVector.transform.position = (vectorToTarget) + gameObject.transform.position;

            Vector3 CurrentPosition = gameObject.transform.position;
            Vector3 targetPosition = followVector.transform.position;

            Vector3 directionOfTravel = targetPosition - CurrentPosition;



            RB.MovePosition(CurrentPosition + (Vector3)firePointFiredAt * travelSpeed * Time.deltaTime);
            print(firePointFiredAt.ToString());

            //INPORTANT: The travel speed amoint maintains the shape and the fire speed of where it was fired from fights against that

        }
        else if (bulletPattern == BulletPaternType.inOut && bulletPattern != BulletPaternType.maintainShape)
        {
            Vector3 vectorToTarget;

            vectorToTarget = (conversionPoint - ((Vector2)transform.position + orginalPath));
            

            followVector.transform.position = (vectorToTarget) + gameObject.transform.position;

            if (inCourtine == false)
            {
                StartCoroutine(InOutEnumator());
            }


            Vector3 CurrentPosition = transform.position;
            Vector3 targetPosition = followVector.transform.position;

            Vector3 directionOfTravel = targetPosition - CurrentPosition;

            RB.MovePosition(CurrentPosition + directionOfTravel * travelSpeed * Time.deltaTime);
            //print("InOut");
        }
    }

    public void FixedUpdate()
    {
        
        
    }

    void lengthSetting(float value)
    {
        travelSpeed = value;
    }

    IEnumerator InOutEnumator()
    {
        inCourtine = true;

        LeanTween.value(gameObject, -startingSpeed, -EndingSpeed, maxDistanceTime).setEaseInCubic().setOnUpdate(lengthSetting);

        yield return new WaitForSeconds(maxDistanceTime);
        if (direction == 1)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        if (speed - distanceSubtract > 0)
        {
            distanceSubtract += distanceSubtractIncrease;
        }
        else
        {
            distanceSubtract = 0;
        }

        if (lowDistanceTime - distanceSubtract > 0)
        {
            lowDistanceTime -= distanceSubtract;
        }
        else
        {
            lowDistanceTime = 0;
        }
        inCourtine = false;

        //print("inCo");
    }

}
