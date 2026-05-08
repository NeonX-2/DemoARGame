using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public GameObject winPanel;
    public TextMeshProUGUI winnerText;

    private bool battleEnded = false;

    void Awake()
    {
        Instance = this;
    }

    public void DeclareWinner(string winnerName)
    {
        if (battleEnded) return;

        battleEnded = true;

        winPanel.SetActive(true);

        winnerText.text = winnerName + " WINS!";
    }
}