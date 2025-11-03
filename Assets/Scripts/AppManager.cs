using UnityEngine;

public class AppManager : Singleton<AppManager>
{

    //Quick and dirty quit for the .exe 

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
