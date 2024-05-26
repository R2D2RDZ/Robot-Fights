using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusic : MonoBehaviour
{
    private void Awake(){
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");
        if(obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Update(){
        if(SceneManager.GetActiveScene().name == "Ring"){
            Destroy(this.gameObject);
        }
    }
}
