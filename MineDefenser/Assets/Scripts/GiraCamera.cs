using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraCamera : MonoBehaviour
{
    public float velocidadeDeGiro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, velocidadeDeGiro*Time.deltaTime, 0), Space.Self);
    }
}
