using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTime;
    private Color textColor;
    public static void Create(Vector3 position, int damageAmount)
    {
        // Tạo một Prefab Text tại vị trí enemy
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);
    }
    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }
    public void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
        textColor = textMesh.color;
        disappearTime = 0.5f; // Thời gian tồn tại của text
    }
    private void Update()
    {
        float moveYSpeed = 1f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        // Giảm dần độ trong suốt của text
        disappearTime -= Time.deltaTime;
        if (disappearTime < 0)
        {
            textColor.a -= 2f * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject); // Xóa object khi alpha = 0
            }
        }
    }
}
