using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using HotelApi_.ManagerHotel;

namespace HotelApi_.Service
{
    public class ServiceLocator
    {
        private static Dictionary<Type, Type> mappedTypes;

        public ServiceLocator()
        {
            mappedTypes=new Dictionary<Type, Type>();
        }

        private static ServiceLocator instance;

        public static void Activate()
        {
            if(instance!=null)
                throw new ServiceActivatorException("Service already running! Close current running instance and try again!");
            instance = new ServiceLocator();
        }

        public static void Dispose()
        {
            if(instance==null)
                throw new ServiceActivatorException("Service in not activated!");
            instance = null;
        }

        public static void RegisterService(Type abstarctType, Type implementType)
        {
            KeyValuePair<Type,Type> service = new KeyValuePair<Type, Type>(abstarctType,implementType);
            mappedTypes.Add(abstarctType,implementType);
        }

        public static object GetService(Type abstarctType)
        {
            var methodOnstanceOf = mappedTypes[abstarctType].GetMethod("GetInstance");
            return methodOnstanceOf.Invoke(null,null);
        }


    }
}