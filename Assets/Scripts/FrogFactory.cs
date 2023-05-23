using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogFactory : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float minDelay = 5f;
    [SerializeField] private float maxDelay = 9f;
    private float nextSpawnTime;

    void Update()
    {
        if(prefab != null)
        {
            if (Time.time >= nextSpawnTime)
            {
                Instantiate(prefab, transform.position, Quaternion.identity);
                SetNextSpawnTime();
            }
        }
        else
        {
            Debug.Log("Prefab reference is not assigned.");
        }
    }

    private void SetNextSpawnTime()
    {
        float randomDelay = Random.Range(minDelay, maxDelay);
        nextSpawnTime = Time.time + randomDelay;
    }
}
