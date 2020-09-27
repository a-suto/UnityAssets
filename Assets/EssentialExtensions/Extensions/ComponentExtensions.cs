using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class ComponentExtensions
{
    public static T AddComponent<T>(this Component self) where T : Component
    {
        return self.gameObject.AddComponent<T>();
    }

    public static T GetOrAddComponent<T>(this Component self) where T : Component
    {
        return self.gameObject.GetOrAddComponent<T>();
    }

    public static void Destroy(this Component self)
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
