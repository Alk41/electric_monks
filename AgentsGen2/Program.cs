using System;
using System.Collections.Generic;

namespace AgentsGen2
{
	class AgentMap
	{
		public int Number;
		public Dictionary<string,string> Map = new Dictionary<string, string>();

		public AgentMap( int number )
		{
			this.Number = number;

			var text = Convert.ToString( number , 2 ).PadLeft( 8 , '0' );

			this.Map.Add( "11" , text.Substring( 0 , 2 ) );
			this.Map.Add( "10" , text.Substring( 2 , 2 ) );
			this.Map.Add( "01" , text.Substring( 4 , 2 ) );
			this.Map.Add( "00" , text.Substring( 6 , 2 ) );
		}

		public AgentMap( string bits )
		{
			this.Number = Convert.ToInt32( bits , 2 );

			var text = bits.PadLeft( 8 , '0' );

			this.Map.Add( "11" , text.Substring( 0 , 2 ) );
			this.Map.Add( "10" , text.Substring( 2 , 2 ) );
			this.Map.Add( "01" , text.Substring( 4 , 2 ) );
			this.Map.Add( "00" , text.Substring( 6 , 2 ) );
		}

		public string ToString8()
		{
			var t = "";
			foreach ( var item in this.Map )
				t += item.Value;
			return t;
		}
	}

	class MainClass
	{
		public static void Main( string[] args )
		{
			var genPrev = new List<AgentMap>();
			genPrev.Add( new AgentMap( 3 ) );
			genPrev.Add( new AgentMap( 6 ) );
			genPrev.Add( new AgentMap( 9 ) );
			genPrev.Add( new AgentMap( 12 ) );
			genPrev.Add( new AgentMap( 18 ) );
			genPrev.Add( new AgentMap( 23 ) );
			genPrev.Add( new AgentMap( 24 ) );
			genPrev.Add( new AgentMap( 29 ) );
			genPrev.Add( new AgentMap( 33 ) );
			genPrev.Add( new AgentMap( 36 ) );
			genPrev.Add( new AgentMap( 43 ) );
			genPrev.Add( new AgentMap( 46 ) );
			genPrev.Add( new AgentMap( 48 ) );
			genPrev.Add( new AgentMap( 53 ) );
			genPrev.Add( new AgentMap( 58 ) );
			genPrev.Add( new AgentMap( 63 ) );
			genPrev.Add( new AgentMap( 66 ) );
			genPrev.Add( new AgentMap( 71 ) );
			genPrev.Add( new AgentMap( 72 ) );
			genPrev.Add( new AgentMap( 77 ) );
			genPrev.Add( new AgentMap( 83 ) );
			genPrev.Add( new AgentMap( 86 ) );
			genPrev.Add( new AgentMap( 89 ) );
			genPrev.Add( new AgentMap( 92 ) );
			genPrev.Add( new AgentMap( 96 ) );
			genPrev.Add( new AgentMap( 101 ) );
			genPrev.Add( new AgentMap( 106 ) );
			genPrev.Add( new AgentMap( 111 ) );
			genPrev.Add( new AgentMap( 113 ) );
			genPrev.Add( new AgentMap( 116 ) );
			genPrev.Add( new AgentMap( 123 ) );
			genPrev.Add( new AgentMap( 126 ) );
			genPrev.Add( new AgentMap( 129 ) );
			genPrev.Add( new AgentMap( 132 ) );
			genPrev.Add( new AgentMap( 139 ) );
			genPrev.Add( new AgentMap( 142 ) );
			genPrev.Add( new AgentMap( 144 ) );
			genPrev.Add( new AgentMap( 149 ) );
			genPrev.Add( new AgentMap( 154 ) );
			genPrev.Add( new AgentMap( 159 ) );
			genPrev.Add( new AgentMap( 163 ) );
			genPrev.Add( new AgentMap( 166 ) );
			genPrev.Add( new AgentMap( 169 ) );
			genPrev.Add( new AgentMap( 172 ) );
			genPrev.Add( new AgentMap( 178 ) );
			genPrev.Add( new AgentMap( 183 ) );
			genPrev.Add( new AgentMap( 184 ) );
			genPrev.Add( new AgentMap( 189 ) );
			genPrev.Add( new AgentMap( 192 ) );
			genPrev.Add( new AgentMap( 197 ) );
			genPrev.Add( new AgentMap( 202 ) );
			genPrev.Add( new AgentMap( 207 ) );
			genPrev.Add( new AgentMap( 209 ) );
			genPrev.Add( new AgentMap( 212 ) );
			genPrev.Add( new AgentMap( 219 ) );
			genPrev.Add( new AgentMap( 222 ) );
			genPrev.Add( new AgentMap( 226 ) );
			genPrev.Add( new AgentMap( 231 ) );
			genPrev.Add( new AgentMap( 232 ) );
			genPrev.Add( new AgentMap( 237 ) );
			genPrev.Add( new AgentMap( 243 ) );
			genPrev.Add( new AgentMap( 246 ) );
			genPrev.Add( new AgentMap( 249 ) );
			genPrev.Add( new AgentMap( 252 ) );

			var genAll = new List<string>();

			foreach ( var a in genPrev )
			{
				var t = "";
				foreach ( var item in a.Map )
					t += item.Value;

				genAll.Add( t );
				Console.WriteLine( "0 " + a.Number + " " + t + " *" );
			}
			Console.WriteLine();

			for ( int gen = 0 ; gen < 4 ; gen++ )
			{
				foreach ( var a1 in genPrev )
				{
					foreach ( var a2 in genPrev )
					{
						var resp = "";
						for ( int p = 1 ; p >= 0 ; p-- )
						{
							for ( int q = 1 ; q >= 0 ; q-- )
							{
								var i = "" + p + q;  // I
								var y = a2.Map[ i ]; // Fy(I)
								var x = a1.Map[ y ]; // Fx(Fy(I))

								resp += x;
							}
						}

						if ( !genAll.Contains( resp ) )
						{
							Console.WriteLine( a1.Number + " " + a2.Number + " " + resp + " *" );
							genAll.Add( resp );
						}
					}
				}

				Console.WriteLine( "gen " + gen + " agents " + genAll.Count );

				genPrev.Clear();
				foreach ( var k in genAll )
					genPrev.Add( new AgentMap( k ) );
			}

			for ( int i = 0 ; i < 256 ; i++ )
			{
				var a = new AgentMap( i );
				var s = a.ToString8();
				if ( !genAll.Contains( s ) )
					Console.WriteLine( "FALTANDO " + i + " " + s );
			}
		}
	}
}