using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject slimePrefab;
    public GameObject turtlePrefab;
    public GameObject impPrefab;

    public float spawnInterval = 2.0f;
    public int maxSpawnCount = 100;

    public float spawnRadius = 30f;  // ¸Ê ¿Ü°û ½ºÆù ¹ÝÁö¸§
    public float spawnDistanceFromEdge = 10f;
    public Vector3 mapCenter = Vector3.zero; 

    private int spawnCount = 0;

    void Start()
    {
        InvokeRepeating(nameof(spawn), 0f, spawnInterval);
    }

    void spawn()
    {
        if (spawnCount >= maxSpawnCount) return;

        GameObject prefabToSpawn = GetRandomMonsterPrefab();
        Vector3 spawnPos = GetRandomOutsidePosition();
        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);

        spawnCount++;
    }
    GameObject GetRandomMonsterPrefab()
    {
        int roll = Random.Range(0, 100);

        if (roll < 60)
            return slimePrefab;      
        else if (roll < 90)
            return turtlePrefab;     
        else
            return impPrefab;        
    }
    Vector3 GetRandomOutsidePosition()
    {
        Vector2 dir2D = Random.insideUnitCircle.normalized;
        Vector3 dir = new Vector3(dir2D.x, 0, dir2D.y);
        float dist = spawnRadius + spawnDistanceFromEdge + Random.Range(0f, 5f);
        return mapCenter + dir * dist;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(mapCenter, spawnRadius);
    }
}
