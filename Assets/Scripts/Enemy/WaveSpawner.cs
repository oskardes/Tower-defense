using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPref;
    private float timeBetweenWaves = 10f;
    private float countdown = 2f;
    private int numberOfWave = 1;
    [SerializeField] private Transform startPosition;
    [SerializeField] private Text countdowner;
    [SerializeField] private Text numberWave;
    private GameObject enemy;
    private Quaternion defaultRotation = new Quaternion(0,0,0,0);
    public event Action ShowStatistics;
    [SerializeField] public GameObject stronghold;
    //EnemyData data;


    private void Update()
    {
        if (numberOfWave <= 14)
        {
            if (countdown <= 0f)
            {

                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }

            countdown -= Time.deltaTime;
            countdowner.text = "Countdown : " + Mathf.Floor(countdown).ToString();
        }
        else
        {
            StopCoroutine(SpawnWave());
            
        }
        if (numberOfWave > 14)
        {
            GameObject[] enemies;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0)
            {
                if (stronghold.GetComponent<HealthBarUI>().GetHP() > 0)
                {
                    ShowStatistics?.Invoke();
                }
            }
        }
    }
    
    IEnumerator SpawnWave()
    {
        numberWave.text = "Fala: " + numberOfWave.ToString() + "/14";
        for (int i=0; i < numberOfWave; i++)
        {
            SpawnOfEnemy();
            yield return new WaitForSeconds(1f);
        }
        numberOfWave++;  
    }

    void SpawnOfEnemy()
    {
       Instantiate(enemyPref, startPosition.position, defaultRotation);
    }
}
