using System;

namespace RabbitMQCore
{
    /// <summary>
    ///  Autor : Orçun TEN
    /// </summary>
    /// <typeparam name="T">Sadece tek instance olarak oluşmasını istediğimiz türetilebilir obje</typeparam>
    public abstract class Singleton<T> where T : class, new()
    {
        private static T obj;

        public static T Instance
        {
            get
            {
                if (obj == null)
                {
                    obj = Activator.CreateInstance<T>();
                }

                return obj;
            }
        }
    }
}
