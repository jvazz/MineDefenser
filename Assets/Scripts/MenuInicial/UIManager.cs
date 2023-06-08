using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panelFases, panelCreditos, panelConfigs;
    public Texture2D cursorPadrao;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorPadrao, Vector2.zero, CursorMode.ForceSoftware);
        Time.timeScale = 1.0f;
        panelFases.SetActive(false);
        panelCreditos.SetActive(false);
        panelConfigs.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fases()
    {
        panelFases.SetActive(true);
        panelCreditos.SetActive(false);
        panelConfigs.SetActive(false);
    }

    public void Creditos()
    {
        panelFases.SetActive(false);
        panelCreditos.SetActive(true);
        panelConfigs.SetActive(false);
    }

    public void Configs()
    {
        panelFases.SetActive(false);
        panelCreditos.SetActive(false);
        panelConfigs.SetActive(true);
    }

    public void Voltar()
    {
        panelFases.SetActive(false);
        panelCreditos.SetActive(false);
        panelConfigs.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
