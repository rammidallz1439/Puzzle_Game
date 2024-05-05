using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CustomLevelEditor;
using UnityEngine.UIElements;

public class LevelEditor : EditorWindow
{
    [MenuItem("Tools/Level Designer")]
    static void OpenWindow()
    {
        LevelEditor window = (LevelEditor)GetWindow(typeof(LevelEditor));
        window.minSize = new Vector2(600, 400);
        window.Show();
    }

    Texture2D LevelTemplateHeader;
    Texture2D LevelLayoutArea;

    Color HeaderColors = new Color(13f / 225f, 32f / 255f, 44f / 225f, 1f);
    Color LayOutColors = Color.gray;

    Rect LevelTemplate;
    Rect LevelLayout;

    string width;
    string height;

    LayoutMaker LevelLayoutMaker;
    private void OnEnable()
    {
        InitTexture();
    }

    void InitTexture()
    {
        LevelTemplateHeader = new Texture2D(1, 1);
        LevelTemplateHeader.SetPixel(0, 0, HeaderColors);
        LevelTemplateHeader.Apply();

        LevelLayoutArea = new Texture2D(1, 1);
        LevelLayoutArea.SetPixel(0, 0, LayOutColors);
        LevelLayoutArea.Apply();

        LevelLayoutMaker = new LayoutMaker();
    }

    private void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        DrawLayoutSetting();
    }
    private void DrawLayouts()
    {
        LevelTemplate.x = 0;
        LevelTemplate.y = 0;
        LevelTemplate.width = Screen.width;
        LevelTemplate.height = 30;

        GUI.DrawTexture(LevelTemplate, LevelTemplateHeader);

        LevelLayout.x = 0;
        LevelLayout.y = 30;
        LevelLayout.width = Screen.width;
        LevelLayout.height = 400;

        GUI.DrawTexture(LevelLayout, LevelLayoutArea);
    }
    void DrawHeader()
    {
        GUILayout.BeginArea(LevelTemplate);

        GUILayout.Label("Level Template");
        GUILayout.EndArea();


    }

    void DrawLayoutSetting()
    {
        GUILayout.BeginArea(LevelLayout);

        width = GUILayout.TextField(width, 20);
        height = GUILayout.TextField(height,20);
        LevelLayoutMaker = new LayoutMaker();
        LevelLayoutMaker.DrawLayoutSetting(int.Parse(width),int.Parse(height));
        GUILayout.EndArea();
    }
}
