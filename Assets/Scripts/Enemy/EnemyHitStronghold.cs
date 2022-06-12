using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitStronghold : MonoBehaviour
{

    [SerializeField] private GameObject stronghold;
    [SerializeField] private GameObject canvas;
    private Quaternion canvasVector = Quaternion.Euler(45,90,0);

    public void HitStronghold()
    { 
         Destroy(gameObject);
         stronghold.GetComponent<HealthBarUI>().DecreaseHP();
    }

    public void StopRotation()
    {
        canvas.transform.rotation = canvasVector;
    }
}
