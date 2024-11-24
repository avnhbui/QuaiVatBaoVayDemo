using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int experience = 0;
    public int levelUpThreshold = 100; // Ngưỡng để lên cấp
    public string playerType = "worm"; // ban đầu là sâu
    public Sprite birdSprite;


    void Update()
    {
        // Kiểm tra nếu đủ kinh nghiệm để lên cấp
        if (experience >= levelUpThreshold)
        {
            LevelUp();
        }
    }

    public virtual void Eat(string food)
    {
        // Logic ăn thức ăn
    }

    public void GainExperience(int exp)
    {
        experience += exp;
    }

    void LevelUp()
    {
        if (playerType == "worm")
        {
            TransformToBird();
        }
    }

    void TransformToBird()
    {
        playerType = "bird";
        // Replace current object with a bird object or change appearance
        // Ví dụ thay đổi sprite hoặc animation
        this.gameObject.GetComponent<SpriteRenderer>().sprite = birdSprite;
        // Thay đổi thuộc tính
        this.gameObject.AddComponent<Bird>();
        Destroy(this.gameObject.GetComponent<Worm>());
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            string foodType = other.gameObject.GetComponent<Food>().type;
            Eat(foodType);
            Destroy(other.gameObject); // Sau khi ăn thì tiêu hủy đối tượng thức ăn
        }
    }


}
