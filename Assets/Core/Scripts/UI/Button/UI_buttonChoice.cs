using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_buttonChoice : MonoBehaviour
{
    public void SelectChoice(int value)
    {
        S_UiGame.Choice(value);
    }
}
