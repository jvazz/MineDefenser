using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fases : MonoBehaviour
{
    public GameObject panelFacil, panelMedio, panelDificil;
    public Button fase1, fase2, fase3, fase4, fase5;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("DificuldadeKey", 2);
        panelFacil.SetActive(false);
        panelMedio.SetActive(true);
        panelDificil.SetActive(false);

        switch (PlayerPrefs.GetInt("FasesVencidasKey"))
        {
            case 0 : 
                fase1.interactable = true;
                fase2.interactable = false;
                fase3.interactable = false;
                fase4.interactable = false;
                fase5.interactable = false;
                break;

            case 1 : 
                fase1.interactable = true;
                fase2.interactable = true;
                fase3.interactable = false;
                fase4.interactable = false;
                fase5.interactable = false;
                break;

            case 2 : 
                fase1.interactable = true;
                fase2.interactable = true;
                fase3.interactable = true;
                fase4.interactable = false;
                fase5.interactable = false;
                break;

            case 3 : 
                fase1.interactable = true;
                fase2.interactable = true;
                fase3.interactable = true;
                fase4.interactable = true;
                fase5.interactable = false;
                break;

            case 4 : 
                fase1.interactable = true;
                fase2.interactable = true;
                fase3.interactable = true;
                fase4.interactable = true;
                fase5.interactable = true;
                break;

            case 5 : 
                fase1.interactable = true;
                fase2.interactable = true;
                fase3.interactable = true;
                fase4.interactable = true;
                fase5.interactable = true;
                break;

            case 6 : 
                fase1.interactable = true;
                fase2.interactable = true;
                fase3.interactable = true;
                fase4.interactable = true;
                fase5.interactable = true;
                break;

            default :
                break;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dificuldade(int dificuldade)
    {
        switch (dificuldade)
            {
                case 1 :
                    PlayerPrefs.SetInt("DificuldadeKey", 1);
                    panelFacil.SetActive(true);
                    panelMedio.SetActive(false);
                    panelDificil.SetActive(false);
                    break;

                case 2 : 
                    PlayerPrefs.SetInt("DificuldadeKey", 2);
                    panelFacil.SetActive(false);
                    panelMedio.SetActive(true);
                    panelDificil.SetActive(false);
                    break;

                case 3 : 
                    PlayerPrefs.SetInt("DificuldadeKey", 3);
                    panelFacil.SetActive(false);
                    panelMedio.SetActive(false);
                    panelDificil.SetActive(true);
                    break;

                default :
                    break;
            }
    }

    public void Fase(int fase)
    {
        if(fase == 0)
        {
            SceneManager.LoadScene("CenaTutorial");
        }
        else if(fase == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }else
        {
            SceneManager.LoadScene("Fase" + fase.ToString(""));
        }
    }
}
