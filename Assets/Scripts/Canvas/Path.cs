using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PathMenu : MonoBehaviour
{
    public Vector3 position;
    public Vector2 playerVelocity;

    public bool PathGame;
    public GameObject _pathGameMenu;

    public void CloseChoose()
    {
        _pathGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PathGame = false;
    }
    public void OpenChoose()
    {
        _pathGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PathGame = true;
    }
    public void ChooseContinue()
    {

        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
    public void ChooseGiveUp()
    {

        SceneManager.LoadScene(4);
    }
}
