using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float attackTime;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject enemyFirePos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Attack");
        curHP = maxHP;
        player = GameObject.Find("Player");
    }

    [SerializeField] GameObject attackEff;
    GameObject player;

    float maxHP = 50;
    float curHP;
    float moveSpeed = 1;

    float curTime = 0;

    void Update()
    {
        moveSpeed = 5;
        curTime += Time.deltaTime;
        Move();
    }
    void Move()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
    }

    public void GetHurt(float damage)
    {
        curHP -= damage;
        if (curHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Attack()
    {
        while (true)
        {
            Instantiate(bullet, enemyFirePos.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(attackTime);
        }
        
    }
}
