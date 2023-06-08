using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerios : MonoBehaviour
{
    public List<GameObject> minerios;
    public List<GameObject> mineriosDesativados;
    [SerializeField] float temporizador = 1;
    public float temporizadorLimite = 10;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < minerios.Count; i++)
        {
            if(!minerios[i].activeInHierarchy)
            {
                mineriosDesativados.Add(minerios[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        temporizador -= Time.deltaTime;
        if(temporizador <= 0)
        {
            int falha = Random.Range(-minerios.Count, 1);
            temporizador = temporizadorLimite;
            if(falha > mineriosDesativados.Count - minerios.Count)
            {
                return;
            }
            if(mineriosDesativados.Count == 0)
            {
                return;
            }else
            {
                int n = Random.Range(0, mineriosDesativados.Count);
                mineriosDesativados[n].SetActive(true);
                mineriosDesativados.Remove(mineriosDesativados[n]);
            }
        }
    }
}
