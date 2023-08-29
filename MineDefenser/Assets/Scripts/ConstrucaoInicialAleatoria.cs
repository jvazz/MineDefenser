using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrucaoInicialAleatoria : MonoBehaviour
{
    public List<GameObject> construcoes;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        int deveSpawnar;
        deveSpawnar = Random.Range(1, 4);
        if(deveSpawnar < 2)
        {
            Instantiate(construcoes[Random.Range(0, 5)], transform.position + offset, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
