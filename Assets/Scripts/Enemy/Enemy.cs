using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float maxHP = 100;
    //[SerializeField] private GameObject arrow;
    private int demage;
    [SerializeField] private float currentHP;
    public event Action UpdateHealtBar;
    private GameObject MoneyUI;
    private int awardForKillEnemy = 15;

    private void Start()
    {
        currentHP = maxHP;
        MoneyUI = GameObject.Find("Text");
        //arrow = gameObject.GetComponent<ShootingTurret>().shootArrow;
        //arrow.GetComponent<Arrow>().GiveDemage += Hurt;
        
    }

    public void Hurt(float demage)
    {
        
       // demage = arrow.GetComponent<Arrow>().GetDemage();
        currentHP -= demage;
        if (currentHP > 0)
        {
            UpdateHealtBar?.Invoke();
        }
        else
        {
            Destroy(gameObject);
            MoneyUI.GetComponent<MoneyUI>().AddMoney(awardForKillEnemy);
        }
    }

   /* public int GetDemage()
    {
        return demage;
    }*/

    public float GetCurrentHP()
    {
        return currentHP;
        
    }

    public float GetMaxHP()
    {
        return maxHP;
    }

}
