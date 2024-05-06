
using UnityEngine;
using Vault;

public class AppEvents
{
  
}
public struct CreateLevelStructureEvent : GameEvent
{

}

public struct SpawnItemEvent : GameEvent
{

}

public struct CharacterSelectionEvent : GameEvent
{
    public Item selectedItem;

    public CharacterSelectionEvent(Item selectedItem)
    {
        this.selectedItem = selectedItem;
    }
}
public struct MatchSelectionEvent : GameEvent
{
    public Item selectedItem;

    public MatchSelectionEvent(Item selectedItem)
    {
        this.selectedItem = selectedItem;
    }
}
public struct ClearBoxesEvent:GameEvent
{

}