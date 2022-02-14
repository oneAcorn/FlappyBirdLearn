using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public class BirdData : EntityData
    {
        /// <summary>
        /// 飞行力度
        /// </summary>
        public float FlyForce { get; private set; }

        public BirdData(int entityId, int typeId, float flyForce) : base(entityId, typeId)
        {
            FlyForce = flyForce;
        }

    }
}
