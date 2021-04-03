using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void SaveName(string name)
    {
        // If we're setting a new name, we're starting a new game, so clear everything else.
        // This is terrible but works, something something product driven
        PlayerPrefs.DeleteAll();
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
        else return 10;
    }


    // Platform loading is done with a string in which each character represents the coloured-ness (c) or not-coloured-ness (n) of each platform.


    public void LoadPlatformsColoured(List<ColourableFloorSection> floorSections)
    {
        if (PlayerPrefs.HasKey("platforms"))
        {
            string loadedPlatformsString = PlayerPrefs.GetString("platforms");
            foreach(ColourableFloorSection floorSection in floorSections)
            {
                if (loadedPlatformsString[floorSection.platformIdentifier] == 'c')
                {
                    floorSection.FillIn();
                }
            }
        }
    }

    // must be passed in in the right order (not ideal but as this is not a leetcode easy i will not write a sort function)

    public void SavePlatformsColoured(List<ColourableFloorSection> floorSections)
    {
        string platformsColoured ="";

        foreach (ColourableFloorSection floorSection in floorSections)
        {
            if (floorSection.GetFilledIn())
            {
                platformsColoured += "c";
            }
            else
            {
                platformsColoured += "n";
            }
        }
        print("saving platforms coloured as ");
        print(platformsColoured);
        PlayerPrefs.SetString("platforms", platformsColoured);
    }
}
