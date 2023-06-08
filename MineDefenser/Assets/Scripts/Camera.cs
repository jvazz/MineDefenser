using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Vector3 posicaoMina;
    Vector3 posicaoInicial;
    [SerializeField] bool estaNaMina;
    public GameObject cameraMiniMapa;

    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = transform.position;
        estaNaMina = false;
        cameraMiniMapa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            AndarCamera();
        }
    }

    public void AndarCamera()
    {
        if(estaNaMina)
        {
            transform.position = posicaoInicial;
        }else
        {
            transform.position = posicaoMina;
        }
        estaNaMina = !estaNaMina;
        cameraMiniMapa.SetActive(estaNaMina);
    }
}
