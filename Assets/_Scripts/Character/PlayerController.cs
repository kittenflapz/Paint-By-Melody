using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{ 
     public Crosshair crosshair;
     
     public bool isFiring;
     public bool isJumping;
     public bool isRunning;


    public AudioClip[] noteClips;
    AudioSource audioSource;

    [SerializeField]
    private GameObject hintCanvas;


    private void Awake()
    {
        hintCanvas.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void OnHint()
    {
        if (hintCanvas.activeInHierarchy)
        {
            hintCanvas.SetActive(false);
        }
        else
        {
            hintCanvas.SetActive(true);
        }
    }

    public void PlayMelody(List<Note> melody)
    {
        StartCoroutine(PlayMelodyWithGivenDelay(0.3f, melody));
    }

    public void PlayNote(Note note)
    {
        audioSource.clip = noteClips[(int)note];
        audioSource.Play();
    }


    IEnumerator PlayMelodyWithGivenDelay(float seconds, List<Note> melody)
    {
        foreach (Note note in melody)
        {
            yield return new WaitForSeconds(seconds);
            PlayNote(note);
        }
    }
}

