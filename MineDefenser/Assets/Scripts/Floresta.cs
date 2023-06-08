using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floresta : MonoBehaviour
{
    public List<GameObject> arvores;
    public List<GameObject> arvoresDesativadas;
    float temporizador = 1;
    public float temporizadorLimite = 10;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < arvores.Count; i++)
        {
            if(!arvores[i].activeInHierarchy)
            {
                arvoresDesativadas.Add(arvores[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        temporizador -= Time.deltaTime;
        if(temporizador <= 0)
        {
            int falha = Random.Range(-10, 1);
            temporizador = temporizadorLimite;
            if(falha > arvoresDesativadas.Count - arvores.Count)
            {
                return;
            }
            if(arvoresDesativadas.Count == 0)
            {
                return;
            }else
            {
                int n = Random.Range(0, arvoresDesativadas.Count);
                arvoresDesativadas[n].SetActive(true);
                arvoresDesativadas.Remove(arvoresDesativadas[n]);
            }
        }
    }
}
