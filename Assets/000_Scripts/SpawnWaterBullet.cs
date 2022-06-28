using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaterBullet : MonoBehaviour
{
    [SerializeField] GameObject waterBullet;
    [SerializeField] GameObject firePos;

    public bool isFire = true;
    public float fireRate;
    float fireWait = 0;

    void Start()
    {
    }

    void Update()
    {
        Fire();
    }
    public void Fire()
    {
        fireWait += Time.deltaTime;
        if (isFire)
            if (Input.GetButton("Fire1") && fireWait >= fireRate && GameObject.Find("Player").GetComponent<PlayerMove>().mana > 0)
            {
                Instantiate(waterBullet, firePos.transform.position, Quaternion.identity);

                //Ray ray = new Ray(transform.position, Camera.main.transform.forward);
                GameObject.Find("Player").GetComponent<PlayerMove>().mana -= 15;
                Debug.Log(GameObject.Find("Player").GetComponent<PlayerMove>().mana);

                Debug.Log("FF");
                fireWait = 0;
            }
    }
}
