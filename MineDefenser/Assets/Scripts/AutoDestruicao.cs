using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruicao : MonoBehaviour
{
    public float tempo;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destruir", tempo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Destruir()
    {
        Destroy(gameObject);
    }
}
