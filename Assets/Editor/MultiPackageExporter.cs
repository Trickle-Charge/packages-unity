using System.IO;
using UnityEditor;
using UnityEngine;

public static class MultiPackageExporter
{
    public static void ExportAllPackages()
    {
        string packagesRoot = "Packages";
        string outputDir = "build";

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        string[] packagePaths = Directory.GetDirectories(packagesRoot);

        foreach (string path in packagePaths)
        {
            string pkgName = Path.GetFileName(path);

            if (pkgName.StartsWith("_") || 
                pkgName.StartsWith(".") || 
                pkgName.StartsWith("com.unity.modules"))
            {
                continue;
            }

            if (!pkgName.StartsWith("com.tricklecharge"))
            {
                continue;
            }

            // Because 'Packages' is at the root, AssetDatabase perfectly understands this path
            string assetPath = $"Packages/{pkgName}";
            string outputPath = Path.Combine(outputDir, $"{pkgName}.unitypackage");

            Debug.Log($"[Exporter] Exporting {pkgName} to {outputPath}...");

            AssetDatabase.ExportPackage(
                assetPath,
                outputPath,
                ExportPackageOptions.Recurse | ExportPackageOptions.IncludeDependencies
            );
        }

        Debug.Log("[Exporter] Batch processing complete!");
    }
}