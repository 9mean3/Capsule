using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Physic : MonoBehaviour
{
    [SerializeField] GameObject attackEff;
    GameObject player;

    float maxHP = 100;
    float curHP;
    float attackdamage = 10;
 float moveSpeed = 8;

    bool isAttack;

    [SerializeField] float attTime = 1;
    float curTime = 0;
    void Start()
    {
        curHP = maxHP;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        moveSpeed = 5;
        curTime += Time.deltaTime;
        Move();
        Attack();
    }
    void Move()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
    }
    void Attack()
    {
        if (Vector3.Distance(gameObject.transform.position, GameObject.Find("Player").transform.position) <=1 && curTime >= attTime)
        {
            StartCoroutine("Attacking");
            curTime = 0;
            moveSpeed = 0;

        }
    }
    IEnumerator Attacking()
    {

        Instantiate(attackEff, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= 4)
            GameObject.Find("Player").GetComponent<PlayerMove>().playerHP -= attackdamage;

        yield return new WaitForSeconds(1f);
        StopCoroutine("Attacking");
    }
    public void GetHurt(float damage)
    {
        curHP -= damage;
        if(curHP <= 0)
        {
            Destroy(gameObject);
        }
    }

}
