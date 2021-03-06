using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{		
	public class OddsAndEndsQuest : BaseQuest
	{					
		/* Odds and Ends */
		public override object Title{ get{ return 1074354; } }
		
		/* I've always been fascinated by primitive cultures -- especially the artifacts.  I'm a collector, you 
		see.  I'm working on building my troglodyte display and I'm saddened to say that I'm short on examples 
		of religion and superstition amongst the creatures.  If you come across any primitive fetishes, I'd be 
		happy to trade you something interesting for them. */	
		public override object Description{ get{ return 1074677; } }
		
		/* Well, okay. But if you decide you are up for it after all, c'mon back and see me. */
		public override object Refuse{ get{ return 1072270; } }
		
		/* I don't really want to know where you get the primitive fetishes, as I can't support the destruction 
		of their lifestyle and culture. That would be wrong. */
		public override object Uncomplete{ get{ return 1074678; } }
		
		/* Bravo!  These fetishes are just what I needed.  You've earned this reward. */
		public override object Complete{ get{ return 1074679; } }
				
		public OddsAndEndsQuest() : base()
		{								
			AddObjective( new ObtainObjective( typeof( PrimitiveFetish ), "primitive fetishes", 12 ) );
						
			AddReward( new BaseReward( typeof( TreasureBag ), 1072583 ) );
		}		
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}		
	}
	
	public class Patricus : MondainQuester
	{
		public override Type[] Quests
		{ 
			get{ return new Type[] 
			{ 
				typeof( HeaveHoQuest ),		
				typeof( OddsAndEndsQuest )
			};} 
		}  
		
		[Constructable]
		public Patricus() : base( "Patricus", "The Trader" )
		{   
		}
		
		public Patricus( Serial serial ) : base( serial )
		{
		}  
		
		public override void InitBody()
		{		
			Female = false;
			Race = Race.Human;		
		
			base.InitBody();
		}
		
		public override void InitOutfit()
		{	
			AddItem( new Backpack() );		
			AddItem( new Shoes( 0x74B ) );
			AddItem( new LongPants( 0x1C ) );
			AddItem( new FancyShirt( 0x71B ) );
			AddItem( new Cloak( 0x1BB ) );		
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		} 
	}
}
  