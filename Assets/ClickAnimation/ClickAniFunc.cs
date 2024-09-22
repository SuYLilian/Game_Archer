using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAniFunc : MonoBehaviour
{
    public GameObject Triangle1, Triangle2;
    int triNum;
    void Start()
    {
        Instantiate(Triangle2, transform.position, Quaternion.identity);

        triNum = Random.Range(7,13);
        for (int i = 0; i < triNum; i++)
        {
            GameObject tri = Instantiate(Triangle1, transform.position, Quaternion.identity);
            float angle = Random.Range(-180,180);
            tri.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        }
        Destroy(gameObject);
    }
}
