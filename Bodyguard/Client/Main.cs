using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Main : BaseScript
    {
        public Main()
        {
            API.RegisterCommand("test",new Action(TestCommand), false );
        }

        private async static void TestCommand()
        {
            Ped player = Game.Player.Character;
            API.RequestModel((uint)PedHash.ChemSec01SMM);
            while(!API.HasModelLoaded((uint)PedHash.ChemSec01SMM))
            {
                Debug.WriteLine("Waiting for model to load");
                await BaseScript.Delay(100);
            }
            Ped bguard = await World.CreatePed(PedHash.ChemSec01SMM,player.Position + (player.ForwardVector * 4));
            bguard.Task.LookAt(player);
            API.SetPedAsGroupMember(bguard.Handle, API.GetPedGroupIndex(player.Handle));
            API.SetPedCombatAbility(bguard.Handle, 1);
            SendMessage("[SERVER]", "Your bodyguard spawned!", 255, 0, 0);
            API.GiveWeaponToPed(bguard.Handle, (uint)WeaponHash.APPistol, 100, false, true);
            bguard.PlayAmbientSpeech("GENERIC_HI");

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
