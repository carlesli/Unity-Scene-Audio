using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] foostepsOnGrass;
    public AudioClip[] foostepsOnSand;
    public AudioClip[] foostepsOnWood;
    public AudioClip jump;
    public AudioClip landGrass;
    public AudioClip landWood;

    public string material;

    void PlayFootstepSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = Random.Range(0.9f, 1.0f);
        audioSource.pitch = Random.Range(0.9f, 1.1f);

        switch (material)
        {
            case "Grass":
                if (foostepsOnGrass.Length > 0)
                    audioSource.PlayOneShot(foostepsOnGrass[Random.Range(0, foostepsOnGrass.Length)]);
                break;

            //case "Sand":
            //    if (foostepsOnSand.Length > 0)
            //        audioSource.PlayOneShot(foostepsOnSand[Random.Range(0, foostepsOnSand.Length)]);
            //    break;

            case "Wood":
                if (foostepsOnWood.Length > 0)
                    audioSource.PlayOneShot(foostepsOnWood[Random.Range(0, foostepsOnWood.Length)]);
                break;

            default:
                break;
        }
    }

    void PlayJumpSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = Random.Range(0.9f, 1.0f);
        audioSource.pitch = Random.Range(0.9f, 1.1f);

        audioSource.PlayOneShot(jump);
    }

    void PlayLandSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = Random.Range(0.9f, 1.0f);
        audioSource.pitch = Random.Range(0.9f, 1.1f);

        switch (material)
        {
            case "Grass":
                audioSource.PlayOneShot(landGrass);
                break;

            case "Wood":
                audioSource.PlayOneShot(landWood);
                break;

            default:
                break;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Grass":
            case "Sand":
            case "Wood":
                material = collision.gameObject.tag;
                break;

            default:
                break;
        }
    }
}
