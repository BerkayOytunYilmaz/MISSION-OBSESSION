using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update


    #region SINGLETON PATTERN
    private static Control _instance;
    public static Control Instance { get { return _instance; } }
    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    public bool havada=false;


  


    private void OnTriggerEnter(Collider nesne)
    {
        if (nesne.transform.tag == "mavi" || nesne.transform.tag == "kirmizi")
        {
            havada = true;
            //Debug.Log("havada");

        }
    }
    private void OnTriggerExit(Collider nesne)
    {
        if (nesne.transform.tag == "mavi" || nesne.transform.tag == "kirmizi")
        {
            havada = false;
            //Debug.Log("yerde");
        }
    }
  
}
