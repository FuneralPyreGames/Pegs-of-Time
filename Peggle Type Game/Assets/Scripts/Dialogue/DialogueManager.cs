using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //Dialogue manager variables
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;    
    public TextMeshProUGUI firstButtonText;
    public TextMeshProUGUI secondButtonText;
    public TextMeshProUGUI thirdButtonText;
    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<int> buttons;    
    public GameObject firstButton;
    public GameObject secondButton;
    public GameObject thirdButton;
    public GameObject Continue;
    public GameObject Car;
    public GameObject Blackout;
    private string button1TextIf1ButtonNeeded;
    private string button1TextIf2ButtonsNeeded;
    private string button2TextIf2ButtonsNeeded;
    private string button1TextIf3ButtonsNeeded;
    private string button2TextIf3ButtonsNeeded;
    private string button3TextIf3ButtonsNeeded;
    public int actionOnEnd;
    public DialogueObject nextDialogueObject;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        sentences = new Queue<string>();
        names = new Queue<string>();
        buttons = new Queue<int>();
    }
    public void StartDialogue(DialogueObject dialogue)
    {
        button1TextIf1ButtonNeeded = dialogue.button1TextIf1ButtonNeeded;
        button1TextIf2ButtonsNeeded = dialogue.button1TextIf2ButtonsNeeded;
        button2TextIf2ButtonsNeeded = dialogue.button2TextIf2ButtonsNeeded;
        button1TextIf3ButtonsNeeded = dialogue.button1TextIf3ButtonsNeeded;
        button2TextIf3ButtonsNeeded = dialogue.button2TextIf3ButtonsNeeded;
        button3TextIf3ButtonsNeeded = dialogue.button3TextIf3ButtonsNeeded;
        actionOnEnd = dialogue.actionOnEnd;
        nextDialogueObject = dialogue.nextDialogueObject;
        sentences.Clear();
        names.Clear();
        LeanTween.scale(gameObject, new Vector3 (1,1,1), 0.25f);
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }
        foreach (int button in dialogue.buttonsNeeded)
        {
            buttons.Enqueue(button);
        }
        DisplayNextSentence();
    }
    public void SetButtons(int numOfButtons)
    {
        switch(numOfButtons)
        {
            case 0:
                Continue.SetActive(true);
                firstButton.SetActive(false);
                secondButton.SetActive(false);
                thirdButton.SetActive(false);
                break;
            case 1:
                Continue.SetActive(false);
                firstButton.SetActive(true);
                secondButton.SetActive(false);
                thirdButton.SetActive(false);
                firstButtonText.text = button1TextIf1ButtonNeeded;
                break;
            case 2:
                Continue.SetActive(false);
                firstButton.SetActive(true);
                secondButton.SetActive(true);
                thirdButton.SetActive(false);
                firstButtonText.text = button1TextIf2ButtonsNeeded;
                secondButtonText.text = button2TextIf2ButtonsNeeded;
                break;
            case 3:
                Continue.SetActive(false);
                firstButton.SetActive(true);
                firstButton.SetActive(true);
                firstButton.SetActive(true);
                firstButtonText.text = button1TextIf3ButtonsNeeded;
                secondButtonText.text = button2TextIf3ButtonsNeeded;
                thirdButtonText.text = button3TextIf3ButtonsNeeded;
                break;
        }
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        int button = buttons.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        nameText.text = name;
        SetButtons(button);
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.010f);
        }
    }
    void EndDialogue()
    {
        if (actionOnEnd == 0){ //Completely end dialogue
            LeanTween.scale(gameObject, new Vector3 (0,0,0), 0.6f);
        }
        if (actionOnEnd == 1){ //Load next dialogue object
            StartDialogue(nextDialogueObject); 
        }
        if (actionOnEnd == 2){ //Load pachinko level

        }
        if (actionOnEnd == 3){ //Custom ending for scene 1
            Car = GameObject.Find("Car");
            Blackout = GameObject.Find("Blackout/Blackout Panel");
            LeanTween.scale(gameObject, new Vector3 (0,0,0), 0.6f);
            StartCoroutine(MoveCar());
        }
    }
    void SetDefaultDialogue(){
        dialogueText.text = "Default Dialogue";
        nameText.text = "Default Name";
    }
    IEnumerator MoveCar(){
        yield return new WaitForSeconds(.5f);
        LeanTween.moveX(Car, 6.05f, 1.5f);
        yield return new WaitForSeconds(.75f);
        LeanTween.scale(Blackout, new Vector3(1.2f,1.2f,1.2f), 0.375f);
    }
}
