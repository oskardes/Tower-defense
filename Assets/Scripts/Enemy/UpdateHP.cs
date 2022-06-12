using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHP : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private Image healthBar;
    private float demage;
    private float currentHP;
    private float maxHP;
    void Start()
    {
        Enemy.gameObject.GetComponent<Enemy>().UpdateHealtBar += DecreaseHP;
        maxHP = Enemy.GetComponent<Enemy>().GetMaxHP();
        Debug.Log(maxHP);

    }

    void GetCurrentHP()
    {
        currentHP = Enemy.gameObject.GetComponent<Enemy>().GetCurrentHP();
        Debug.Log("Aktualne HP: " +currentHP);
    }

    void DecreaseHP()
    {
        GetCurrentHP();
        Debug.Log(currentHP / maxHP);
        healthBar.fillAmount = currentHP / maxHP;
    }
}
