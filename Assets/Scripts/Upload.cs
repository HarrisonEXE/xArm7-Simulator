using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleFileBrowser;

public class Upload : MonoBehaviour
{
	public static string destination;
	void Start()
	{
		FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png"), new FileBrowser.Filter("Text Files", ".txt", ".pdf"));
		FileBrowser.SetDefaultFilter(".csv");
		FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");
		FileBrowser.AddQuickLink("Users", "C:\\Users", null);
	}

	public void OnButtonClick()
    {
		StartCoroutine(ShowLoadDialogCoroutine());
	}

	IEnumerator ShowLoadDialogCoroutine()
	{

		yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.FilesAndFolders, true, null, null, "Load Files and Folders", "Load");

		//Debug.Log(FileBrowser.Success);

		if (FileBrowser.Success)
		{
		
			//for (int i = 0; i < FileBrowser.Result.Length; i++)
				//Debug.Log(FileBrowser.Result[i]);

		
			byte[] bytes = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result[0]);


			string destinationPath = Path.Combine(Application.persistentDataPath, FileBrowserHelpers.GetFilename(FileBrowser.Result[0]));
			//Debug.Log(Application.persistentDataPath);
			FileBrowserHelpers.CopyFile(FileBrowser.Result[0], destinationPath);
			CSVReader.ReadCSV(destinationPath);
		}
	}
}
