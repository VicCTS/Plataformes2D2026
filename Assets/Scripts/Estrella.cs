using UnityEngine;
using UnityEngine.SceneManagement;

public class Estrella : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Victory");
        }
    }
}