using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mina : MonoBehaviour
{
    Player player;
    [SerializeField] float precoAbrirMina;
    [SerializeField] GameObject minaPanel;
    [SerializeField] GameObject placaMina;
    [SerializeField] bool minaAberta;
    [SerializeField] bool panelMinaAberto;
    GameObject cam;
    [SerializeField] Button abrirMinaBtn;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        minaPanel.SetActive(false);
        placaMina.SetActive(true);
        minaAberta = false;
        panelMinaAberto = false;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        abrirMinaBtn.interactable = false;
    }

    void Update()
    {
        if(panelMinaAberto)
        {
            if(player.ouro >= precoAbrirMina)
            {
                abrirMinaBtn.interactable = true;
            }else
            {
                abrirMinaBtn.interactable = false;
            }
            
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                panelMinaAberto = false;
                minaPanel.SetActive(false);
            }
        }
    }

    void OnMouseDown()
    {
        if(!minaAberta)
        {
            panelMinaAberto = true;
            minaPanel.SetActive(true);
        }else
        {
            cam.GetComponent<Camera>().AndarCamera();
        }
    }

    public void AbrirMinaBtn()
    {
        if(player.ouro >= precoAbrirMina)
        {
            minaPanel.SetActive(false);
            placaMina.SetActive(false);
            minaAberta = true;
            player.ouro -= Mathf.RoundToInt(precoAbrirMina);
            //cam.GetComponent<Camera>().AndarCamera();
        }
    }

    public void FecharMinaPanel()
    {
        minaPanel.SetActive(false);
    }
}
