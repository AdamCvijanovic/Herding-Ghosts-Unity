using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Scriptable Objects/CutSceneDialogues")]
public class CutSceneDialogue:ScriptableObject
{
    public string playerName;
    public string customerName;
    //[TextArea(3, 10)]
    public Sentence[] sentences;
}
