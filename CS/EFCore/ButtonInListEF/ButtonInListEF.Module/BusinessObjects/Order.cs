using System;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;

namespace WinSolution.Module {
    [DefaultClassOptions]
    public class Order : BaseObject, ISimpleBusinessAction {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Active { get; set; }
        [Action]
        public void SimpleBusinessAction() {
            Active = !Active;
        }
    }
    public interface ISimpleBusinessAction {
        bool Active { get; }
        void SimpleBusinessAction();
    }
}