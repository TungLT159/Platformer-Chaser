using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerupPrefab;

    [SerializeField] private Vector2 spawnRange;

    private int m_EnemyCount;
    private int m_waves;

    private void Awake()
    {
        m_waves= 1;
        enabled = false; 
    }

 
    private void Update()
    {
        m_EnemyCount = FindObjectsOfType<EnemyController>().Length;

        if (m_EnemyCount == 0)//Neu so luong enemy = 0 thi tao va tang 1 so voi lan truoc do
        {
            m_waves++;
            SpawnEnemy();
            SpawnPowerup();
        }
    }

    public void StartSpawning()
    {
        enabled= true;
        SpawnEnemy();
        SpawnPowerup();
    }

    private void SpawnPowerup()
    {
        SpawnEntity(powerupPrefab);
    }

    //Logic tao Enemy
    private void SpawnEnemy()
    {
        for (var i = 0; i < m_waves; i++)
        {
            SpawnEntity(enemyPrefab);
        }
    }

    private void SpawnEntity(GameObject entity)
    {
        Vector3 spawnPosition = new Vector3(
           Random.Range(spawnRange[0], spawnRange[1]),
           enemyPrefab.transform.position.y,
           Random.Range(spawnRange[0], spawnRange[1]));

        Instantiate(entity, spawnPosition, entity.transform.rotation);
    }
         
}
