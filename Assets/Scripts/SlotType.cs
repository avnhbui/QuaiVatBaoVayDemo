using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotType : MonoBehaviour
{
    public enum SlotCategory { Inventory, Equip1, Equip2, Equip3, Equip4 }
    public SlotCategory slotCategory;
    public int slotIndex;
}
