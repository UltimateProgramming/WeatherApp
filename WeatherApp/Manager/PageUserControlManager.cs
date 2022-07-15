using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WeatherApp.Manager
{
    public class PageUserControlManager
    {
        private Dictionary<string, UserControl> _userControlDictionary = new Dictionary<string, UserControl>();
        private static PageUserControlManager instance;

        public static PageUserControlManager Instance
        {
            get
            {
                if (instance is null)
                    instance = new PageUserControlManager();
                return instance;
            }
        }

        private PageUserControlManager() { }

        public void AddUserControlPage(UserControl page)
        {
            if (!_userControlDictionary.ContainsKey(nameof(page)))
                _userControlDictionary.Add(nameof(page), page);
        }

        public UserControl GetSpecificUserControl(string key)
        {
            UserControl userControl = null;
            _userControlDictionary.TryGetValue(key, out userControl);
            if (userControl == null)
                throw new ArgumentNullException(nameof(userControl));
            return userControl;
        }

        public void DeleteSpecificUserControlPage(string key)
        {
            _userControlDictionary.Remove(key);
        }

        public void ClearUserControlDict()
        {
            _userControlDictionary.Clear();
        }
        
    }
}
