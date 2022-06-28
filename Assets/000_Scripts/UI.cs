using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HPUI();
        ManaUI();
        SelectedBullet();
    }
    void HPUI()
    {
        GameObject.Find("HPViewer").GetComponent<Slider>().value = GameObject.Find("Player").GetComponent<PlayerMove>().playerHP / 100f;
    }
    void ManaUI()
    {
        GameObject.Find("ManaViewer").GetComponent<Slider>().value = GameObject.Find("Player").GetComponent<PlayerMove>().mana / GameObject.Find("Player").GetComponent<PlayerMove>().maxMana;
    }
    void SelectedBullet() 
    {
        if(GameObject.Find("BulletHolder").GetComponent<BulletSelect>().selectedBullet == 0)
        {
            GameObject.Find("DefImage").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            GameObject.Find("ElectronicImage").GetComponent<Image>().color = new Color(0, 1, 1, 0.5f);
            GameObject.Find("WaterImage").GetComponent<Image>().color = new Color(1, 0, 0, 0.5f);
        }
        else if (GameObject.Find("BulletHolder").GetComponent<BulletSelect>().selectedBullet == 1)
        {
            GameObject.Find("DefImage").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            GameObject.Find("ElectronicImage").GetComponent<Image>().color = new Color(0, 1, 1, 1);
            GameObject.Find("WaterImage").GetComponent<Image>().color = new Color(1, 0, 0, 0.5f);
        }
        else if (GameObject.Find("BulletHolder").GetComponent<BulletSelect>().selectedBullet == 2)
        {
            GameObject.Find("DefImage").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            GameObject.Find("ElectronicImage").GetComponent<Image>().color = new Color(0, 1, 1, 0.5f);
            GameObject.Find("WaterImage").GetComponent<Image>().color = new Color(1, 0, 0, 1);
        }
        if (Input.GetKey(KeyCode.E))
        {
            GameObject.Find("DefImage").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            GameObject.Find("ElectronicImage").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            GameObject.Find("WaterImage").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
    }
}
