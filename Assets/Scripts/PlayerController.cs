using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // รับค่าการกดปุ่ม W, S, A, D หรือปุ่มลูกศร
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // คำนวณทิศทาง (X คือซ้ายขวา, Z คือหน้าหลัง)
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        // สั่งเคลื่อนที่
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // หันหน้าไปทิศที่เดิน
        if (direction != Vector3.zero)
        {
            if (direction != Vector3.zero) transform.rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(-90, 0, 0);
        }
    }
}