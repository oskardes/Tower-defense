using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Turret Attacker Data", menuName = "Data/TuretAttackerData")]
public class TurretAttackerData : ScriptableObject
{
    [Header("Parameters")]
    [SerializeField] public int cost;


    [Header("Prefab")]
    [SerializeField] public GameObject turretPrefab;



}
