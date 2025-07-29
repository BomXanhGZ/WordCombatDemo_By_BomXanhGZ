
using UnityEngine;

namespace GameUtility
{
    static public class Utility
    {
        static public bool CheckIsNotNull<T>(T _obj, string _info) where T : Object
        {
            string object_info = _info;
            bool is_not_null = true;
            
            if(_obj == null)
            {
                Debug.LogWarning("NUll At: " + object_info);
                is_not_null = false;
            }

            return is_not_null;
        }
    }
}
