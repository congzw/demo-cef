using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace WpfApp3
{
    public class PageHolder
    {
        public PageHolder()
        {
            Pages = new Dictionary<string, Page>(StringComparer.OrdinalIgnoreCase);
            Pages.Add("Main", new MainPage());
            Pages.Add("Child", new ChildPage());
            Current = "Main";
        }

        public string Current { get; set; }
        public Dictionary<string, Page> Pages { get; set; }

        public void Navigate(Frame frame, string name)
        {
            if (!Pages.ContainsKey(name))
            {
                return;
            }
            var thePage = Pages[name];
            frame.Navigate(thePage);
        }

        #region Singleton
        
        public static PageHolder Instance = new PageHolder();

        #endregion
    }
}
