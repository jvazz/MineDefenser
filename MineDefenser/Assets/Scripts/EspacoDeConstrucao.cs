using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspacoDeConstrucao : MonoBehaviour
{
    public GameObject minhaConstrucao;
    Player player;
    public Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if(minhaConstrucao != null)
        {
            return;
        }
        if(player.modoContrucao)
        {
           switch (player.tipoConstrucao)
           {
                case "Carvoeira" : 
                    minhaConstrucao = Instantiate(player.listaCostrucoesFantasmas[0], transform.position + offset, Quaternion.identity);
                    break;
                
                case "Canhao" : 
                    minhaConstrucao = Instantiate(player.listaCostrucoesFantasmas[1], transform.position + offset, Quaternion.identity);
                    break;

                case "Besta" : 
                    minhaConstrucao = Instantiate(player.listaCostrucoesFantasmas[2], transform.position + offset, Quaternion.identity);
                    break;

                case "Bruxa" : 
                    minhaConstrucao = Instantiate(player.listaCostrucoesFantasmas[3], transform.position + offset, Quaternion.identity);
                    break;
                
                case "IronGolen" : 
                    minhaConstrucao = Instantiate(player.listaCostrucoesFantasmas[4], transform.position + offset, Quaternion.identity);
                    break;

                default :
                    break;
           } 
        }
    }

    void OnMouseDown()
    {
        if(minhaConstrucao != null)
        {
            if(!minhaConstrucao.CompareTag("Fantasma"))
                return;
        }
        if(player.modoContrucao)
        {
           switch (player.tipoConstrucao)
           {
                case "Carvoeira" : 
                    Destroy(minhaConstrucao);
                    minhaConstrucao = Instantiate(player.listaCostrucoes[0], transform.position + offset, Quaternion.identity);
                    player.ouro -= 10;
                    player.modoContrucao = false;
                    minhaConstrucao.GetComponent<Carvoeira>().meuLugar = this;
                    break;

                case "Besta" : 
                    Destroy(minhaConstrucao);
                    minhaConstrucao = Instantiate(player.listaCostrucoes[2], transform.position + offset, Quaternion.identity);
                    player.ouro -= 20;
                    player.modoContrucao = false;
                    minhaConstrucao.GetComponent<Armas>().meuLugar = this;
                    break;

                case "Canhao" : 
                    Destroy(minhaConstrucao);
                    minhaConstrucao = Instantiate(player.listaCostrucoes[1], transform.position + offset, Quaternion.identity);
                    player.ouro -= 50;
                    player.modoContrucao = false;
                    minhaConstrucao.GetComponent<Armas>().meuLugar = this;
                    break;
                
                case "Bruxa" : 
                    Destroy(minhaConstrucao);
                    minhaConstrucao = Instantiate(player.listaCostrucoes[3], transform.position + offset, Quaternion.identity);
                    player.ouro -= 100;
                    player.modoContrucao = false;
                    minhaConstrucao.GetComponent<Armas>().meuLugar = this;
                    break;

                case "IronGolen" : 
                    Destroy(minhaConstrucao);
                    minhaConstrucao = Instantiate(player.listaCostrucoes[4], transform.position + offset, Quaternion.identity);
                    player.ferro -= 10;
                    player.modoContrucao = false;
                    minhaConstrucao.GetComponent<IronGolem>().meuLugar = this;
                    break;

                default :
                    break;
           } 
        }
    }

    void OnMouseExit()
    {
        if(minhaConstrucao != null)
        {
            if(minhaConstrucao.CompareTag("Fantasma"))
            {
                Destroy(minhaConstrucao);
            }
        }
    }
}
