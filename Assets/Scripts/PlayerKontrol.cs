using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKontrol : MonoBehaviour
{
    Rigidbody fizik;
    float horizontal = 0, vertical = 0;
    public float hiz=5;
    public float MinX=-5.9f, MaxX= 5.9f, MaxZ=16, MinZ=-1.1f, egimHiz=3;
    float atesZamani = 0;
    public float atesGecenSure = 1;
    public GameObject kursun;
    public Transform KursunNeredenCiksin;
    AudioSource audio;
    Vector3 vec;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time>atesZamani)
        {
             atesZamani = Time.time + atesGecenSure;
            Instantiate(kursun,KursunNeredenCiksin.position,Quaternion.identity);
            audio.Play();

        }
    }
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical   = Input.GetAxis(  "Vertical");
       // Debug.Log("horizontal: "+horizontal +" horizontal:"+vertical);
        
        vec = new Vector3(horizontal, 0, vertical);

        fizik.velocity = vec * hiz;
        fizik.position = new Vector3(
            Mathf.Clamp(fizik.position.x,MinX,MaxX),
            0.0f,
            Mathf.Clamp(fizik.position.z,MinZ,MaxZ));
        fizik.rotation = Quaternion.Euler(0, 0, (fizik.velocity.x)*-egimHiz);

    }
}
