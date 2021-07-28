using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stacks : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> tup1 = new List<GameObject>();
    public List<GameObject> tup2 = new List<GameObject>();
    public List<GameObject> tup3 = new List<GameObject>();

    public GameObject kirmizi1;
    public GameObject kirmizi2;
    public GameObject kirmizi3;
    public GameObject kirmizi4;
    public GameObject mavi1;
    public GameObject mavi2;
    public GameObject mavi3;
    public GameObject mavi4;
    public GameObject yedek;

    bool havada;
    bool tup1true = false;
    bool tup2true = false;
    bool tup3true = false;
    public int nerede = 0;
    bool finished;
    public Ease hareket;
    public AudioSource tick;
    public AudioSource tock;
    bool enough = false;
    public GameObject finalsound;
    public AudioSource finalsound1;
    void Start()
    {
        tup1.Add(kirmizi1);
        tup1.Add(mavi2);

        tup2.Add(mavi1);
        tup2.Add(kirmizi2);
        tup2.Add(mavi3);

        tup3.Add(kirmizi4);
        tup3.Add(mavi4);
        tup3.Add(kirmizi3);

        finished = true;

        tick = GetComponent<AudioSource>();
        tock = GetComponentInChildren<AudioSource>();
        finalsound1= finalsound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        tiklama();
        havada = Control.Instance.havada;
        Controller();

        if (((tup1true == true && tup2true == true) || (tup1true && tup3true) || (tup2true && tup3true))&&enough==false)
        {
            Debug.Log("KAZANDIN");
            Camera.main.transform.DOShakePosition(2f, 1f, 5, 90, false, true);
            enough = true;
            finalsound1.Play();
        }
    }




    void tiklama()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);



            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Degen(hit);
                Yerlestir(hit);
            }
        }
    }

    void Degen(RaycastHit degen)
    {
        if (degen.transform.gameObject.tag == "tup1" && havada == false&&finished==true)
        {

            //tup1[tup1.Count - 1].transform.Translate(0f, 7f - tup1.Count, 0f);
            tick.Play();
            finished = false;
            nerede = 1;
            yedek = tup1[tup1.Count - 1];
            tup1[tup1.Count - 1].transform.DOMoveY(6.5f, 0.3f).SetEase(hareket).OnComplete(() =>
            {

                finished = true;

            });


        }
        if (degen.transform.gameObject.tag == "tup2" && havada == false&&finished==true)
        {

            //tup2[tup2.Count - 1].transform.Translate(0f, 7f - tup2.Count, 0f);
            tick.Play();
            finished = false;

            nerede = 2;
            yedek = tup2[tup2.Count - 1];
            tup2[tup2.Count - 1].transform.DOMoveY(6.5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {

                finished = true;

            }); 


        }
        if (degen.transform.gameObject.tag == "tup3" && havada == false && finished == true)
        {

            //tup3[tup3.Count - 1].transform.Translate(0f, 7f - tup3.Count, 0f);
            tick.Play();
            finished = false;
            nerede = 3;
            yedek = tup3[tup3.Count - 1];
            tup3[tup3.Count - 1].transform.DOMoveY(6.5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {

                finished = true;

            });

        }
    }
    void Yerlestir(RaycastHit degen)
    {
        if (degen.transform.gameObject.tag == "tup1" && havada == true && nerede == 1&&finished==true)
        {

            //tup1[tup1.Count - 1].transform.Translate(0f, -(7f - tup1.Count), 0f);
            finished = false;
            tup1[tup1.Count - 1].transform.DOMoveY(tup1.Count-0.5f, 0.5f).OnComplete(() =>
            {

                 tup1.RemoveAt(tup1.Count - 1);
                 tup1.Add(yedek);
                 finished = true;
                 tock.Play();
            }); 


        }
        if (degen.transform.gameObject.tag == "tup1" && havada == true && nerede == 2 && tup1.Count < 4&&finished==true)
        {

            //tup2[tup2.Count - 1].transform.Translate(0f, -(6f - tup1.Count), -5f);
            finished = false;
            tup2[tup2.Count - 1].transform.DOMoveZ(0f, 0.5f).SetEase(hareket).OnComplete(() =>
            {

                tup2[tup2.Count - 1].transform.DOMoveY(tup1.Count + 0.5f, 0.5f).OnComplete(() =>
                {

                    finished = true;
                    tock.Play();
                });
                tup2.RemoveAt(tup2.Count - 1);
                 tup1.Add(yedek);

            });




        }
        if (degen.transform.gameObject.tag == "tup1" && havada == true && nerede == 3 && tup1.Count < 4&&finished==true)
        {
            finished = false;
            tup3[tup3.Count - 1].transform.DOMoveZ(0f, 0.5f).SetEase(hareket).OnComplete(() =>
            {

                tup3[tup3.Count - 1].transform.DOMoveY(tup1.Count + 0.5f, 0.5f).OnComplete(() =>
                {

                    finished = true;
                    tock.Play();
                });
                tup3.RemoveAt(tup3.Count - 1);
                tup1.Add(yedek);


            });



        }

        //TUP2

        if (degen.transform.gameObject.tag == "tup2" && havada == true && nerede == 1 && tup2.Count < 4&&finished==true)
        {
            finished = false;
            tup1[tup1.Count - 1].transform.DOMoveZ(5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {

                tup1[tup1.Count - 1].transform.DOMoveY(tup2.Count + 0.5f, 0.5f).OnComplete(() =>
                {

                    finished = true;
                    tock.Play();
                });
                tup1.RemoveAt(tup1.Count - 1);
                tup2.Add(yedek);

            });

            //tup1[tup1.Count - 1].transform.Translate(0f, -(6f - tup2.Count), 5f);
            //tup1.RemoveAt(tup1.Count - 1);
            //tup2.Add(yedek);

        }
        if (degen.transform.gameObject.tag == "tup2" && havada == true && nerede == 2&&finished==true)
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
        if (degen.transform.gameObject.tag == "tup2" && havada == true && nerede == 3 && tup2.Count < 4&&finished==true)
        {
            finished = false;
            tup3[tup3.Count - 1].transform.DOMoveZ(5f, 0.5f).SetEase(hareket).OnComplete(() =>
            {

                tup3[tup3.Count - 1].transform.DOMoveY(tup2.Count + 0.5f, 0.5f).OnComplete(() =>
                {

                    finished = true;
                    tock.Play();
                });
                tup3.RemoveAt(tup3.Count - 1);
                tup2.Add(yedek);

            });
            //tup3[tup3.Count - 1].transform.Translate(0f, -(6f - tup2.Count), -5f);
            //tup3.RemoveAt(tup3.Count - 1);
            //tup2.Add(yedek);

        }


        //TUP3

        if (degen.transform.gameObject.tag == "tup3" && havada == true && nerede == 1 && tup3.Count < 4&&finished==true)
        {
            finished = false;
            tup1[tup1.Count - 1].transform.DOMoveZ(10f, 0.5f).SetEase(hareket).OnComplete(() =>
            {

                tup1[tup1.Count - 1].transform.DOMoveY(tup3.Count + 0.5f, 0.5f).OnComplete(() =>
                {

                    finished = true;
                    tock.Play();
                });
                tup1.RemoveAt(tup1.Count - 1);
                tup3.Add(yedek);

            });
            //tup1[tup1.Count - 1].transform.Translate(0f, -(6f - tup3.Count), 10f);
            //tup1.RemoveAt(tup1.Count - 1);
            //tup3.Add(yedek);

        }
        if (degen.transform.gameObject.tag == "tup3" && havada == true && nerede == 2 && tup3.Count < 4&&finished==true)
        {
            finished = false;
            tup2[tup2.Count - 1].transform.DOMoveZ(10f, 0.5f).SetEase(hareket).OnComplete(() =>
            {

                tup2[tup2.Count - 1].transform.DOMoveY(tup3.Count + 0.5f, 0.5f).OnComplete(() =>
                {

                    finished = true;
                    tock.Play();
                }); 
                tup2.RemoveAt(tup2.Count - 1);
                tup3.Add(yedek);

            });
            //tup2[tup2.Count - 1].transform.Translate(0f, -(6f - tup3.Count), 5f);
            //tup2.RemoveAt(tup2.Count - 1);
            //tup3.Add(yedek);


        }
        if (degen.transform.gameObject.tag == "tup3" && havada == true && nerede == 3&&finished==true)
        {
            finished = false;
            tup3[tup3.Count - 1].transform.DOMoveY(tup3.Count-0.5f,0.5f).OnComplete(() =>
            {


                 tup3.RemoveAt(tup3.Count - 1);
                 tup3.Add(yedek);
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
                    Debug.Log("tup1= " + tup1true);
                }

                else
                {
                    tup1true = false;
                    Debug.Log("tup1= " + tup1true);
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
                    Debug.Log(tup2true);
                    Debug.Log("tup2= " + tup2true);
                }

                else
                {
                    tup2true = false;
                    Debug.Log("tup2= " + tup2true);
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
                    Debug.Log("tup3= " + tup3true);
                }
                else
                {
                    tup3true = false;
                    Debug.Log("tup3= " + tup3true);
                }


            }

        }

    }
}
