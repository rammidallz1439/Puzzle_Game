using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class LevelManager : MonoBehaviour
    {
        public GameObject BoxPrefab;

        public LevelData LevelDataConfig;
        public int CurrentLevel;
        public List<GameObject> SpawnableObjects;

        public List<GameObject> SpawnedBoxes = new List<GameObject>();
    }
}

