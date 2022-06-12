using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    int layerMaskNode = 1 << 8;
    public GameObject chooseObject = null;
    private Renderer rend;
    Vector3 pos;
    public bool isAnyObject = false;
    [SerializeField] public UnityEngine.Object myPrefab;
   // private UnityEngine.Object myPrefab = null;
    private GameObject eventObject;
    [SerializeField] private List<TurretAttackerData> PrefabList;
    private int budget;
    private int cost;
    //[SerializeField] private GameObject playerStats;

    private void Start()
    {
        eventObject = GameObject.Find("ChooseObject");
        rend = GetComponent<Renderer>();
        eventObject.GetComponent<ChooseTurret>().CannonTowerChooseEvent += ChooseCannonBallTower;
        eventObject.GetComponent<ChooseTurret>().ShootArrowTowerChooseEvent += ChooseArrowTower;
        eventObject.GetComponent<ChooseTurret>().GetGoldTowerChooseEvent += ChooseGoldTower;
        cost = 50;
        

    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        if (Physics.Raycast(ray, out hit, 500f, layerMaskNode))
        {
             chooseObject = hit.collider.gameObject;
             pos = chooseObject.transform.position;
        }
        else
        {
            chooseObject = null;
        }
        if (chooseObject == this.gameObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                BuildTower();
            }
        }
    }

    void OnMouseEnter()
    {
        rend.material.color = Color.grey;
    }

    private void OnMouseExit()
    {
        rend.material.color = Color.white;
    }

    private void ChooseCannonBallTower()
    {
        myPrefab = PrefabList.ElementAt(1).turretPrefab;
        cost = PrefabList.ElementAt(1).cost;
    }

    private void ChooseArrowTower()
    {
        myPrefab = PrefabList.ElementAt(0).turretPrefab;
        cost = PrefabList.ElementAt(0).cost;

    }

    private void ChooseGoldTower()
    {
        myPrefab = PrefabList.ElementAt(2).turretPrefab;
        cost = PrefabList.ElementAt(2).cost;
    }
    void BuildTower()
    {
        budget = PlayerStats.money;
        if (budget >= cost)
        {
            if (isAnyObject == false)
            {
                Instantiate(myPrefab, pos, Quaternion.identity);
                isAnyObject = true;
                GameObject.FindObjectOfType<MoneyUI>().ReduceMoney(cost);
                PlayerStats.money = budget - cost;
            }
            //budget -= cost;
            //UpdateMoney?.Invoke();
        }
    }


}
