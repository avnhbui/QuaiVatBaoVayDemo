using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    public GunInfor gunInfo;
    public ItemInfoDisplay itemInfoDisplay;
    public int slotIndex;
    private void Awake()
    {

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

    }
    private void Start()
    {
        if (itemInfoDisplay == null)
        {
            itemInfoDisplay = FindObjectOfType<ItemInfoDisplay>();
        }

        if (itemInfoDisplay != null && gunInfo != null)
        {
            itemInfoDisplay.ShowItemInfo(gunInfo);
        }
    }
    void Update()
    {
        if (itemInfoDisplay.infoPanel.activeSelf)
        {
            Vector3 mousePos = Input.mousePosition;
            itemInfoDisplay.UpdateInfoPanelPosition(mousePos);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (itemInfoDisplay != null && gunInfo != null)
        {
            itemInfoDisplay.ShowItemInfo(gunInfo);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (itemInfoDisplay != null)
        {
            itemInfoDisplay.HideItemInfo();
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(transform.root);
        itemBeingDragged = gameObject;

    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;

    }



    public void OnEndDrag(PointerEventData eventData)
    {
         itemBeingDragged = null;

        SlotType slotType = transform.parent != null ? transform.parent.GetComponent<SlotType>() : null;

        if (slotType == null || !(slotType.slotCategory == SlotType.SlotCategory.Inventory ||
                                  slotType.slotCategory == SlotType.SlotCategory.Equip1 ||
                                  slotType.slotCategory == SlotType.SlotCategory.Equip2 ||
                                  slotType.slotCategory == SlotType.SlotCategory.Equip3 ||
                                  slotType.slotCategory == SlotType.SlotCategory.Equip4))
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
        else
        {
            slotIndex = slotType.slotIndex;

            if (gunInfo != null && slotType.slotCategory != SlotType.SlotCategory.Inventory)
            {
                GameData.EquipGun(slotIndex, gunInfo);
                Debug.Log($"Gun {gunInfo.gunName} equipped in slot {slotIndex}");
            }
            else
            {
                Debug.Log($"Item dropped into inventory slot {slotIndex}");
            }
        }

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }


}