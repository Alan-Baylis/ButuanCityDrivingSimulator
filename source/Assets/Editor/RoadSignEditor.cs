using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RoadSign)), CanEditMultipleObjects]
public class RoadSignEditor : Editor {
    public SerializedProperty signTypeProp, speedProp, 
        speedLimitAreaProp, noParkingAreaProp, modelsProp;

    void OnEnable() {
        signTypeProp = serializedObject.FindProperty("signType");
        speedProp = serializedObject.FindProperty("speed");
        speedLimitAreaProp = serializedObject.FindProperty("speedLimitArea");
        noParkingAreaProp = serializedObject.FindProperty("noParkingArea");
        modelsProp = serializedObject.FindProperty("models");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorGUILayout.PropertyField(signTypeProp);
        int index = signTypeProp.enumValueIndex;

        switch (index)
        {
            case 0: 
                EditorGUILayout.PropertyField(speedProp, new GUIContent("Speed"));
                EditorGUILayout.PropertyField(speedLimitAreaProp, new GUIContent("AOE"));
                break;
            case 1:
                EditorGUILayout.PropertyField(noParkingAreaProp, new GUIContent("AOE"));
                break;
            default:
                break;
        }

        EditorGUILayout.PropertyField(modelsProp, true);
        serializedObject.ApplyModifiedProperties();
    }
}
