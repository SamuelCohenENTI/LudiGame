using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesMenuSelection : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadPreviousScene()
    {
        // Obtiene el �ndice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Verifica que no estemos en la primera escena (�ndice 0)
        if (currentSceneIndex > 0)
        {
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
        else
        {
            Debug.LogWarning("No hay una escena anterior para cargar.");
        }
    }
}
