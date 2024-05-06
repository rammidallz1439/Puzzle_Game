using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Vault;

namespace Game
{
    public class LevelHandler
    {
        protected LevelManager manager;

        #region Event methods
        protected void CreateLevelStructureHandler(CreateLevelStructureEvent e)
        {
            try
            {

                manager.LevelDataConfig = DataManager.Instance.LoadJsonData<LevelData>(GameConstants.jsonPath);
                InstantiateObjects(manager.LevelDataConfig.LevelLayoutData[manager.CurrentLevel].Placement,
                    manager.LevelDataConfig.LevelLayoutData[manager.CurrentLevel].XPositions);
            }
            catch (Exception ex)
            {
                Debug.LogError("Error creating level structure: " + ex.Message);
            }
        }

        protected void SpawnItemsHandler(SpawnItemEvent e)
        {
            SpawnItems();
        }

        protected void ClearBoxesEventHandler(ClearBoxesEvent e)
        {
            foreach (GameObject item in manager.SpawnedBoxes)
            {
                if(item.transform.childCount <= 2)
                {
                    item.SetActive(false);
                   
                }
            }
        }

        #endregion



        #region methods
       
        void InstantiateObjects(List<List<int>> PlacementData, List<List<float>> Xpositions)
        {
            if (PlacementData == null)
            {
                Debug.LogWarning("Position data is null.");
                return;
            }

            float Yspacing = 1.33f;
            Vector3 positionOffset = Vector3.zero;

            try
            {
                for (int y = 0; y < PlacementData.Count; y++)
                {

                    for (int x = 0; x < PlacementData[y].Count; x++)
                    {
                        if (PlacementData[y][x] == 1)
                        {
                           
                            float yPos = y * Yspacing;
                         
                            Vector3 position = new Vector3(Xpositions[y][x], yPos, 0) + positionOffset;

                            GameObject box = MonoHelper.instance.InstantiateObject(manager.BoxPrefab, position, Quaternion.Euler(180f, 180f, 180f));
                            manager.SpawnedBoxes.Add(box);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Error instantiating objects: " + ex.Message);
            }
        }

        int count = 0;
        void SpawnItems()
        {
            
            Box box = null;
            for (int j = 0; j < manager.SpawnedBoxes.Count; j++)
            {
                for (int i = 0; i < manager.LevelDataConfig.LevelLayoutData[manager.CurrentLevel].SpawnCount; i++)
                {
                    if(count <= manager.LevelDataConfig.LevelLayoutData[manager.CurrentLevel].Items.Count - 1)
                    {
                        GameObject obj = ChangeItemType(manager.LevelDataConfig.LevelLayoutData[manager.CurrentLevel].Items[count].Item,
                     manager.SpawnedBoxes[j].transform);
                        box = manager.SpawnedBoxes[j].transform.GetComponent<Box>();
                        box.SpawnedObjects.Add(obj.transform);
                        count++;
                    }
                 
                }
                PlaceSpawnableObjects(box.SpawnedObjects, box.SpawnPoints);
            }
        }

        GameObject ChangeItemType(ItemTypes type, Transform transform)
        {
            GameObject obj = null;
            switch (type)
            {
                case ItemTypes.Chicken:
                    obj = MonoHelper.instance.InstantiateObject(manager.SpawnableObjects[0].gameObject, transform);
                    break;
                case ItemTypes.Cat:
                    obj = MonoHelper.instance.InstantiateObject(manager.SpawnableObjects[1].gameObject, transform);
                    break;
                case ItemTypes.Penguine:
                    obj = MonoHelper.instance.InstantiateObject(manager.SpawnableObjects[2].gameObject, transform);
                    break;

            }
            return obj;

        }

        void PlaceSpawnableObjects(List<Transform> pos,List<Transform> spawnPoint)
        {
            if (manager.LevelDataConfig.LevelLayoutData[manager.CurrentLevel].SpawnCount == 1)
            {
                pos[0].position = spawnPoint[0].transform.position;

            }
            else if (manager.LevelDataConfig.LevelLayoutData[manager.CurrentLevel].SpawnCount == 2)
            {
                if (count <= manager.LevelDataConfig.LevelLayoutData[manager.CurrentLevel].Items.Count - 1)
                {
                    pos[0].position = spawnPoint[1].transform.position + new Vector3(0.3f, 0f, 0f);
                    pos[1].position = spawnPoint[2].transform.position + new Vector3(-0.3f, 0f, 0f);
                }
                
            }
            else if (manager.LevelDataConfig.LevelLayoutData[manager.CurrentLevel].SpawnCount == 3)
            {
                for (int i = 0; i < pos.Count; i++)
                {
                    pos[i].position = spawnPoint[i].transform.position;
                }

            }


        }
        #endregion
    }
}
