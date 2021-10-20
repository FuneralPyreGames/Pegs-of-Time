using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
[System.Serializable]
public class DialogueObject : ScriptableObject
{
    public string[] names;
    [TextArea(3, 10)]
    public string[] sentences;
    public string speakerName;
    public int[] buttonsNeeded;
    public string button1TextIf2ButtonsNeeded;
    public string button2TextIf2ButtonsNeeded;
    public string button1TextIf3ButtonsNeeded;
    public string button2TextIf3ButtonsNeeded;
    public string button3TextIf3ButtonsNeeded;
    public DialogueObject nextDialogueObject;
    public DialogueObject buttonOneDialogueObject;
    public DialogueObject buttonTwoDialogueObject;
    public DialogueObject buttonThreeDialogueObject;
    public string sceneToSwitchTo;
    public int actionOnEnd;
}
