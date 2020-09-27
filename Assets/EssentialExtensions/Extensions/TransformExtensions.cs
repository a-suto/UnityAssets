using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class TransformExtensions
{
    public static void DestroyAllChildren(this Transform self)
    {
#if UNITY_EDITOR
        if (EditorApplication.isPlaying == false)
        {
            while (0 < self.childCount)
            {
                GameObject.DestroyImmediate(self.GetChild(0).gameObject);
            }
        }
        else
#endif
        {
            foreach (Transform t in self)
            {
                GameObject.Destroy(t.gameObject);
            }
        }
    }
}
