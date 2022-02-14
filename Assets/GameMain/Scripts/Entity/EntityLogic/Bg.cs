using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class Bg : Entity
    {
        private BgData mBgData;
        private bool isSpawn = false;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            mBgData = (BgData)userData;
            //修改开始位置
            CachedTransform.SetLocalPositionX(mBgData.StartPostion);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            //控制背景实体移动
            CachedTransform.Translate(Vector3.left * mBgData.MoveSpeed * elapseSeconds, Space.World);
            if (CachedTransform.position.x <= mBgData.SpawnTarget && isSpawn == false)
            {
                //显示背景实体
                GameEntry.Entity.ShowBg(new BgData(GameEntry.Entity.GenerateSerialId(), mBgData.TypeId, mBgData.MoveSpeed, 20.58f));
                isSpawn = true;
            }

            if (CachedTransform.position.x <= mBgData.HideTarget)
            {
                //隐藏实体
                GameEntry.Entity.HideEntity(this);
            }
        }
        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            isSpawn = false;
        }
    }
}