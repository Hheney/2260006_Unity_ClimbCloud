using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement; //씬을 전환하기 위한 씬매니저 임포트

public class ClearDirector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    
}
