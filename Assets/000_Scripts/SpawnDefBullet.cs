using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDefBullet : MonoBehaviour
{
    [SerializeField] GameObject defBullet;
    [SerializeField] GameObject firePos;

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
            if (Input.GetButton("Fire1") && fireWait >= fireRate)
            {
                Instantiate(defBullet, firePos.transform.position, Quaternion.identity);

                Debug.Log(GameObject.Find("Player").GetComponent<PlayerMove>().mana);

                Debug.Log("FF");
                fireWait = 0;
            }
    }
}
