using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TriviaSO", menuName = "TriviaScriptableObject")]

public class TriviaSO : ScriptableObject
{
    [Header("Vote, MultipleChoice, Text")]
    public int type = 2;

    [Header("GainLife, Giant")]
    public int WinnerEffect = 1;

    [Header("LoseLife")]
    public int LoserEffect = 0;

    public bool winnerEffected;

    public int[] effectors;

    public string prompt;

    public float timeLimit;

    [Header("Vote")]
    public string[] VoteOptions;

    [Header("Majority, PlayerVote")]
    public int voteType;

    [Header("MultipleChoice")]
    public string[] MultipleChoiceOptions;
    public int correctAnswer;

    [Header("Text")]
    public string[] submisions;


}
