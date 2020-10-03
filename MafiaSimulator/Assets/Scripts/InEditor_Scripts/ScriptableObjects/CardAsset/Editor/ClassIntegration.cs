using UnityEditor;
using UnityEngine;

public class ClassIntegration
{
    [MenuItem("Assets/Create/PlayerClass")]
    public static void CreateYourScriptableObject()
    {
        SOUnity.CreateAsset<PlayerClass>();
    }
}
