using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Suffix S refers to 'sharp' since we can't use #
public enum Note
{ 
    C,
    CS,
    D,
    DS,
    E, 
    F, 
    FS, 
    G,
    GS,
    A,
    AS,
    B
}

public class Key : MonoBehaviour
{
    [SerializeField]
    Note note;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    KeyManager keyManager;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        keyManager = FindObjectOfType<KeyManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        AssignNote();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AssignNote()
    {
        audioSource.clip = keyManager.noteClips[(int)note];
    }

    public void PlayNote()
    {
        audioSource.Play();
        keyManager.notesJustPlayed.Add(note);
    }
}
