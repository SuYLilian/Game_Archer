using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public int d;//一次生成d個子彈
   // public float posAngle;
    float d_angle;
    float d_radian;
    public GameObject[] bulletPrefabs = new GameObject[4];
    //public Vector3[] attackValue;
    public int rd_skill;
    float rd_time;
    float timer;
    public Image BoosHealthFill;
    public float bossHealth;
    public Animator ani_boss;



    ObjectPool<Bullet> bulletPool_0;
    ObjectPool<Bullet> bulletPool_1;
    ObjectPool<Bullet> bulletPool_2;
    ObjectPool<Bullet> bulletPool_3;

    


    void Awake()
    {
        rd_time = Random.Range(1.5f, 4f);
        rd_skill = Random.Range(0, 4);
    }

    private void Start()
    {
        bulletPool_0 = new ObjectPool<Bullet>(
        () =>
        {
            Bullet b= Instantiate(bulletPrefabs[0], new Vector3(transform.position.x-0.3f,transform.position.y+1.9f,transform.position.z), Quaternion.identity).GetComponent<Bullet>();
            b.recycle = (bullet) =>
            {
                bulletPool_0.Release(bullet);
            };
            return b;
        },
        (bullet) =>
        {
            bullet.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 1.9f, transform.position.z);
            bullet.timer = bullet.bulletExistTimer;
            bullet.gameObject.SetActive(true);
        },
        (bullet) =>
        {
            bullet.gameObject.SetActive(false);
        },
        (bullet) =>
        {
            Destroy(bullet.gameObject);
        },true,20,40
        );

        bulletPool_1 = new ObjectPool<Bullet>(
        () =>
        {
            Bullet b = Instantiate(bulletPrefabs[1], new Vector3(transform.position.x - 0.3f, transform.position.y + 1.9f, transform.position.z), Quaternion.identity).GetComponent<Bullet>();
            b.recycle = (bullet) =>
            {
                bulletPool_1.Release(bullet);
            };
            return b;
        },
        (bullet) =>
        {
            bullet.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 1.9f, transform.position.z);
            bullet.timer = bullet.bulletExistTimer;
            bullet.gameObject.SetActive(true);
        },
        (bullet) =>
        {
            bullet.gameObject.SetActive(false);
        },
        (bullet) =>
        {
            Destroy(bullet.gameObject);
        }, true, 20, 40
        );

        bulletPool_2 = new ObjectPool<Bullet>(
        () =>
        {
            Bullet b = Instantiate(bulletPrefabs[2], new Vector3(transform.position.x - 0.3f, transform.position.y + 1.9f, transform.position.z), Quaternion.identity).GetComponent<Bullet>();
            b.recycle = (bullet) =>
            {
                bulletPool_2.Release(bullet);
            };
            return b;
        },
        (bullet) =>
        {
            bullet.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 1.9f, transform.position.z);
            bullet.timer = bullet.bulletExistTimer;
            bullet.gameObject.SetActive(true);
        },
        (bullet) =>
        {
            bullet.gameObject.SetActive(false);
        },
        (bullet) =>
        {
            Destroy(bullet.gameObject);
        }, true, 20, 40
        );

        bulletPool_3 = new ObjectPool<Bullet>(
        () =>
        {
            Bullet b = Instantiate(bulletPrefabs[3], new Vector3(transform.position.x - 0.3f, transform.position.y + 1.9f, transform.position.z), Quaternion.identity).GetComponent<Bullet>();
            b.recycle = (bullet) =>
            {
                bulletPool_3.Release(bullet);
            };
            return b;
        },
        (bullet) =>
        {
            bullet.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 1.9f, transform.position.z);
            bullet.timer = bullet.bulletExistTimer;
            bullet.gameObject.SetActive(true);
        },
        (bullet) =>
        {
            bullet.gameObject.SetActive(false);
        },
        (bullet) =>
        {
            Destroy(bullet.gameObject);
        }, true, 20, 40
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isPlaying)
        {
            timer += Time.deltaTime;

            if (timer >= rd_time)
            {
                timer = 0;
                rd_time = Random.Range(0.9f, 4f);
                ani_boss.SetTrigger("isAttack");

                if (rd_skill == 0)
                {
                    d = 16;
                    d_angle = 360 / d;
                    d_radian = 360 / d * Mathf.PI / 180;

                    for (int i = 0; i < d; i++)
                    {
                        // GameObject g = Instantiate(bulletPrefabs[0], transform.position, Quaternion.identity);
                        // Bullet b = g.GetComponent<Bullet>();
                        Bullet b = bulletPool_0.Get();
                        b.bulletRadian = d_radian * i;
                        b.rotationMultiple = 0;
                    }
                }

                else if (rd_skill == 1)
                {
                    d = 8;
                    d_angle = 360 / d;
                    d_radian = 360 / d * Mathf.PI / 180;

                    for (int i = 0; i < d; i++)
                    {
                        //GameObject g = Instantiate(bulletPrefabs[1], transform.position, Quaternion.identity);
                        //Bullet b = g.GetComponent<Bullet>();
                        Bullet b = bulletPool_1.Get();
                        b.bulletRadian = d_radian * i;
                        b.rotationMultiple = -3;

                    }
                }

                else if (rd_skill == 2)
                {
                    d = 10;
                    d_angle = 360 / d;
                    d_radian = 360 / d * Mathf.PI / 180;

                    for (int i = 0; i < d; i++)
                    {
                        //GameObject g = Instantiate(bulletPrefabs[2], transform.position, Quaternion.identity);
                        //Bullet b = g.GetComponent<Bullet>();
                        Bullet b = bulletPool_2.Get();
                        b.bulletRadian = d_radian * i;
                        b.rotationMultiple = 0;
                    }
                }

                else if (rd_skill == 3)
                {
                    d = 14;
                    d_angle = 360 / d;
                    d_radian = 360 / d * Mathf.PI / 180;

                    for (int i = 0; i < d; i++)
                    {
                        //GameObject g = Instantiate(bulletPrefabs[3], transform.position, Quaternion.identity);
                        // Bullet b = g.GetComponent<Bullet>();
                        Bullet b = bulletPool_3.Get();
                        b.bulletRadian = d_radian * i;
                        b.rotationMultiple = 1.5f;
                    }
                }

                rd_skill = Random.Range(0, 4);

            }
        }


    }
}
