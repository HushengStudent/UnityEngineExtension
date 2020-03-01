/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2019/11/02 22:57:00
** desc:  单例模板;
*********************************************************************************/

namespace Framework
{
    public class Singleton<T> : SingletonBase where T : class, new()
    {
        private static T _singleton = null;
        private static readonly object _lock = new object();

        public static T singleton
        {
            get
            {
                if (null == _singleton)
                {
                    lock (_lock)
                    {
                        _singleton = new T(); //调用构造函数;

                        Singletoninterface singleton = _singleton as Singletoninterface;
                        if (singleton != null)
                        {
                            singleton.SingletoninterfaceOnInitialize();
                        }
                    }
                }
                return _singleton;
            }
        }

        /// 构造函数;
        protected Singleton()
        {
            if (null == _singleton)
            {
                LogHelper.Print("[Singleton]" + (typeof(T)).ToString() + " singleton instance created.");
            }
        }
    }
}
