/***********************************************
* auto-generated code from T4
* 
* ********************************************/

using Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ERPS.Models
{
    /// <summary>
    /// 枚举
    /// </summary>
    public enum ActionSign
    {
        [Description("创建")]
        Create,
        [Description("删除")]
        Delete,
        [Description("保存")]
        Update,
        [Description("查询")]
        Search,
        [Description("审核")]
        Review,
        [Description("反审核")]
        UnReview,
        [Description("废弃")]
        Abandon,
        [Description("恢复")]
        Recovery,
        [Description("查看")]
        LookOver
    }
}
