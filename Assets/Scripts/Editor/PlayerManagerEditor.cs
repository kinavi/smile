using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(PlayerManager))]
[CanEditMultipleObjects]
public class PlayerManagerEditor : Editor
{
    PlayerManager targetScript;

    private void OnEnable()
    {
        targetScript = (PlayerManager)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical("box");
        targetScript.maxHealth = EditorGUILayout.FloatField("Максимальное здоровье", targetScript.maxHealth);
        targetScript.curHealth = Mathf.Round(GUILayout.HorizontalSlider(targetScript.curHealth, 0, targetScript.maxHealth));

        ProgressBar(targetScript.curHealth / targetScript.maxHealth, "Зоровье: " + targetScript.curHealth);
        EditorGUILayout.EndVertical();

        targetScript.DamagePoint = EditorGUILayout.FloatField("Очки урона", targetScript.DamagePoint);
        targetScript.HealthBar = (BarUI)EditorGUILayout.ObjectField("Объект шкалы здоровья", targetScript.HealthBar,typeof(BarUI), false);
        targetScript.ForcePush = EditorGUILayout.FloatField("Сила толчка", targetScript.ForcePush);
        //targetScript.BushTime = EditorGUILayout.FloatField("Время баша", targetScript.BushTime);

        if (GUI.changed && !EditorApplication.isPlaying)
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
