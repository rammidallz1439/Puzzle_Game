using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomLevelEditor
{
    public class LayoutMaker
    {

        private int spacing = 1;


        /* void PrepareToggles(int Count , Toggle tog)
         {
             int[,] positions = new int[width, height];
             for (int y = 0; y < height; y++)
             {
                 for (int x = 0; x < width; x++)
                 {
                     positions[y, x] = 1;
                 }
             }

             for (int y = 0; y < height; y++)
             {
                 for (int x = 0; x < width; x++)
                 {
                     // If the array value is 1, instantiate an object
                     if (positions[y, x] == 1)
                     {
                         Vector3 position = new Vector3(x * spacing, 0f, y * spacing);
                         position[y,x] =GUILayout.Toggle(position[y,x],"");
                     }
                 }
             }
         }*/


       public void DrawLayoutSetting(int width, int height)
        {

            // Initialize the 2D array with sample values
            bool[,] toggleValues = new bool[height, width];

            // Iterate through the array to create toggles
            for (int y = 0; y < height; y++)
            {
                GUILayout.BeginHorizontal();
                for (int x = 0; x < width; x++)
                {
                    // Create a toggle with the value from the array
                    toggleValues[y, x] = GUILayout.Toggle(toggleValues[y * spacing, x * spacing], "");
                }
                GUILayout.EndHorizontal();
            }


        }

    }


}

