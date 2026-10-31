using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class Dialouge : MonoBehaviour
{


    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI textComponent2;
    public string[] lines;
    public float textSpeed;
    public GameObject Portrait;
    public string npcName;
    public GameObject replacement;

    private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //  Portrait = GetComponent<Sprite>();
        textComponent2.text = npcName;
        textComponent.text = string.Empty;
        replacement = Portrait;
        StartDialouge();
    }

    // Update is called once per frame
    //In the update pressing Z ttransitions the text. The GetMouseDown dosen't do anything because it's commented.
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialouge()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
          
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
