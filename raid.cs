using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Drawing;
using Be.Timvw.Framework.ComponentModel;
using PoiBot.Util;
using System.Data;
using PoiBot.AlissaWindow;
using PoiBot.Parsing;
using System.Threading;
using System.Reflection;
using JNogueira.Discord.Webhook.Client;
using System.Threading.Tasks;
using NaoParse;

namespace PoiBot
{
	public partial class RaidBot : Form
	{
		private SortableBindingList<DamageMeterRow> AttackerList = new SortableBindingList<DamageMeterRow>();
		private Stopwatch watch = new Stopwatch();
		private SafeDictionary<long, string> characters = new SafeDictionary<long, string>();
		private HashSet<int> packetIdSet = new HashSet<int>();


		// pale, source : https://github.com/exectails/MabiPale2
		public static Queue<Msg> packetQueue = new Queue<Msg>();
		private Alissa invisWindow;
		string avahook2 = "https://discord.com/api/webhooks/845531374937047041/z3OtRwsgXF20w2bMA2dpHw-KP-c72LmJIazCKNoA834UappfW4Fm6ancQjm5X2QY2wfa";
		string wbhhook2 = "https://discord.com/api/webhooks/845533319433027594/5sXK81NQVI17HCCjwU27RLQsTZG4Xs3ik3usG0s3RA-0sBXqJCzGb5IWd8yGyAOXR-P1";
		string wbhooktrusted = "https://discord.com/api/webhooks/845535867196014602/kwS1VKSDzpQXFe-MW_8RY5cyWaNdrfi-YkGKyfpx8wIxc4Ef7inGo4qJSKd7zYq3feZe";

		string marketch = "https://discord.com/api/webhooks/845542083174334506/Vtg5oDfRWQrRY6jOSCs4BONJXMJSsOzMOPttGed-R__Zz0adWrQNZU_nn7dB4tlWiEhF";
		string horns = "https://discord.com/api/webhooks/845542557185474590/5OV6OmG-_GYclQlRkYggo06g7kVgK046XwS-5OQd-2ZQBpLXSoybPUs4BSRjFQj_W6gM";

		string log = "https://discord.com/api/webhooks/845543026755633183/SM9e7Nr1imPoHYEFgrMjzpwUJ-2y5nV30Z-DveJMCfQpcydEnwpqlcGyY7FdpIkOr_fQ";

		string avahook1line = "https://discord.com/api/webhooks/845842810389004319/hXcA3B0revJcDWO0CWZTcOngUQuT1gA50cOnnSjsEiMnhsotSNxmcstHRThb_dKsXQZd";
		string statusofbot = "https://discord.com/api/webhooks/847797101761134612/-bzKg0P4cIlz9MAbSsO5tov1PR_QsQRgwuLF6e3aJfe5pb4p3Sr8F8hyrfqO8VqinV1W";
		string currentch = "";
		public static string name = "";
		bool market = false;
		int time = 0;





		List<string> marketmessage = new List<string>() { "-------------------------------------------------------------------" };
		private async Task DiscordRaidMessageAysc(string Raid, byte Status, string currentch)
		{
			var zone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
			var utcNow = DateTime.UtcNow;
			var pacificNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, zone);
			string time = pacificNow + "";
			string here = "";
			string living = "";
			string thumb = "";
			if (Raid == "Sylvan dragon")
			{
				if (Status == 1)
				{

					here = "@here";
					living = "Alive";
					thumb = "https://cdn.discordapp.com/attachments/723052224821067796/845533952206307378/576208265138929664.png";

				}
				else if (Status == 2)
				{
					here = " ";
					living = "Dead";
					thumb = "https://cdn.discordapp.com/attachments/723052224821067796/845634787841671188/syl.png";
				}
				var client2 = new DiscordWebhookClient(avahook2);
				// Create your DiscordMessage with all parameters of your message.
				var message = new DiscordMessage(
					here + " " + currentch,
					username: "Raidbot9002",
					avatarUrl: "https://cdn.discordapp.com/attachments/723052224821067796/845522826580852766/guradrink.png",
					tts: false,
					embeds: new[]
					{
							new DiscordMessageEmbed
							(
							"Raid Call",
							color: 0,
							description: "Avalon Raid Sylvan dragon",
							fields: new[]
							{
								new DiscordMessageEmbedField("Status: ", living),
							},
							thumbnail: new DiscordMessageEmbedThumbnail(thumb),
							footer: new DiscordMessageEmbedFooter(time)
							)
					}
				);

				// Send the message!
				await client2.SendToDiscord(message);

				var client1line = new DiscordWebhookClient(avahook1line);
				var message2 = new DiscordMessage
					(
					here + " " + currentch + " " + "Sylvan Dragon " + living + "    " + time,
					username: "Raidbot9002",
					avatarUrl: "https://cdn.discordapp.com/attachments/723052224821067796/845522826580852766/guradrink.png",
					tts: false,
					null
					);
				await client1line.SendToDiscord(message2);

			}
			else if (Raid == "Mokkurkalfi")
			{
				if (Status == 1)
				{

					here = "@here";
					living = "Alive";
					thumb = "https://cdn.discordapp.com/attachments/723052224821067796/845534222264434698/576208283644329994.png";

				}
				else if (Status == 2)
				{
					here = " ";
					living = "Dead";
					thumb = "https://cdn.discordapp.com/attachments/723052224821067796/845634589632102400/mok.png";
				}
				var client2 = new DiscordWebhookClient(avahook2);
				// Create your DiscordMessage with all parameters of your message.
				var message = new DiscordMessage(
					here + " " + currentch,
					username: "Raidbot9002",
					avatarUrl: "https://cdn.discordapp.com/attachments/723052224821067796/845522826580852766/guradrink.png",
					tts: false,
					embeds: new[]
					{
							new DiscordMessageEmbed
							(
							"Raid Call",
							color: 0,
							description: "Avalon Raid Mokkurkalfi",
							fields: new[]
							{
								new DiscordMessageEmbedField("Status: ", living),
							},
							thumbnail: new DiscordMessageEmbedThumbnail(thumb),
							footer: new DiscordMessageEmbedFooter(time)
							)
					}
				);


				// Send the message!
				await client2.SendToDiscord(message);

				var client1line = new DiscordWebhookClient(avahook1line);
				var message2 = new DiscordMessage
					(
					here + " " + currentch + " " + "Moku " + living + "    " + time,
					username: "Raidbot9002",
					avatarUrl: "https://cdn.discordapp.com/attachments/723052224821067796/845522826580852766/guradrink.png",
					tts: false,
					null
					);
				await client1line.SendToDiscord(message2);
			}
			else if (Raid == "white dragon summon")
			{
				if (Status == 1)
				{

					here = "@here";
					living = "Alive";
					thumb = "https://cdn.discordapp.com/attachments/723052224821067796/845534156767494154/576202220631228416.png";

				}
				else if (Status == 2)
				{
					here = " ";
					living = "Dead";
					thumb = "https://cdn.discordapp.com/attachments/723052224821067796/845634592412139550/white.png";
				}
				var client2 = new DiscordWebhookClient(wbhhook2);
				// Create your DiscordMessage with all parameters of your message.
				var message = new DiscordMessage(
					here + " " + currentch,
					username: "Raidbot9002",
					avatarUrl: "https://cdn.discordapp.com/attachments/723052224821067796/845522826580852766/guradrink.png",
					tts: false,
					embeds: new[]
					{
							new DiscordMessageEmbed
							(
							"Raid Call",
							color: 0,
							description: "White dragon summon",
							fields: new[]
							{
								new DiscordMessageEmbedField("Status: ", living),
							},
							thumbnail: new DiscordMessageEmbedThumbnail(thumb),
							footer: new DiscordMessageEmbedFooter(time)
							)
					}
				);

				// Send the message!
				await client2.SendToDiscord(message);
			}
			else if (Raid == "black dragon summon")
			{
				if (Status == 1)
				{

					here = "@here";
					living = "Alive";
					thumb = "https://cdn.discordapp.com/attachments/723052224821067796/845534134793011260/576202233947881482.png";

				}
				else if (Status == 2)
				{
					here = " ";
					living = "Dead";
					thumb = "https://cdn.discordapp.com/attachments/723052224821067796/845635109452513351/blac.png";
				}
				var client2 = new DiscordWebhookClient(wbhhook2);
				// Create your DiscordMessage with all parameters of your message.
				var message = new DiscordMessage(
					here + " " + currentch,
					username: "Raidbot9002",
					avatarUrl: "https://cdn.discordapp.com/attachments/723052224821067796/845522826580852766/guradrink.png",
					tts: false,
					embeds: new[]
					{
							new DiscordMessageEmbed
							(
							"Raid Call",
							color: 0,
							description: "Black dragon summon",
							fields: new[]
							{
								new DiscordMessageEmbedField("Status: ", living),
							},
							thumbnail: new DiscordMessageEmbedThumbnail(thumb),
							footer: new DiscordMessageEmbedFooter(time)
							)
					}
				);

				// Send the message!
				await client2.SendToDiscord(message);
			}
			else if (Raid == "white dragon")
			{
				if (Status == 1)
				{

					here = "@here";
					living = "Alive";
					thumb = "https://cdn.discordapp.com/attachments/723052224821067796/845534156767494154/576202220631228416.png";

				}
				else if (Status == 2)
				{
					here = " ";
					living = "Dead";
					thumb = "https://cdn.discordapp.com/attachments/723052224821067796/845634592412139550/white.png";
				}
				var client2 = new DiscordWebhookClient(wbhooktrusted);
				// Create your DiscordMessage with all parameters of your message.
				var message = new DiscordMessage
					(
					here + " " + currentch + " " + "White Dragon " + living + "    " + time,
					username: "Raidbot9002",
					avatarUrl: "https://cdn.discordapp.com/attachments/723052224821067796/845522826580852766/guradrink.png",
					tts: false,
					null
					);

				// Send the message!
				await client2.SendToDiscord(message);
			}
			else if (Raid == "black dragon")
			{
				if (Status == 1)
				{

					here = "@here";
					living = "Alive";
					thumb = "https://cdn.discordapp.com/attachments/723052224821067796/845534134793011260/576202233947881482.png";

				}
				else if (Status == 2)
				{
					here = " ";
					living = "Dead";
					thumb = "https://cdn.discordapp.com/attachments/723052224821067796/845635109452513351/blac.png";
				}
				var client2 = new DiscordWebhookClient(wbhooktrusted);
				// Create your DiscordMessage with all parameters of your message.
				var message = new DiscordMessage
					(
					here + " " + currentch + " " + "Black Dragon " + living + "    " + time,
					username: "Raidbot9002",
					avatarUrl: "https://cdn.discordapp.com/attachments/723052224821067796/845522826580852766/guradrink.png",
					tts: false,
					null
					);

				// Send the message!
				await client2.SendToDiscord(message);
			}



		}

		private static async Task Mabitodiscord(string hook, string messagee, string name)
		{
			var client = new DiscordWebhookClient(hook);
			var message = new DiscordMessage
			(
				messagee,
				username: name,
				avatarUrl: "https://cdn.discordapp.com/attachments/723052224821067796/845522826580852766/guradrink.png",
				tts: false
			);
			await client.SendToDiscord(message);
		}


		public RaidBot()
		{
			InitializeComponent();
			
		}





		private void onSend(Msg msg)
		{
			if (msg.Op == Op.Run)
			{

			}
			else if (msg.Op == Op.FlyTo)
			{

			}
		}
		private async Task ProcessRaidPacketAsync(int type, byte status)
		{
			string raid = "";
			string aliveorno = "";
			switch (type)
			{
				//white black dragon
				case 21:
					raid = "white dragon";
					break;
				case 22:
					raid = "white dragon summon";
					break;
				case 23:
					raid = "white dragon";
					break;
				case 24:
					raid = "black dragon";
					break;
				case 25:
					raid = "black dragon";
					break;
				case 26:
					raid = "black dragon summon";
					break;
				case 27:
					raid = "black dragon";
					break;
				case 28:
					raid = "black dragon";
					break;
				case 29:
					raid = "black dragon summon";
					break;
				case 30:
					raid = "white dragon";
					break;
				case 31:
					raid = "white dragon";
					break;
				case 32:
					raid = "white dragon summon";
					break;
				case 33:
					raid = "white dragon";
					break;
				case 34:
					raid = "white dragon";
					break;
				case 35:
					raid = "black dragon";
					break;
				case 36:
					raid = "black dragon";
					break;
				case 37:
					raid = "black dragon summon";
					break;
				case 38:
					raid = "black dragon";
					break;
				case 39:
					raid = "black dragon";
					break;
				case 40:
					raid = "black dragon summon";
					break;
				case 41:
					raid = "white dragon";
					break;
				case 42:
					raid = "white dragon";
					break;
				case 43:
					raid = "white dragon summon";
					break;
				case 44:
					raid = "black dragon";
					break;
				case 45:
					raid = "black dragon";
					break;
				case 46:
					raid = "black dragon summon";
					break;
				case 47:
					raid = "white dragon";
					break;
				case 48:
					raid = "white dragon";
					break;
				case 49:
					raid = "white dragon";
					break;
				case 50:
					raid = "white dragon";
					break;
				case 51:
					raid = "white dragon";
					break;
				case 52:
					raid = "white dragon summon";
					break;

				//avalon
				case 133:
					raid = "Mokkurkalfi";
					break;
				case 134:
					raid = "Mokkurkalfi";
					break;
				case 135:
					raid = "Sylvan dragon";
					break;
				case 136:
					raid = "Sylvan dragon";
					break;
				case 137:
					raid = "Mokkurkalfi";
					break;
				case 138:
					raid = "Mokkurkalfi";
					break;
				case 139:
					raid = "Sylvan dragon";
					break;
				case 140:
					raid = "Sylvan dragon";
					break;
				case 141:
					raid = "Mokkurkalfi";
					break;
				case 142:
					raid = "Mokkurkalfi";
					break;
				case 143:
					raid = "Sylvan dragon";
					break;
				case 144:
					raid = "Sylvan dragon";
					break;
				default:
					raid = "other raid ID:" + type;
					break;

			}
			string message = "";
			bool send = false;
			switch (status)
			{
				case 1:
					aliveorno = "spawned";
					message = currentch + " " + raid + " " + aliveorno + " @here";
					send = true;
					break;
				case 2:
					aliveorno = "dead";
					message = currentch + " " + raid + " " + aliveorno;
					send = true;
					break;
				case 3:
					aliveorno = "despawned";
					message = currentch + " " + raid + " is " + aliveorno;
					send = false;
					break;
				default:
					aliveorno = "other state";
					send = false;
					break;
			}
			if (send)
			{
				bool avalonorno = message.Contains("Sylvan") | message.Contains("Mokkurkalfi");

				if (avalonorno)
				{
					//await DiscordMessageAsync(Avalonhook, message, "Raidbot 9001");
					await DiscordRaidMessageAysc(raid, status, currentch);
				}
				else
				{
					//await DiscordMessageAsync(Whiteblackhook, message, "Raidbot 9001");
					await DiscordRaidMessageAysc(raid, status, currentch);
				}
			}
		}

		private async Task onRecvAsync(Msg msg)
		{
			time = 0;
			main.online = "connect" + " " + currentch;
			this.BackColor = Color.White;
			switch (msg.Op)
			{
				case Op.ChannelCharacterInfoRequestR:
					{
						bool hasCreature = msg.Packet.GetBool();
						if (hasCreature)
						{
							var eid = msg.Packet.GetLong();
							if (EntityId.IsCharacter(eid))
							{
								msg.Packet.GetByte();
								name = msg.Packet.GetString();
								characters.SafeSet(eid, name);
							}
							
							var zone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
							var utcNow = DateTime.UtcNow;
							var pacificNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, zone);
							string time = pacificNow + "";
							string message = time + "   " + name + " " + currentch + " has CCed";
							main.clientnameplusch = name + " " + currentch + "-";
							await Mabitodiscord(log, message, "Log");
							await Mabitodiscord(statusofbot, currentch + " " + "Has connected", "statusbot");
							

						}
						break;
					}
				case Op.EntityAppears:
					{
						var eid = msg.Packet.GetLong();
						if (EntityId.IsCharacter(eid))
						{
							msg.Packet.GetByte();
							var name = msg.Packet.GetString();
							
							characters.SafeSet(eid, name);
						}
						break;
					}
				case Op.EntitiesAppear:
					{
						var count = msg.Packet.GetShort();
						for (var i = 0; i < count; i++)
						{
							var type = msg.Packet.GetShort();
							msg.Packet.GetInt();
							var data = msg.Packet.GetBin();
							Packet subMsg = new Packet(data, 0);
							var eid = subMsg.GetLong();
							if (EntityId.IsCharacter(eid))
							{
								if (type == 16)
								{
									subMsg.GetByte();
									var name = subMsg.GetString();
									characters.SafeSet(eid, name);
								}
							}
						}

						break;
					}


				case Op.Chat:
					{
						if (market)
						{
							byte something = msg.Packet.GetByte();
							string name = msg.Packet.GetString();
							string message = msg.Packet.GetString();
							bool v = message.Contains("[Wanted]");
							if (v)
							{
								bool listcontainsmessage = true;

								foreach (string str in marketmessage)
								{
									if (message.Contains(str) == true)
									{
										listcontainsmessage = true;
										break;
									}
									else
									{
										listcontainsmessage = false;

									}
								}
								if (listcontainsmessage == false)
								{

									if (message.Contains("@"))
                                    {
										message.Replace("@", "at ");
                                    }

										marketmessage.Add(message);
										var zone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
										var utcNow = DateTime.UtcNow;
										var pacificNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, zone);
										string time = pacificNow + "";
										await Mabitodiscord(marketch, time + "   " + message, "market");
									



								}

							}

							bool e = name.Contains("<ALL_CHANNELS>");
							if (e)
							{
								if (message.Contains("@"))
								{
									message.Replace("@", "at ");
								}

									//await DiscordMessageAsync(discordWebhookURLother2, "HORN NORM> " + message, "Horns");
									var zone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
									var utcNow = DateTime.UtcNow;
									var pacificNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, zone);
									string time = pacificNow + "";
									await Mabitodiscord(horns, time + "   " + "HORN NORM> " + message, "Horns");
								

							}
						}
						break;
					}

				case Op.raid:
					{
						int type = msg.Packet.GetInt();
						byte status = msg.Packet.GetByte();
						await ProcessRaidPacketAsync(type, status);

						break;
					}
				case Op.Chchange:
					{
						byte a = msg.Packet.GetByte();
						string b = msg.Packet.GetString();
						currentch = msg.Packet.GetString();
						break;
					}
				case Op.Lobby:
					{

						byte a = msg.Packet.GetByte();
						string b = msg.Packet.GetString();
						currentch = msg.Packet.GetString();



						break;
					}
				case Op.Horns:
					{
						if (market)
						{
							byte a = msg.Packet.GetByte();
							string message = msg.Packet.GetString();
							bool v = message.Contains(":");
							if (v)
							{
								if (message.Contains("@"))
								{
									message.Replace("@", "at ");
								}
							
								//await DiscordMessageAsync(discordWebhookURLother2, "HORN PREMIUM> " + Message, "Horns");
								var zone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
									var utcNow = DateTime.UtcNow;
									var pacificNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, zone);
									string time = pacificNow + "";
									await Mabitodiscord(horns, time + "   " + "HORN PREMIUM> " + message, "Horns");

								
							}
						}
						break;
					}
			}
		}






        private async void button1_Click(object sender, EventArgs e)
        {
			byte fakestatus = 0;
			switch (combofakestatus.SelectedIndex)
			{
				case -1:
					fakestatus = 4;
					break;
				case 0:
					fakestatus = 1;
					break;
				case 1:
					fakestatus = 2;
					break;
				case 2:
					fakestatus = 3;
					break;

			}
			await DiscordRaidMessageAysc("white dragon", fakestatus, currentch);
		}

        private async void button3_Click(object sender, EventArgs e)
        {
			byte fakestatus = 0;
			switch (combofakestatus.SelectedIndex)
			{
				case -1:
					fakestatus = 4;
					break;
				case 0:
					fakestatus = 1;
					break;
				case 1:
					fakestatus = 2;
					break;
				case 2:
					fakestatus = 3;
					break;

			}
			await DiscordRaidMessageAysc("black dragon", fakestatus, currentch);
		}

        private async void button2_Click(object sender, EventArgs e)
        {
			byte fakestatus = 0;
			switch (combofakestatus.SelectedIndex)
			{
				case -1:
					fakestatus = 4;
					break;
				case 0:
					fakestatus = 1;
					break;
				case 1:
					fakestatus = 2;
					break;
				case 2:
					fakestatus = 3;
					break;

			}
			await DiscordRaidMessageAysc("Mokkurkalfi", fakestatus, currentch);
		}

        private async void button4_Click(object sender, EventArgs e)
        {
			byte fakestatus = 0;
			switch (combofakestatus.SelectedIndex)
			{
				case -1:
					fakestatus = 4;
					break;
				case 0:
					fakestatus = 1;
					break;
				case 1:
					fakestatus = 2;
					break;
				case 2:
					fakestatus = 3;
					break;

			}
			await DiscordRaidMessageAysc("Sylvan dragon", fakestatus, currentch);
		}

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
			while (true)
			{
				Thread.Sleep(250);
				
				var count = packetQueue.Count;
				if (rMarket.Checked == true)
                {
					market = true;
                }
				else if (rNormal.Checked == true)
                {
					market = false;
				}

				if (count == 0)
					continue;
				var newPackets = new List<Msg>();
				for (int i = 0; i < count; ++i)
				{
					Msg packet;
					lock (packetQueue)
						packet = packetQueue.Dequeue();

					if (packet == null)
						continue;

					newPackets.Add(packet);
				}

				foreach (var packet in newPackets)
				{
					if (packet.Received)
						onRecvAsync(packet);
					else
						onSend(packet);
				}
				
				
			}
		}

        private void RaidBot_Load_1(object sender, EventArgs e)
        {
			
			// Creating an invisible message receiver window in a separate thread
			Thread invisWindowThread = new Thread(new ThreadStart(() =>
			{
				invisWindow = new Alissa();
				invisWindow.Show();
				invisWindow.Visible = false;
				System.Windows.Threading.Dispatcher.Run();
			}));

			// Starting the thread
			invisWindowThread.SetApartmentState(ApartmentState.STA);
			invisWindowThread.IsBackground = true;
			invisWindowThread.Start();

			backgroundWorker1.RunWorkerAsync();
		}

        private async void button5_Click(object sender, EventArgs e)
        {
			string message = "I AM " + name + " on " + currentch;
			if(market == true)
            {
				message += " I am also a market ch bot";
            }
			else if(market == false)
            {
				message += " I am not a market ch bot";
            }
			await Mabitodiscord(log, message, "Log");
		}

        private async void timer1_Tick(object sender, EventArgs e)
        {
			time++;
			if (time == 60)
            {
				
				this.BackColor = Color.LightPink;
				await Mabitodiscord(statusofbot, currentch +  " " + "Has timed out, someone tell a admin", "statusbot");


			}

		}

        private void button6_Click(object sender, EventArgs e)
        {

			this.Text = nameme.Text;

		}
    }
}

