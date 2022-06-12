using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float demage = 20;
    private GameObject parent;
    private void Start()
    {
       /* parent = GameObject.Find("Parent");
        parent.GetComponent<ShootingTurret>().DestroyObject += DestroyObjectEvent;*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Zderzenie");
            collision.gameObject.GetComponent<Enemy>().Hurt(demage);
            Destroy(gameObject);
        }
    }

    public float GetDemage()
    {
        return demage;
    }

  /*  private void DestroyObjectEvent()
    {
        Destroy(gameObject);   
    }*/
}
