using TMPro;
using UnityEngine;

public class Ui_paineEnd : MonoBehaviour
{
    [SerializeField] private TMP_Text m_textEnd;
    [SerializeField] private GameObject m_painelActive;
    private void OnEnable()
    {
        S_UiGame.End += EndGame;
    }
    private void OnDisable()
    {
        S_UiGame.End -= EndGame;

    }
    public void ResetGame()
    {
        S_UiGame.ResetDuel();   
    }
    public void EndGame(int value)
    {
        switch (value)
        {
            case 0:
                m_textEnd.text = "Venceu!";
                m_textEnd.color = Color.green;
                break;

            case 1:
                m_textEnd.text = "Empatou!";
                m_textEnd.color = Color.yellow;

                break;
            case 2:
                m_textEnd.text = "Perdeu!";
                m_textEnd.color = Color.red;

                break;
        }
    }
}
