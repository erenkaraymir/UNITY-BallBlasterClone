using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] meteorPrefabs;
    [SerializeField] int meteorsCount;
    [SerializeField] float spawnDelay;

    GameObject[] meteors;

    void Start()
    {
        PrepareMeteors();
        StartCoroutine(SpawnMeteors());
    }

    IEnumerator SpawnMeteors()
    {
        for (int i = 0; i < meteorsCount; i++)
        {
            meteors[i].SetActive(true);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void PrepareMeteors()
    {
        meteors = new GameObject[meteorsCount];
        int prefabCount = meteorPrefabs.Length;
        for (int i = 0; i < meteorsCount; i++)
        {
            meteors[i] = Instantiate(meteorPrefabs[Random.Range(0, prefabCount)], transform);
            meteors[i].SetActive(false);
        }
    }

}
