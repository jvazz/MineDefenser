using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{
    public GameObject lojaPanel;
    public bool lojaAberta = false;
    Player player;
    public List<Button> botoes;
    public List<int> precos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < botoes.Count; i++)
        {
            if(player.ouro >= precos[i])
            {
                botoes[i].interactable = true;
            }else
            {
                botoes[i].interactable = false;
            }

            if(i == 4)
            {
                if(player.ferro >= precos[i])
                {
                    botoes[i].interactable = true;
                }else
                {
                    botoes[i].interactable = false;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(lojaAberta)
            {
                lojaAberta = !lojaAberta;
            }
        }

        if(lojaAberta)
        {
            lojaPanel.SetActive(true);
        }else
        {
            lojaPanel.SetActive(false);
        }
    }

    public void LojaBtn()
    {
        lojaPanel.SetActive(!lojaAberta);
        lojaAberta = !lojaAberta;
    }

    public void MaquinaBtn(string maquina)
    {
        player.modoContrucao = true;
        player.tipoConstrucao = maquina;
    }
}
