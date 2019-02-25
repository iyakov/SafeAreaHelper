using UnityEditor;
using UnityEngine;
using System;

/// <summary>
/// Creates a neat package for SafeAreaHelper plugins
/// </summary>
public static class ExportSafeAreaHelperPackage
{
    [MenuItem(">> Package Export Automation <</Export project as Package Now!")]
    private static void Export()
    {
        EditorUtility.DisplayProgressBar("Export package", "Collecting files...", 0.1f);

        try
        {
            EditorUtility.DisplayProgressBar($"Export package v{Application.version}...", "Exporting...", 0.3f);

            string[] includePaths = { "Assets/SafeAreaHelper" };
            string packageName = $"Builds/SafeAreaHelper.{Application.version}.unitypackage";

            AssetDatabase.ExportPackage(includePaths, packageName, ExportPackageOptions.IncludeDependencies | ExportPackageOptions.Recurse);
        }
        catch (Exception exception)
        {
            EditorUtility.DisplayDialog("Error creating a package!", exception.ToString(), "OK");
        }
        finally
        {
            EditorUtility.ClearProgressBar();
        }
    }
}