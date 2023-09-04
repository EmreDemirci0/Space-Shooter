using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHareketi : MonoBehaviour
{
    Rigidbody fizik;
    public float AsteroidHiz=-3;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.forward * AsteroidHiz;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
