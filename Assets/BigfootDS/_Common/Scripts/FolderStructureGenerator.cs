using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class FolderStructureGenerator : MonoBehaviour {

    // There is no perfect Project folder structure and this is not an immutable structure.
    // Each game project will end up being laid out differently - this is just a starting point.
    static string[] foldersToGenerate = new string[] { "__Sandbox", "_Demo", "_ImportedAssets", "Animations", "Audio", "Fonts", "Materials", "Models", "Prefabs", "Plugins" ,"ScriptableObjects", "Scripts", "Shaders", "Sprites", "Textures", "Audio/SFX", "Audio/Music", "Scripts/Editor", "Plugins/iOS", "Plugins/Android" };

    [MenuItem("BigfootDS/Quick Generate Folders in Project")]
	public static void GenerateBasicFolderStructure ()
    {
        Debug.Log("Starting the basic project folder structure generator.");
        for (int i = 0; i < foldersToGenerate.Length; i++)
        {
            // The "CreateDirectory" function automatically does nothing if the filepath is invalid or already used.
            // So no if statements or crazy validation checking needed - we can just run the function!
            Directory.CreateDirectory("Assets/" + foldersToGenerate[i]);
        }
        // Forcing an asset database refresh means we will see these new folders in our Project tab instantly.
        AssetDatabase.Refresh();
        Debug.Log("Finished generating a basic project folder structure.");
    }



}


public class FolderStructureWizard : ScriptableWizard {
    // Using a ScriptableWizard creates a pop-up Unity tab, allowing us to customize the functions we call before we run them.
    // Read more about it here: https://docs.unity3d.com/ScriptReference/ScriptableWizard.html

    public string[] customFoldersToGenerate = new string[] { "__Sandbox", "_Demo", "_ImportedAssets", "Animations", "Audio", "Fonts", "Materials", "Models", "Prefabs", "Plugins", "ScriptableObjects", "Scripts", "Shaders", "Sprites", "Textures", "Audio/SFX", "Audio/Music", "Scripts/Editor", "Plugins/iOS", "Plugins/Android" };

    [MenuItem("BigfootDS/Custom Generate Folders in Project")]
    static void CreateFolderStructureWizard()
    {
        ScriptableWizard.DisplayWizard<FolderStructureWizard>("Folder Structure Wizard", "Create Folders", "Reset Options");
        
    }



    void OnWizardUpdate()
    {
        helpString = "Please set the folders that you would like to generate!";
        // helpString is automatically picked up by the ScriptableWizard type.
    }

    // When the user presses the "Create" button OnWizardCreate is called.
    // Think of it as the primary button of the wizard.
    void OnWizardCreate()
    {
        Debug.Log("Starting the custom project folder structure generator via the wizard.");
        for (int i = 0; i < customFoldersToGenerate.Length; i++)
        {
            // The "CreateDirectory" function automatically does nothing if the filepath is invalid or already used.
            // So no if statements or crazy validation checking needed - we can just run the function!
            Directory.CreateDirectory("Assets/" + customFoldersToGenerate[i]);
        }

        // Forcing an asset database refresh means we will see these new folders in our Project tab instantly.
        AssetDatabase.Refresh();
        Debug.Log("Finished generating a custom project folder structure via the wizard.");
    }

    // When the user presses the "Apply" button OnWizardOtherButton is called.
    // Think of it as the secondary button of the wizard.
    void OnWizardOtherButton()
    {
        customFoldersToGenerate = new string[] { "_Demo", "_ImportedAssets", "Animations", "Audio", "Fonts", "Materials", "Models", "Prefabs", "ScriptableObjects", "Scripts", "Shaders", "Sprites", "Textures", "Audio/SFX", "Audio/Music", "Scripts/Editor" };
    }
}
