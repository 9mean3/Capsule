using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject bossAttackPos;
    public GameObject attackEff;
    public float bossHP = 7000;

    float i = 0;
    private void Start()
    {
        /*StartCoroutine("up");*/

        StartCoroutine("Attack");
    }
    float time;
    void Update()
    {
        time += Time.deltaTime;
        if(bossHP <= 0)
        {
            transform.position += Vector3.down * 5 * Time.deltaTime;
            
            StopCoroutine("Attack");
            if(transform.position.y <= -80)
            {
                Destroy(gameObject);
            }
        }
    }
    IEnumerator up()
    {
        while (true)
        {
            if(transform.position.y <= 25)
            {
                transform.position += Vector3.up * 4 * Time.deltaTime;
            }
            if(transform.position.y >= 25) { StopCoroutine("up"); }
        }
    }
    IEnumerator down()
    {
        while (true)
        {
            if(transform.position.y >= -80)
            {
                transform.position += Vector3.down * 4 * Time.deltaTime;
            }
            if(transform.position.y <= -80) { StopCoroutine("down"); }
        }
    }
    IEnumerator Attack()
    {
        while (true)
        {
            Instantiate(attackEff, bossAttackPos.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1.7f);
        }

    }

    /*IEnumerator Move()
     * 
    {
        gameObject.transform.position += Vector3.up * 6 * Time.deltaTime;
        if (transform.position.y >= 10)
        {
            yield return new WaitForSeconds(7f);
            transform.Translate(Vector3.zero);
            

            transform.position += Vector3.down * 8 * Time.deltaTime;
            if (transform.position.y <= -80)
            {
                transform.position = new Vector3(0, -80, -145);
                transform.Translate(Vector3.up * 4 * Time.deltaTime);
                if (transform.position.y >= 10)
                {
                    transform.Translate(Vector3.zero);
                }
            }
        }
    }*/

}
