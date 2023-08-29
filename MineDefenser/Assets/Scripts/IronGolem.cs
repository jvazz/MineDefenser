using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronGolem : MonoBehaviour
{
    public bool combustivelInfinito = false;
    public Transform alvo;
    public float raio = 8;
    public Transform parteQueGira;
    //public GameObject projetil;
    public float tempoCorrente;
    public float tempoDelay;
    Player player;
    [SerializeField] bool funcionando;
    [SerializeField] int combustivel = 0;
    [SerializeField] int combustivelMaximo;
    public GameObject iconeAmarelo, iconeVermelho;
    [SerializeField] float alertaRecarga;
    public bool redstoneOn;
    [SerializeField] float tempoTurbo;
    public GameObject particulaRedstone;
    Animator meuAnim;
    public EspacoDeConstrucao meuLugar;

    // Start is called before the first frame update
    void Start()
    {
        meuAnim = GetComponent<Animator>();
        InvokeRepeating("AchaAlvo", 0.3f, 0.3f);
        tempoCorrente = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        funcionando = true;
        iconeVermelho.SetActive(false);
        iconeAmarelo.SetActive(false);
        combustivel = combustivelMaximo;
        redstoneOn = false;  
        particulaRedstone.SetActive(false);
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
        //GameObject meuTiro;
        //meuTiro = Instantiate(projetil, parteQueGira.position, parteQueGira.rotation);
        meuAnim.SetTrigger("Atacar");
        //alvo.transform.position = Vector3.MoveTowards(alvo.transform.position, new Vector3(alvo.transform.position.x, alvo.transform.position.y + 10, alvo.transform.position.z), velocidadeSubida);
        alvo.GetComponent<Inimigo>().JogadoParaCima();
    }

    void OnMouseDown()
    {
        if(player.inventario == "destruir")
        {
            meuLugar.minhaConstrucao = null;
            Destroy(gameObject);
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
}
