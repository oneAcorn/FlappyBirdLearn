using GameFramework.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public class AddScoreEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(AddScoreEventArgs).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 加分数量
        /// </summary>
        public int AddCount { get; private set; }

        /// <summary>
        /// 填充事件
        /// </summary>
        public AddScoreEventArgs Fill(int addCount)
        {
            AddCount = addCount;

            return this;
        }

        public override void Clear()
        {
            AddCount = 0;
        }

    }
}
