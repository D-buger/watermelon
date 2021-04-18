using UnityEngine;

public class InputMouse
{
    private float mousePosX;

    private enum eMouseState
    {
        None,
        Drag,
        Up
    }
    private eMouseState state = eMouseState.None;

    public void Update()
    {
        state = Input.GetMouseButton(0) ? eMouseState.Drag : 
            state == eMouseState.Drag ? eMouseState.Up : eMouseState.None;

        mousePosX = state == eMouseState.Drag ?
            Camera.main.ScreenToWorldPoint(
                new Vector3( Input.mousePosition.x , 0 , 0)).x
                : mousePosX;

        if (state == eMouseState.Up)
            Act();
        
    }

    public void Act()
    {
        // TODO : ���콺 �巡�װ� ������ �� ���� Ȱ��ȭ
    }


}
