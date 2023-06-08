using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public float tempo = 0;
    [SerializeField] float tempoEntreWaves, tempoEntreInimigos;
    public List<Wave> waves;
    public int contadorInimigos;
    public int contadorDeWaves;
    public Vector3 offSet;
    bool terminou = false;
    Player player;

    void Start()
    {
        contadorInimigos = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        tempo -= Time.deltaTime;

        if(waves.Count == contadorDeWaves && player.inimigosVivos == 0)
        {
            terminou = true;
            player.painelVitoria.SetActive(true);
            if(PlayerPrefs.GetInt("FasesVencidasKey") < player.numeroDaFase)
            {
                PlayerPrefs.SetInt("FasesVencidasKey", player.numeroDaFase);
            }
            Time.timeScale = 0;
        }

        if(tempo > 0 || terminou)
        {
            return;
        }

        if(contadorInimigos < waves[contadorDeWaves].wave.Count)
        {
            Instantiate(waves[contadorDeWaves].wave[contadorInimigos], transform.position + offSet, transform.rotation);
            tempo = waves[contadorDeWaves].tempoEntreInimigos;
            contadorInimigos++;
        }
        else if(contadorInimigos == waves[contadorDeWaves].wave.Count)
        {
            tempo = tempoEntreWaves;
            contadorDeWaves++;
            contadorInimigos = 0;
        }

        /*
        tempo += Time.deltaTime;
        if(tempo >= tempoLimite)
        {
            int aleatorio;
            aleatorio = Random.Range(1, 5);
            switch (aleatorio)
            {
                case 1 : 
                    Instantiate(inimigo, transform.position + Vector3.up * 0.5f, transform.rotation);
                    break;
                
                case 2 : 
                    Instantiate(inimigo, transform.position + Vector3.up * 0.5f, transform.rotation);
                    break;

                case 3 : 
                    Instantiate(inimigo, transform.position + Vector3.up * 0.5f, transform.rotation);
                    break;

                case 4 : 
                    Instantiate(inimigo2, transform.position + Vector3.up * 0.5f, transform.rotation);
                    break;

                default :
                    break;
            } 
            tempo = 0;
        }
        */
    }
}
