using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playButton;

    public void StartGame()
    {
        playButton.SetActive(false);
        FindObjectOfType<FireballController>().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        FindObjectOfType<AreaSpawner>().StartSpawning();
        FindObjectOfType<ScoreManager>().StartAutoScore();
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
