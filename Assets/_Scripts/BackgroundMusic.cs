using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource audio;
    [Range(0, 1.25f)]
    public float pitchRange = 1;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audio = GetComponent<AudioSource>();
        InvokeRepeating("PlayWind", .5f, 51f);
    }

    void PlayWind()
    {
        pitchRange = Random.Range(0, 1.25f);

        audio.pitch = pitchRange;
        audio.Play();
        //TODO add variety to the wind

    }
        
    
}
