using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackG : MonoBehaviour
{
    private Renderer objRenderer;

    // Mảng chứa các màu với mã màu tương ứng
    private Dictionary<int, Color> colorMap = new Dictionary<int, Color>()
    {
        { 0, new Color(0f, 27f, 255f)},//blue
        { 1, new Color(255f, 0f, 183f) }, // Pink
        { 2, new Color(0f, 248f, 28f) },//green
        { 3, new Color(255f, 0f, 0f) }//red
    };

    void Start()
    {
        // Lấy tất cả các GameObjects có tag "_Color"
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("_Color");

        // Duyệt qua từng GameObject và random màu sắc
        foreach (GameObject obj in objectsWithTag)
        {
            objRenderer = obj.GetComponent<Renderer>();

            if (objRenderer != null)
            {
                // Tạo một bản sao của material để tránh chia sẻ với các đối tượng khác
                objRenderer.material = new Material(objRenderer.material);

                // Randomize background color
                RandomizeColor(objRenderer);
            }
        }
    }

    void RandomizeColor(Renderer renderer)
    {
        // Chọn một mã màu ngẫu nhiên từ 0 đến 3
        int randomColorCode = Random.Range(0, colorMap.Count);

        // Lấy màu tương ứng từ dictionary
        Color randomColor = colorMap[randomColorCode];

        if (renderer != null)
        {
            renderer.material.SetColor("_Color", randomColor);
        }
    }
}