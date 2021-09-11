using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Animator animator;
   
    public Text dialogueText;
    public Text nameText;
    private int speaker = 0;
    public string char1;
    public string char2;

    void Start()
    {
        sentences = new Queue<string>();

        
    }

    public void StartDialogue (Dialogue dialogue)
    {
        char1 = dialogue.name;
        char2 = dialogue.name2;
        animator.SetBool("IsOpen", true);
        Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;
        sentences.Clear();
        
        

        

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();


    }

    public void DisplayNextSentence () {
        if (sentences.Count == 0 )
        {
            EndDialogue();
            return;
        }
        
        if (speaker == 0)
        {
            nameText.text = char1;
            speaker =1;
        }else{
            nameText.text = char2;
            speaker =0;
        }


        string sentence = sentences.Dequeue();
        Debug.Log("meme");

        Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    void EndDialogue(){
        Debug.Log("End of conversation");
        animator.SetBool("IsOpen", false);
    }

}
