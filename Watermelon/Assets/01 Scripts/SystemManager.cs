using UnityEngine;

public class SystemManager : MonoBehaviour
{
    InputMouse inputMouse;

    private void Awake()
    {
        inputMouse = new InputMouse();
    }

    private void Update()
    {
        inputMouse.Update();    
    }


}
