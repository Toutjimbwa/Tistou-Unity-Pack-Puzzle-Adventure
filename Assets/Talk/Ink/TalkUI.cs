using UnityEngine;
using UnityEngine.UI;
using System;
using Ink.Runtime;

public class TalkUI : MonoBehaviour
{
    [SerializeField] private Canvas textCanvas = null;
    [SerializeField] private Canvas buttonCanvas = null;
    [SerializeField] private Text textPrefab = null;
    [SerializeField] private Button buttonPrefab = null;
    [SerializeField] private GameObject background = null;
    private void Start()
    {
        Background(false);
        ClearCanvas();
    }
    public void CreateContentView(string text)
    {
        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = text;
        storyText.transform.SetParent(textCanvas.transform, false);
    }
    public Button CreateChoiceView(string text)
    {
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(buttonCanvas.transform, false);

        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;

        return choice;
    }
    public void ClearCanvas()
    {
        RemoveChildren(textCanvas);
        RemoveChildren(buttonCanvas);
    }
    void RemoveChildren(Canvas c)
    {
        int childCount = c.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(c.transform.GetChild(i).gameObject);
        }
    }
    public void Background(bool b)
    {
        background.SetActive(b);
    }
}
