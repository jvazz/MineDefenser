using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAldeao : MonoBehaviour
{
    public GameObject controladorDeWaves;
    Player player;
    public GameObject aldeaoVida;
    [SerializeField] float tempoSeguro;
    [SerializeField] bool taNascido;
    [SerializeField] Vector3 posicaoCasa;
    [SerializeField] Vector3 posicaoAldeao;
    [SerializeField] float velocidadeAldeao;
    public GameObject simboloDiamante, simboloPicaretas;
    public bool podeComprar;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        taNascido = false;
        tempoSeguro = 0;
        podeComprar = false;
        //aldeaoVida.SetActive(false);
        //aldeaoPicareta.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tempoSeguro += Time.deltaTime;
        if(tempoSeguro > 5)
        {
            if(!taNascido)
            {
                if(controladorDeWaves.GetComponent<WaveSpawner>().contadorDeWaves >= 2)
                {
                    if(player.vida < 2)
                    {
                        taNascido = true;
                    }
                }
                /*if(controladorDeWaves.GetComponent<WaveSpawner>().contadorDeWaves >= 2)
                {
                if(player.nivelPicareta < 5)
                {
                    aldeaoPicareta.SetActive(true);
                }
                }*/

                //aldeaoVida.SetActive(true);
                //aldeaoPicareta.SetActive(true);
            }
        }
        else
        {
            //aldeaoVida.SetActive(false);
            //aldeaoPicareta.SetActive(false);
        }

        if(taNascido && aldeaoVida.transform.position != posicaoAldeao)
        {
            aldeaoVida.transform.position = Vector3.MoveTowards(aldeaoVida.transform.position, posicaoAldeao, velocidadeAldeao * Time.deltaTime);   
        }
        if(!taNascido && aldeaoVida.transform.position != posicaoCasa)
        {
            aldeaoVida.transform.position = Vector3.MoveTowards(aldeaoVida.transform.position, posicaoCasa, velocidadeAldeao * Time.deltaTime);
        }

        if(aldeaoVida.transform.position == posicaoAldeao)
        {
            simboloDiamante.SetActive(true);
            podeComprar = true;
        }else
        {
            simboloDiamante.SetActive(false);
            podeComprar = false;
        }

        if(player.nivelPicareta > 4)
        {
            simboloPicaretas.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Inimigo")
        {
            //aldeaoVida.SetActive(false);
            //aldeaoPicareta.SetActive(false);
            tempoSeguro = 0;
            taNascido = false;
        }
    }
}
