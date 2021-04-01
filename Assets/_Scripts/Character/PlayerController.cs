using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{ 
     public Crosshair crosshair;
     
     public bool isFiring;
     public bool isJumping;
     public bool isRunning;


    [SerializeField]
    private GameObject hintCanvas;


    private void Awake()
    {
        hintCanvas.SetActive(false);
    }

    public void OnHint()
    {
        print("hi");
        if (hintCanvas.activeInHierarchy)
        {
            hintCanvas.SetActive(false);
        }
        else
        {
            hintCanvas.SetActive(true);
        }
    }

}

