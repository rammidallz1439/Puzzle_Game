using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vault;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
       
        private void Start()
        {
            EventManager.Instance.TriggerEvent(new CreateLevelStructureEvent());  
            EventManager.Instance.TriggerEvent(new SpawnItemEvent());  
        }


       
    }
}

