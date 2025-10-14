using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesMenuSelection : MonoBehaviour
{
    public void LoadMapScene()
    {
        SceneManager.LoadScene("MapGame");
    }
}
