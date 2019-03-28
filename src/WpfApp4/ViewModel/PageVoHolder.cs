using System;
using System.Collections.Generic;

namespace WpfApp4.ViewModel
{
    public class CefViewVoHolder
    {
        public CefViewVoHolder()
        {
            CefViewVos = new Dictionary<string, ICefViewVo>(StringComparer.OrdinalIgnoreCase);
        }

        public Dictionary<string, ICefViewVo> CefViewVos { get; set; }
        
        #region Singleton

        public static CefViewVoHolder Instance = new CefViewVoHolder();

        #endregion
    }
}
