using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pengolahsoal : MonoBehaviour
{
    public TextAsset assetSoal;
    private string[] soal;
    private string[,] soalBag;

    public TextMeshProUGUI txtsoal, txtOpsiA, txtOpsiB, txtOpsiC, txtOpsiD;

    int indexSoal;
    int maxSoal;
    bool ambilSoal;
    char kunciJ;

    bool isHasil;
    private float durasi;
    public float durasiPenilaian;

    int jwbBenar, jwbSalah;
    float nilai;

    public GameObject panel;
    public GameObject imgNilai, imgHasil;
    public TextMeshProUGUI txtHasil;
    // Start is called before the first frame update
    void Start()
    {
        durasi = durasiPenilaian;
        soal = assetSoal.ToString().Split('#');
        soalBag = new string[soal.Length, 6];
        maxSoal = soal.Length;
        ambilSoal = true;

        OlahSoal();

        TampilSoal();

        print (soalBag[1, 3]);
        
    }

    private void OlahSoal()
    {
        for(int i=0; i<soal.Length; i++)
        {
            string[] tempsoal = soal[i].Split('+');
            for(int j = 0; j < tempsoal.Length; j++)
            {
                soalBag[i, j] = tempsoal[j];
                continue;
            }
            continue;
        }
    }

    private void TampilSoal()
    {
        if (indexSoal < maxSoal)
        {
            if(ambilSoal)
            {
                txtsoal.text = soalBag[indexSoal, 0];
                txtOpsiA.text = soalBag[indexSoal, 1];
                txtOpsiB.text = soalBag[indexSoal, 2];
                txtOpsiC.text = soalBag[indexSoal, 3];
                txtOpsiD.text = soalBag[indexSoal, 4];
                kunciJ = soalBag[indexSoal, 5][0];

                ambilSoal = false;
            }
        }
    }



    public void Opsi(string opsiHuruf)
    {
        CheckJawaban(opsiHuruf[0]);
        if(indexSoal == maxSoal - 1)
        {
            isHasil = true;

        }
        else
        {
        indexSoal++;
        ambilSoal = true;          
        }

        panel.SetActive(true);
        
    }

    private float HitungNilai()
    {
        return nilai = (float)jwbBenar / maxSoal * 100;
    }

    public TextMeshProUGUI txtPenilaian;

    private void CheckJawaban(char huruf)
    {
        string penilaian;

        if(huruf.Equals(kunciJ))
        {
            penilaian = "Benar!!";
            jwbBenar++;
        }
        else
        {
            penilaian = "Salah!!";
            jwbSalah++;
        }
        txtPenilaian.text = penilaian;
    }

    // Update is called once per frame
    void Update()
    {
        if (panel.activeSelf)
        {
            durasiPenilaian -= Time.deltaTime;
            

            if(isHasil)
            {
                imgNilai.SetActive(true);
                imgHasil.SetActive(false);

                if (durasiPenilaian <= 0)
                {
                    txtHasil.text = "Jumlah Benar : "+jwbBenar+"\nJumlah Salah:"+jwbSalah+"\n\nNilai:"+ HitungNilai();

                    imgNilai.SetActive(false);
                    imgHasil.SetActive(true);

                    durasiPenilaian = 0;
                }
            }
            else
            {
                imgNilai.SetActive(true);
                imgHasil.SetActive(false);

                if(durasiPenilaian <= 0)
            {
                panel.SetActive(false);
                durasiPenilaian = durasi;

                TampilSoal();
            }
            }
        }
        
    }
}
