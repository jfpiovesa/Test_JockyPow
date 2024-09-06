using UnityEngine;


public class AIController : MonoBehaviour
{
    public PlayerController.Choice GetAIChoice()
    {
        return (PlayerController.Choice)Random.Range(0, 3);
    }
}
