//using System.Collections;
//using UnityEngine;

//public class CutsceneStarter : MonoBehaviour
//{
//    public TypewriterEffect typewriter;
//    public string[] dialogueLines;
//    public GameObject cutscenePanel;

//    private int currentLine = 0;

//    void Start()
//    {
//        StartCutscene();
//    }

//    public void StartCutscene()
//    {
//        cutscenePanel.SetActive(true);
//        ShowNextLine();
//    }

//    void ShowNextLine()
//    {
//        if (currentLine >= dialogueLines.Length)
//        {
//            // Катсцена закончилась
//            cutscenePanel.SetActive(false);
//            return;
//        }

//        typewriter.StartTyping(dialogueLines[currentLine]);
//        currentLine++;

//        // Показываем следующую строку через 2 секунды
//        Invoke("ShowNextLine", 2f);
//    }
//}//public TextMeshProUGUI textComponent;
//public float typingSpeed = 0.05f;
//public KeyCode skipKey = KeyCode.Space; // Нажмите пробел для пропуска

//private string fullText;
//private bool isTyping = false;

//void 
//{
//    if (isTyping && Input.GetKeyDown(skipKey))
//    {
//        StopAllCoroutines();
//        textComponent.text = fullText;
//        isTyping = false;
//    }
//}

//public void StartTyping(string newText)
//{
//    fullText = newText;
//    isTyping = true;
//    StartCoroutine(TypeText());
//}

//IEnumerator TypeText()
//{
//    textComponent.text = "";

//    for (int i = 0; i <= fullText.Length; i++)
//    {
//        if (!isTyping) yield break;
//        textComponent.text = fullText.Substring(0, i);
//        yield return new WaitForSeconds(typingSpeed);
//    }

//    isTyping = false;
//}