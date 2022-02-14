using FlappyBird;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuForm : UGuiForm
{
    private ProcedureMenu m_ProcedureMenu;

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        m_ProcedureMenu = (ProcedureMenu)userData;
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        m_ProcedureMenu = null;
        base.OnClose(isShutdown, userData);
    }

    public void OnStartButtonClick()
    {
        m_ProcedureMenu.isStartGame = true;
    }

    public void OnSettingButtonClick()
    {
        GameEntry.UI.OpenUIForm(UIFormId.SettingForm);
    }
}
