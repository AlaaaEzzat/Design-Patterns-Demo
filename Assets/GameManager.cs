using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private List<Transform> spawnPoints;

    private void Start()
    {
        for(int i = 0; i < spawnPoints.Count; i++)
        {
            GameObject obj =  ObjectPoolingManager.SpawnGameObject(enemy, spawnPoints[i].position, Quaternion.identity);
        }
    }
}
