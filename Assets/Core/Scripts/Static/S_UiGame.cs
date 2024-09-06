using System;
using UnityEngine;
using static PlayerController;

public static class S_UiGame
{
    public static Action<int> TimeAction { get; set; }
    public static Action<int> ChoiceForPlayer { get; set; }

    public static Action<int> ChoicePlayer { get; set; }
    public static Action<int> ChoiceIa { get; set; }

    public static Action<int> End { get; set; }

    public static Action Start { get; set; }

    public static Action Reset { get; set; }

    public static void SetTimer(int value)
    {
        TimeAction?.Invoke(value);
    }
    public static void Choice(int value)
    {
        ChoiceForPlayer?.Invoke(value);
    }
    public static void ChoicePlayerSet(int value)
    {
        ChoicePlayer?.Invoke(value);
    }
    public static void ChoiceIASet(int value)
    {
        ChoiceIa?.Invoke(value);
    }
    public static void StartDuel()
    {
        Start?.Invoke();
    }
    public static void ResetDuel()
    {
        Reset?.Invoke();
    }
    public static void EndDuel(int value)
    {
        End?.Invoke(value);
    }
}
