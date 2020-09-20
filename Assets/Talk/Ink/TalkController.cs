using UnityEngine;
using UnityEngine.UI;
using System;
using Ink.Runtime;

public class TalkController : MonoBehaviour
{
    
    public Story story;
    public TalkUI talkUI;
    public static event Action<Story> OnCreateStory;
    public void StartTalk(Talk talk)
    {
        talkUI.Background(true);
        story = new Story(talk.inkJSONAsset.text);
        if (OnCreateStory != null) OnCreateStory(story);
        RefreshView();
    }
    public void EndTalk()
    {
        talkUI.Background(false);
        talkUI.ClearCanvas();
        story = null;
    }
    void RefreshView()
    {
        talkUI.ClearCanvas();
        while (story.canContinue)
        {
            string text = story.Continue();
            text = text.Trim();
            talkUI.CreateContentView(text);
        }
        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = talkUI.CreateChoiceView(choice.text.Trim());
                button.onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
            }
        }
        else
        {
            Button button = talkUI.CreateChoiceView("Bye");
            button.onClick.AddListener(delegate {
                EndTalk();
            });
        }
    }
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }
}