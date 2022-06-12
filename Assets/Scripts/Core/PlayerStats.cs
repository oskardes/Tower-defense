using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    [SerializeField] public int moneyOnStart = 360;

    public static int lives;
    [SerializeField] public int livesOnStart = 19;

    private static int magic;
    [SerializeField] private  int magicOnStart = 50;

    void Start()
    {
        money = moneyOnStart;
        lives = livesOnStart;
        magic = magicOnStart;
    }

}
