using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void SaveName(string name)
    {
        PlayerPrefs.SetString("name", name);
    }

    public string LoadName()
    {
        if (PlayerPrefs.HasKey("name"))
        {
            return PlayerPrefs.GetString("name");
        }
        else return "";
    }

    public void SaveAmmo(int ammo)
    {
        PlayerPrefs.SetInt("ammo", ammo);
    }

    public int LoadAmmo()
    {
        if (PlayerPrefs.HasKey("ammo"))
        {
            return PlayerPrefs.GetInt("ammo");
        }
        else return -1;
    }
}
