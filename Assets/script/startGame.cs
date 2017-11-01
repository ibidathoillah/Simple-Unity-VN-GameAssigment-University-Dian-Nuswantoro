using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class startGame : MonoBehaviour {

    public void moveScene(string namalevel)
    {
        SceneManager.LoadScene(namalevel);

    }
}

