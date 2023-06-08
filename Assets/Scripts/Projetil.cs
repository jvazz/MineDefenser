using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float velocidade;
    public Transform alvo;
    public float distanciaColisao;
    public Vector3 offSet;
    public int dano;
    public float area;
    public GameObject particulaExplosao;
    public bool lentidao = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(alvo == null)
        {
            Destroy(gameObject);
        }else
        {
            transform.position = Vector3.MoveTowards(transform.position, alvo.position + offSet, velocidade * Time.deltaTime);

            if(Vector3.Distance(transform.position, alvo.position + offSet) < distanciaColisao)
            {
                Acertou();
            }
        }
    }

    /*void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, area);
    }*/

    void Acertou()
    {
        if(area == 0)
        {
            if(lentidao) alvo.gameObject.GetComponent<Inimigo>().AplicaLentidao();
            alvo.gameObject.GetComponent<Inimigo>().TomaDano(dano);
            Destroy(gameObject);
        }else
        {
            GameObject[] inimigos;
            inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
            foreach(GameObject ini in inimigos)
            {
                if(Vector3.Distance(ini.transform.position, transform.position) <= area)
                {
                    if(lentidao) ini.GetComponent<Inimigo>().AplicaLentidao();
                    ini.GetComponent<Inimigo>().TomaDano(dano);
                }
            }
            Instantiate(particulaExplosao, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
