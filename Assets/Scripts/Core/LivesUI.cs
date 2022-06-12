using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private Text lives;

    void Start()
    {
        lives.text =  "Lives: " + PlayerStats.lives.ToString();
    }
}
