using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;



namespace testcs.Client
{
    public class ClientMain : BaseScript
    {
        private Dictionary<string, Dictionary<string, dynamic>> m_data = new Dictionary<string, Dictionary<string, dynamic>>();
        void ToMainStorage(dynamic obj)
        {
            IDictionary<string, object> dataStorage = obj;

            foreach (var firstKey in dataStorage.Keys)
            {
                IDictionary<string, object> secondDict = (IDictionary<string, object>)dataStorage[firstKey];
                foreach (var secondKey in secondDict.Keys)
                {
                    m_data.Add(firstKey, new Dictionary<string, dynamic>());
                    m_data[firstKey].Add(secondKey, secondDict[secondKey]);
                }
                
            } 
        }
        
        public ClientMain()
        {
            Debug.WriteLine("Hi from testcs.Client!");
            

            RegisterCommand("butt", new Action<int, List<object>, string>((source, args, raw) =>
            {
                TriggerServerEvent("to_test:TriggerTest");
                Debug.WriteLine("első lépés");
            }), false);
            
            EventHandlers["to_test:Sync"] += new Action<dynamic>(Sync);


            // Create a function to handle the event somewhere else in your code, or use a lambda.
            void Sync(dynamic asd)
            {
                ToMainStorage(asd);
                Debug.WriteLine(m_data["seggem"]["curvy"]);
            }

            
        }

        [Tick]
        public Task OnTick()
        {
            DrawRect(0.5f, 0.5f, 0.5f, 0.5f, 255, 255, 255, 150);

            return Task.FromResult(0);
        }
        
        
    }
}