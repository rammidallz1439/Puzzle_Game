using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vault;

namespace Game
{
    public class LevelController : LevelHandler, IObserver
    {
        public void OnEnable()
        {
        }

        public void OnNotify()
        {
            manager = Object.FindObjectOfType<LevelManager>(); 
        }

        public void OnRelease()
        {
        }

        public void OnStart()
        {
        }

        public void RegisterListeners()
        {
            EventManager.Instance.AddListener<CreateLevelStructureEvent>(CreateLevelStructureHandler);
            EventManager.Instance.AddListener<SpawnItemEvent>(SpawnItemsHandler);
        }

        public void RemoveListeners()
        {
            EventManager.Instance.RemoveListener<CreateLevelStructureEvent>(CreateLevelStructureHandler);
            EventManager.Instance.RemoveListener<SpawnItemEvent>(SpawnItemsHandler);

        }
    }

}
