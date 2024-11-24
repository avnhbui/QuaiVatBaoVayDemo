using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPref;
    [SerializeField] GameObject enemyCharger;

    [SerializeField] float timeSpawn = 0.5f;
    float currentTimeSpawn;
    Transform enemiesParent;
    public static EnemyManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        enemiesParent = GameObject.Find("Enemies").transform;
    }
    private void Update()
    {

        currentTimeSpawn -= Time.deltaTime;
        if( currentTimeSpawn <= 0 )
        {
            SpawnEnemy();
            currentTimeSpawn = timeSpawn;
        }
    }
    Vector2 RandomPos()
    {
        return new Vector2(Random.Range(-16,16), Random.Range(-8,8));
    }
    void SpawnEnemy()
    {
        var randomm = Random.Range(0, 100);
        var enemyType = randomm <90 ? enemyPref : enemyCharger;
        var e = Instantiate(enemyType, RandomPos(), Quaternion.identity);
        e.transform.SetParent(enemiesParent);
    }
    public void DestroyAllEnemies()
    {
        foreach(Transform e in enemiesParent)      
            Destroy(e.gameObject);     
    }
}
