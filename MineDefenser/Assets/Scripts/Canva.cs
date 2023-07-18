using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Canva : MonoBehaviour
{
    public GameObject botaoAmpliar, botaoRetrair, retraiveis;
    public bool jogoPausado;
    public GameObject painelPause;
    public GameObject painelConfirmacao;
    string objetivo;

    // Start is called before the first frame update
    void Start()
    {
        botaoAmpliar.SetActive(true);
        botaoRetrair.SetActive(false);
        retraiveis.SetActive(false);
        jogoPausado = false;
        painelPause.SetActive(false);
        painelConfirmacao.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }
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

    public void Pausar()
    {
        if(!jogoPausado)
        {
            Time.timeScale = 0;
            painelPause.SetActive(true);
            painelConfirmacao.SetActive(false);
            jogoPausado = true;
        }else
        {
            Time.timeScale = 1;
            painelPause.SetActive(false);
            jogoPausado = false;
        }
    }

    public void Confirmacao(bool fechar)
    {
        if(fechar)
        {
            painelConfirmacao.SetActive(false);
        }else
        {
            if(objetivo == "Reiniciar")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if(objetivo == "MenuInicial")
            {
                SceneManager.LoadScene("TelaInicial");
            }
        }
    }

    public void Reiniciar()
    {
        objetivo = "Reiniciar";
        painelConfirmacao.SetActive(true);
    }

    public void MenuInicial()
    {
        objetivo = "MenuInicial";
        painelConfirmacao.SetActive(true);
    }
}
