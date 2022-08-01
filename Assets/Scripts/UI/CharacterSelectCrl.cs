using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectCrl : MonoBehaviour
{
    public void LaunchGame()
    {
        SceneManager.LoadScene("map_dried+lake");
        Debug.Log("Play!");
    }
}
