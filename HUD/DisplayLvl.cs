﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using Matcha.Game.Tweens;


public class DisplayLvl : BaseBehaviour
{
    private Text textComponent;
    private int intToDisplay;
    private string legend = "Lvl: ";

    void FadeInText()
    {
        // fade to zero instantly, then fade up slowly
        MTween.Fade(textComponent, 0, 0, 0);
        MTween.Fade(textComponent, 1, HUD_FADE_IN_AFTER, HUD_INITIAL_TIME_TO_FADE);
    }

    void OnInitInteger(int initInt)
    {
        textComponent = gameObject.GetComponent<Text>();
        textComponent.text = legend + initInt.ToString();
        textComponent.DOKill();
        FadeInText();
    }

    void OnChangeInteger(int newInt)
    {
        textComponent.text = legend + newInt.ToString();

        // MTween.DisplayScore(gameObject, textComponent);
    }

    void OnFadeHud(bool status)
    {
        MTween.Fade(textComponent, 0, HUD_FADE_OUT_AFTER, HUD_INITIAL_TIME_TO_FADE);
    }

    void OnEnable()
    {
        Messenger.AddListener<int>("init lvl", OnInitInteger);
        // Messenger.AddListener<int>("change score", OnChangeInteger);
        Messenger.AddListener<bool>("fade hud", OnFadeHud);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener<int>("init lvl", OnInitInteger);
        // Messenger.RemoveListener<int>("change score", OnChangeInteger);
        Messenger.RemoveListener<bool>("fade hud", OnFadeHud);
    }
}