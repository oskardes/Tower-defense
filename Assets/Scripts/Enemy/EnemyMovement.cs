using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] GameObject stronghold;
    private Transform target;
    private int wavepointIndex = 0;
    [SerializeField] private Animator anim;

    private void Start()
    {

        target = Waypoints.points[0];
        
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.4f)
        {
            FollowNextWaypoint();
        }
    }

    void FollowNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            stronghold.GetComponent<HealthBarUI>().DecreaseHP();
            return;
                }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
