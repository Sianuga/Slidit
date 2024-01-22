using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite emptyHeart;

    [SerializeField] private GameObject replayButton;


    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            DecreaseHealth();

        }


    }

    public void DecreaseHealth()
    {
        health--;
        hearts[health].sprite = emptyHeart;

        if (health <= 0)
        {
            stopGame();
            openPlayMenu();
            Destroy(gameObject);
        }
    }

    private void stopGame()
    {
        Time.timeScale = 0;
    }

    private void openPlayMenu()
    {
        replayButton.SetActive(true);
    }
}
