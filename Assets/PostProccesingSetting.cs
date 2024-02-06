using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProccesingSetting : MonoBehaviour
{
    public GameObject camObject;
    public PostProcessVolume PPVolume;
    public PostProcessProfile[] Profile;
    // Start is called before the first frame update
    void Start()
    {
        PPVolume = camObject.GetComponent<PostProcessVolume>();
        int profile = Random.Range(0, Profile.Length );
        
        PPVolume.profile = Profile[profile];

        print(profile.ToString());

        print(Profile.Length.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
