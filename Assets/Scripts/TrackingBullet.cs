using UnityEngine;

public class TrackingBullet : MonoBehaviour
{
    public Transform player;

    public float speed = 0.005f;

    // 플레이어 추적 공격
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // 리지드 바디의 속도 = 앞쪽 방향(Z축) * 이동속도(speed)
        // transform.foward는 현재 게임 오브젝트의 앞쪽 방향(Z축 방향)을 나타내는 Vector3 타입의 변수
        // transform 컴포넌트에 접근하려면 GetComponent<>() 메서드를 사용해야 하지만 transform은
        // 코드상에서 자신의 Transform 컴포넌트로 바로 접근할 수 있다.
        // rb.linearVelocity = transform.forward * speed;

        // 3초 뒤에 자신의 게임 오브젝트 파괴
        // Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Die();
        }
    }

    void Update()
    {
        
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed);
    }
}
