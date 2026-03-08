using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1000f; // ปรับให้เข้ากับ Scale 100 ของคุณ
    private AudioSource footstepSource;

    void Start()
    {
        // ไปดึง Audio Source มาจากตัวหุ่นยนต์
        footstepSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 1. รับค่าการกดปุ่ม (ใช้แบบเดิมที่คุณขยับได้แล้ว)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        // 2. ถ้ามีการกดปุ่มขยับ
        if (direction != Vector3.zero)
        {
            // สั่งเคลื่อนที่
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            // แก้หน้าก้ม: ใช้ท่าไม้ตายที่คุณส่งมา (Rotation -90)
            transform.rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(-90, 0, 0);

            // เร่งเสียงเดิน (ถ้าใส่ Audio Source แล้ว)
            if (footstepSource != null) footstepSource.volume = 1.0f;
        }
        else
        {
            // ถ้าหยุดเดิน ให้เบาเสียงเดินเป็น 0
            if (footstepSource != null) footstepSource.volume = 0f;
        }
    }
}