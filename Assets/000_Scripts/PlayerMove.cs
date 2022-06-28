using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    Vector3 dir;
    public float mouseSpeed;
    public float moveSpeed;
    public float playerHP;
    public float jumpPower;
    float mouseX = 0;
    float mouseY = 0;

    Rigidbody rigid;

    public float mana;
    public float maxMana = 100;


    bool isGround;
    void Start()
    {
        mana = maxMana;
        rigid = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        CamRot();
        ChaRot();
        Move();
        Jump();
        Die();
    }
    void CamRot()
    {
        mouseY -= Input.GetAxis("Mouse Y") * mouseSpeed;
        mouseY = Mathf.Clamp(mouseY, -89, 89);
        Camera.main.transform.localEulerAngles = new Vector3(mouseY, 0, 0);
    }
    void ChaRot()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        dir = Vector3.right * h + Vector3.forward * v;
        dir = transform.TransformDirection(dir);
        dir.Normalize();
        transform.position += dir * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-100,100),Mathf.Clamp(transform.position.y,-100,100),Mathf.Clamp(transform.position.z,-100,100));
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rigid.AddForce(Vector3.up * jumpPower);
            isGround = false;
        }
    }
    void Die()
    {
        if(playerHP <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isGround = true;
        }
    }
}
