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
                InstantiateObjects(manager.LevelDataConfig.LevelLayoutData[manager.CurrentLevel].Position);
            }
            catch (Exception ex)
            {
                Debug.LogError("Error creating level structure: " + ex.Message);
            }
        }
        #endregion

        #region methods
        void InstantiateObjects(List<List<int>> positionData)
        {
            if (positionData == null)
            {
                Debug.LogWarning("Position data is null.");
                return;
            }

            int Xspacing = 1;
            int Yspacing = 1;
            Vector3 positionOffset = Vector3.zero;

            try
            {
                for (int y = 0; y < positionData.Count; y++)
                {
                    for (int x = 0; x < positionData[y].Count; x++)
                    {
                        if (positionData[y][x] == 1)
                        {
                            Vector3 position = new Vector3(x * Xspacing, y * Yspacing, 0f) + positionOffset;
                            MonoHelper.instance.InstantiateObject(manager.BoxPrefab, position, Quaternion.identity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Error instantiating objects: " + ex.Message);
            }
        }
        #endregion
    }
}
