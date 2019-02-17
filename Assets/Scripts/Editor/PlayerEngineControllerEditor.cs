using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;

[CustomEditor(typeof(PlayerEngineController))]
[CanEditMultipleObjects]
public class PlayerEngineControllerEditor : Editor
{
    PlayerEngineController targetScript;//= (PlayerEngineController)target;

    private void OnEnable()
    {
        targetScript = (PlayerEngineController)target;
    }

    public override void OnInspectorGUI()
    {
        targetScript.Speed = Mathf.Round(GUILayout.HorizontalSlider(targetScript.Speed, 0, 10)); 
        ProgressBar(targetScript.Speed / 10f, "Скорость передвижения: "+ targetScript.Speed);

        targetScript.SpeedAttack = (float) Math.Round(GUILayout.HorizontalSlider(targetScript.SpeedAttack, 0.1f, 3f), 1);
        ProgressBar(targetScript.SpeedAttack / 3f, "Скорость атаки: "+ targetScript.SpeedAttack);

        targetScript.DistanceAttack= Mathf.Round(GUILayout.HorizontalSlider(targetScript.DistanceAttack, 0, 10));
        ProgressBar(targetScript.DistanceAttack / 10f, "Дистанция атаки: " + targetScript.DistanceAttack);

        
        if (GUI.changed&&!EditorApplication.isPlaying)
            SetObjectDirty(targetScript.gameObject);
    }

    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }

    public static void SetObjectDirty(GameObject target)
    {
        EditorUtility.SetDirty(target);
        EditorSceneManager.MarkSceneDirty(target.scene);
        PrefabUtility.ApplyPrefabInstance(target, InteractionMode.AutomatedAction);
    }
}
