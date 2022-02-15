using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class PipeData : EntityData
    {
        /// <summary>
        /// 移动速度
        /// </summary>
        public float MoveSpeed { get; private set; }

        /// <summary>
        /// 上管道偏移
        /// </summary>
        public float OffsetUp { get; private set; }

        /// <summary>
        /// 下管道偏移
        /// </summary>
        public float OffsetDown { get; private set; }

        /// <summary>
        /// 到达此目标时隐藏自身
        /// </summary>
        public float HideTarget { get; private set; }

        public PipeData(int entityId, int typeId, float moveSpeed) : base(entityId, typeId)
        {
            MoveSpeed = moveSpeed;
            OffsetUp = Random.Range(5.66f, 8f);
            OffsetDown = Random.Range(-0.75f, -3.05f);
            HideTarget = -11f;
        }

    }
}