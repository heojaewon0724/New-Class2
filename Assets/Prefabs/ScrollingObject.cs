using UnityEngine;

public class ScrollingObject : MonoBehaviour
{        public float speed = 100f; // 스크롤 속도

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    private void Update()
    {
        if (!Gamemanager.instance.isGameOver)
        {
            // 게임 오버 상태가 아니라면 스크롤 속도에 따라 왼쪽으로 이동
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
