using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armas : MonoBehaviour
{
    public bool combustivelInfinito = false;
    public Transform alvo;
    public float raio = 8;
    public Transform parteQueGira;
    public GameObject projetil;
    public float tempoCorrente;
    public float tempoDelay;
    Player player;
    [SerializeField] bool funcionando;
    public int combustivel = 0;
    [SerializeField] int combustivelMaximo;
    public GameObject iconeAmarelo, iconeVermelho;
    [SerializeField] float alertaRecarga;
    public bool redstoneOn;
    [SerializeField] float tempoTurbo;
    public GameObject particulaRedstone;
    public EspacoDeConstrucao meuLugar;
    [SerializeField] string upgrade;
    public GameObject painelUpgrades;
    [SerializeField] Material materialUpgrade1, materialUpgrade2, materialUpgrade3;
    public bool painelUpgradesAtivado;
    public List<Renderer> materiaisMetalicos;
    //A cor dos materiais metalicos mudam de acordo com o upgrade
    GameObject inventario;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AchaAlvo", 0.3f, 0.3f);
        tempoCorrente = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        funcionando = true;
        iconeVermelho.SetActive(false);
        iconeAmarelo.SetActive(false);
        combustivel = combustivelMaximo;
        redstoneOn = false;  
        particulaRedstone.SetActive(false);
        painelUpgrades.SetActive(false);
        painelUpgradesAtivado = false;
        upgrade = "padrao";
        inventario = GameObject.Find("Inventario");
    }

    // Update is called once per frame
    void Update()
    {
        tempoCorrente -= Time.deltaTime;
        if(combustivel <= alertaRecarga && combustivel != 0)
        {
            iconeVermelho.SetActive(false);
            iconeAmarelo.SetActive(true);
        }

        if(alvo == null)
        {
            return;
        }

        Vector3 direcao;
        Quaternion rotacaoParaOlhar;
        Vector3 rotacao;

        direcao = alvo.position - transform.position;
        rotacaoParaOlhar = Quaternion.LookRotation(direcao);
        rotacao = rotacaoParaOlhar.eulerAngles;
        parteQueGira.rotation = Quaternion.Euler(0, rotacao.y, 0);

        //Parte para atirar
        if(combustivel > 0)
        {
            if(tempoCorrente <= 0)
            {
                if(redstoneOn)
                {
                    tempoCorrente = tempoDelay/2;
                }else
                {
                    tempoCorrente = tempoDelay;
                }
                Atira();
            }
        }else
        {
            funcionando = false;
            iconeVermelho.SetActive(true);
            iconeAmarelo.SetActive(false);
        }

        if(Vector3.Distance(transform.position, alvo.position) > raio)
        {
            alvo = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raio);
    }

    void AchaAlvo()
    {
        GameObject[] inimigos;
        float menordistancia = 100;
        GameObject inimigoMaisProximo;

        inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
        if(alvo != null)
        {
            return;
        }
        if(inimigos == null)
        {
            return;
        }
        foreach(GameObject inimigo in inimigos)
        {
            if(Vector3.Distance(transform.position, inimigo.transform.position) < menordistancia && Vector3.Distance(transform.position, inimigo.transform.position) <= raio)
            {
                inimigoMaisProximo = inimigo;
                menordistancia = Vector3.Distance(transform.position, inimigo.transform.position);
                alvo = inimigoMaisProximo.transform;
            }
        }
    }

    void PararTurbo()
    {
        redstoneOn = false;
        particulaRedstone.SetActive(false);
    }

    void Atira()
    {
        if(!redstoneOn)
        {
            if(!combustivelInfinito)
            {
                combustivel -= 1;
            }
        }
        GameObject meuTiro;
        meuTiro = Instantiate(projetil, parteQueGira.position, parteQueGira.rotation);
        meuTiro.GetComponent<Projetil>().alvo = alvo;
        if(upgrade == "dano")
        {
            meuTiro.GetComponent<Projetil>().dano*=2;
        }
        if(upgrade == "lentidao")
        {
            meuTiro.GetComponent<Projetil>().lentidao = true;
        }
    }

    void OnMouseDown()
    {
        if(player.inventario == "destruir")
        {
            meuLugar.minhaConstrucao = null;
            Destroy(gameObject);
        }
        if(player.inventario == "melhorar")
        {
            if(!painelUpgradesAtivado)
            {
                if(player.lapisLazuli >= 1)
                {
                    painelUpgradesAtivado = true;
                    painelUpgrades.SetActive(true);
                    inventario.GetComponent<Inventario>().BotoesInventario(1);
                }
            }else
            {
                painelUpgradesAtivado = false;
                painelUpgrades.SetActive(false);
            }
        }
        if(player.carvao >= 1 && combustivel <= alertaRecarga && player.inventario == "carvao")
        {
            player.carvao--;
            funcionando = true;
            combustivel = combustivelMaximo;
            iconeVermelho.SetActive(false);
            iconeAmarelo.SetActive(false);
        }

        if(player.redstone >= 1 && player.inventario == "redstone")
        {
            if(!redstoneOn)
            {
                player.redstone--;
                redstoneOn = true;
                particulaRedstone.SetActive(true);
                Invoke("PararTurbo", tempoTurbo);
            }
        }
    }

    public void BotaoMelhoria(string upgradeBotao)
    {
        player.lapisLazuli -= 1;
        upgrade = upgradeBotao;

        if(upgrade == "alcance")
        {
            raio*=2;
            foreach(Renderer mat in materiaisMetalicos)
            {
                //mat.material.SetColor("_Color", corUpgrade1);
                mat.material = materialUpgrade1;
            }
        }

        if(upgrade == "dano")
        {
            foreach(Renderer mat in materiaisMetalicos)
            {
                //mat.material.SetColor("_Color", corUpgrade2);
                mat.material = materialUpgrade2;
            }
        }

        if(upgrade == "lentidao")
        {
            foreach(Renderer mat in materiaisMetalicos)
            {
                //mat.material.SetColor("_Color", corUpgrade3);
                mat.material = materialUpgrade3;
            }
        }

        painelUpgradesAtivado = false;
        painelUpgrades.SetActive(false);
    }
}