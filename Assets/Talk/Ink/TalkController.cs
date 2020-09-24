using UnityEngine;
using UnityEngine.UI;
using System;
using Ink.Runtime;

public class TalkController : MonoBehaviour
{
    public Story story;
    public TalkUI talkUI;
    public static event Action<Story> OnCreateStory;
    public RJItem giveItem;
    public TradeOnce trade;
    public bool triedTrade;
    public void StartTalk(Talk talk, RJItem item)
    {
        triedTrade = false;
        giveItem = item;
        talkUI.Background(true);
        trade = talk.transform.parent.GetComponentInChildren<TradeOnce>();
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
            CreateByeButton();
        }
        if (giveItem && !triedTrade)
        {
            Button b = talkUI.CreateChoiceView($"Give: {giveItem.name}");
            b.onClick.AddListener(delegate {
                OnClickGiveButton();
            });
        }
    }
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }
    void OnClickGiveButton()
    {
        if (trade)
        {
            if (trade.Trade(giveItem))
            {
                talkUI.ClearCanvas();
                talkUI.CreateContentView(trade.comment);
                CreateByeButton();

            }
            else
            {
                talkUI.ClearCanvas();
                talkUI.CreateContentView("No thanks");
                triedTrade = false;
                CreateByeButton();
            }
        }
    }

    void CreateByeButton()
    {
        Button button = talkUI.CreateChoiceView("Bye");
        button.onClick.AddListener(delegate {
            EndTalk();
        });
    }
}