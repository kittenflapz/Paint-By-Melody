using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class PlayerController : MonoBehaviour
{ 
     public Crosshair crosshair;
     
     public bool isFiring;
     public bool isJumping;
     public bool isRunning;

    [SerializeField]
    Transform startPosition;


    public AudioClip[] noteClips;
    AudioSource audioSource;

    [SerializeField]
    private GameObject hintCanvas;

    SaveManager saveManager;

    KeyManager keyManager;
    public TextMeshProUGUI ammoLabel;

    public int ammo;

    private void Awake()
    {
        hintCanvas.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        saveManager = FindObjectOfType<SaveManager>();
        keyManager = FindObjectOfType<KeyManager>();
    }
    private void Start()
    {
        ammo = saveManager.LoadAmmo();
        ammoLabel.SetText(ammo.ToString());
    }

    public void ReduceAmmo()
    {
        if (ammo > 0)
        {
            ammo--;

            ammoLabel.SetText(ammo.ToString());
        }
    }

    public void OnJump()
    {
        if (ammo < 99)
        {
            ammo++;
            ammoLabel.SetText(ammo.ToString());
        }
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

    public void OnQuit()
    {

        saveManager.SavePlatformsColoured(keyManager.floorSections);
        saveManager.SaveAmmo(ammo);

#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
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

    public void RespawnAtHome()
    {
        transform.position = startPosition.position;
    }
    IEnumerator PlayMelodyWithGivenDelay(float seconds, List<Note> melody)
    {
        foreach (Note note in melody)
        {
            yield return new WaitForSeconds(seconds);
            PlayNote(note);
        }
    }

    private void OnDestroy()
    {
        saveManager.SaveAmmo(ammo);
    }
}

