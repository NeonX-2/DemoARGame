using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;
    
    public GameObject winPanel;
    public TextMeshProUGUI winnerText;
    
    public AutoBattle dragonBattle;
    public AutoBattle knightBattle;
    
    public GameObject fightButton;
    private bool battleEnded = false;
    
    void Awake()
    {
        Instance = this;
    }
    
    public void StartFight()
    {
        dragonBattle.StartBattle();
        knightBattle.StartBattle();

        fightButton.SetActive(false);
    }
    
    public void DeclareWinner(string winnerName)
    {
        if (battleEnded) return;

        battleEnded = true;

        winPanel.SetActive(true);

        winnerText.text = winnerName + " WINS!";
    }
    
    public void ReplayBattle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}