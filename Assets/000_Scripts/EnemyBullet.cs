using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Vector3 dir;
    Vector3 rid;
    Vector3 dirdir;
    Vector3 newpos;

    [SerializeField] GameObject defEff;

    void Start()
    {
        dir = GameObject.Find("Player").transform.position;
        rid = gameObject.transform.position;
        newpos = (rid - dir);
    }

    void Update()
    {
        transform.position -= newpos.normalized * bulletSpeed * Time.deltaTime;
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) { return; }
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(defEff, gameObject.transform.position, Quaternion.identity);
            other.gameObject.GetComponent<PlayerMove>().playerHP -= 20; 
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Instantiate(defEff, gameObject.transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

    }
}
