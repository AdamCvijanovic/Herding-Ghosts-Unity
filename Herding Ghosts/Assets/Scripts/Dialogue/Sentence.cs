using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Sentence
{
    public string playerName;
    public string customerName;

    public Image customerImage;
    public Image playerImage;
    public Image background;

    public enum Speaker {Player, Customer}
    public Speaker currentSpeaker;

    [TextArea(3, 10)]
    public string sentenceText;
}
