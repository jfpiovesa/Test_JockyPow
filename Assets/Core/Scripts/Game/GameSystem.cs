using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;

    public AIController aiController;


    public float timeLimit = 10f; // Limite de tempo definido como 10 segundos
    private float timer;
    private bool playerHasChosen = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        ResetGame();
        S_UiGame.Start = StartGame;
        S_UiGame.Reset = ResetGame;
    }
    private void Update()
    {
        if (playerHasChosen)
        {
            timer -= Time.deltaTime;
            int displayTime = Mathf.CeilToInt(timer);
            S_UiGame.TimeAction(displayTime);
            if (timer <= 0)
            {
                PlayerTimeout();
            }
        }
    }
    public void CompareChoices(PlayerController.Choice playerChoice)
    {
        playerHasChosen = false;

        PlayerController.Choice aiChoice = aiController.GetAIChoice();
        S_UiGame.ChoiceIASet((int)aiChoice);
        S_UiGame.ChoicePlayerSet((int)playerChoice);

        Debug.Log("Jogador escolheu: " + playerChoice);
        Debug.Log("IA escolheu: " + aiChoice);

        if (playerChoice == aiChoice)
        {
            Debug.Log("Empate!");
            S_UiGame.End(1);
        }
        else if ((playerChoice == PlayerController.Choice.Rock && aiChoice == PlayerController.Choice.Scissor) ||
           (playerChoice == PlayerController.Choice.Paper && aiChoice == PlayerController.Choice.Rock) ||
           (playerChoice == PlayerController.Choice.Scissor && aiChoice == PlayerController.Choice.Paper))
        {
            Debug.Log("Jogador venceu!");
            S_UiGame.End(0);
        }
        else
        {
            Debug.Log("IA venceu!");
            S_UiGame.End(2);
        }
       
    }
    private void PlayerTimeout()
    {
        playerHasChosen = false;
        Debug.Log("O jogador não fez uma escolha a tempo!");
        PlayerController.Choice randomChoice = (PlayerController.Choice)Random.Range(0, 3); // Escolha aleatória
        CompareChoices(randomChoice); // Executa o jogo com uma escolha aleatória

    }

    public void StartGame()
    {
        playerHasChosen = true;
    }
    public void ResetGame()
    {
        playerHasChosen = false;
        timer = timeLimit;
        S_UiGame.TimeAction(10);
    }

}
