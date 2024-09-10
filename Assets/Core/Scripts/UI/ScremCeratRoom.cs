using MoreMountains.Feedbacks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ScremCeratRoom : MonoBehaviour
{
    [SerializeField] private MMFeedbacks playe;
    [SerializeField] private TMP_InputField _nameRoom;
    [SerializeField] private TMP_InputField _namePlayer;

    [SerializeField] private TMP_InputField _idrooom;

    [SerializeField] private TMP_InputField _nameRoomId;
    [SerializeField] private TMP_InputField _namePlayerId;


    [SerializeField] private TMP_InputField _nameRoom_SubmitChoice;
    [SerializeField] private TMP_InputField _namePlayer_SubmitChoice;
    [SerializeField] private Button btn_rock;
    [SerializeField] private Button btn_paper;
    [SerializeField] private Button btn_scissor;

    int _nummberChoice = 0;

    private void OnEnable()
    {
        btn_paper.onClick.AddListener(() => SetNumer(0));
        btn_rock.onClick.AddListener(() => SetNumer(1));
        btn_scissor.onClick.AddListener(() => SetNumer(2));

    }

    public void CreateRoom()
    {
        if (!string.IsNullOrEmpty(_nameRoom.text) && !string.IsNullOrEmpty(_namePlayer.text))
        {
            GameSystem.instance.apiRequest.RequestCreateRoom(_nameRoom.text, _namePlayer.text, ActionPlayer);
        }
        else
        {
            S_UiGame.InfoActionSet("Preencha os campos");
        }
    }
    public void ResultRoom()
    {
        if (!string.IsNullOrEmpty(_idrooom.text))
        {
            GameSystem.instance.apiRequest.RequestGetResult(_idrooom.text, ActionPlayer);

        }
        else
        {
            S_UiGame.InfoActionSet("Preencha os campos");
        }
    }
    public void GetSubmitChoice()
    {
        if (!string.IsNullOrEmpty(_nameRoomId.text) && !string.IsNullOrEmpty(_namePlayerId.text))
        {
            GameSystem.instance.apiRequest.RequestGetSubmitChoice(_nameRoomId.text, _namePlayerId.text, ActionPlayer);
        }
        else
        {
            S_UiGame.InfoActionSet("Preencha os campos");
        }
    }

    public void SubmitChoice()
    {
        if (!string.IsNullOrEmpty(_namePlayer_SubmitChoice.text) && !string.IsNullOrEmpty(_nameRoom_SubmitChoice.text))
        {
            GameSystem.instance.apiRequest.RequestSubmitChoice(_namePlayer_SubmitChoice.text
                , _nameRoom_SubmitChoice.text,
                 _nummberChoice.ToString(), ActionPlayer);
        }
        else
        {
            S_UiGame.InfoActionSet("Preencha os campos");
        }

    }
    public void ActionPlayer()
    {
        // playe.PlayFeedbacks(); 
    }

    public void SetNumer(int value)
    {
        _nummberChoice = value;
    }


}
