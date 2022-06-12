using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTurret : MonoBehaviour
{
    public event Action ShootArrowTowerChooseEvent;
    public event Action CannonTowerChooseEvent;
    public event Action GetGoldTowerChooseEvent;
   // [SerializeField] private List<TurretAttackerData> PrefabList;
    //private GameObject choose;

    public void ShootTowerChoose()
    {
        //choose.GetComponent<Building>().myPrefab = PrefabList.ElementAt(0).turretPrefab;
        ShotTower();
        //ShootArrowTowerChooseEvent?.Invoke();
    }

    public void CannonTowerChoose()
    {
        //choose.GetComponent<Building>().myPrefab = PrefabList.ElementAt(1).turretPrefab;
        //CannonTowerChooseEvent?.Invoke();
        CannTower();
    }

    public void GetGoldTowerChoose()
    {
        //choose.GetComponent<Building>().myPrefab = PrefabList.ElementAt(2).turretPrefab;
        //GetGoldTowerChooseEvent?.Invoke();
        GoldTower();
    }

    void ShotTower()
    {
        ShootArrowTowerChooseEvent?.Invoke();
    }

    void CannTower()
    {
        CannonTowerChooseEvent?.Invoke();
    }

    void GoldTower()
    {
        GetGoldTowerChooseEvent?.Invoke();
    }
}
