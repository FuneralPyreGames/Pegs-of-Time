using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI firstButtonText;
    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<int> buttons;
    public GameObject firstButton;
    public GameObject secondButton;
    public GameObject thirdButton;
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        buttons = new Queue<int>();
    }
    public void StartDialogue(DialogueObject dialogue)
    {
        sentences.Clear();
        names.Clear();
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
            case 1:
                firstButton.SetActive(true);
                secondButton.SetActive(false);
                thirdButton.SetActive(false);
                firstButtonText.text = "Continue";
                break;
            case 2:
                firstButton.SetActive(true);
                secondButton.SetActive(true);
                thirdButton.SetActive(false);
                break;
            case 3:
                firstButton.SetActive(true);
                firstButton.SetActive(true);
                firstButton.SetActive(true);
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
        dialogueText.text = "Default Dialogue";
        nameText.text = "Default Name";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
