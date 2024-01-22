using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfIncreasing : MonoBehaviour
{
    [SerializeField] private float maxSize = 10f;

    [SerializeField] private float increaseRate = 0.1f;

    [SerializeField] private bool isBomb = false;


    private void Start()
    {
        StartCoroutine(IncreaseSize());
    }

    private IEnumerator IncreaseSize()
    {
        while (transform.localScale.x < maxSize)
        {
            yield return new WaitForSeconds(increaseRate);
            transform.localScale += new Vector3(increaseRate, increaseRate, 0);
        }

        transform.localScale = new Vector3(maxSize, maxSize, 0);

        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        if (isBomb)
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
        else
        {
            yield return new WaitForSeconds(3f);
            FindObjectOfType<HealthManager>().DecreaseHealth();
            Destroy(gameObject);
        }
    }
}
