using PlatformerGU.GenerateLevel;
using UnityEditor;
using UnityEngine;

namespace PlatformerGU.MyEditor
{
    [CustomEditor(typeof(GenerateLevelView))]
    public class GenerateLevelEditor : Editor
    {
        private GenerateLevelController _generateLevelController;

        private void OnEnable()
        {
            var generatroLevelView = (GenerateLevelView)target;
            _generateLevelController = new GenerateLevelController(generatroLevelView);
        }

        public override void OnInspectorGUI()
        {
            if (GUI.Button(new Rect(10, 0, 100, 50), "Generate"))
            {
                _generateLevelController.Awake();
            }

            GUILayout.Space(50);
        }
    }
}
