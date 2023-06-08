using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carvoeira : MonoBehaviour
{
    Player player;
    bool funcionando = false;
    public GameObject fumaca;
    public EspacoDeConstrucao meuLugar;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        fumaca.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(player.inventario == "destruir")
        {
            meuLugar.minhaConstrucao = null;
            Destroy(gameObject);
        }
        if(player.madeira >= 3 && !funcionando)
        {
            funcionando = true;
            player.madeira -= 3;
            fumaca.SetActive(true);
            Invoke("CarvaoPronto", 10f);
        }
    }

    void CarvaoPronto()
    {
        player.carvao += 3;
        funcionando = false;
        fumaca.SetActive(false);
    }
}
