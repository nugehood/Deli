using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/CreateItem")]
public class itemData : ScriptableObject
{
    public string itemName;
    public string itemQuote;
    [TextArea(5, 2)]
    public string itemDesc;
    public float rarity;
    [Tooltip("Agility,range,ETC!")]
    public string itemType;
    public Color typeColor;
    public Sprite itemSprt;
    
}
