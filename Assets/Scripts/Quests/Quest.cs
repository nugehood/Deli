using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Quest
{
    public string title;
    public string description;
    public itemData unlockItem;

    public QuestGoal goal;
    
}
