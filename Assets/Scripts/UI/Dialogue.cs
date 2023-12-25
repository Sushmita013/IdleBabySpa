using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Dialogue : MonoBehaviour
{
    public TMP_Text textComponent;
    public string[] lines;
    public float speed;

    private int index;

    public Button GetCustomersButton;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        //StartDialogue();
        string name = "GameScene";
        GetCustomersButton.onClick.AddListener(() => SwitchScene(name));
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(Typeline());
    }

    IEnumerator Typeline()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c.ToString();
            yield return new WaitForSeconds(speed); 
        }
    }

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        GetComponent<RectTransform>().DOAnchorPosY(-1500, 0.1f); 
    }
}
