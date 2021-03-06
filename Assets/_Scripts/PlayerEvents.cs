using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{
    public delegate void WeaponEquipped(WeaponComponent weapon);

    public static event WeaponEquipped OnEquipWeapon;

    public static void Invoke_OnWeaponEquipped(WeaponComponent weapon)
    {
        OnEquipWeapon?.Invoke(weapon);
    }
}
