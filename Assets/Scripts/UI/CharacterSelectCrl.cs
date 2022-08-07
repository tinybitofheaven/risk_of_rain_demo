using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectCrl : MonoBehaviour
{
    [SerializeField] private string[] maps;

    public void LaunchGame()
    {
        SceneManager.LoadScene(maps[Random.Range(0,maps.Length)]);
        Debug.Log("Play!");
    }
}
