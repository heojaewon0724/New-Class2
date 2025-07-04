using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance; // 싱글톤 인스턴스
    public bool isGameOver = false; // 게임 오버 상태
    public TextMeshProUGUI scoreText; // 점수 텍스트 UI

    public GameObject gameoverUI;
    public int score = 0; // 현재 점수
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this; // 싱글톤 인스턴스 설정
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임매니저 존재!"); // 이미 인스턴스가 존재하는 경우 경고 메시지 출력
            Destroy(gameObject); // 이미 인스턴스가 존재하면 현재 오브젝트 삭제
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            // 게임 오버 상태에서 마우스 왼쪽 버튼 클릭 시 게임 재시작
            SceneManager.LoadScene(0);
        }
    }
    public void AddScore(int newScore)
    {
        if (!isGameOver)
        {
            score += newScore; // 점수 추가
            scoreText.text = "Score: " + score; // 점수 텍스트 업데이트
        }
    }
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUI.SetActive(true); // 게임 오버 UI 활성화
    }
    
}
