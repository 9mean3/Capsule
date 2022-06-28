using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronicBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Vector3 dir;

    [SerializeField] GameObject ElecEff;
    
    void Start()
    {
        dir = Camera.main.transform.forward;
    }

    void Update()
    {
        transform.position += dir * bulletSpeed * Time.deltaTime;
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){ return; }
        if (other.gameObject.CompareTag("BossAttack")) { return; }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy_Physic>().GetHurt(30f);
        }
        if (other.gameObject.CompareTag("OneEnemy"))
        {
            other.gameObject.GetComponent<EnemyAttack>().GetHurt(30f);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<Boss>().bossHP -= 30f;
        }
        Instantiate(ElecEff, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
