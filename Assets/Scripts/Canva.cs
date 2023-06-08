using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canva : MonoBehaviour
{
    public GameObject botaoAmpliar, botaoRetrair, retraiveis;

    // Start is called before the first frame update
    void Start()
    {
        botaoAmpliar.SetActive(true);
        botaoRetrair.SetActive(false);
        retraiveis.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ampliar()
    {
        botaoAmpliar.SetActive(false);
        botaoRetrair.SetActive(true);
        retraiveis.SetActive(true);
    }
    public void Retrair()
    {
        botaoAmpliar.SetActive(true);
        botaoRetrair.SetActive(false);
        retraiveis.SetActive(false);
    }
}
