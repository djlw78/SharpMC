﻿using SharpMC.Classes;

namespace SharpMC.Networking.Packages
{
	internal class PlayerLook : Package<PlayerLook>
	{
		public PlayerLook(ClientWrapper client) : base(client)
		{
			ReadId = 0x05;
		}

		public PlayerLook(ClientWrapper client, MSGBuffer buffer) : base(client, buffer)
		{
			ReadId = 0x05;
		}

		public override void Read()
		{
			if (Buffer != null)
			{
				Client.Player.Yaw = Buffer.ReadFloat();
				Client.Player.Pitch = Buffer.ReadFloat();
				Client.Player.OnGround = Buffer.ReadBool();

				new EntityLook(Client) {Player = Client.Player}.Broadcast(false, Client.Player);
			}
		}
	}
}