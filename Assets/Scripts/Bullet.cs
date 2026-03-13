using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // 리지드 바디의 속도 = 앞쪽 방향(Z축) * 이동속도(speed)
        // transform.foward는 현재 게임 오브젝트의 앞쪽 방향(Z축 방향)을 나타내는 Vector3 타입의 변수
        // transform 컴포넌트에 접근하려면 GetComponent<>() 메서드를 사용해야 하지만 transform은
        // 코드상에서 자신의 Transform 컴포넌트로 바로 접근할 수 있다.
        rb.linearVelocity = transform.forward * speed;

        // 3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3.0f);
    }

    // Collider의 IsTrigger 옵션을 체크하지 않은 경우
    // OnCollisionEnter : 오브젝트가 충돌하는 순간 호출되는 메서드
    // OnCollisionStay : 오브젝트가 충돌하는 동안 호출되는 메서드
    // OnCollisionExit : 오브젝트가 충돌했다가 분리되는 순간 호출되는 메서드

    // Collider의 IsTrigger 옵션을 체크한 경우
    // OnTriggerEnter
    // OnTriggerStay
    // OnTriggerExit
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Die();
        }
    }
}
