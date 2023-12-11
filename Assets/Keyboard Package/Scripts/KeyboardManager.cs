using UnityEngine;
using TMPro;

public class KeyboardManager : MonoBehaviour
{
    public static KeyboardManager Instance;
    public TextMeshProUGUI textBox;
    public TextMeshProUGUI printBox;

    private void Start()
    {
        Instance = this;
        printBox.text = "";
        textBox.text = "";
    }

    public void DeleteLetter()
    {
        if(textBox.text.Length != 0) {
            textBox.text = textBox.text.Remove(textBox.text.Length - 1, 1);
        }
    }

    public void AddLetter(string letter)
    {
        textBox.text = textBox.text + letter;
        //Debug.Log(letter);
    }

    public void SubmitWord()
    {
        printBox.text = textBox.text;
        textBox.text = "";
        // Debug.Log("Text submitted successfully!");
    }
}
