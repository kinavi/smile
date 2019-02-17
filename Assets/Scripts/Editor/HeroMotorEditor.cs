using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(PlayerEngineController))]
[CanEditMultipleObjects]
public class HeroMotorEditor : Editor
{
    PlayerEngineController PECobj;
    //public int Speed;
    //private int minSpeed = 0;
    //private int maxSpeed = 10;

    private void OnEnable()
    {
        PECobj = (PlayerEngineController)target;
    }

    public override void OnInspectorGUI()
    {
        PECobj.Speed = EditorGUILayout.IntSlider("Скорость передвижения", PECobj.Speed, 0, 10);
        //PECobj.Speed = EditorGUILayout.FloatField("Скорость передвижения", PECobj.Speed);
        //base.OnInspectorGUI();
    }

    
    public static void SetDirty(GameObject target)
    {
        EditorUtility.SetDirty(target);
        EditorSceneManager.MarkSceneDirty(target.scene);
    }
}
