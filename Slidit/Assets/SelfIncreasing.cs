using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfIncreasing : MonoBehaviour
{
    [SerializeField] private float maxSize = 10f;

    [SerializeField] private float increaseRate = 0.1f;


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
    }
}
