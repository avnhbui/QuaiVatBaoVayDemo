using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoDisplay : MonoBehaviour
{
    public GameObject infoPanel; 
    public Image gunImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dmgText;
    public TextMeshProUGUI fireRateText;
    public TextMeshProUGUI fireRangeText;
    public TextMeshProUGUI fireSpeedText;
    public TextMeshProUGUI lifeStealText;
    public TextMeshProUGUI critRateText;
    public TextMeshProUGUI criteDmgText;

    void Start()
    {
        infoPanel.SetActive(false);
    }

    public void ShowItemInfo(GunInfor gun)
    {
        gunImage.sprite = gun.gunSprite;
        nameText.text = gun.gunName;
        dmgText.text = "Sát thương: " + gun.fireDamage.ToString();
        fireRateText.text = "Tốc độ bắn: " + gun.fireRate.ToString();
        fireRangeText.text = "Tầm bắn: " + gun.fireRange.ToString();
        fireSpeedText.text = "Tốc độ đạn: " + gun.fireSpeed.ToString();
        lifeStealText.text = "Hút máu: " + gun.lifeSteal.ToString() + "%";
        critRateText.text = "Tỷ lệ chí mạng: " + gun.critRate.ToString() + "%";
        criteDmgText.text = "Sát thương chí mạng: " + "x" + gun.critDmg.ToString();
        infoPanel.SetActive(true);
    }
    public void HideItemInfo()
    {
        infoPanel.SetActive(false);
    }
    public void UpdateInfoPanelPosition(Vector3 mousePos)
    {
        infoPanel.transform.position = mousePos + new Vector3(250, -180, 0); 
    }
}