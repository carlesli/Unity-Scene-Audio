using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicChange : MonoBehaviour
{
    public AudioMixerSnapshot baseSnapshot;
    public AudioMixerSnapshot tensionSnapshot;
    public AudioMixerSnapshot combatSnapshot;

    public float transitionTime = 0.2f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Indoor")
            combatSnapshot.TransitionTo(transitionTime);

        if (collider.gameObject.tag == "Tension Area")
            tensionSnapshot.TransitionTo(transitionTime);
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Indoor")
            tensionSnapshot.TransitionTo(transitionTime);

        if (collider.gameObject.tag == "Tension Area")
            baseSnapshot.TransitionTo(transitionTime);
    }
}
