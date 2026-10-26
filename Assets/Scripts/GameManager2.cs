using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instance;

    public int coins = 0;

    [SerializeField] private Text _coinsText;

    void Awake()
    {
        /*if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }*/

        Instance = this;
    }

    public void AddCoins()
    {
        coins ++;
        _coinsText.text = coins.ToString();
    }
}
