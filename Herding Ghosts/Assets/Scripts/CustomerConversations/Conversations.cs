using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Conversation")]

public class Conversations : ScriptableObject
{
    public string playerName;
    public string customerName;
    [TextArea(3, 10)]
    public string[] convSentences;
}