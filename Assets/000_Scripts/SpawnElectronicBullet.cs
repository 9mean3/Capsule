using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElectronicBullet : MonoBehaviour
{
    [SerializeField] GameObject electBullet;
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
    void Fire()
    {
        fireWait += Time.deltaTime;
        if (isFire)
            if (Input.GetButton("Fire1") && fireWait >= fireRate && GameObject.Find("Player").GetComponent<PlayerMove>().mana > 0)
            {
                Instantiate(electBullet, firePos.transform.position, Quaternion.identity);

                //Ray ray = new Ray(transform.position, Camera.main.transform.forward);
                GameObject.Find("Player").GetComponent<PlayerMove>().mana -= 3;
                Debug.Log(GameObject.Find("Player").GetComponent<PlayerMove>().mana);

                Debug.Log("FF");
                fireWait = 0;
            }
    }
}
