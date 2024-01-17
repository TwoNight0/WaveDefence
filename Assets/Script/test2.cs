using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        transform.position = Vector3.up * 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
