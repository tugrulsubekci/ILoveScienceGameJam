using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabs;

    private int randomIndex;

    [SerializeField] float repeatRate = 2;
    [SerializeField] float startTime = 0;

    private Vector3 spawnPosition = new Vector3(-6, 0.75f, -2);
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnPrefab), startTime, repeatRate);
    }

    void SpawnPrefab()
    {
        randomIndex = Random.Range(0, prefabs.Count);
        Instantiate(prefabs[randomIndex], spawnPosition, prefabs[randomIndex].transform.rotation);
    }
}
