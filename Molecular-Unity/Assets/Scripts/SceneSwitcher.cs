using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {
    // Work in progress
    // TODO: Unsure if Unity cleans up assets when SceneManager.LoadScene is called

    // This class will hold the scenes we need to switch to and from
    public void MoleculeView()
    {
        Debug.Log("Switch to Molecule View");
        SceneManager.LoadScene(1);
    }

    // Quit the application.
    public void Quit()
    {
        Debug.Log("has quit game");
        Application.Quit();
    }
}
