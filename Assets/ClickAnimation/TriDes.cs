using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriDes : MonoBehaviour
{
    void Start()
    {
        if (tag == "T0")
        InvokeRepeating("des", 0.4f,0.003f);
        else
        InvokeRepeating("des2", 0.2f,0.003f);
    }
    void des()
    {
        GetComponent<SpriteRenderer>().color -= new Color32(0,0,0,5);
        transform.localScale -= new Vector3(0.02f,0.02f,0);
        if (GetComponent<SpriteRenderer>().color.a <= 0)
            Destroy(gameObject);
    }
    void des2()
    {
        GetComponent<SpriteRenderer>().color -= new Color32(0,0,0,3);
        transform.localScale -= new Vector3(0.017f,0.017f,0);
        if (GetComponent<SpriteRenderer>().color.a <= 0)
            Destroy(gameObject);
    }
}
