using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vault;

namespace Game
{
    public class CharacterSelectionController : CharacterSelectionHandler,IObserver
    {
        public void OnEnable()
        {

        }

        public void OnNotify()
        {
            handler = Object.FindObjectOfType<CharacterSelectionManager>();
        }

        public void OnRelease()
        {
            
        }

        public void OnStart()
        {
           
        }

        public void RegisterListeners()
        {
            EventManager.Instance.AddListener<CharacterSelectionEvent>(CharacterSelectionEventHandler);
            EventManager.Instance.AddListener<MatchSelectionEvent>(MatchSelectionEventHandler);
        }

        public void RemoveListeners()
        {
            EventManager.Instance.RemoveListener<CharacterSelectionEvent>(CharacterSelectionEventHandler);
            EventManager.Instance.AddListener<MatchSelectionEvent>(MatchSelectionEventHandler);


        }


    }
}

