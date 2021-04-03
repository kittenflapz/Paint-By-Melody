using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartCanvasController : MonoBehaviour
{
    SaveManager saveManager;

    [SerializeField]
    GameObject loadButton;

    [SerializeField]
    TextMeshProUGUI loadName;

    [SerializeField]
    TMP_InputField nameInput;

    string loadGameButtonText;
   
    private void Awake()
    {
        saveManager = FindObjectOfType<SaveManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (saveManager.LoadName() != "")
        {
            loadButton.SetActive(true);
            loadGameButtonText = "Load ";
            loadGameButtonText += saveManager.LoadName();
            loadGameButtonText += "'s game";
            loadName.SetText(loadGameButtonText);
        }
        else // probably not needed
        {
            loadButton.SetActive(false);
        }
    }

    public void SaveName()
    {
       
       saveManager.SaveName(nameInput.text);
      
    }
}
