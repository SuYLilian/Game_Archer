using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletExistTimer;
    public float timer;
    public float bulletRadian;
    public float rotationMultiple;
    public delegate void Recycle(Bullet bullet);
    public Recycle recycle;
   // public GameObject restartButton, menu_bg, logo;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // Destroy(gameObject);
            recycle(this);
        }
        transform.position += new Vector3(bulletSpeed * Time.deltaTime * Mathf.Sin(bulletRadian+ timer * rotationMultiple), 
                                          bulletSpeed * Time.deltaTime * Mathf.Cos(bulletRadian+ timer * rotationMultiple), 0);
        if (!PlayerController.isPlaying)
        {
            recycle(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<PlayerController>().playerHealth -= 10;
            FindObjectOfType<PlayerController>().playerHealthFill.fillAmount = FindObjectOfType<PlayerController>().playerHealth / 150;
            if (FindObjectOfType<PlayerController>().playerHealth <= 0)
            {
                PlayerController.isPlaying = false;
                UIManager.isDead = true;
                FindObjectOfType<PlayerController>().ani_player.SetBool("isMoving", false);
                FindObjectOfType<PlayerController>().ani_player.SetBool("isDead", true);
               // StartCoroutine(PlayerDead());
               // restartButton.SetActive(true);
                //menu_bg.SetActive(true);
            }
            recycle(this);

        }
    }

    IEnumerator PlayerDead()
    {
        yield return new WaitForSeconds(1.5f);
        UIManager.canShowMenu = true;
        Time.timeScale = 0;
    }
}
