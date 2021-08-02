using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Stacks : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> tup1 = new List<GameObject>();
    public List<GameObject> tup2 = new List<GameObject>();
    public List<GameObject> tup3 = new List<GameObject>();
    public List<GameObject> tup4 = new List<GameObject>();
    public List<GameObject> tup5 = new List<GameObject>();
    public List<GameObject> tup6 = new List<GameObject>();
    public List<GameObject> tup7 = new List<GameObject>();
    public List<GameObject> general = new List<GameObject>();

    public GameObject kirmizi1;
    public GameObject kirmizi2;
    public GameObject kirmizi3;
    public GameObject kirmizi4;
    public GameObject mavi1;
    public GameObject mavi2;
    public GameObject mavi3;
    public GameObject mavi4;
    public GameObject mor1;
    public GameObject mor2;
    public GameObject mor3;
    public GameObject mor4;
    public GameObject sari1;
    public GameObject sari2;
    public GameObject sari3;
    public GameObject sari4;
    public GameObject yesil1;
    public GameObject yesil2;
    public GameObject yesil3;
    public GameObject yesil4;
    public GameObject siyah1;
    public GameObject siyah2;
    public GameObject siyah3;
    public GameObject siyah4;

    public GameObject tup1effect;
    public GameObject tup2effect;
    public GameObject tup3effect;
    public GameObject tup4effect;
    public GameObject tup5effect;
    public GameObject tup6effect;
    public GameObject tup7effect;
    public GameObject havaifisek;
    public GameObject stareffect;
    public AudioSource stareffectaudio;
    public GameObject yedek;
    public GameObject panel;
    public GameObject levelskor;
    public GameObject cylinder5;
    public GameObject cylinder6;
    public GameObject cylinder7;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject magic;
    public AudioSource magicaudi;
    public GameObject LevelTime;
    public Text levelskortext;
    public Text leveltimetext;
    public float tup5z;
    public float tup6z;
    public float tup7z;

    bool havada;
    bool tup1true = false;
    bool tup2true = false;
    bool tup3true = false;
    bool tup4true = false;
    bool tup5true = false;
    bool tup6true = false;
    bool tup7true = false;
    public int nerede = 0;
    bool finished;
    public Ease hareket;
    public AudioSource tick;
    public AudioSource tock;
    bool enough = false;
    public GameObject finalsound;
    public AudioSource finalsound1;
    bool enough1 = false;
    bool enough2=false;
    bool enough3 = false;
    bool enough4 = false;
    bool enough5 = false;
    bool enough6 = false;
    bool enough7 = false;
    int tuprange;
    int length = 500;
    bool destiny1 = false;
    bool destiny2 = false;
    bool destiny3 = false;
    bool destiny4 = false;
    bool destiny5 = false;
    bool destiny6 = false;
    bool destiny7 = false;
    public int layer_mask;
    bool timefinished = false;
    public float time=0f;

    public int a1 = 0;
    public int a2 = 0;
    public int a3 = 0;
    public int a4 = 0;
    public int a5 = 0;
    public int a6 = 0;
    public int a7 = 0;
    public int inttime = 0;
    void Start()
    {


        havaifisek.SetActive(false);
        tup5z = 7.5f;
        tup6z = 3.66f;
        tup7z = 7.5f;
        layer_mask = LayerMask.GetMask("cylinder");
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
        }
        levelskortext = levelskor.GetComponent<Text>();
        leveltimetext = LevelTime.GetComponent<Text>();
        general.Add(kirmizi1);
        general.Add(kirmizi2);
        general.Add(kirmizi3);
        general.Add(kirmizi4);
        general.Add(mavi1);
        general.Add(mavi2);
        general.Add(mavi3);
        general.Add(mavi4);
        if (PlayerPrefs.GetInt("level") > 3)
        {
            general.Add(mor1);
            general.Add(mor2);
            general.Add(mor3);
            general.Add(mor4);
            Camera.main.transform.DOMoveX(35f,0.1f);
            Camera.main.transform.DOMoveY(13f, 0.1f);
            Camera.main.transform.DOMoveZ(7.42f,0.1f);
        }
        if (PlayerPrefs.GetInt("level") > 6)
        {
            general.Add(sari1);
            general.Add(sari2);
            general.Add(sari3);
            general.Add(sari4);
            cylinder5.transform.DOMoveZ(tup5z, 0.1f);
            tup5effect.transform.DOMoveZ(tup5z, 0.1f);
        }
        if (PlayerPrefs.GetInt("level") > 9)
        {
            general.Add(yesil1);
            general.Add(yesil2);
            general.Add(yesil3);
            general.Add(yesil4);
            tup5z = 11.28f;
            cylinder5.transform.DOMoveZ(tup5z, 0.1f);
            cylinder6.transform.DOMoveZ(tup6z, 0.1f);
            tup5effect.transform.DOMoveZ(tup5z, 0.1f);
            tup6effect.transform.DOMoveZ(tup6z, 0.1f);
        }
        if (PlayerPrefs.GetInt("level") > 12)
        {
            general.Add(siyah1);
            general.Add(siyah2);
            general.Add(siyah3);
            general.Add(siyah4);
            cylinder5.transform.DOMoveZ(tup5z, 0.1f);
            cylinder6.transform.DOMoveZ(tup6z, 0.1f);
            cylinder7.transform.DOMoveZ(tup7z, 0.1f);
            tup7effect.transform.DOMoveZ(tup7z, 0.1f);
        }
        panel.SetActive(false);
        finished = true;

        tick = GetComponent<AudioSource>();
        tock = GetComponentInChildren<AudioSource>();
        finalsound1 = finalsound.GetComponent<AudioSource>();
        magicaudi = magic.GetComponent<AudioSource>();
        stareffectaudio = stareffect.GetComponent<AudioSource>();
        distribution();
        tup1effect.SetActive(false);
        tup2effect.SetActive(false);
        tup3effect.SetActive(false);
        tup4effect.SetActive(false);
        tup5effect.SetActive(false);
        tup6effect.SetActive(false);
        tup7effect.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (timefinished==false)
        {
            time += Time.deltaTime;

        }
        inttime = (int)Math.Round(time);


        levelskortext.text = "level " + PlayerPrefs.GetInt("level");
        leveltimetext.text = "" + inttime;
        tiklama();
        havada = Control.Instance.havada;
        Controller();
        //Formagic();
        if (PlayerPrefs.GetInt("level") <= 3)
        {
            if (((tup1true == true && tup2true == true) || (tup1true && tup3true) || (tup2true && tup3true)) && enough == false)
            {
                timefinished = true;
                Debug.Log("KAZANDIN");
                enough = true;
                finalsound1.Play();
                panel.SetActive(true);
                havaifisek.SetActive(true);
                if (time<=20)
                {
                    StartCoroutine(ExampleCoroutine());
                }
                if (time<30 && time>20)
                {
                    StartCoroutine(ExampleCoroutine2());
                }
                if (time>=30)
                {
                    StartCoroutine(ExampleCoroutine3());
                }


                

            }
            if ((a1 + a2 + a3) < 2)
            {
                Formagic();
            }

        }
        if (PlayerPrefs.GetInt("level") > 3 && PlayerPrefs.GetInt("level") <7)
        {
            if (((tup1true && tup2true && tup3true) || (tup1true && tup2true && tup4true) || (tup2true && tup3true && tup4true) || (tup1true && tup3true && tup4true)) && enough == false)
            {
                havaifisek.SetActive(true);
                timefinished = true;
                Debug.Log("KAZANDIN");
                enough = true;
                finalsound1.Play();
                panel.SetActive(true);
                if (time <= 30)
                {
                    StartCoroutine(ExampleCoroutine());
                }
                if (time < 40 && time > 30)
                {
                    StartCoroutine(ExampleCoroutine2());
                }
                if (time >= 40)
                {
                    StartCoroutine(ExampleCoroutine3());
                }
            }
            if ((a1 + a2 + a3 + a4) < 3)
            {
                Formagic();
            }
        }
        if (PlayerPrefs.GetInt("level") > 6 && PlayerPrefs.GetInt("level") < 10)
        {
            if (((tup1true && tup2true && tup3true&& tup4true) || (tup1true && tup2true && tup3true && tup5true) || (tup1true && tup2true && tup4true && tup5true) || (tup1true &&tup3true && tup4true && tup5true) || (tup2true && tup3true && tup4true && tup5true)) && enough == false)
            {
                havaifisek.SetActive(true);
                timefinished = true;
                Debug.Log("KAZANDIN");
                enough = true;
                finalsound1.Play();
                panel.SetActive(true);
                if (time <= 45)
                {
                    StartCoroutine(ExampleCoroutine());
                }
                if (time < 55 && time > 45)
                {
                    StartCoroutine(ExampleCoroutine2());
                }
                if (time >= 55)
                {
                    StartCoroutine(ExampleCoroutine3());
                }
            }
            if ((a1 + a2 + a3 + a4 + a5) < 4)
            {
                Formagic();
            }
        }
        if (PlayerPrefs.GetInt("level") > 9 && PlayerPrefs.GetInt("level") < 13)
        {
            if (((tup1true && tup2true && tup3true && tup4true && tup5true) || (tup1true && tup2true && tup3true && tup4true && tup6true) || (tup1true && tup2true && tup3true && tup5true && tup6true) || (tup1true && tup3true && tup4true && tup5true && tup6true) || (tup2true && tup3true && tup4true && tup5true && tup6true) || (tup1true && tup2true && tup4true && tup5true && tup6true)) && enough == false)
            {
                havaifisek.SetActive(true);
                timefinished = true;
                Debug.Log("KAZANDIN");
                enough = true;
                finalsound1.Play();
                panel.SetActive(true);
                if (time <= 60)
                {
                    StartCoroutine(ExampleCoroutine());
                }
                if (time < 80 && time > 60)
                {
                    StartCoroutine(ExampleCoroutine2());
                }
                if (time >= 80)
                {
                    StartCoroutine(ExampleCoroutine3());
                }
            }
            if ((a1 + a2 + a3 + a4 + a5 + a6) < 5)
            {
                Formagic();
            }
        }
        if (PlayerPrefs.GetInt("level") > 12)
        {
            if (((tup1true && tup2true && tup3true && tup4true && tup5true && tup6true) || (tup1true && tup2true && tup3true && tup4true && tup5true && tup7true) || (tup1true && tup2true && tup3true && tup4true && tup6true && tup7true) || (tup1true && tup2true && tup3true && tup5true && tup6true && tup7true) || (tup1true && tup2true && tup4true && tup5true && tup6true && tup7true) || (tup1true && tup3true && tup4true && tup5true && tup6true && tup7true) || (tup2true && tup3true && tup4true && tup5true && tup6true && tup7true)) && enough == false)
            {
                havaifisek.SetActive(true);
                timefinished = true;
                Debug.Log("KAZANDIN");
                enough = true;
                finalsound1.Play();
                panel.SetActive(true);
                if (time <= 70)
                {
                    StartCoroutine(ExampleCoroutine());
                }
                if (time < 90 && time > 70)
                {
                    StartCoroutine(ExampleCoroutine2());
                }
                if (time >= 90)
                {
                    StartCoroutine(ExampleCoroutine3());
                }
            }
            if ((a1 + a2 + a3 + a4 + a5 + a6 + a7) < 6)
            {
                Formagic();
            }
        }

       
    }




    void tiklama()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);



            if (Physics.Raycast(ray, out hit, 100.0f,layer_mask))
            {
                Degen(hit);
                Yerlestir(hit);
            }
        }

    }

    void Degen(RaycastHit degen)
    {
        if (degen.transform.gameObject.tag == "tup1" && havada == false && finished == true && tup1.Count != 0)
        {


            tick.Play();
            finished = false;
            nerede = 1;
            yedek = tup1[tup1.Count - 1];
            tup1[tup1.Count - 1].transform.DOMoveY(6.5f, 0.3f).SetEase(hareket).OnComplete(() =>
            {

                finished = true;

            });


        }
        if (degen.transform.gameObject.tag == "tup2" && havada == false && finished == true && tup2.Count != 0)
        {


            tick.Play();
            finished = false;

            nerede = 2;
            yedek = tup2[tup2.Count - 1];
            tup2[tup2.Count - 1].transform.DOMoveY(6.5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {

                finished = true;

            });


        }
        if (degen.transform.gameObject.tag == "tup3" && havada == false && finished == true && tup3.Count != 0)
        {


            tick.Play();
            finished = false;
            nerede = 3;
            yedek = tup3[tup3.Count - 1];
            tup3[tup3.Count - 1].transform.DOMoveY(6.5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {

                finished = true;

            });

        }
        if (degen.transform.gameObject.tag == "tup4" && havada == false && finished == true && tup4.Count != 0)
        {


            tick.Play();
            finished = false;
            nerede = 4;
            yedek = tup4[tup4.Count - 1];
            tup4[tup4.Count - 1].transform.DOMoveY(6.5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {

                finished = true;

            });

        }

        if (degen.transform.gameObject.tag == "tup5" && havada == false && finished == true && tup5.Count != 0)
        {


            tick.Play();
            finished = false;
            nerede = 5;
            yedek = tup5[tup5.Count - 1];
            tup5[tup5.Count - 1].transform.DOMoveY(6.5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {

                finished = true;

            });

        }

        if (degen.transform.gameObject.tag == "tup6" && havada == false && finished == true && tup6.Count != 0)
        {


            tick.Play();
            finished = false;
            nerede = 6;
            yedek = tup6[tup6.Count - 1];
            tup6[tup6.Count - 1].transform.DOMoveY(6.5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {

                finished = true;

            });

        }
        if (degen.transform.gameObject.tag == "tup7" && havada == false && finished == true && tup7.Count != 0)
        {


            tick.Play();
            finished = false;
            nerede = 7;
            yedek = tup7[tup7.Count - 1];
            tup7[tup7.Count - 1].transform.DOMoveY(6.5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {

                finished = true;

            });

        }
    }
    void Yerlestir(RaycastHit degen)
    {


        //TUP1

        if (degen.transform.gameObject.tag == "tup1" && havada == true && nerede == 1 && finished == true)
        {


            finished = false;
            tup1[tup1.Count - 1].transform.DOMoveY(tup1.Count - 0.5f, 0.5f).OnComplete(() =>
              {

                  tup1.RemoveAt(tup1.Count - 1);
                  tup1.Add(yedek);
                  finished = true;
                  tock.Play();
              });


        }
        if (degen.transform.gameObject.tag == "tup1" && havada == true && nerede == 2 && tup1.Count < 4 && finished == true)
        {


            finished = false;
            tup2[tup2.Count - 1].transform.DOMoveZ(0f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup2[tup2.Count - 1].transform.DOMoveY(tup1.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup2.RemoveAt(tup2.Count - 1);
                tup1.Add(yedek);

            });




        }
        if (degen.transform.gameObject.tag == "tup1" && havada == true && nerede == 3 && tup1.Count < 4 && finished == true)
        {
            finished = false;
            tup3[tup3.Count - 1].transform.DOMoveZ(0f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup3[tup3.Count - 1].transform.DOMoveY(tup1.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup3.RemoveAt(tup3.Count - 1);
                tup1.Add(yedek);


            });



        }
        if (degen.transform.gameObject.tag == "tup1" && havada == true && nerede == 4 && tup1.Count < 4 && finished == true)
        {
            finished = false;
            tup4[tup4.Count - 1].transform.DOMoveZ(0f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup4[tup4.Count - 1].transform.DOMoveY(tup1.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup4.RemoveAt(tup4.Count - 1);
                tup1.Add(yedek);


            });



        }
        if (degen.transform.gameObject.tag == "tup1" && havada == true && nerede == 5 && tup1.Count < 4 && finished == true)
        {
            finished = false;
            tup5[tup5.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
            tup5[tup5.Count - 1].transform.DOMoveZ(0f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup5[tup5.Count - 1].transform.DOMoveY(tup1.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup5.RemoveAt(tup5.Count - 1);
                tup1.Add(yedek);


            });



        }
        if (degen.transform.gameObject.tag == "tup1" && havada == true && nerede == 6 && tup1.Count < 4 && finished == true)
        {
            finished = false;
            tup6[tup6.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
            tup6[tup6.Count - 1].transform.DOMoveZ(0f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup6[tup6.Count - 1].transform.DOMoveY(tup1.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup6.RemoveAt(tup6.Count - 1);
                tup1.Add(yedek);


            });



        }
        if (degen.transform.gameObject.tag == "tup1" && havada == true && nerede == 7 && tup1.Count < 4 && finished == true)
        {
            finished = false;
            tup7[tup7.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
            tup7[tup7.Count - 1].transform.DOMoveZ(0f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup7[tup7.Count - 1].transform.DOMoveY(tup1.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup7.RemoveAt(tup7.Count - 1);
                tup1.Add(yedek);


            });



        }

        //TUP2

        if (degen.transform.gameObject.tag == "tup2" && havada == true && nerede == 1 && tup2.Count < 4 && finished == true)
        {
            finished = false;
            tup1[tup1.Count - 1].transform.DOMoveZ(5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup1[tup1.Count - 1].transform.DOMoveY(tup2.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup1.RemoveAt(tup1.Count - 1);
                tup2.Add(yedek);

            });



        }
        if (degen.transform.gameObject.tag == "tup2" && havada == true && nerede == 2 && finished == true)
        {
            finished = false;
            tup2[tup2.Count - 1].transform.DOMoveY(tup2.Count - 0.5f, 0.5f).OnComplete(() =>
            {
                tup2.RemoveAt(tup2.Count - 1);
                tup2.Add(yedek);
                finished = true;
                tock.Play();
            });



        }
        if (degen.transform.gameObject.tag == "tup2" && havada == true && nerede == 3 && tup2.Count < 4 && finished == true)
        {
            finished = false;
            tup3[tup3.Count - 1].transform.DOMoveZ(5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup3[tup3.Count - 1].transform.DOMoveY(tup2.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup3.RemoveAt(tup3.Count - 1);
                tup2.Add(yedek);

            });

        }
        if (degen.transform.gameObject.tag == "tup2" && havada == true && nerede == 4 && tup2.Count < 4 && finished == true)
        {
            finished = false;
            tup4[tup4.Count - 1].transform.DOMoveZ(5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup4[tup4.Count - 1].transform.DOMoveY(tup2.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup4.RemoveAt(tup4.Count - 1);
                tup2.Add(yedek);

            });

        }
        if (degen.transform.gameObject.tag == "tup2" && havada == true && nerede == 5 && tup2.Count < 4 && finished == true)
        {
            finished = false;
            tup5[tup5.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
            tup5[tup5.Count - 1].transform.DOMoveZ(5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup5[tup5.Count - 1].transform.DOMoveY(tup2.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup5.RemoveAt(tup5.Count - 1);
                tup2.Add(yedek);

            });



        }
        if (degen.transform.gameObject.tag == "tup2" && havada == true && nerede == 6 && tup2.Count < 4 && finished == true)
        {
            finished = false;
            tup6[tup6.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
            tup6[tup6.Count - 1].transform.DOMoveZ(5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup6[tup6.Count - 1].transform.DOMoveY(tup2.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup6.RemoveAt(tup6.Count - 1);
                tup2.Add(yedek);

            });



        }
        if (degen.transform.gameObject.tag == "tup2" && havada == true && nerede == 7 && tup2.Count < 4 && finished == true)
        {
            finished = false;
            tup7[tup7.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
            tup7[tup7.Count - 1].transform.DOMoveZ(5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup7[tup7.Count - 1].transform.DOMoveY(tup2.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup7.RemoveAt(tup7.Count - 1);
                tup2.Add(yedek);

            });



        }

        //TUP3

        if (degen.transform.gameObject.tag == "tup3" && havada == true && nerede == 1 && tup3.Count < 4 && finished == true)
        {
            finished = false;
            tup1[tup1.Count - 1].transform.DOMoveZ(10f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup1[tup1.Count - 1].transform.DOMoveY(tup3.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup1.RemoveAt(tup1.Count - 1);
                tup3.Add(yedek);

            });


        }
        if (degen.transform.gameObject.tag == "tup3" && havada == true && nerede == 2 && tup3.Count < 4 && finished == true)
        {
            finished = false;
            tup2[tup2.Count - 1].transform.DOMoveZ(10f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup2[tup2.Count - 1].transform.DOMoveY(tup3.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup2.RemoveAt(tup2.Count - 1);
                tup3.Add(yedek);

            });



        }
        if (degen.transform.gameObject.tag == "tup3" && havada == true && nerede == 3 && finished == true)
        {
            finished = false;
            tup3[tup3.Count - 1].transform.DOMoveY(tup3.Count - 0.5f, 0.5f).OnComplete(() =>
               {


                   tup3.RemoveAt(tup3.Count - 1);
                   tup3.Add(yedek);
                   finished = true;
                   tock.Play();
               });


        }
        if (degen.transform.gameObject.tag == "tup3" && havada == true && nerede == 4 && tup3.Count < 4 && finished == true)
        {
            finished = false;
            tup4[tup4.Count - 1].transform.DOMoveZ(10f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup4[tup4.Count - 1].transform.DOMoveY(tup3.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup4.RemoveAt(tup4.Count - 1);
                tup3.Add(yedek);

            });


        }
        if (degen.transform.gameObject.tag == "tup3" && havada == true && nerede == 5 && tup3.Count < 4 && finished == true)
        {
            finished = false;
            tup5[tup5.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
            tup5[tup5.Count - 1].transform.DOMoveZ(10f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup5[tup5.Count - 1].transform.DOMoveY(tup3.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup5.RemoveAt(tup5.Count - 1);
                tup3.Add(yedek);

            });


        }
        if (degen.transform.gameObject.tag == "tup3" && havada == true && nerede == 6 && tup3.Count < 4 && finished == true)
        {
            finished = false;
            tup6[tup6.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
            tup6[tup6.Count - 1].transform.DOMoveZ(10f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup6[tup6.Count - 1].transform.DOMoveY(tup3.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup6.RemoveAt(tup6.Count - 1);
                tup3.Add(yedek);

            });


        }
        if (degen.transform.gameObject.tag == "tup3" && havada == true && nerede == 7 && tup3.Count < 4 && finished == true)
        {
            finished = false;
            tup7[tup7.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
            tup7[tup7.Count - 1].transform.DOMoveZ(10f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup7[tup7.Count - 1].transform.DOMoveY(tup3.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup7.RemoveAt(tup7.Count - 1);
                tup3.Add(yedek);

            });


        }

        //TUP4
        if (degen.transform.gameObject.tag == "tup4" && havada == true && nerede == 1 && tup4.Count < 4 && finished == true)
        {
            finished = false;
            tup1[tup1.Count - 1].transform.DOMoveZ(15f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup1[tup1.Count - 1].transform.DOMoveY(tup4.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup1.RemoveAt(tup1.Count - 1);
                tup4.Add(yedek);

            });


        }
        if (degen.transform.gameObject.tag == "tup4" && havada == true && nerede == 2 && tup4.Count < 4 && finished == true)
        {
            finished = false;
            tup2[tup2.Count - 1].transform.DOMoveZ(15f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup2[tup2.Count - 1].transform.DOMoveY(tup4.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup2.RemoveAt(tup2.Count - 1);
                tup4.Add(yedek);

            });

        }

        if (degen.transform.gameObject.tag == "tup4" && havada == true && nerede == 3 && tup4.Count < 4 && finished == true)
        {
            finished = false;
            tup3[tup3.Count - 1].transform.DOMoveZ(15f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup3[tup3.Count - 1].transform.DOMoveY(tup4.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup3.RemoveAt(tup3.Count - 1);
                tup4.Add(yedek);

            });

        }

        if (degen.transform.gameObject.tag == "tup4" && havada == true && nerede == 4 && finished == true)
        {
            finished = false;
            tup4[tup4.Count - 1].transform.DOMoveY(tup4.Count - 0.5f, 0.5f).OnComplete(() =>
            {


                tup4.RemoveAt(tup4.Count - 1);
                tup4.Add(yedek);
                finished = true;
                tock.Play();
            });


        }
        if (degen.transform.gameObject.tag == "tup4" && havada == true && nerede == 5 && tup4.Count < 4 && finished == true)
        {
            finished = false;
            tup5[tup5.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
            tup5[tup5.Count - 1].transform.DOMoveZ(15f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup5[tup5.Count - 1].transform.DOMoveY(tup4.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup5.RemoveAt(tup5.Count - 1);
                tup4.Add(yedek);

            });


        }
        if (degen.transform.gameObject.tag == "tup4" && havada == true && nerede == 6 && tup4.Count < 4 && finished == true)
        {
            finished = false;
            tup6[tup6.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
            tup6[tup6.Count - 1].transform.DOMoveZ(15f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup6[tup6.Count - 1].transform.DOMoveY(tup4.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup6.RemoveAt(tup6.Count - 1);
                tup4.Add(yedek);

            });


        }
        if (degen.transform.gameObject.tag == "tup4" && havada == true && nerede == 7 && tup4.Count < 4 && finished == true)
        {
            finished = false;
            tup7[tup7.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
            tup7[tup7.Count - 1].transform.DOMoveZ(15f, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup7[tup7.Count - 1].transform.DOMoveY(tup4.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup7.RemoveAt(tup7.Count - 1);
                tup4.Add(yedek);

            });


        }
        //TUP5

        if (degen.transform.gameObject.tag == "tup5" && havada == true && nerede == 1 && tup5.Count < 4 && finished == true)
        {
            finished = false;
            tup1[tup1.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup1[tup1.Count - 1].transform.DOMoveZ(tup5z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup1[tup1.Count - 1].transform.DOMoveY(tup5.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup1.RemoveAt(tup1.Count - 1);
                tup5.Add(yedek);

            });


        }
        if (degen.transform.gameObject.tag == "tup5" && havada == true && nerede == 2 && tup5.Count < 4 && finished == true)
        {
            finished = false;
            tup2[tup2.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup2[tup2.Count - 1].transform.DOMoveZ(tup5z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup2[tup2.Count - 1].transform.DOMoveY(tup5.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup2.RemoveAt(tup2.Count - 1);
                tup5.Add(yedek);

            });

        }

        if (degen.transform.gameObject.tag == "tup5" && havada == true && nerede == 3 && tup5.Count < 4 && finished == true)
        {
            finished = false;
            tup3[tup3.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup3[tup3.Count - 1].transform.DOMoveZ(tup5z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup3[tup3.Count - 1].transform.DOMoveY(tup5.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup3.RemoveAt(tup3.Count - 1);
                tup5.Add(yedek);

            });

        }

        if (degen.transform.gameObject.tag == "tup5" && havada == true && nerede == 4 && tup5.Count < 4 && finished == true)
        {
            finished = false;
            tup4[tup4.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup4[tup4.Count - 1].transform.DOMoveZ(tup5z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup4[tup4.Count - 1].transform.DOMoveY(tup5.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup4.RemoveAt(tup4.Count - 1);
                tup5.Add(yedek);


            });



        }

        if (degen.transform.gameObject.tag == "tup5" && havada == true && nerede == 5 && finished == true)
        {
            finished = false;
            tup5[tup5.Count - 1].transform.DOMoveY(tup5.Count - 0.5f, 0.5f).OnComplete(() =>
            {


                tup5.RemoveAt(tup5.Count - 1);
                tup5.Add(yedek);
                finished = true;
                tock.Play();
            });


        }

        if (degen.transform.gameObject.tag == "tup5" && havada == true && nerede == 6 && tup5.Count < 4 && finished == true)
        {
            finished = false;
            tup6[tup6.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup6[tup6.Count - 1].transform.DOMoveZ(tup5z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup6[tup6.Count - 1].transform.DOMoveY(tup5.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup6.RemoveAt(tup6.Count - 1);
                tup5.Add(yedek);


            });
        }
        if (degen.transform.gameObject.tag == "tup5" && havada == true && nerede == 7 && tup5.Count < 4 && finished == true)
        {
            finished = false;
            tup7[tup7.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup7[tup7.Count - 1].transform.DOMoveZ(tup5z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup7[tup7.Count - 1].transform.DOMoveY(tup5.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup7.RemoveAt(tup7.Count - 1);
                tup5.Add(yedek);


            });
        }

        //TUP6

        if (degen.transform.gameObject.tag == "tup6" && havada == true && nerede == 1 && tup6.Count < 4 && finished == true)
        {
            finished = false;
            tup1[tup1.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup1[tup1.Count - 1].transform.DOMoveZ(tup6z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup1[tup1.Count - 1].transform.DOMoveY(tup6.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup1.RemoveAt(tup1.Count - 1);
                tup6.Add(yedek);

            });


        }
        if (degen.transform.gameObject.tag == "tup6" && havada == true && nerede == 2 && tup6.Count < 4 && finished == true)
        {
            finished = false;
            tup2[tup2.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup2[tup2.Count - 1].transform.DOMoveZ(tup6z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup2[tup2.Count - 1].transform.DOMoveY(tup6.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup2.RemoveAt(tup2.Count - 1);
                tup6.Add(yedek);

            });

        }

        if (degen.transform.gameObject.tag == "tup6" && havada == true && nerede == 3 && tup6.Count < 4 && finished == true)
        {
            finished = false;
            tup3[tup3.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup3[tup3.Count - 1].transform.DOMoveZ(tup6z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup3[tup3.Count - 1].transform.DOMoveY(tup6.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup3.RemoveAt(tup3.Count - 1);
                tup6.Add(yedek);

            });

        }

        if (degen.transform.gameObject.tag == "tup6" && havada == true && nerede == 4 && tup6.Count < 4 && finished == true)
        {
            finished = false;
            tup4[tup4.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup4[tup4.Count - 1].transform.DOMoveZ(tup6z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup4[tup4.Count - 1].transform.DOMoveY(tup6.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup4.RemoveAt(tup4.Count - 1);
                tup6.Add(yedek);


            });

        }

        if (degen.transform.gameObject.tag == "tup6" && havada == true && nerede == 5 && tup6.Count < 4 && finished == true)
        {
            finished = false;
            tup5[tup5.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup5[tup5.Count - 1].transform.DOMoveZ(tup6z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup5[tup5.Count - 1].transform.DOMoveY(tup6.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup5.RemoveAt(tup5.Count - 1);
                tup6.Add(yedek);

            });

        }

        if (degen.transform.gameObject.tag == "tup6" && havada == true && nerede == 6 && finished == true)
        {
            finished = false;
            tup6[tup6.Count - 1].transform.DOMoveY(tup6.Count - 0.5f, 0.5f).OnComplete(() =>
            {


                tup6.RemoveAt(tup6.Count - 1);
                tup6.Add(yedek);
                finished = true;
                tock.Play();
            });


        }

        if (degen.transform.gameObject.tag == "tup6" && havada == true && nerede == 7 && tup6.Count < 4 && finished == true)
        {
            finished = false;
            tup7[tup7.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup7[tup7.Count - 1].transform.DOMoveZ(tup6z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup7[tup7.Count - 1].transform.DOMoveY(tup6.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup7.RemoveAt(tup7.Count - 1);
                tup6.Add(yedek);

            });

        }

        //TUP7

        if (degen.transform.gameObject.tag == "tup7" && havada == true && nerede == 1 && tup7.Count < 4 && finished == true)
        {
            finished = false;
            tup1[tup1.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup1[tup1.Count - 1].transform.DOMoveZ(tup7z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup1[tup1.Count - 1].transform.DOMoveY(tup7.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup1.RemoveAt(tup1.Count - 1);
                tup7.Add(yedek);

            });


        }
        if (degen.transform.gameObject.tag == "tup7" && havada == true && nerede == 2 && tup7.Count < 4 && finished == true)
        {
            finished = false;
            tup2[tup2.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup2[tup2.Count - 1].transform.DOMoveZ(tup7z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup2[tup2.Count - 1].transform.DOMoveY(tup7.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup2.RemoveAt(tup2.Count - 1);
                tup7.Add(yedek);

            });

        }

        if (degen.transform.gameObject.tag == "tup7" && havada == true && nerede == 3 && tup7.Count < 4 && finished == true)
        {
            finished = false;
            tup3[tup3.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup3[tup3.Count - 1].transform.DOMoveZ(tup7z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup3[tup3.Count - 1].transform.DOMoveY(tup7.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup3.RemoveAt(tup3.Count - 1);
                tup7.Add(yedek);

            });

        }

        if (degen.transform.gameObject.tag == "tup7" && havada == true && nerede == 4 && tup7.Count < 4 && finished == true)
        {
            finished = false;
            tup4[tup4.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup4[tup4.Count - 1].transform.DOMoveZ(tup7z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup4[tup4.Count - 1].transform.DOMoveY(tup7.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup4.RemoveAt(tup4.Count - 1);
                tup7.Add(yedek);


            });

        }

        if (degen.transform.gameObject.tag == "tup7" && havada == true && nerede == 5 && tup7.Count < 4 && finished == true)
        {
            finished = false;
            tup5[tup5.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup5[tup5.Count - 1].transform.DOMoveZ(tup7z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup5[tup5.Count - 1].transform.DOMoveY(tup7.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup5.RemoveAt(tup5.Count - 1);
                tup7.Add(yedek);

            });

        }
        if (degen.transform.gameObject.tag == "tup7" && havada == true && nerede == 6 && tup7.Count < 4 && finished == true)
        {
            finished = false;
            tup6[tup6.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
            tup6[tup6.Count - 1].transform.DOMoveZ(tup7z, 0.5f).SetEase(hareket).OnComplete(() =>
            {
                tock.Play();
                tup6[tup6.Count - 1].transform.DOMoveY(tup7.Count + 0.5f, 0.3f).OnComplete(() =>
                {

                    finished = true;

                });
                tup6.RemoveAt(tup6.Count - 1);
                tup7.Add(yedek);

            });

        }
        if (degen.transform.gameObject.tag == "tup7" && havada == true && nerede == 7 && finished == true)
        {
            finished = false;
            tup7[tup7.Count - 1].transform.DOMoveY(tup7.Count - 0.5f, 0.5f).OnComplete(() =>
            {


                tup7.RemoveAt(tup7.Count - 1);
                tup7.Add(yedek);
                finished = true;
                tock.Play();
            });


        }
    }
    void Controller()
    {
        if (tup1.Count != 0)
        {
            if (tup1.Count > 3)
            {
                if (tup1[0].tag.Equals(tup1[1].tag) && tup1[0].tag.Equals(tup1[2].tag) && tup1[0].tag.Equals(tup1[3].tag))
                {
                    tup1true = true;
                    tup1effect.SetActive(true);
                    a1 = 1;
                }

                else
                {
                    tup1true = false;
                }


            }

        }


        if (tup2.Count != 0)
        {
            if (tup2.Count > 3)
            {
                if (tup2[0].tag.Equals(tup2[1].tag) && tup2[0].tag.Equals(tup2[2].tag) && tup2[0].tag.Equals(tup2[3].tag))
                {
                    tup2true = true;
                    tup2effect.SetActive(true);
                    a2 = 1;
                }

                else
                {
                    tup2true = false;
                }


            }

        }


        if (tup3.Count != 0)
        {
            if (tup3.Count > 3)
            {
                if (tup3[0].tag.Equals(tup3[1].tag) && tup3[0].tag.Equals(tup3[2].tag) && tup3[0].tag.Equals(tup3[3].tag))
                {
                    tup3true = true;
                    tup3effect.SetActive(true);
                    a3 = 1;
                }
                else
                {
                    tup3true = false;

                }


            }

        }

        if (tup4.Count != 0)
        {
            if (tup4.Count > 3)
            {
                if (tup4[0].tag.Equals(tup4[1].tag) && tup4[0].tag.Equals(tup4[2].tag) && tup4[0].tag.Equals(tup4[3].tag))
                {
                    tup4true = true;
                    tup4effect.SetActive(true);
                    a4 = 1;
                }
                else
                {
                    tup4true = false;

                }


            }

        }

        if (tup5.Count != 0)
        {
            if (tup5.Count > 3)
            {
                if (tup5[0].tag.Equals(tup5[1].tag) && tup5[0].tag.Equals(tup5[2].tag) && tup5[0].tag.Equals(tup5[3].tag))
                {
                    tup5true = true;
                    tup5effect.SetActive(true);
                    a5 = 1;
                }
                else
                {
                    tup5true = false;

                }


            }

        }

        if (tup6.Count != 0)
        {
            if (tup6.Count > 3)
            {
                if (tup6[0].tag.Equals(tup6[1].tag) && tup6[0].tag.Equals(tup6[2].tag) && tup6[0].tag.Equals(tup6[3].tag))
                {
                    tup6true = true;
                    tup6effect.SetActive(true);
                    a6 = 1;
                }
                else
                {
                    tup6true = false;

                }


            }

        }

        if (tup7.Count != 0)
        {
            if (tup7.Count > 3)
            {
                if (tup7[0].tag.Equals(tup7[1].tag) && tup7[0].tag.Equals(tup7[2].tag) && tup7[0].tag.Equals(tup7[3].tag))
                {
                    tup7true = true;
                    tup7effect.SetActive(true);
                    a7 = 1;
                }
                else
                {
                    tup7true = false;

                }


            }

        }

    }


    void distribution()
    {


        for (int i = 0; i < length; i++)
        {
            if (PlayerPrefs.GetInt("level") <= 3)
            {
                tuprange = UnityEngine.Random.Range(1, 4);
            }
            if (PlayerPrefs.GetInt("level") > 3 && PlayerPrefs.GetInt("level") < 7)
            {
                tuprange = UnityEngine.Random.Range(1, 5);
            }
            if (PlayerPrefs.GetInt("level") > 6 && PlayerPrefs.GetInt("level") < 10)
            {
                tuprange = UnityEngine.Random.Range(1, 6);
            }
            if (PlayerPrefs.GetInt("level") > 9 && PlayerPrefs.GetInt("level") < 13)
            {
                tuprange = UnityEngine.Random.Range(1, 7);
            }
            if (PlayerPrefs.GetInt("level") > 12)
            {
                tuprange = UnityEngine.Random.Range(1, 8);
            }


            if (tuprange == 1 && tup1.Count < 4 && destiny1 == false && general.Count > 0)
            {
                tup1.Add(general[general.Count - 1]);
                tup1[tup1.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
                tup1[tup1.Count - 1].transform.DOMoveZ(0f, 0.5f).SetEase(hareket);
                tup1[tup1.Count - 1].transform.DOMoveY(tup1.Count - 0.5f, 0.5f);
                general.RemoveAt(general.Count - 1);
            }

            if (tuprange == 2 && tup2.Count < 4 && destiny2 == false && general.Count > 0)
            {
                tup2.Add(general[general.Count - 1]);
                tup2[tup2.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
                tup2[tup2.Count - 1].transform.DOMoveZ(5f, 0.5f).SetEase(hareket);
                tup2[tup2.Count - 1].transform.DOMoveY(tup2.Count - 0.5f, 0.5f);
                general.RemoveAt(general.Count - 1);
            }

            if (tuprange == 3 && tup3.Count < 4 && destiny3 == false && general.Count > 0)
            {
                tup3.Add(general[general.Count - 1]);
                tup3[tup3.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
                tup3[tup3.Count - 1].transform.DOMoveZ(10f, 0.5f).SetEase(hareket);
                tup3[tup3.Count - 1].transform.DOMoveY(tup3.Count - 0.5f, 0.5f);
                general.RemoveAt(general.Count - 1);
            }

            if (tuprange == 4 && tup4.Count < 4 && destiny4 == false && general.Count > 0)
            {
                tup4.Add(general[general.Count - 1]);
                tup4[tup4.Count - 1].transform.DOMoveX(0f, 0.5f).SetEase(hareket);
                tup4[tup4.Count - 1].transform.DOMoveZ(15f, 0.5f).SetEase(hareket);
                tup4[tup4.Count - 1].transform.DOMoveY(tup4.Count - 0.5f, 0.5f);
                general.RemoveAt(general.Count - 1);
            }

            if (tuprange == 5 && tup5.Count < 4 && destiny5 == false && general.Count > 0)
            {
                tup5.Add(general[general.Count - 1]);
                tup5[tup5.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
                tup5[tup5.Count - 1].transform.DOMoveZ(tup5z, 0.5f).SetEase(hareket);
                tup5[tup5.Count - 1].transform.DOMoveY(tup5.Count - 0.5f, 0.5f);
                general.RemoveAt(general.Count - 1);
            }
            if (tuprange == 6 && tup6.Count < 4 && destiny6 == false && general.Count > 0)
            {
                tup6.Add(general[general.Count - 1]);
                tup6[tup6.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
                tup6[tup6.Count - 1].transform.DOMoveZ(tup6z, 0.5f).SetEase(hareket);
                tup6[tup6.Count - 1].transform.DOMoveY(tup6.Count - 0.5f, 0.5f);
                general.RemoveAt(general.Count - 1);
            }
            if (tuprange == 7 && tup7.Count < 4 && destiny7 == false && general.Count > 0)
            {
                tup7.Add(general[general.Count - 1]);
                tup7[tup7.Count - 1].transform.DOMoveX(9f, 0.5f).SetEase(hareket);
                tup7[tup7.Count - 1].transform.DOMoveZ(tup7z, 0.5f).SetEase(hareket);
                tup7[tup7.Count - 1].transform.DOMoveY(tup7.Count - 0.5f, 0.5f);
                general.RemoveAt(general.Count - 1);
            }

            //dont start with finished

            if (tup1.Count > 2)
            {
                if (tup1[0].tag.Equals(tup1[1].tag) && tup1[0].tag.Equals(tup1[2].tag))
                {
                    destiny1 = true;
                }

            }

            if (tup2.Count > 2)
            {
                if (tup2[0].tag.Equals(tup2[1].tag) && tup2[0].tag.Equals(tup2[2].tag))
                {
                    destiny2 = true;
                }

            }

            if (tup3.Count > 2)
            {
                if (tup3[0].tag.Equals(tup3[1].tag) && tup3[0].tag.Equals(tup3[2].tag))
                {
                    destiny3 = true;
                }

            }
            if (tup4.Count > 2)
            {
                if (tup4[0].tag.Equals(tup4[1].tag) && tup4[0].tag.Equals(tup4[2].tag))
                {
                    destiny4 = true;
                }

            }
            if (tup5.Count > 2)
            {
                if (tup5[0].tag.Equals(tup5[1].tag) && tup5[0].tag.Equals(tup5[2].tag))
                {
                    destiny5 = true;
                }

            }
            if (tup6.Count > 2)
            {
                if (tup6[0].tag.Equals(tup6[1].tag) && tup6[0].tag.Equals(tup6[2].tag))
                {
                    destiny6 = true;
                }

            }
            if (tup7.Count > 2)
            {
                if (tup7[0].tag.Equals(tup7[1].tag) && tup7[0].tag.Equals(tup7[2].tag))
                {
                    destiny7 = true;
                }

            }


        }





    }

    public void LevelUp()
    {

        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        SceneManager.LoadScene("SampleScene");
    }

    public void Formagic()
    {
        if (tup1true == true&& enough1==false)
        {
            magicaudi.Play();
            enough1 = true;
        }
        if (tup2true == true && enough2 == false)
        {
            magicaudi.Play();
            enough2 = true;
        }
        if (tup3true == true && enough3 == false)
        {
            magicaudi.Play();
            enough3 = true;
        }
        if (tup4true == true && enough4 == false)
        {
            magicaudi.Play();
            enough4 = true;
        }
        if (tup5true == true && enough5 == false)
        {
            magicaudi.Play();
            enough5 = true;
        }
        if (tup6true == true && enough6 == false)
        {
            magicaudi.Play();
            enough6 = true;
        }
        if (tup7true == true && enough7 == false)
        {
            magicaudi.Play();
            enough7 = true;
        }
    }

    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(0.5f);
        stareffectaudio.Play();
        star1.SetActive(false);
        yield return new WaitForSeconds(0.75f);
        stareffectaudio.Play();
        star2.SetActive(false);
        yield return new WaitForSeconds(0.75f);
        stareffectaudio.Play();
        star3.SetActive(false);
    }
    IEnumerator ExampleCoroutine2()
    {

        yield return new WaitForSeconds(0.5f);
        stareffectaudio.Play();
        star1.SetActive(false);
        yield return new WaitForSeconds(0.75f);
        stareffectaudio.Play();
        star2.SetActive(false);
    }
    IEnumerator ExampleCoroutine3()
    {

        yield return new WaitForSeconds(0.5f);
        stareffectaudio.Play();
        star1.SetActive(false);
    }
}
