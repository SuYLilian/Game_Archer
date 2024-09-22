using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float arrowSpeed;
    public float arrowExistTimer;
   // public Animator ani_player;

    // public GameObject restartButton, menu_bg, logo, winImage;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        arrowExistTimer -= Time.deltaTime;
        transform.position += Vector3.up * arrowSpeed * Time.deltaTime;
        if (arrowExistTimer <= 0)
        {
            Destroy(gameObject);
        }

        if(!PlayerController.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boss")
        {
            FindObjectOfType<BossController>().bossHealth -= 10;
            FindObjectOfType<BossController>().BoosHealthFill.fillAmount = FindObjectOfType<BossController>().bossHealth / 500;
            if (FindObjectOfType<BossController>().bossHealth <= 0)
            {
                PlayerController.isPlaying = false;
                UIManager.isDead = true;
                FindObjectOfType<BossController>().ani_boss.SetBool("isDead", true);
                // StartCoroutine(BossDead());
                //Time.timeScale = 0;               
                //restartButton.SetActive(true);
                //menu_bg.SetActive(true);
                //winImage.SetActive(true);
            }
            Destroy(gameObject);
        }
    }

    IEnumerator BossDead()
    {
        yield return new WaitForSeconds(1.5f);
        UIManager.canShowMenu = true;
        Time.timeScale = 0;
    }
}
