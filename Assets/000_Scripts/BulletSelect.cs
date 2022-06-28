using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSelect : MonoBehaviour
{
    public int selectedBullet;
    void Start()
    {
        
    }

    void Update()
    {        
        SelectBullet();
        SwitchingBullet();
    }
    public void SelectBullet()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedBullet){ weapon.gameObject.SetActive(true); }
            else { weapon.gameObject.SetActive(false); }
            i++;
        }
    }
    void SwitchingBullet()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedBullet >= transform.childCount - 1)
                selectedBullet = 0;
            else
                selectedBullet++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedBullet <= 0)
                selectedBullet = transform.childCount - 1;
            else
                selectedBullet--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) { selectedBullet = 0; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { selectedBullet = 1; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { selectedBullet = 2; }
    }
}
