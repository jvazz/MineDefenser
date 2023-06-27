using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorTutorial : MonoBehaviour
{
    public string etapaDoTutorial;
    [SerializeField] Text textoTutorial;
    [SerializeField] Text textoControles, textoControles2;
    [SerializeField] bool etapaConcluida;
    [SerializeField] List<string> explicacoes;
    [SerializeField] List<string> controles;
    [SerializeField] GameObject painelControles;
    [SerializeField] List<GameObject> objetosInterativos;
    Transform antigoParent;
    Player player;
    [SerializeField] GameObject zumbiTutorial;
    [SerializeField] List<GameObject> scriptsAcessados;
    [SerializeField] GameObject inimigoTutorial;


    public float velocidadeEscrita;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        painelControles.SetActive(false);
        etapaDoTutorial = "introducao";
        //textoTutorial.text = explicacoes[0];
        textoControles.text = controles[0];
        textoControles2.text = controles[0];
        etapaConcluida = false;
        StartCoroutine(Introducao());
        StartCoroutine(EscreverTextoTutorial(0));
        textoControles2.gameObject.SetActive(false);
        player.ouro = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EscreverTextoTutorial(int index)
    {
        textoTutorial.text = "";
        foreach (char letter in explicacoes[index].ToCharArray())
        {
            textoTutorial.text += letter;
            yield return new WaitForSeconds(velocidadeEscrita);
        } 
    }

    IEnumerator Introducao()
    {
        //Escrevendo os primeiros textos
        yield return new WaitForSeconds(3f);
        textoTutorial.text = explicacoes[0];
        textoControles.text = controles[0];
        textoControles2.text = controles[0];
        //Deiaxando o painel dos controles visivel
        painelControles.SetActive(true);
        //Parando o zumbi
        zumbiTutorial.GetComponent<SeguidorDeCaminhos>().velocidade = 0;
        //Destacando o elemento da HUD
        antigoParent = objetosInterativos[0].transform.parent;
        objetosInterativos[0].transform.SetParent(painelControles.transform);
        //Conferindo se o comando foi cumprido
        while(!etapaConcluida)
        {
            if(player.inventario == "espada") etapaConcluida = true;
            yield return null;
        }
        //Volta o elemento destacado da HUD para seu estado normal
        objetosInterativos[0].transform.SetParent(antigoParent);
        etapaConcluida = false;
        //Novos textos
        textoControles.text = controles[1];
        textoControles2.text = controles[1];
        yield return new WaitForSeconds(1f);
        painelControles.SetActive(false);
        textoControles2.gameObject.SetActive(true);
        //Reativa zumbi
        zumbiTutorial.GetComponent<SeguidorDeCaminhos>().velocidade = 3;
        //Da seguimento ao código se o zumbi estiver morto
        while(!etapaConcluida)
        {
            if(zumbiTutorial == null) etapaConcluida = true;
            yield return null;
        }
        //Chama a nova etapa
        StartCoroutine(Construcoes());

        yield return null;
    }

    IEnumerator Construcoes()
    {
        etapaConcluida = false;
        //Escreve novos textos
        StartCoroutine(EscreverTextoTutorial(1));
        textoControles2.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        textoControles.text = controles[2];
        textoControles2.text = controles[2];
        painelControles.SetActive(true);
        //Destacando o elemento da HUD
        antigoParent = objetosInterativos[1].transform.parent;
        objetosInterativos[1].transform.SetParent(painelControles.transform);
        while(!etapaConcluida)
        {
            if(scriptsAcessados[0].GetComponent<Loja>().lojaAberta) etapaConcluida = true;
            yield return null;
        }
        etapaConcluida = false;
        objetosInterativos[1].transform.SetParent(antigoParent);
        textoControles.text = controles[3];
        textoControles2.text = controles[3];
        antigoParent = objetosInterativos[2].transform.parent;
        objetosInterativos[2].transform.SetParent(painelControles.transform);
        while(!etapaConcluida)
        {
            if(player.tipoConstrucao == "Besta") etapaConcluida = true;
            yield return null;
        }
        etapaConcluida = false;
        objetosInterativos[2].transform.SetParent(antigoParent);
        textoControles.text = controles[4];
        textoControles2.text = controles[4];
        objetosInterativos[1].GetComponent<Button>().interactable = false;
        scriptsAcessados[0].GetComponent<Loja>().lojaAberta = false;
        yield return new WaitForSeconds(2f);
        painelControles.SetActive(false);
        textoControles2.gameObject.SetActive(true);
        while(!etapaConcluida)
        {
            if(player.ouro == 0) etapaConcluida = true;
            yield return null;
        }
        etapaConcluida = false;
        objetosInterativos[1].GetComponent<Button>().interactable = true;
        textoControles2.gameObject.SetActive(false);
        StartCoroutine(EscreverTextoTutorial(2));
        yield return new WaitForSeconds(3f);
        zumbiTutorial = Instantiate(inimigoTutorial, scriptsAcessados[1].transform.position + scriptsAcessados[1].GetComponent<WaveSpawner>().offSet, scriptsAcessados[1].transform.rotation);
        while(!etapaConcluida)
        {
            if(zumbiTutorial == null) etapaConcluida = true;
            yield return null;
        }
        etapaConcluida = false;
        GameObject besta = GameObject.Find("Besta(Clone)");
        besta.GetComponent<Armas>().combustivel = 3;
        //Chama a nova etapa
        StartCoroutine(Carvao());

        yield return null;
    }

    IEnumerator Carvao()
    {
        //Escrevendo os primeiros textos
        yield return new WaitForSeconds(1f);
        StartCoroutine(EscreverTextoTutorial(3));
        yield return new WaitForSeconds(7f);
        StartCoroutine(EscreverTextoTutorial(4));
        yield return new WaitForSeconds(4f);
        textoControles.text = controles[5];
        textoControles2.text = controles[5];
        //Deiaxando o painel dos controles visivel
        painelControles.SetActive(true);
        antigoParent = objetosInterativos[3].transform.parent;
        objetosInterativos[3].transform.SetParent(painelControles.transform);
        while(!etapaConcluida)
        {
            if(player.inventario == "machado") etapaConcluida = true;
            yield return null;
        }
        etapaConcluida = false;
        objetosInterativos[3].transform.SetParent(antigoParent);
        textoControles.text = controles[6];
        textoControles2.text = controles[6];
        yield return new WaitForSeconds(1f);
        painelControles.SetActive(false);
        textoControles2.gameObject.SetActive(true);
        while(!etapaConcluida)
        {
            if(player.madeira > 0) etapaConcluida = true;
            yield return null;
        }
        etapaConcluida = false;
        textoControles2.gameObject.SetActive(false);
        StartCoroutine(EscreverTextoTutorial(5));
        yield return new WaitForSeconds(3f);
        while(!etapaConcluida)
        {
            if(player.ouro == 0) etapaConcluida = true;
            yield return null;
        }
        etapaConcluida = false;
        yield return new WaitForSeconds(1f);
        painelControles.SetActive(true);
        textoControles.text = controles[7];
        textoControles2.text = controles[7];
        yield return new WaitForSeconds(3f);
        painelControles.SetActive(false);
        textoControles2.gameObject.SetActive(true);
        StartCoroutine(EscreverTextoTutorial(6));
        while(!etapaConcluida)
        {
            if(player.carvao > 0) etapaConcluida = true;
            yield return null;
        }
        etapaConcluida = false;
        textoControles2.gameObject.SetActive(false);
        StartCoroutine(EscreverTextoTutorial(7));
        yield return new WaitForSeconds(2f);
        textoControles.text = controles[8];
        textoControles2.text = controles[8];
        painelControles.SetActive(true);
        antigoParent = objetosInterativos[4].transform.parent;
        objetosInterativos[4].transform.SetParent(painelControles.transform);
        while(!etapaConcluida)
        {
            if(player.inventario == "carvao") etapaConcluida = true;
            yield return null;
        }
        etapaConcluida = false;
        objetosInterativos[4].transform.SetParent(antigoParent);
        textoControles.text = controles[9];
        textoControles2.text = controles[9];
        yield return new WaitForSeconds(2f);
        painelControles.SetActive(false);
        textoControles2.gameObject.SetActive(true);
        GameObject besta = GameObject.Find("Besta(Clone)");
        while(!etapaConcluida)
        {
            if(besta.GetComponent<Armas>().combustivel > 3) etapaConcluida = true;
            yield return null;
        }
        etapaConcluida = false;
        textoControles2.gameObject.SetActive(false);
        StartCoroutine(Mina());
        
        yield return null;
    }
    
    IEnumerator Mina()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(EscreverTextoTutorial(8));
        yield return new WaitForSeconds(7f);
        StartCoroutine(EscreverTextoTutorial(9));
        yield return new WaitForSeconds(7f);
        player.ouro = 100;
        objetosInterativos[1].GetComponent<Button>().interactable = false;
        textoControles.text = controles[10];
        textoControles2.text = controles[10];
        //Deiaxando o painel dos controles visivel
        painelControles.SetActive(true);
        yield return new WaitForSeconds(2f);
        painelControles.SetActive(false);
        textoControles2.gameObject.SetActive(true);
        objetosInterativos[5].SetActive(true);
        while(!etapaConcluida)
        {
            if(player.ouro <= 0) etapaConcluida = true;
            yield return null;
        }
        etapaConcluida = false;
        objetosInterativos[5].SetActive(false);
        textoControles2.gameObject.SetActive(false);
        textoControles.text = controles[11];
        textoControles2.text = controles[11];
        painelControles.SetActive(true);
        yield return new WaitForSeconds(2f);
        painelControles.SetActive(false);
        textoControles2.gameObject.SetActive(true);
        while(!etapaConcluida)
        {
            if(scriptsAcessados[2].GetComponent<Camera>().estaNaMina) etapaConcluida = true;
            yield return null;
        }
        etapaConcluida = false;
        textoControles2.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(EscreverTextoTutorial(10));
        yield return new WaitForSeconds(4f);
        StartCoroutine(EscreverTextoTutorial(11));
        yield return new WaitForSeconds(3f);
        textoControles.text = controles[12];
        textoControles2.text = controles[12];
        painelControles.SetActive(true);
        antigoParent = objetosInterativos[6].transform.parent;
        objetosInterativos[6].transform.SetParent(painelControles.transform);
        //Conferindo se o comando foi cumprido
        while(!etapaConcluida)
        {
            if(player.inventario == "picareta") etapaConcluida = true;
            yield return null;
        }
        etapaConcluida = false;
        //Volta o elemento destacado da HUD para seu estado normal
        objetosInterativos[6].transform.SetParent(antigoParent);
        textoControles.text = controles[13];
        textoControles2.text = controles[13];
        yield return new WaitForSeconds(2f);
        painelControles.SetActive(false);
        textoControles2.gameObject.SetActive(true);
        while(!etapaConcluida)
        {
            if(player.lapisLazuli > 0) etapaConcluida = true;
            yield return null;
        }
        etapaConcluida = false;
        textoControles2.gameObject.SetActive(false);
        StartCoroutine(EscreverTextoTutorial(12));

        yield return null;
    }
}
