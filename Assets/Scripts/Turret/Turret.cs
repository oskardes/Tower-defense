using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject target;
    private float range = 15f;
    [SerializeField] private Transform[] partsToRotate = new Transform[2];
    private float turnSpeed = 10f;
    private int layerMaskEnemy = 1 << 7;
    public event Action DetectEnemy;
    private GameObject nearestEnemy;
    public event Action EnemyOutRange;

    private void Start()
    {
        //InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
       UpdateTarget();

        if (target == null) { return; }

            Vector3 direction = target.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            foreach (Transform partToRotate in partsToRotate)
            {
                Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
                partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            }
        
    }

    void UpdateTarget()
    {
        float shortestDistance = 15;
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, layerMaskEnemy);

        foreach (Collider coll in colliders)
        {
            float howFarToEnemy = Vector3.Distance(transform.position, coll.transform.position);
            if (howFarToEnemy < shortestDistance)
            {
                shortestDistance = howFarToEnemy;
                nearestEnemy = coll.gameObject;
            }
            else 
            {
                nearestEnemy = null;
                //StopAllCoroutines();
                EnemyOutRange?.Invoke();
            }
        }
        if (nearestEnemy != null && shortestDistance <= range && nearestEnemy != target)
        {
            target = nearestEnemy;
            DetectEnemy?.Invoke();
        }
        else if (nearestEnemy == target)
        {
            return;
        }
        else
        {
            target = null;   
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
