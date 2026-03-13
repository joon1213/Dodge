// BulletSpawner 는 일정 간격으로 Bullet을 생성.

using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // 생성할 Bullet의 원본 프리팹
    public GameObject bulletPrefab;

    // Bullet의 최소 생성 주기
    public float spawnRateMin = 0.5f;
    // Bullet의 최대 생성 주기
    public float spawnRateMax = 2.0f;

    // Bullet의 생성 주기
    private float spawnRate;

    // Bullet을 발사할 대상 (타겟)
    public Transform target;

    // 최근 생성 시점에서 지난 시간 (딜레이). 마지막 탄알 생성 시점부터 흐른 시간을 표시하는 타이머.
    private float timeAfterSpawn;

    void Start()
    {
        // 최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0.0f;
        // 탄알 생성 간격을 spawnRateMin 과 spawnRateMax 사시에서 랜덤으로 지정하여 spawnRate 변수에 저장한다.
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 타겟으로 설정
        target = FindFirstObjectByType<PlayerController>().transform;
    }

    void Update()
    {
        // timeAfterSpawn 갱신
        // deltaTime 으로 컴퓨터 사양과 상관없이 일정한 프레임을 생성
        timeAfterSpawn += Time.deltaTime;

        // 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if (timeAfterSpawn >= spawnRate)
        {
            // 누적된 시간을 리셋
            timeAfterSpawn = 0.0f;

            // bulletPrefab의 복제본을 transform.position의 위치와 transform.rotation의 회전값으로 생성을 해준다.
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // 생성된 bullet 게임 오브젝트의 방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);

            // 다음번 생성 간격을 spawnRateMin, spawnRateMax 사이에서 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        }


    }
}
