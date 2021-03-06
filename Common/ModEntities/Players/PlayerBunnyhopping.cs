﻿using TerrariaOverhaul.Utilities.Extensions;

namespace TerrariaOverhaul.Common.ModEntities.Players
{
	public sealed class PlayerBunnyhopping : PlayerBase
	{
		public static float DefaultBoost => 0.75f;

		public float boost;

		public override void ResetEffects()
		{
			boost = DefaultBoost;

			Player.autoJump = true;
		}

		public override void PostItemCheck()
		{
			bool onGround = Player.OnGround();
			bool wasOnGround = Player.WasOnGround();

			if(!onGround && wasOnGround && Player.velocity.Y < 0f) {
				Player.velocity.X += Player.controlLeft ? -boost : Player.controlRight ? boost : 0f;
			}
		}
	}
}
