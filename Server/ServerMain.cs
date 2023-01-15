using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;


namespace testcs.Server
{
    public class ServerMain : BaseScript
    {
        private Dictionary<string, Dictionary<string, dynamic>> m_data = new Dictionary<string, Dictionary<string, dynamic>>();

        public ServerMain()
        {
            Debug.WriteLine("Hi from testcs.Server!");
            m_data.Add("seggem", new Dictionary<string, dynamic>());
            m_data["seggem"].Add("curvy", "hol gurlfrnd?");

            EventHandlers["to_test:TriggerTest"] += new Action<Player>(TargetFunction);
            
            // Create a function to handle the event somewhere else in your code, or use a lambda.
            void TargetFunction(Player src)
            {
                TriggerClientEvent("to_test:Sync", m_data);
            }
        }
        
    }
}