using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] Image healtbar;
    private float maxHP = 300;
    [SerializeField] private float currentHP;
    private float demage = 40f;
    [SerializeField] GameObject gameOver;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void DecreaseHP()
    {
        if (currentHP > 0)
        {
            currentHP -= demage;
            UpdateHealthBar();
        }
        else
        {
            gameOver.SetActive(true);
        }
    }

    private void UpdateHealthBar()
    {
        healtbar.fillAmount = currentHP/maxHP;
    }

    public float GetHP()
    {
        return currentHP;
    }
}
