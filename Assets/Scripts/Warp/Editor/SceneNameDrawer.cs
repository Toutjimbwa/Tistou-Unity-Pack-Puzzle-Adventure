using System;
using UnityEditor;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        [CustomPropertyDrawer(typeof(SceneNameAttribute))]
        public class SceneNameDrawer : UnityEditor.PropertyDrawer
        {
            private int _sceneIndex = -1;
            private GUIContent[] _sceneNames;
            private readonly string[] _scenePathSplitters = { "/", ".unity" };

            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                if (EditorBuildSettings.scenes.Length == 0)
                {
                    EditorGUI.LabelField(position, label.text, "No scenes in File/Build settings");
                    return;
                }
                if (_sceneIndex == -1)
                    Setup(property);

                int oldIndex = _sceneIndex;
                _sceneIndex = EditorGUI.Popup(position, label, _sceneIndex, _sceneNames);
                if (oldIndex != _sceneIndex)
                    property.stringValue = _sceneNames[_sceneIndex].text;
            }

            void Setup(SerializedProperty property)
            {

                EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
                _sceneNames = new GUIContent[scenes.Length];

                for (int i = 0; i < _sceneNames.Length; i++)
                {
                    string path = scenes[i].path;
                    string[] splitPath = path.Split(_scenePathSplitters, StringSplitOptions.RemoveEmptyEntries);
                    _sceneNames[i] = new GUIContent(splitPath[splitPath.Length - 1]);
                }

                if (!string.IsNullOrEmpty(property.stringValue))
                {
                    bool sceneNameFound = false;
                    for (int i = 0; i < _sceneNames.Length; i++)
                    {
                        if (_sceneNames[i].text == property.stringValue)
                        {
                            _sceneIndex = i;
                            sceneNameFound = true;
                            break;
                        }
                    }
                    if (!sceneNameFound)
                        _sceneIndex = 0;
                }
                else _sceneIndex = 0;

                property.stringValue = _sceneNames[_sceneIndex].text;
            }
        }
    }
}