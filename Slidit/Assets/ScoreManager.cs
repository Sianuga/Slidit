using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private int scorePerSecond = 1;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    private void Start()
    {
        StartCoroutine(IncreaseScore());
    }

    private IEnumerator IncreaseScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            score += scorePerSecond;
            scoreText.text = score.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            score += 10;
            scoreText.text = score.ToString();
        }
    }
}
