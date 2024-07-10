/**********************************************
* Script Name: AI Npc.cs                      *
* Author ImaNewb Aka Delphi                   *
* For use with ModernUO                       *
* Date: June 19, 2024                         *
**********************************************/

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Server.Items;
using ModernUO.Serialization;
using Server.Spells.Seventh;

namespace Server.Mobiles
{
    [SerializationGenerator(0, false)]
    public partial class NpcAi : BaseVendor
    {
        private readonly List<SBInfo> m_SBInfos = new();
        private static readonly HttpClient HttpClient = new HttpClient();

        // Config : Set these before running or this will not pass to the AI
        private readonly string NpcRole = "a seasoned mage"; // Set the AI role to use in the prompt
        private readonly string NpcTitle = "the mage"; //
        private const string ChatGPTApiKey = "your_api_key_here"; // Replace with your actual OpenAI API key
        // End Config

        private readonly string NpcName;
        private readonly string BasePersonalityPrompt;

        [Constructible]
        public NpcAi()
        {
            Name = Female ? NameList.RandomName("female") : NameList.RandomName("male");
            NpcName = Name;
            SpeechHue = 75;
            Title = NpcTitle;

            BasePersonalityPrompt = $"You are {NpcRole} named {NpcName} in the game world of Ultima Online and an NPC in Britannia. You interact with the players and adventurers of this world always speaking in character and responding appropriately in your role. Use detailed description to make it immersive like a storyteller might but keep it short. Use the prefix 'Description:' for actions such as the man looks up from his book and 'Response:' for speech. Describe your character's actions when engaging with 'Description:' first and then respond to players' speech with 'Response:'. Doing both will enhance the experience. Stay in character and engage with the players as if you truly belong in Ultima Online. You are to roleplay every interaction and always use a description of the character's actions before giving a response. Use period-appropriate language to enhance the role-playing experience. Listen to the context of the conversation and only respond with relevant responses to that conversation. Your conversation should be fluid.";

            InitStats(100, 50, 100);
            SetSkill(SkillName.EvalInt, 900, 100.0);
            SetSkill(SkillName.Magery, 100.0, 100.0);
            SetSkill(SkillName.Meditation, 90.0, 100.0);
            SetSkill(SkillName.MagicResist, 65.0, 88.0);
            SetSkill(SkillName.Wrestling, 75.0, 90.0);
        }

        protected override List<SBInfo> SBInfos => m_SBInfos;

        public override NpcGuild NpcGuild => NpcGuild.MagesGuild;

        public override VendorShoeType ShoeType => Utility.RandomBool() ? VendorShoeType.Shoes : VendorShoeType.Sandals;

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBNpcAI());
        }

        public override void InitOutfit()
        {
            base.InitOutfit();
            AddItem(new Robe(Utility.RandomDyedHue()));
        }

        public class SBNpcAI : SBInfo
        {
            public override IShopSellInfo SellInfo { get; } = new InternalSellInfo();
            public override List<GenericBuyInfo> BuyInfo { get; } = new InternalBuyInfo();

            public class InternalBuyInfo : List<GenericBuyInfo>
            {
                public InternalBuyInfo()
                {
                    // Customize Your Buy Inventory
                    Add(new GenericBuyInfo(typeof(Ginseng), 3, 20, 0xF85, 0));
                    Add(new GenericBuyInfo(typeof(Garlic), 3, 20, 0xF84, 0));
                    Add(new GenericBuyInfo(typeof(MandrakeRoot), 3, 20, 0xF86, 0));
                    Add(new GenericBuyInfo(typeof(Nightshade), 3, 20, 0xF88, 0));
                    Add(new GenericBuyInfo(typeof(Bloodmoss), 5, 20, 0xF7B, 0));
                    Add(new GenericBuyInfo(typeof(MortarPestle), 8, 20, 0xE9B, 0));
                    Add(new GenericBuyInfo(typeof(Bottle), 5, 20, 0xF0E, 0));
                }
            }

            public class InternalSellInfo : GenericSellInfo
            {
                public InternalSellInfo()
                {
                    // Customize Your Sell Inventory
                    Add(typeof(Bloodmoss), 3);
                    Add(typeof(MandrakeRoot), 2);
                    Add(typeof(Garlic), 2);
                    Add(typeof(Ginseng), 2);
                    Add(typeof(Nightshade), 2);
                    Add(typeof(Bottle), 3);
                    Add(typeof(MortarPestle), 4);
                }
            }
        }

        private string GetNpcDataJson()
        {
            var npcData = new
            {
                NpcName,
                Role = NpcRole,
                Title = NpcTitle,
                Stats = new
                {
                    Str = RawStr,
                    Dex = RawDex,
                    Int = RawInt
                },
                Skills = new Dictionary<string, double>
                {
                    { "EvalInt", Skills[SkillName.EvalInt].Base },
                    { "Magery", Skills[SkillName.Magery].Base },
                    { "Meditation", Skills[SkillName.Meditation].Base },
                    { "MagicResist", Skills[SkillName.MagicResist].Base },
                    { "Wrestling", Skills[SkillName.Wrestling].Base }
                },
                Inventory = new List<string>(),
                Location = new
                {
                    Location.X,
                    Location.Y,
                    Location.Z,
                    Map = Map.Name,
                    Region = Region.Name
                }
            };

            foreach (var item in Items)
            {
                npcData.Inventory.Add(item.GetType().Name);
            }

            return JsonSerializer.Serialize(npcData);
        }

        public async Task<string> GetChatGPTResponse(string message, string playerName)
        {
            var npcDataJson = GetNpcDataJson();
            var prompt = BasePersonalityPrompt;

            var payload = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = prompt },
                    new { role = "system", content = $"NPC Data: {npcDataJson}" },
                    new { role = "user", content = $"Player {playerName} says: {message}" }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ChatGPTApiKey);

            var response = await HttpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseString = await response.Content.ReadAsStringAsync();

            var chatGPTResponse = JsonSerializer.Deserialize<ChatGPTResponse>(responseString);
            return chatGPTResponse.choices[0].message.content;
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            base.OnSpeech(e);

            Console.WriteLine($"Debug: OnSpeech triggered with speech = {e.Speech}");

            if (e.Mobile.InRange(this, 3) && !string.IsNullOrEmpty(e.Speech))
            {
                // Make the NPC face the player
                this.Direction = GetDirectionTo(e.Mobile);

                if (e.Speech.ToLower().Contains("cast gate travel to"))
                {
                    var town = e.Speech.ToLower().Replace("cast gate travel to ", "").Trim();
                    Console.WriteLine($"Debug: Detected command to cast gate travel to {town}");
                    CastGateTravel(town, e.Mobile);
                }
                else if (!string.IsNullOrEmpty(ChatGPTApiKey) && ChatGPTApiKey != "your_api_key_here")
                {
                    // Use ChatGPT API if the API key is set
                    Task.Run(async () =>
                    {
                        var response = await GetChatGPTResponse(e.Speech, e.Mobile.Name);
                        Console.WriteLine($"Debug: Received response from API = {response}");
                        ProcessResponse(response, e.Mobile);
                    });
                }
                else
                {
                    // Fallback behavior when API key is not set
                    var fallbackResponses = new[]
                    {
                        "Greetings, traveler. How may I assist thee?",
                        "Hello, adventurer. What dost thou seek?",
                        "Well met! What brings thee here today?"
                    };
                    Say(fallbackResponses[Utility.Random(fallbackResponses.Length)]);
                }
            }
        }

        private void ProcessResponse(string response, Mobile from)
        {
            Console.WriteLine($"Debug: Processing response = {response}");

            string[] lines = response.Split('\n');
            foreach (var line in lines)
            {
                if (line.StartsWith("Description:"))
                {
                    SendMessage(from, line.Replace("Description:", "").Trim(), 55); // Use hue 55 for descriptions
                }
                else if (line.StartsWith("Response:"))
                {
                    Say(line.Replace("Response:", "").Trim());
                }
            }
        }

        private void SendMessage(Mobile to, string message, int hue)
        {
            to.SendMessage(hue, message);
        }

        public override bool HandlesOnSpeech(Mobile from) => true;

        private void CastGateTravel(string town, Mobile from)
        {
            Point3D location = Point3D.Zero;
            Map map = this.Map; // Use the NPC's current map

            // Define location based on town name
            location = town.ToLower() switch
            {
                "britain"    => new Point3D(1496, 1628, 10),
                "yew"        => new Point3D(633, 858, 0),
                "minoc"      => new Point3D(2476, 413, 15),
                "moonglow"   => new Point3D(4408, 1168, 0),
                "trinsic"    => new Point3D(1845, 2745, 0),
                "magincia"   => new Point3D(3734, 2222, 20),
                "jhelom"     => new Point3D(1374, 3826, 0),
                "skara brae" => new Point3D(618, 2234, 0),
                "vesper"     => new Point3D(2771, 976, 0),
                "occlo"      => new Point3D(3667, 2625, 0),
                _            => location
            };

            if (location != Point3D.Zero)
            {
                Console.WriteLine("Debug: Location identified. Attempting to cast gate travel spell.");

                GateTravelSpell spell = new GateTravelSpell(this, null);

                if (!spell.CheckCast())
                {
                    Say("Oh, that's odd, I seem to be out of reagents.");
                    Console.WriteLine("Debug: CheckCast failed.");
                    return;
                }

                spell.Cast();
                Say("Vas Rel Por");

                // Delay to simulate casting time
                Timer.DelayCall(TimeSpan.FromSeconds(3), () =>
                {
                    Console.WriteLine("Debug: Timer triggered. Calling spell.Effect.");
                    spell.Effect(location, map, true);
                    Say($"A gate to {town} has been opened, {from.Name}.");
                    Console.WriteLine($"Debug: Gate to {town} opened at {location}");
                });
            }
            else
            {
                Say("I do not know of that town.");
            }
        }

        private Direction GetDirectionTo(Mobile target)
        {
            int dx = target.X - this.X;
            int dy = target.Y - this.Y;

            int adx = Math.Abs(dx);
            int ady = Math.Abs(dy);

            if (adx >= ady * 3)
            {
                return dx > 0 ? Direction.East : Direction.West;
            }
            else if (ady >= adx * 3)
            {
                return dy > 0 ? Direction.South : Direction.North;
            }
            else if (dx > 0 && dy > 0)
            {
                return Direction.Down;
            }
            else if (dx > 0 && dy < 0)
            {
                return Direction.Right;
            }
            else if (dx < 0 && dy > 0)
            {
                return Direction.Left;
            }
            else
            {
                return Direction.Up;
            }
        }
    }

    public class ChatGPTResponse
    {
        public ChatGPTChoice[] choices { get; init; }
    }

    public class ChatGPTChoice
    {
        public ChatGPTMessage message { get; set; }
    }

    public class ChatGPTMessage
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}
