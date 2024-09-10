using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ui_infoGame : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text_info;
    [SerializeField] private GameObject painelInfo;


    private void OnEnable()
    {
        S_UiGame.InfoAction += SetupInfo;
    }

    private void OnDisable()
    {
        S_UiGame.InfoAction -= SetupInfo;

    }
    public void SetupInfo(string valueInfo)
    {
        m_Text_info.text = valueInfo;
        painelInfo.SetActive(true);
    }

}
