using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Vector3 dir;

    [SerializeField] GameObject defEff;

    void Start()
    {
        dir = Camera.main.transform.forward;
    }

    void Update()
    {
        transform.position += dir * bulletSpeed * Time.deltaTime;
        Destroy(gameObject,10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { return; }
        if (other.gameObject.CompareTag("BossAttack")) { return; }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy_Physic>().GetHurt(5f);
        }
        if (other.gameObject.CompareTag("OneEnemy"))
        {
            other.gameObject.GetComponent<EnemyAttack>().GetHurt(5f);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<Boss>().bossHP -= 5f;
        }
        Instantiate(defEff, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
