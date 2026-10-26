using UnityEngine;

public class Coins2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager2.Instance.AddCoins();
            Destroy(gameObject);
        }
    }
}
