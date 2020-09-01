using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carSpawn
{
    public class carSpawn : BaseScript
    {
        public carSpawn()
        {
            API.RegisterCommand("spawnlambonak", new Action<int, List<object>, string>(async(src, args, raw) =>
            {
                var car = new Model(VehicleHash.Zentorno);

               var ferari =  await World.CreateVehicle(car, Game.PlayerPed.GetOffsetPosition(new Vector3(0f,5f,1f)), Game.PlayerPed.Heading);
                ferari.NeedsToBeHotwired = false;
                

            }), false);
        }








        public static void SendMessage(string title, string message, int r, int g, int b)
        {
            var msg = new Dictionary<string, object>
            {
                ["color"] = new[] { r, g, b },
                ["args"] = new[] { title, message }
            };
            TriggerEvent("chat:addMessage", msg);
        }

    }
}





