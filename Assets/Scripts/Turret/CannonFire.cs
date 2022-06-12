using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject targetEnemy;
    //private float smoothing = 3f;
    [SerializeField] public GameObject shootCannonBall;
    [SerializeField] private GameObject cannonBall;
    private float targetHP;
    [SerializeField] private AudioSource sourse;
    public event Action DestroyObject;

    // Start is called before the first frame update
    void Start()
    {
        turret.GetComponent<Turret>().DetectEnemy += Shooting;
        //turret.GetComponent<Turret>().EnemyOutRange += StopShooting;
    }

    private void Shooting()
    {
        targetEnemy = turret.GetComponent<Turret>().target;
        targetHP = targetEnemy.GetComponent<Enemy>().GetCurrentHP();
        StartCoroutine(CannonBallShoot());
    }

    IEnumerator CannonBallShoot()
    {
        Vector3 offset = new Vector3(cannonBall.transform.position.x + 0.5f, cannonBall.transform.position.y + 0.5f, cannonBall.transform.position.z + 0.5f);
        shootCannonBall = Instantiate(cannonBall, offset, Quaternion.identity);
        //shootCannonBall.AddComponent<CannonBall>();
        StartCoroutine(MoveCannonBall());
        yield return new WaitForSeconds(1f);
        if (targetEnemy != null)
        {
            targetHP = targetEnemy.GetComponent<Enemy>().GetCurrentHP();
            if (targetHP > 0)
            {
                StartCoroutine(CannonBallShoot());
            }
            else
            {
                targetEnemy = null;
                Destroy(shootCannonBall);
            }
        }
        else
        {
            Destroy(shootCannonBall);
        }
    }

    IEnumerator MoveCannonBall()
    {
        if (targetEnemy != null)
        {
            Vector3 enemyPosisiton = targetEnemy.transform.position;
            float interpolator = 0;
            do
            {
                if (shootCannonBall == null)
                {
                    break;
                }
                sourse.Play();
                enemyPosisiton = targetEnemy.transform.position;
                shootCannonBall.transform.position = Vector3.Lerp(shootCannonBall.transform.position, enemyPosisiton, interpolator);
                interpolator += Time.deltaTime / 40;
                yield return null;
            }
            while (shootCannonBall != null && shootCannonBall.transform.position != enemyPosisiton);
        }
        else
        {
            Destroy(shootCannonBall);
        }
    }
/*    private void StopShooting()
    {
        DestroyObject?.Invoke();
    }*/
}
