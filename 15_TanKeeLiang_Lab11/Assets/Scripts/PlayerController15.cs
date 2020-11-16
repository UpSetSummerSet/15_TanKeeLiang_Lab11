using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController15 : MonoBehaviour
{
    public GameObject healthText;
    public float health;
    public float damageRate;
    float speed = 5.00f;
    bool IsDead = false;

    Animator playerAnim;
    Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        healthText.GetComponent<Text>().text = "Health: " + health.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                playerAnim.SetBool("isStrafe", true);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                playerAnim.SetBool("isStrafe", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                playerAnim.SetBool("isStrafe", true);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                playerAnim.SetBool("isStrafe", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                playerAnim.SetBool("isStrafe", true);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                playerAnim.SetBool("isStrafe", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                playerAnim.SetBool("isStrafe", true);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                playerAnim.SetBool("isStrafe", false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnim.SetTrigger("trigAttack");
            }
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            playerAnim.SetTrigger("trigDeath");
            IsDead = true;
        }
    }*/
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Fire")
        {
            health -= damageRate * Time.deltaTime;
            healthText.GetComponent<Text>().text = "Health: " + health.ToString("0");
        }
        if(health <= 0)
        {
            playerAnim.SetTrigger("trigDeath");
            IsDead = true;
        }
    }
}
