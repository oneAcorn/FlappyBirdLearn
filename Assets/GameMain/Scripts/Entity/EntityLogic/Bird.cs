using GameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FlappyBird
{
    public class Bird : Entity
    {
        /// <summary>
        /// 小鸟实体数据
        /// </summary>
        private BirdData m_BirdData = null;

        /// <summary>
        /// 射击时间
        /// </summary>
        private float m_ShootTime = 2f;

        /// <summary>
        /// 射击计时器
        /// </summary>
        private float m_ShootTimer = 0f;

        private Rigidbody2D m_Rigidbody = null;
        private float ScreenWidth;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_BirdData = (BirdData)userData;
            //修改缩放
            CachedTransform.localScale = Vector2.one * 2;
            if (m_Rigidbody == null)
            {
                m_Rigidbody = GetComponent<Rigidbody2D>();
            }
            //重置射击冷却
            m_ShootTimer = 10f;
            ScreenWidth = Screen.width;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);


            //上升控制
            if (Input.GetKeyDown(KeyCode.Space) || IsTouchLeft())
            {
                GameEntry.Sound.PlaySound(2);
                m_Rigidbody.velocity = new Vector2(0, m_BirdData.FlyForce);
            }

            //射击控制
            m_ShootTimer += elapseSeconds;
            if (m_ShootTimer >= m_ShootTime && (Input.GetKeyDown(KeyCode.J) || IsTouchRight()))
            {
                m_ShootTimer = 0;
                GameEntry.Sound.PlaySound(3);
                GameEntry.Entity.ShowBullet(new BulletData(GameEntry.Entity.GenerateSerialId(), 4, CachedTransform.position + CachedTransform.right, 6));
            }
        }

        private bool IsTouchRight()
        {
            if (Input.touchCount == 1)
            {
                Touch t1 = Input.GetTouch(0);
                if (t1.phase == TouchPhase.Ended)
                {
                    if (t1.position.x < ScreenWidth / 2)
                    {
                        return true;
                    }
                }
            }
            else if (Input.touchCount == 2)
            {
                Touch t1 = Input.GetTouch(0);
                Touch t2 = Input.GetTouch(1);
                if (t1.phase == TouchPhase.Ended)
                {
                    if (t1.position.x < ScreenWidth / 2)
                    {
                        return true;
                    }
                }
                else if (t2.phase == TouchPhase.Ended)
                {
                    if (t1.position.x < ScreenWidth / 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsTouchLeft()
        {
            if (Input.touchCount == 1)
            {
                Touch t1 = Input.GetTouch(0);
                if (t1.phase == TouchPhase.Ended)
                {
                    if (t1.position.x > ScreenWidth / 2)
                    {
                        return true;
                    }
                }
            }
            else if (Input.touchCount == 2)
            {
                Touch t1 = Input.GetTouch(0);
                Touch t2 = Input.GetTouch(1);
                if (t1.phase == TouchPhase.Ended)
                {
                    if (t1.position.x > ScreenWidth / 2)
                    {
                        return true;
                    }
                }
                else if (t2.phase == TouchPhase.Ended)
                {
                    if (t1.position.x > ScreenWidth / 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameEntry.Sound.PlaySound(1);
            GameEntry.Entity.HideEntity(this);

            //派发小鸟死亡事件
            GameEntry.Event.Fire(this, ReferencePool.Acquire<BirdDeadEventArgs>());
        }

    }
}
