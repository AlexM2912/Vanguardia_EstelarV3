using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiManager : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel 1 Polo");
    }

    public void IrInstrucciones()
    {
        SceneManager.LoadScene("Pantalla de Instrucciones");
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("Pantalla de Inicio");
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}