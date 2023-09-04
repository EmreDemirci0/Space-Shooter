using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fxKontrol : MonoBehaviour
{
    Rigidbody fizik;
    public float KursunHiz;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.forward*KursunHiz;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
