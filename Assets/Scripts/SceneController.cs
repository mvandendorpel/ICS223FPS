using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject lizardPrefab;
    private GameObject enemy;
    private GameObject lizard;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);
    private int maxEnemies = 5;
    private int maxLizards = 5;
    private GameObject[] enemies;
    private GameObject[] lizards;
    private readonly Vector3[] spawnLocations = new Vector3[] {new Vector3(-7.24155712f, 2.38418579e-07f, 9.00306129f), new Vector3(1f, 2.38418579e-07f, 19.6499996f), new Vector3(8.56999969f, 2.38418579e-07f, 19.6499996f),
        new Vector3(20.0699997f, 2.38418579e-07f, 11.1300001f), new Vector3(-19.9200001f,2.38418579e-07f,2.9000001f) };
    private void Start()
    {
        enemies = new GameObject[maxEnemies];
        lizards = new GameObject[maxLizards];
        for (int i = 0; i < maxLizards; i++)
        {
            if (lizards[i] == null)
            {
                lizard = Instantiate(lizardPrefab) as GameObject;
                lizard.transform.position = spawnLocations[i];
                float angle = Random.Range(0, 360);
                lizard.transform.Rotate(0, angle, 0);
                lizards[i] = lizard;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
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
