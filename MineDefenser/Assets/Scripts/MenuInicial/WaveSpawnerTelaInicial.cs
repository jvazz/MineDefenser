using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerTelaInicial : MonoBehaviour
{
    public List<GameObject> inimigos;
    public float delay;
    public float delayWaves;
    public Vector3 offSet;
    int vezes;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CriarInimigo", delay);
        vezes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CriarInimigo()
    {
        Instantiate(inimigos[Random.Range(0, 9)], transform.position + offSet, transform.rotation);
        vezes++;
        if(vezes == 5)
        {
            Invoke("CriarInimigo", delay*delayWaves);
            vezes = 0;
        }else
        {
            Invoke("CriarInimigo", delay);
        }
    }
}
