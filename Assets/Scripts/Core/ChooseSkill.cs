using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChooseSkill : MonoBehaviour
{
    public event Action enebleSlowMotion;
    [SerializeField] private GameObject moneyUI;
    private int cost = 20;

    public void SlowMotion()
    {
        enebleSlowMotion?.Invoke();
        moneyUI.GetComponent<MoneyUI>().ReduceMoney(cost);
    }
}
