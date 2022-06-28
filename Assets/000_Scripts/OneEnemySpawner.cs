using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OneEnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject spEff;
    [SerializeField] GameObject enemy;
    [SerializeField] int spCount;
    int i = 0;
    void Start()
    {
        StartCoroutine("EnemySpawning");
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Clear");

        }
    }
    IEnumerator EnemySpawning()
    {

        for (i = 0; i <= spCount; i++)
        {

            float x = Random.Range(-90, 90);
            float z = Random.Range(-90, 90);
            transform.position = new Vector3(x, 0, z);
            Instantiate(spEff, transform.position, Quaternion.identity);
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1);
            i++;
        }
        StopCoroutine("EnemySpawning");

    }
}
