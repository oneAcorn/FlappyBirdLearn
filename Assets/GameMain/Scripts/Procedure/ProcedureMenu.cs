using GameFramework.Event;
using GameFramework.Fsm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityGameFramework.Runtime;

namespace FlappyBird
{
    class ProcedureMenu : ProcedureBase
    {
        public bool isStartGame { get; set; }
        private MenuForm mMenuForm;

        public override bool UseNativeDialog => true;

        protected override void OnEnter(IFsm<GameFramework.Procedure.IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            isStartGame = false;
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            GameEntry.UI.OpenUIForm(UIFormId.MenuForm, this);
        }

        protected override void OnUpdate(IFsm<GameFramework.Procedure.IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (isStartGame)
            {
                //切换到主场景
                procedureOwner.SetData<VarInt32>(Constant.ProcedureData.NextSceneId, GameEntry.Config.GetInt("Scene.Main"));
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }
        }

        protected override void OnLeave(IFsm<GameFramework.Procedure.IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            if (mMenuForm != null)
            {
                mMenuForm.Close(isShutdown);
                mMenuForm = null;
            }

            //取消订阅事件
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
            mMenuForm = (MenuForm)ne.UIForm.Logic;
        }

    }
}
