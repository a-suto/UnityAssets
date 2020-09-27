using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class GameObjectExtensions
{
    public static T GetOrAddComponent<T>(this GameObject self) where T : Component
    {
        return self.TryGetComponent<T>(out var component) ? component : self.AddComponent<T>();
    }

    public static void Destroy(this GameObject self)
    {
#if UNITY_EDITOR
        if (EditorApplication.isPlaying == false)
        {
            Object.DestroyImmediate(self);
        }
        else
#endif
        {
            Object.Destroy(self);
        }
    }
}
