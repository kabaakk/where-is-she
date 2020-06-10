using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ev")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
