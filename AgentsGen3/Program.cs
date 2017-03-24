using System;
using System.Collections.Generic;

namespace AgentsGen3
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
			var gen1 = new List<AgentMap>();
			gen1.Add( new AgentMap( 3 ) );
			gen1.Add( new AgentMap( 6 ) );
			gen1.Add( new AgentMap( 9 ) );
			gen1.Add( new AgentMap( 12 ) );
			gen1.Add( new AgentMap( 18 ) );
			gen1.Add( new AgentMap( 23 ) );
			gen1.Add( new AgentMap( 24 ) );
			gen1.Add( new AgentMap( 29 ) );
			gen1.Add( new AgentMap( 33 ) );
			gen1.Add( new AgentMap( 36 ) );
			gen1.Add( new AgentMap( 43 ) );
			gen1.Add( new AgentMap( 46 ) );
			gen1.Add( new AgentMap( 48 ) );
			gen1.Add( new AgentMap( 53 ) );
			gen1.Add( new AgentMap( 58 ) );
			gen1.Add( new AgentMap( 63 ) );
			gen1.Add( new AgentMap( 66 ) );
			gen1.Add( new AgentMap( 71 ) );
			gen1.Add( new AgentMap( 72 ) );
			gen1.Add( new AgentMap( 77 ) );
			gen1.Add( new AgentMap( 83 ) );
			gen1.Add( new AgentMap( 86 ) );
			gen1.Add( new AgentMap( 89 ) );
			gen1.Add( new AgentMap( 92 ) );
			gen1.Add( new AgentMap( 96 ) );
			gen1.Add( new AgentMap( 101 ) );
			gen1.Add( new AgentMap( 106 ) );
			gen1.Add( new AgentMap( 111 ) );
			gen1.Add( new AgentMap( 113 ) );
			gen1.Add( new AgentMap( 116 ) );
			gen1.Add( new AgentMap( 123 ) );
			gen1.Add( new AgentMap( 126 ) );
			gen1.Add( new AgentMap( 129 ) );
			gen1.Add( new AgentMap( 132 ) );
			gen1.Add( new AgentMap( 139 ) );
			gen1.Add( new AgentMap( 142 ) );
			gen1.Add( new AgentMap( 144 ) );
			gen1.Add( new AgentMap( 149 ) );
			gen1.Add( new AgentMap( 154 ) );
			gen1.Add( new AgentMap( 159 ) );
			gen1.Add( new AgentMap( 163 ) );
			gen1.Add( new AgentMap( 166 ) );
			gen1.Add( new AgentMap( 169 ) );
			gen1.Add( new AgentMap( 172 ) );
			gen1.Add( new AgentMap( 178 ) );
			gen1.Add( new AgentMap( 183 ) );
			gen1.Add( new AgentMap( 184 ) );
			gen1.Add( new AgentMap( 189 ) );
			gen1.Add( new AgentMap( 192 ) );
			gen1.Add( new AgentMap( 197 ) );
			gen1.Add( new AgentMap( 202 ) );
			gen1.Add( new AgentMap( 207 ) );
			gen1.Add( new AgentMap( 209 ) );
			gen1.Add( new AgentMap( 212 ) );
			gen1.Add( new AgentMap( 219 ) );
			gen1.Add( new AgentMap( 222 ) );
			gen1.Add( new AgentMap( 226 ) );
			gen1.Add( new AgentMap( 231 ) );
			gen1.Add( new AgentMap( 232 ) );
			gen1.Add( new AgentMap( 237 ) );
			gen1.Add( new AgentMap( 243 ) );
			gen1.Add( new AgentMap( 246 ) );
			gen1.Add( new AgentMap( 249 ) );
			gen1.Add( new AgentMap( 252 ) );

			var gen3 = new List<string>();

			foreach ( var a in gen1 )
			{
				var s = a.ToString8();
				gen3.Add( s );
				Console.WriteLine( "0 0 " + a.Number + " " + a.Number + ":" + s + " *" );
			}
			Console.WriteLine();

			foreach ( var a1 in gen1 )
			{
				foreach ( var a2 in gen1 )
				{
					foreach ( var a3 in gen1 )
					{
						var resp = "";
						for ( int p = 1 ; p >= 0 ; p-- )
						{
							for ( int q = 1 ; q >= 0 ; q-- )
							{
								var i = "" + p + q;                      // I
								var r = a1.Map[ a2.Map[ a3.Map[ i ] ] ]; // Fx(Fy(Fz(I))
								resp += r;
							}
						}

						if ( !gen3.Contains( resp ) )
						{
							var a4 = new AgentMap( resp );
							Console.WriteLine( a1.Number + " " + a2.Number + " " + a3.Number + " " + a4.Number + ":" + resp + " *" );
							gen3.Add( resp );
						}
					}
				}
			}

			Console.WriteLine();
			Console.WriteLine( "Missing agents:" );
			for ( int i = 0 ; i < 256 ; i++ )
			{
				var a = new AgentMap( i );
				var s = a.ToString8();
				if ( !gen3.Contains( s ) )
					Console.WriteLine( "\t" + i + ":" + s );
			}
		}
	}
}