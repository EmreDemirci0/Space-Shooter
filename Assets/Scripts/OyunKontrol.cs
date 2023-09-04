using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class OyunKontrol : MonoBehaviour
{
    public GameObject asteroid;
    int score;
    public Vector3 RandomPos;
    public Text ScoreTexti;
    bool OyunBittiMi = false;
    bool YenidenBaslaKontrol = false;
    Vector3 vec;//randompos ta aralık verdik.Vec te bu aralıktan rastgele göndertirdik
    public float BaslangicBeklemeSuresi, olusturmaBeklemeSuresi, donguBeklemeSuresi;
    public Text oyunBittiText;
    void Start()
    {
         score = 0;
        ScoreTexti.text = "score : " + score;
        StartCoroutine(olustur());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && YenidenBaslaKontrol==true)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    IEnumerator olustur()
    {
        yield return new WaitForSeconds(BaslangicBeklemeSuresi);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                vec = new Vector3(Random.Range(-RandomPos.x, RandomPos.x), 0, RandomPos.z);
                Instantiate(asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(olusturmaBeklemeSuresi);
            }
            if(OyunBittiMi)
            {
                YenidenBaslaKontrol=true;
                break;
            }
            yield return new WaitForSeconds(donguBeklemeSuresi);
        }


    }

    
    public void scoreArttir(int gelenScore)
    {
        score += gelenScore;
        ScoreTexti.text = "score : " + score;
      //  Debug.Log(score);

    }
    public void OyunBitti()
    {
        OyunBittiMi = true;
        oyunBittiText.text = "Oyun Bitti.Baslamak için tum asteroidler bittikten sonra R tusuna bas";
        
    }
}
