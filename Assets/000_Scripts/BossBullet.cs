using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    float time;
    void Start()
    {
        time = 0;
    }

    void Update()
    {
        time+=Time.deltaTime;
        Destroy(gameObject,3);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && time >=1) {
            GameObject.Find("Player").GetComponent<PlayerMove>().playerHP -= 10;
            time = 0;
        }
    }
}
