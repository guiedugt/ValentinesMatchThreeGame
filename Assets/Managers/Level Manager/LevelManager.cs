﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelManager : MonoBehaviour
{

  int currentLevel = 0;
  ScoreManager scoreManager;
  ShapesManager shapesManager;
  SoundManager soundManager;
  Text levelText;
  Timer timer;

  // Use this for initialization
  void Start()
  {
    levelText = GetComponentInChildren<Text>();
    levelText.text = "Lv. " + (currentLevel + 1).ToString("n0");
    scoreManager = FindObjectOfType<ScoreManager>();
    shapesManager = FindObjectOfType<ShapesManager>();
    soundManager = FindObjectOfType<SoundManager>();
    timer = FindObjectOfType<Timer>();
  }

  public int GetCurrentLevel()
  {
    return currentLevel;
  }

  public void LevelUpCheck()
  {
    try
    {
      if (scoreManager.GetScore() >= Constants.scoreNeededToLevel[currentLevel + 1])
      {
        timer.Reset();
        currentLevel++;
				levelText.text = "Lv. " + (currentLevel + 1).ToString("n0");
        shapesManager.Bonus();
        soundManager.PlayPowerUp();
      }
    }
    catch (IndexOutOfRangeException e)
    {
      Debug.LogWarning("Player already reached maximum level");
			Debug.LogWarning(e);
    }

  }

}