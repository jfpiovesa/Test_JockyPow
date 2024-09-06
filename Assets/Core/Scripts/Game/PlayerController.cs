using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Choice {Paper, Rock, Scissor };
    public Choice playerChoice;



    private void OnEnable()
    {
        S_UiGame.ChoiceForPlayer += SetPlayerChoice;
    }

    private void OnDisable()
    {
        S_UiGame.ChoiceForPlayer -= SetPlayerChoice;
    }

    public void SetPlayerChoice(int choice)
    {
        playerChoice = (Choice)choice;
        GameSystem.instance.CompareChoices(playerChoice);
    }

    
}
