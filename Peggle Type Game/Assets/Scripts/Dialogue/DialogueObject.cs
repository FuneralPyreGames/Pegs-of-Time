using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class DialogueObject : ScriptableObject
{
    [Header("Dialogue")]
    [Space(5)]
    public string[] names;
    [TextArea(3, 10)]
    public string[] sentences;
    public string speakerName;
    [Header("Options")]
    [Space(5)]
    public int[] buttonsNeeded;
    public string button1TextIf1ButtonNeeded;
    public string button1TextIf2ButtonsNeeded;
    public string button2TextIf2ButtonsNeeded;
    public string button1TextIf3ButtonsNeeded;
    public string button2TextIf3ButtonsNeeded;
    public string button3TextIf3ButtonsNeeded;
}
