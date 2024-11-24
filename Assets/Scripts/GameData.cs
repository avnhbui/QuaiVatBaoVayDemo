using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameData : MonoBehaviour
{
     public static GunInfor[] equippedGuns = new GunInfor[4]; // 4 slot 

    public static void EquipGun(int slotIndex, GunInfor gunIf)
    {
        if (slotIndex >= 0 && slotIndex < equippedGuns.Length)
        {
            equippedGuns[slotIndex] = gunIf;
        }
        else
        {
            Debug.LogWarning("Invalid slot index");
        }
    }

    public static GunInfor GetEquippedGun(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < equippedGuns.Length)
        {
            return equippedGuns[slotIndex];
        }
        return null;
    }
}
