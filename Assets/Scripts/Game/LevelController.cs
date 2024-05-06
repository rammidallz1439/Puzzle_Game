using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vault;

namespace Game
{
    public class LevelController : LevelHandler, IObserver,ITickable
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
            EventManager.Instance.AddListener<ClearBoxesEvent>(ClearBoxesEventHandler);
        }

        public void RemoveListeners()
        {
            EventManager.Instance.RemoveListener<CreateLevelStructureEvent>(CreateLevelStructureHandler);
            EventManager.Instance.RemoveListener<SpawnItemEvent>(SpawnItemsHandler);
            EventManager.Instance.AddListener<ClearBoxesEvent>(ClearBoxesEventHandler);

        }

        public void Tick()
        {
            EventManager.Instance.TriggerEvent(new ClearBoxesEvent());
            if (Input.GetMouseButtonDown(0))
            {
               
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    
                    if (hit.collider.gameObject.CompareTag("Item"))
                    {
                        EventManager.Instance.TriggerEvent(new CharacterSelectionEvent(hit.collider.gameObject.transform.GetComponent<Item>()));
                        EventManager.Instance.TriggerEvent(new MatchSelectionEvent(hit.collider.gameObject.transform.GetComponent<Item>()));
                    }
                }
            }
        }
    }

}
