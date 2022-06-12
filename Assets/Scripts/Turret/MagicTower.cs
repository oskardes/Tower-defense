using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTower : MonoBehaviour
{
    private int increaseMoney = 20;
    private GameObject moneyUpdate;
    void Start()
    {
        moneyUpdate = GameObject.Find("Text");
        StartCoroutine(GenerateMoney());
    }

    IEnumerator GenerateMoney()
    {
        moneyUpdate.GetComponent<MoneyUI>().AddMoney(increaseMoney);
        yield return new WaitForSeconds(2f);
        StartCoroutine(GenerateMoney());
    }
}
