using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;


    public float speed = 8.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(0.0f, 0.0f, speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-speed, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0.0f, 0.0f, -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed, 0.0f, 0.0f);
        }
        */

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 통해 계산한다.
        xInput *= speed;
        yInput *= speed;

        Vector3 velocity = new Vector3(xInput, 0.0f, yInput);

        rb.linearVelocity = velocity;
    }

    public void Die()
    {
        // 자신의 게임 오브젝트 비활성화
        gameObject.SetActive(false);
               
    }

}
