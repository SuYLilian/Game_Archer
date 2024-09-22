using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public GameObject arrrowPrefab;
    public int arrowNum;
    public GameObject[] magazines = new GameObject[4];
    bool canShoot = true;
    public float fillingDuration;
    float fillingCount;
    public Image playerHealthFill;
    public float playerHealth;
    public Vector3 playerPos;
    public Animator ani_player;

    public static bool isPlaying=false;

    void Awake()
    {
        playerPos = transform.position;
        if(!isPlaying)
        {
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            PlayerMoving();
            Shooting();
            FillingArrow();
        }
    }

    private void PlayerMoving()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            ani_player.SetBool("isMoving",true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            ani_player.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            ani_player.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            ani_player.SetBool("isMoving", true);
        }
        if(!Input.GetKey(KeyCode.LeftArrow)&& !Input.GetKey(KeyCode.RightArrow)&& 
           !Input.GetKey(KeyCode.DownArrow)&& !Input.GetKey(KeyCode.UpArrow))
        {
            ani_player.SetBool("isMoving", false);

        }

        /* else
         {
             ani_player.SetBool("isMoving", false);

         }*/

    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[1]);
            arrowNum--;
            Instantiate(arrrowPrefab,new Vector3 (transform.position.x-0.14f, transform.position.y+0.76f,transform.position.z), Quaternion.identity);
            magazines[arrowNum].SetActive(false);
            if (arrowNum == 0)
            {
                canShoot = false;
            }
        }
    }

    void FillingArrow()
    {
        if (canShoot == false)
        {
            fillingCount += Time.deltaTime;

            if (fillingCount >= fillingDuration && arrowNum != 4)
            {
                magazines[arrowNum].SetActive(true);
                arrowNum++;
                fillingCount = 0;

            }

            else if (fillingCount >= fillingDuration && arrowNum == 4)
            {
                fillingCount = 0;
                canShoot = true;
            }
        }
    }
}
