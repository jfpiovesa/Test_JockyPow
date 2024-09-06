using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_timer : MonoBehaviour
{

    [Header("Image timer")]
    [SerializeField] private Image m_timerFill;
    [SerializeField] private Image m_timerCount;
    [SerializeField] private Sprite[] m_timers;


    float fillamount = 1;
    private void OnEnable()
    {
        S_UiGame.TimeAction += TimerImagesChange;
    }
    private void OnDisable()
    {
        S_UiGame.TimeAction -= TimerImagesChange;
    }
    public void TimerImagesChange(int value)
    {
        int valueTimeLocal = Mathf.Clamp(value - 1, 0, 9);
        m_timerCount.sprite = m_timers[valueTimeLocal];
        fillamount = (float)value / 10f;
        m_timerFill.fillAmount = Mathf.Lerp(m_timerFill.fillAmount, fillamount, 0.05f);

    }
}
