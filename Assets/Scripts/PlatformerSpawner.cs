using UnityEngine;

public class PlatformerSpawner : MonoBehaviour
{
    public GameObject platformPrefab; // 생성할 플랫폼 프리팹
    public int count = 3;
    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 2.5f;

    private float timeBetSpawn; // 다음 플랫폼 생성까지의 시간
    public float yMin = -3.5f;
    public float yMax = 1.5f;
    private float xPos = 20f  ;
    private GameObject[] platforms; // 생성된 플랫폼들을 저장할 배열    
    private int currentIndex = 0; // 현재 플랫폼 인덱스

    private Vector2 poolPosition = new Vector2(0, -25);
    private float lastSpawnTime; // 풀링된 플랫폼의 위치

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        platforms = new GameObject[count]; // 플랫폼 배열 초기화
        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Gamemanager.instance.isGameOver)
        {
            // 게임 오버 상태에서는 플랫폼 생성 중지
            return;
        }
        
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            // 플랫폼 생성 시간 간격이 지났다면
            lastSpawnTime = Time.time; // 마지막 생성 시간을 현재 시간으로 갱신
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax); // 다음 생성 시간 간격 랜덤 설정

            float yPos = Random.Range(yMin, yMax); // y 위치 랜덤 설정
            // 플랫폼을 풀링된 위치에서 가져와서 활성화
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true); // 플랫폼 활성화
            platforms[currentIndex].transform.position = new Vector2(xPos, yPos); // 플랫폼 위치 설정
            

            // 다음 인덱스로 이동
            currentIndex++;
            if (currentIndex >= count)
            {
                currentIndex = 0; // 인덱스가 배열 크기를 초과하면 0으로 리셋
            }
        }
    }
}
