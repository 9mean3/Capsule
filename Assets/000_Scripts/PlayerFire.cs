using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public float mana;
    public float maxMana = 100;

    RaycastHit hit;
    public float bulletSpeed;
    [SerializeField] GameObject firePos;
    GameObject bullet;

    [SerializeField] GameObject bulletHolder;

    [SerializeField] GameObject _defBullet;
    [SerializeField] GameObject _electronicBullet;
    [SerializeField] GameObject _waterBullet;

    PlayerMove playerMana;

    float time;
    [SerializeField] GameObject rechargeEff;

    void Start()
    {
        playerMana = gameObject.GetComponent<PlayerMove>();
        //hit = GetComponent<RaycastHit>();
    }

    void Update()
    {
        time = Time.deltaTime;

        if(time > 0.5)
        {
            playerMana.mana += 5f;
            time = 0;
        }
        RechargeMana();
    }

    void RechargeMana()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine("RechgM");
            playerMana.moveSpeed = 0;
            bulletHolder.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            StopCoroutine("RechgM");
            playerMana.moveSpeed = 10;
            bulletHolder.SetActive(true);
            Camera.main.fieldOfView = 60;
        }
    }
    IEnumerator RechgM()
    {
        while (true)
        {
            playerMana.mana += 2;

            yield return new WaitForSeconds(0.08f);
            Camera.main.fieldOfView += 0.07f;

            if (playerMana.mana >= playerMana.maxMana)
            {
                StopCoroutine("RechgM");
                playerMana.moveSpeed = 10; 
                Camera.main.fieldOfView = 60;
            }
        }




    }

    void Hit()
    {

    }
}
