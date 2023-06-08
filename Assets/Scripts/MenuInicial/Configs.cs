using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configs : MonoBehaviour
{
    public GameObject panelGraficos, panelSom, panelControle;

    // Start is called before the first frame update
    void Start()
    {
        panelGraficos.SetActive(true);
        panelSom.SetActive(false);
        panelControle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Configurar(int configurar)
    {
        switch (configurar)
            {
                case 1 :
                    panelGraficos.SetActive(true);
                    panelSom.SetActive(false);
                    panelControle.SetActive(false);
                    break;

                case 2 : 
                    panelGraficos.SetActive(false);
                    panelSom.SetActive(true);
                    panelControle.SetActive(false);
                    break;

                case 3 : 
                    panelGraficos.SetActive(false);
                    panelSom.SetActive(false);
                    panelControle.SetActive(true);
                    break;

                default :
                    break;
            }
    }
}
