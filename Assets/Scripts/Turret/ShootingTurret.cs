using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTurret : MonoBehaviour
{

    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject targetEnemy;
    //[SerializeField] public GameObject shootArrow;
    [SerializeField] private GameObject arrow;
    private float targetHP;
    [SerializeField] private AudioSource sourse;
    //public event Action DestroyObject;

    void Start()
    {
        turret.GetComponent<Turret>().DetectEnemy += Shooting;
        //turret.GetComponent<Turret>().EnemyOutRange += StopShooting;
    }

    private void Shooting()
    {
        targetEnemy = turret.GetComponent<Turret>().target;
        targetHP = targetEnemy.GetComponent<Enemy>().GetCurrentHP();
        StartCoroutine(ArrowShoot());
    }

    IEnumerator ArrowShoot()
    {
        Vector3 offset = new Vector3(arrow.transform.position.x + 0.5f, arrow.transform.position.y + 0.5f, arrow.transform.position.z + 0.5f);
        GameObject shootArrow = Instantiate(arrow, offset, Quaternion.identity);
        shootArrow.AddComponent<Arrow>();
        StartCoroutine(MoveArrow(shootArrow));
        yield return new WaitForSeconds(1f);
        if (targetEnemy != null)
        {
            targetHP = targetEnemy.GetComponent<Enemy>().GetCurrentHP();
            if (targetHP > 0)
            {
                StartCoroutine(ArrowShoot());
            }
            else
            {
                targetEnemy = null;
                StopAllCoroutines();
                Destroy(shootArrow);
                //DestroyObject?.Invoke();
            }
        }
        else
        {
            StopAllCoroutines();
            //Destroy(shootArrow);
            //DestroyObject?.Invoke();
        }

    }


        IEnumerator MoveArrow(GameObject shootArrow)
        {
            if (targetEnemy != null)
            {
                float interpolator = 0;
                float interRotate = 0;
                Vector3 enemyPosisiton;
                do
                {
                    if (shootArrow == null)
                    {
                        break;
                    }
                    sourse.Play();
                    enemyPosisiton = new Vector3(targetEnemy.transform.position.x, targetEnemy.transform.position.y + 2f, targetEnemy.transform.position.z);
                    shootArrow.transform.position = Vector3.Lerp(shootArrow.transform.position, enemyPosisiton, interpolator);
                    Vector3 direction = enemyPosisiton - shootArrow.transform.position;
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    Vector3 rotation = Quaternion.Lerp(shootArrow.transform.rotation, lookRotation, interRotate).eulerAngles;
                    shootArrow.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                    interpolator += Time.deltaTime / 20;
                    interRotate += Time.deltaTime / 2;
                    yield return null;
                }
                while (shootArrow != null && shootArrow.transform.position != enemyPosisiton);
            }
            else
            {
                StopAllCoroutines();
               // Destroy(shootArrow);
                //DestroyObject?.Invoke();
            }
        }

      /*  private void StopShooting() 
        {
        DestroyObject?.Invoke();
        }*/
    
}
