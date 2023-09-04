using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemaslaYokOl : MonoBehaviour
{
    public GameObject patlama;
    public GameObject PlayerPatlama;
    GameObject OyunKontrolcusu;
    AudioSource patlamaSes;

    OyunKontrol kontrol;
    //üstteki yeşil oyunkontrol scriptin ismi
     void Start()
    {
        OyunKontrolcusu = GameObject.FindGameObjectWithTag("oyunkontrol");
        kontrol = OyunKontrolcusu.GetComponent<OyunKontrol>();
        patlamaSes = GetComponent<AudioSource>();
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "sınır" )
        {
          
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(patlama, this.transform.position, this.transform.rotation);
            patlamaSes.Play();
            kontrol.scoreArttir(10);
            
        }
        if (col.tag == "Player")
        {
            Instantiate(PlayerPatlama, col.transform.position, /*Quaternion.identity*/col.transform.rotation);
            kontrol.OyunBitti();
        }
    }
}
