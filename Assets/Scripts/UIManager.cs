using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public GameObject startButton, restartButton, menu_bg,logo,winImage;
    public Image bossHealthFill, playerHealthFill;
    public GameObject[] maganizes;
    public static bool canShowMenu=false;
    public static bool isDead=false;
    private void Update()
    {
        if(!PlayerController.isPlaying&&isDead)
        {
            if(FindObjectOfType<PlayerController>().playerHealth <= 0)
            {
                isDead = false;
                StartCoroutine(PlayerDead());
            }

            else if(FindObjectOfType<BossController>().bossHealth <= 0)
            {
                isDead = false;
                StartCoroutine(BossDead());
            }
        }
        if(FindObjectOfType<PlayerController>().playerHealth<=0&&!PlayerController.isPlaying&&canShowMenu)
        {
            menu_bg.SetActive(true);
            restartButton.SetActive(true);
        }
        else if(FindObjectOfType<BossController>().bossHealth <= 0 && !PlayerController.isPlaying && canShowMenu)
        {
            menu_bg.SetActive(true);
            restartButton.SetActive(true);
            winImage.SetActive(true);
        }
    }

    public void StartGame()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[0]);
        startButton.SetActive(false);
        menu_bg.SetActive(false);
        logo.SetActive(false);
        PlayerController.isPlaying = true;
        canShowMenu = false;
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[0]);
        FindObjectOfType<PlayerController>().gameObject.transform.position = FindObjectOfType<PlayerController>().playerPos;
        FindObjectOfType<PlayerController>().playerHealth = 150;
        FindObjectOfType<BossController>().bossHealth = 500;
        bossHealthFill.fillAmount = 1;
        playerHealthFill.fillAmount = 1;
        FindObjectOfType<PlayerController>().arrowNum = 4;
        for(int i=0;i<4;i++)
        {
            maganizes[i].SetActive(true);
        }
        FindObjectOfType<PlayerController>().ani_player.SetBool("isMoving", false);
        FindObjectOfType<PlayerController>().ani_player.SetBool("isDead", false);
        FindObjectOfType<BossController>().ani_boss.SetBool("isDead", false);
        restartButton.SetActive(false);
        menu_bg.SetActive(false);
        winImage.SetActive(false);
        PlayerController.isPlaying = true;
        canShowMenu = false;
        Time.timeScale = 1;
    }

    IEnumerator PlayerDead()
    {
        yield return new WaitForSeconds(1.5f);
        UIManager.canShowMenu = true;
        Time.timeScale = 0;
    }

    IEnumerator BossDead()
    {
        yield return new WaitForSeconds(1.5f);
        UIManager.canShowMenu = true;
        Time.timeScale = 0;
    }
}
