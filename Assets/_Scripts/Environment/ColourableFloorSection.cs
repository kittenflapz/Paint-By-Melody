﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourableFloorSection : MonoBehaviour
{

    private bool filledIn;

    [SerializeField]
    MelodyScriptableObject melody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("filling in");
            FillIn();
        }
    }

    public void FillIn()
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", melody.successfulFloorColor);
    }
}
