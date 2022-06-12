using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private float demage = 35;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Zderzenie");
            //GiveDemage?.Invoke();
            collision.gameObject.GetComponent<Enemy>().Hurt(demage);
            Destroy(gameObject);
        }
    }

    public float GetDemage()
    {
        return demage;
    }

}

