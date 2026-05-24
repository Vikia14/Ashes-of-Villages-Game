using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleport : MonoBehaviour
{
    //[SerializeField] private GameManager gameManager;
    //[SerializeField] private PathMenu pathMenu;
    public string SceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
