using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private Text money;
    [SerializeField] private GameObject building;
    //private int cost;
    private int actualMoney;
    //private int awardForEnemy = 15;
    void Start()
    {
        money.text =  PlayerStats.money.ToString() + "$";
        actualMoney = PlayerStats.money;
        //building.GetComponent<Building>().UpdateMoney += UpdateMoneyUI;
        InvokeRepeating("AddTimeMoney", 5f, 10f);
    }

    private void UpdateMoneyUI()
    {
        money.text = actualMoney.ToString() + "$";
    }

    public void ReduceMoney(int cost)
    {
        actualMoney -= cost;
        UpdateMoneyUI();
    }

    public void AddMoney(int amountMoney) {
        actualMoney += amountMoney;
        UpdateMoneyUI();
    }

    private void AddTimeMoney()
    {
        actualMoney += 10;
        UpdateMoneyUI();
    }
   
}
