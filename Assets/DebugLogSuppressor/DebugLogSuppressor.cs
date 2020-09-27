#if !UNITY_EDITOR && !DEVELOPMENT_BUILD
using System;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityDebug = UnityEngine.Debug;

[DefaultExecutionOrder(-99999)]
public static class Debug
{
    private const string NeverDefinedSymbol = "______";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize()
    {
        var logger = (ILogger) typeof(UnityDebug).GetField("s_Logger", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
        logger.logHandler = new DummyLogHandler();
    }

    private class DummyLogHandler : ILogHandler
    {
        public void LogFormat(LogType logType, Object context, string format, params object[] args) {}
        public void LogException(Exception exception, Object context) {}
    }

    [Conditional(NeverDefinedSymbol)] public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0, bool depthTest = true) {}
    [Conditional(NeverDefinedSymbol)] public static void DrawLine(Vector3 start, Vector3 end) {}
    [Conditional(NeverDefinedSymbol)] public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration = 0, bool depthTest = true) {}
    [Conditional(NeverDefinedSymbol)] public static void DrawRay(Vector3 start, Vector3 dir) {}
    [Conditional(NeverDefinedSymbol)] public static void Break() {}
    [Conditional(NeverDefinedSymbol)] public static void DebugBreak() {}
    [Conditional(NeverDefinedSymbol)] public static void Log(object message) {}
    [Conditional(NeverDefinedSymbol)] public static void Log(object message, Object context) {}
    [Conditional(NeverDefinedSymbol)] public static void LogFormat(string format, params object[] args) {}
    [Conditional(NeverDefinedSymbol)] public static void LogFormat(Object context, string format, params object[] args) {}
    [Conditional(NeverDefinedSymbol)] public static void LogError(object message) {}
    [Conditional(NeverDefinedSymbol)] public static void LogError(object message, Object context) {}
    [Conditional(NeverDefinedSymbol)] public static void LogErrorFormat(string format, params object[] args) {}
    [Conditional(NeverDefinedSymbol)] public static void LogErrorFormat(Object context, string format, params object[] args) {}
    [Conditional(NeverDefinedSymbol)] public static void ClearDeveloperConsole() {}
    [Conditional(NeverDefinedSymbol)] public static void LogException(Exception exception) {}
    [Conditional(NeverDefinedSymbol)] public static void LogException(Exception exception, Object context) {}
    [Conditional(NeverDefinedSymbol)] public static void LogWarning(object message) {}
    [Conditional(NeverDefinedSymbol)] public static void LogWarning(object message, Object context) {}
    [Conditional(NeverDefinedSymbol)] public static void LogWarningFormat(string format, params object[] args) {}
    [Conditional(NeverDefinedSymbol)] public static void LogWarningFormat(Object context, string format, params object[] args) {}
    [Conditional(NeverDefinedSymbol)] public static void Assert(bool condition) {}
    [Conditional(NeverDefinedSymbol)] public static void Assert(bool condition, Object context) {}
    [Conditional(NeverDefinedSymbol)] public static void Assert(bool condition, object message) {}
    [Conditional(NeverDefinedSymbol)] public static void Assert(bool condition, string message) {}
    [Conditional(NeverDefinedSymbol)] public static void Assert(bool condition, object message, Object context) {}
    [Conditional(NeverDefinedSymbol)] public static void Assert(bool condition, string message, Object context) {}
    [Conditional(NeverDefinedSymbol)] public static void AssertFormat(bool condition, string format, params object[] args) {}
    [Conditional(NeverDefinedSymbol)] public static void AssertFormat(bool condition, Object context, string format, params object[] args) {}
    [Conditional(NeverDefinedSymbol)] public static void LogAssertion(object message) {}
    [Conditional(NeverDefinedSymbol)] public static void LogAssertion(object message, Object context) {}
    [Conditional(NeverDefinedSymbol)] public static void LogAssertionFormat(string format, params object[] args) {}
    [Conditional(NeverDefinedSymbol)] public static void LogAssertionFormat(Object context, string format, params object[] args) {}
    [Conditional(NeverDefinedSymbol)] public static void Assert(bool condition, string format, params object[] args) {}
}
#endif
