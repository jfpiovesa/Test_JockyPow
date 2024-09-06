using MoreMountains.Feedbacks;
using UnityEngine;

public class UI_Hands : MonoBehaviour
{
    [SerializeField] MMF_Player mmf_player;
    [SerializeField] GameObject[] handsIa;
    [SerializeField] GameObject[] handsPlayer;


    private void OnEnable()
    {
        S_UiGame.ChoicePlayer += SelectedHandPlay;
        S_UiGame.ChoiceIa += SelectedHandIa;
    }
    private void OnDisable()
    {
        S_UiGame.ChoicePlayer -= SelectedHandPlay;
        S_UiGame.ChoiceIa -= SelectedHandIa;
    }
    public void SelectedHandPlay(int value)
    {
        foreach (GameObject hand in handsPlayer)
        {
            hand.SetActive(false);
        }
        handsPlayer[value].SetActive(true);
        mmf_player.PlayFeedbacks();
    }
    public void SelectedHandIa(int value)
    {
        foreach (GameObject hand in handsIa)
        {
            hand.SetActive(false);
        }
        handsIa[value].SetActive(true);
    }
    public void HandDisebles()
    {
        foreach (GameObject hand in handsPlayer)
        {
            hand.SetActive(false);
        }
        foreach (GameObject hand in handsIa)
        {
            hand.SetActive(false);
        }
    }
}
