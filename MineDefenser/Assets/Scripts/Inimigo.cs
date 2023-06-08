using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] int vida;
    GameObject player;
    public int recompensa;
    public bool jogadoParaCima;
    Vector3 posicaoAtual;
    public float velocidadeSubida;
    [SerializeField] int danoIronGolem;
    SeguidorDeCaminhos meuSeguidor;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        jogadoParaCima = false;
        vida = vida * PlayerPrefs.GetInt("DificuldadeKey");
        player.GetComponent<Player>().inimigosVivos++;
        meuSeguidor = gameObject.GetComponent<SeguidorDeCaminhos>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
        {
            player.GetComponent<Player>().ouro += recompensa;
            player.GetComponent<Player>().inimigosVivos--;
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        if(player.GetComponent<Player>().inventario == "espada")
        {
            vida--;
        }
    }

    public void TomaDano(int dano)
    {
        vida -= dano;
    }

    public void JogadoParaCima()
    {
        jogadoParaCima = true;
        posicaoAtual = transform.position;
        gameObject.GetComponent<SeguidorDeCaminhos>().enabled = false;
        StartCoroutine("Sobe");
    }

    IEnumerator Sobe()
    {
        while(Vector3.Distance(transform.position, posicaoAtual + Vector3.up*2.5f) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicaoAtual + Vector3.up*2.5f, velocidadeSubida * Time.deltaTime);
            yield return null;
        }
        StartCoroutine("Desce");
    }

    IEnumerator Desce()
    {
        while(Vector3.Distance(transform.position, posicaoAtual) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicaoAtual, velocidadeSubida * Time.deltaTime);
            yield return null;
        }
        jogadoParaCima = false;
        gameObject.GetComponent<SeguidorDeCaminhos>().enabled = true;
        vida -= danoIronGolem;
    }

    public void AplicaLentidao()
    {
        meuSeguidor.velocidade *= 0.666f;
        if(meuSeguidor.velocidade < meuSeguidor.velocidadeMinima)
        {
            meuSeguidor.velocidade = meuSeguidor.velocidadeMinima;
        }
    }
}
