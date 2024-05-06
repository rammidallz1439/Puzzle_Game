using System;
using System.Collections.Generic;
using UnityEngine;
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


        #endregion



        #region methods
        //Instantiate Boxes From the data
        void InstantiateObjects(List<List<int>> PlacementData, List<List<float>> Xpositions)
        {
            if (PlacementData == null)
            {
                Debug.LogWarning("Position data is null.");
                return;
            }

            float Yspacing = 1.33f; //  vertical spacing between rows 
            Vector3 positionOffset = Vector3.zero;

            try
            {
                for (int y = 0; y < PlacementData.Count; y++)
                {

                    for (int x = 0; x < PlacementData[y].Count; x++)
                    {
                        if (PlacementData[y][x] == 1)
                        {
                            // Calculate y position based on row index
                            float yPos = y * Yspacing;
                            // Create position of Object
                            Vector3 position = new Vector3(Xpositions[y][x], yPos, 0) + positionOffset;

                            // Instantiate the prefab at the calculated position
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


        void SpawnItems()
        {
            int count = 0;
            for (int j = 0; j < manager.SpawnedBoxes.Count; j++)
            {
                for (int i = 0; i < manager.LevelDataConfig.LevelLayoutData[manager.CurrentLevel].SpawnCount; i++)
                {
                    
                    GameObject obj = ChangeItemType(manager.LevelDataConfig.LevelLayoutData[manager.CurrentLevel].Items[count].Item,
                        manager.SpawnedBoxes[j].transform);
                    obj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    obj.transform.rotation = Quaternion.Euler(0,180,0);
                    count++;
                }
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

        #endregion
    }
}
