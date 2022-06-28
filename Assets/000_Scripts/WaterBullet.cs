using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Vector3 dir;

    [SerializeField] GameObject waterEff;

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
        if (other.gameObject.CompareTag("Player")) { return; }
        if (other.gameObject.CompareTag("BossAttack")) { return; }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy_Physic>().GetHurt(50f);
        }
        /*if(Vector3.Distance(gameObject.transform.position, other.gameObject.transform.position) <= 3)
        {
            other.gameObject.GetComponent<Enemy_Physic>().GetHurt(35f);
        }*/
        if (other.gameObject.CompareTag("OneEnemy"))
        {
            other.gameObject.GetComponent<EnemyAttack>().GetHurt(50f);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<Boss>().bossHP -= 50f;
        }
        Instantiate(waterEff, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
