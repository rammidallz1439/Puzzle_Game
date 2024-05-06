
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

namespace Game
{
    public class CharacterSelectionHandler
    {
        protected CharacterSelectionManager handler;

        #region handler methods
        protected void CharacterSelectionEventHandler(CharacterSelectionEvent e)
        {

            Slot _slot = handler.Slots.Find(x => x.isEmpty == false);
            GameObject objectToSpawn = MonoHelper.instance.InstantiateObject(e.selectedItem.gameObject, _slot.transform);
            objectToSpawn.transform.position = _slot.transform.position;
            objectToSpawn.transform.GetComponent<BoxCollider>().enabled = false;
            _slot.isEmpty = true;
            handler.SelectedObjects.Add(objectToSpawn);
            MonoHelper.instance.DestroyObject(e.selectedItem.gameObject);

        }
        protected void MatchSelectionEventHandler(MatchSelectionEvent e)
        {
            MatchObjects(e.selectedItem);
        }
        #endregion

        #region methods
        void MatchObjects(Item obj)
        {
        
            if (handler.SelectedObjects.Count > 2)
            {

                MonoHelper.instance.RunCouroutine(RemoveItems(obj));
            }
        }

        IEnumerator RemoveItems(Item obj)
        {
          
            for (int i = 0; i < handler.SelectedObjects.Count; i++)
            {
                List<GameObject> templist = handler.SelectedObjects.FindAll(x => x.transform.GetComponent<Item>().Type
                == obj.transform.GetComponent<Item>().Type);
                if (templist.Count == 3)
                {
                    handler.SelectedObjects.Clear();
                    yield return new WaitForSeconds(0.1f);
                    foreach (GameObject temp in templist)
                    {
                      
                        MonoHelper.instance.DestroyObject(temp);

                    }
                    templist.Clear();
                }

            }
            for (int j = 0; j < handler.Slots.Count; j++)
            {
                if (handler.Slots[j].transform.childCount == 1)
                {
                    handler.Slots[j].isEmpty = false;
                }

            }
        }

        #endregion

    }
}

