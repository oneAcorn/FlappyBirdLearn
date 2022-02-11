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
        public override bool UseNativeDialog => true;

        protected override void OnEnter(IFsm<GameFramework.Procedure.IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

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
    }
}
