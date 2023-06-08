using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguidorDeCaminhos : MonoBehaviour
{
    public List<GameObject> esquinas = new List<GameObject>();

    public GameObject paiDeTodos;

    public int alvo = 0;

    public float velocidade;
    public float velocidadeMinima;

    Player player;

    [SerializeField] bool modoTutoial = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        paiDeTodos = GameObject.Find("ControladorCaminho");

        for(int i = 0; i != paiDeTodos.transform.childCount; i++)
        {
            esquinas.Add(paiDeTodos.transform.GetChild(i).gameObject);
        }

        transform.LookAt(esquinas[alvo].transform.position);
    }

    void Update()
    {
        if(Vector3.Distance(esquinas[esquinas.Count - 1].transform.position, transform.position) < 4f && modoTutoial)
        {
            velocidade = 0;
        }

        if(Vector3.Distance(esquinas[alvo].transform.position, transform.position) < 0.1f)
        {
            alvo++;
            if(alvo == esquinas.Count)
            {
                player.vida -= 1;
                Destroy(gameObject);
                return;
            }
            transform.LookAt(esquinas[alvo].transform.position);

        }

        transform.position = Vector3.MoveTowards(transform.position, esquinas[alvo].transform.position, velocidade * Time.deltaTime);
    }
}
