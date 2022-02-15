using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject enemy;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);
    private int maxEnemies = 5;
    private GameObject[] enemies;

    private void Start()
    {
        enemies = new GameObject[maxEnemies];
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxEnemies; i++) {
            if (enemies[i] == null)
            {
                enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = spawnPoint - new Vector3(0, 0, i * 3);
                float angle = Random.Range(0, 360);
                enemy.transform.Rotate(0, angle, 0);
                enemies[i] = enemy;
            }
        }
        
    }

}
