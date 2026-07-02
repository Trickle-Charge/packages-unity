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

            // Skip template, hidden folders, or standard modules
            if (pkgName.StartsWith("_") || 
                pkgName.StartsWith(".") || 
                pkgName.StartsWith("com.unity.modules"))
            {
                Debug.Log($"[Exporter] Skipping excluded folder: {pkgName}");
                continue;
            }

            // Only process your custom scoped packages
            if (!pkgName.StartsWith("com.tricklecharge"))
            {
                continue;
            }

            string assetPath = $"Packages/{pkgName}";
            string outputPath = Path.Combine(outputDir, $"{pkgName}.unitypackage");

            Debug.Log($"[Exporter] Exporting {pkgName} from {assetPath} to {outputPath}...");

            AssetDatabase.ExportPackage(
                assetPath,
                outputPath,
                ExportPackageOptions.Recurse | ExportPackageOptions.IncludeDependencies
            );
        }

        Debug.Log("[Exporter] Batch processing complete!");
    }
}
