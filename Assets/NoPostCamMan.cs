using UnityEngine;

public class NoPostCamMan : MonoBehaviour
{
    public GameObject manCam;
    public Camera mainCam;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = manCam.GetComponent<Camera>();
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.orthographicSize = mainCam.orthographicSize;
        //print(mainCam.orthographicSize.ToString());
    }
}
