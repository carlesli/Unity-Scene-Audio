using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicChange : MonoBehaviour
{
    public AudioMixerSnapshot forestSnapshot;
    public AudioMixerSnapshot insideSnapshot;
    public AudioMixerSnapshot waterSnapshot;

    public float transitionTime = 0.2f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Indoor")
            insideSnapshot.TransitionTo(transitionTime);

        if (collider.gameObject.tag == "UnderWater")
            waterSnapshot.TransitionTo(transitionTime);
    }

    void OnTriggerExit(Collider collider)
    {
        forestSnapshot.TransitionTo(transitionTime);
    }
}
