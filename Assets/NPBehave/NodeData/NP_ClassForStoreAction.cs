﻿using System;
using MainCore;
using UnityEngine;

namespace NPBehave
{
    public class NP_ClassForStoreAction
    {
        /// <summary>
        /// 归属的UnitID
        /// </summary>
        public Unit BelongToUnit;

        /// <summary>
        /// 运行时归属的行为树
        /// </summary>
        public NP_RuntimeTree BelongRuntimeTree;

        public System.Action Action;

        public Func<bool> Func1;

        public Func<bool, NPBehave.Action.Result> Func2;


        /// <summary>
        /// 获取将要执行的委托函数
        /// </summary>
        /// <returns></returns>
        public virtual System.Action GetActionToBeDone()
        {
            return null;
        }

        public virtual Func<bool> GetFunc1ToBeDone()
        {
            return null;
        }

        public virtual Func<bool, Action.Result> GetFunc2ToBeDone()
        {
            return null;
        }
        
        public NPBehave.Action _CreateNPBehaveAction()
        {
            GetActionToBeDone();
            if (this.Action != null)
            {
                return new NPBehave.Action(this.Action);
            }

            GetFunc1ToBeDone();
            if (this.Func1 != null)
            {
                return new NPBehave.Action(this.Func1);
            }

            GetFunc2ToBeDone();
            if (this.Func2 != null)
            {
                return new NPBehave.Action(this.Func2);
            }

            Debug.LogError($"{this.GetType()} _CreateNPBehaveAction失败，因为没有找到可以绑定的委托");
            return null;
        }
    }
}