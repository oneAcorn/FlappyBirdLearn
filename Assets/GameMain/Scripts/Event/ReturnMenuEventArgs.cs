using GameFramework.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    /// <summary>
    /// 返回菜单场景
    /// </summary>
    public class ReturnMenuEventArgs:GameEventArgs
    {
        public static readonly int EventId = typeof(ReturnMenuEventArgs).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public override void Clear()
        {

        }
    }
}
