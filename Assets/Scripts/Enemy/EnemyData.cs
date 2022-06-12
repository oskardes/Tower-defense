using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Data/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Paramaters")]
    public int health;
    public int speed;
    public int damage;
    [Space(10)]

    [Header("EnemyData")]
    [SerializeField] List<EnemyData> enemyData;
    [Space(10)]

    [Header("Prefabs")]
    [SerializeField] List<GameObject> enemyPrefabs;
}
