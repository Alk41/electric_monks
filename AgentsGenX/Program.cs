using System;
using System.Collections.Generic;

namespace AgentsGenX
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
			var prev = new List<AgentMap>();
			prev.Add( new AgentMap( 3 ) );
			prev.Add( new AgentMap( 6 ) );
			prev.Add( new AgentMap( 9 ) );
			prev.Add( new AgentMap( 12 ) );
			prev.Add( new AgentMap( 18 ) );
			prev.Add( new AgentMap( 23 ) );
			prev.Add( new AgentMap( 24 ) );
			prev.Add( new AgentMap( 29 ) );
			prev.Add( new AgentMap( 33 ) );
			prev.Add( new AgentMap( 36 ) );
			prev.Add( new AgentMap( 43 ) );
			prev.Add( new AgentMap( 46 ) );
			prev.Add( new AgentMap( 48 ) );
			prev.Add( new AgentMap( 53 ) );
			prev.Add( new AgentMap( 58 ) );
			prev.Add( new AgentMap( 63 ) );
			prev.Add( new AgentMap( 66 ) );
			prev.Add( new AgentMap( 71 ) );
			prev.Add( new AgentMap( 72 ) );
			prev.Add( new AgentMap( 77 ) );
			prev.Add( new AgentMap( 83 ) );
			prev.Add( new AgentMap( 86 ) );
			prev.Add( new AgentMap( 89 ) );
			prev.Add( new AgentMap( 92 ) );
			prev.Add( new AgentMap( 96 ) );
			prev.Add( new AgentMap( 101 ) );
			prev.Add( new AgentMap( 106 ) );
			prev.Add( new AgentMap( 111 ) );
			prev.Add( new AgentMap( 113 ) );
			prev.Add( new AgentMap( 116 ) );
			prev.Add( new AgentMap( 123 ) );
			prev.Add( new AgentMap( 126 ) );
			prev.Add( new AgentMap( 129 ) );
			prev.Add( new AgentMap( 132 ) );
			prev.Add( new AgentMap( 139 ) );
			prev.Add( new AgentMap( 142 ) );
			prev.Add( new AgentMap( 144 ) );
			prev.Add( new AgentMap( 149 ) );
			prev.Add( new AgentMap( 154 ) );
			prev.Add( new AgentMap( 159 ) );
			prev.Add( new AgentMap( 163 ) );
			prev.Add( new AgentMap( 166 ) );
			prev.Add( new AgentMap( 169 ) );
			prev.Add( new AgentMap( 172 ) );
			prev.Add( new AgentMap( 178 ) );
			prev.Add( new AgentMap( 183 ) );
			prev.Add( new AgentMap( 184 ) );
			prev.Add( new AgentMap( 189 ) );
			prev.Add( new AgentMap( 192 ) );
			prev.Add( new AgentMap( 197 ) );
			prev.Add( new AgentMap( 202 ) );
			prev.Add( new AgentMap( 207 ) );
			prev.Add( new AgentMap( 209 ) );
			prev.Add( new AgentMap( 212 ) );
			prev.Add( new AgentMap( 219 ) );
			prev.Add( new AgentMap( 222 ) );
			prev.Add( new AgentMap( 226 ) );
			prev.Add( new AgentMap( 231 ) );
			prev.Add( new AgentMap( 232 ) );
			prev.Add( new AgentMap( 237 ) );
			prev.Add( new AgentMap( 243 ) );
			prev.Add( new AgentMap( 246 ) );
			prev.Add( new AgentMap( 249 ) );
			prev.Add( new AgentMap( 252 ) );

			var next = new List<string>();

			Console.WriteLine( "Gen1:" );
			foreach ( var a in prev )
			{
				var t = "";
				foreach ( var item in a.Map )
					t += item.Value;

				next.Add( t );
				Console.WriteLine( "0 " + a.Number + " " + a.Number + ":" + t + " *" );
			}
			Console.WriteLine();

			var onezero = new int[]{ 1, 0 };

			for ( int gen = 0 ; gen < 4 ; gen++ )
			{
				foreach ( var a1 in prev )
				{
					foreach ( var a2 in prev )
					{
						var resp = "";
						foreach ( var p in onezero )
						{
							foreach ( var q in onezero )
							{
								var i = "" + p + q;  // I
								var y = a2.Map[ i ]; // Fy(I)
								var x = a1.Map[ y ]; // Fx(Fy(I))

								resp += x;
							}
						}

						if ( !next.Contains( resp ) )
						{
							var ag = new AgentMap( resp );
							Console.WriteLine( a1.Number + " " + a2.Number + " " + ag.Number + ":" + resp + " *" );
							next.Add( resp );
						}
					}
				}
			}
			Console.WriteLine( "Gen2 total: " + next.Count );

			prev.Clear();
			foreach ( var bits in next )
				prev.Add( new AgentMap( bits ) );

			Console.WriteLine();

			for ( int gen = 0 ; gen < 4 ; gen++ )
			{
				foreach ( var a1 in prev )
				{
					foreach ( var a2 in prev )
					{
						var resp = "";
						foreach ( var p in onezero )
						{
							foreach ( var q in onezero )
							{
								var i = "" + p + q;  // I
								var y = a2.Map[ i ]; // Fy(I)
								var x = a1.Map[ y ]; // Fx(Fy(I))

								resp += x;
							}
						}

						if ( !next.Contains( resp ) )
						{
							var ag = new AgentMap( resp );
							Console.WriteLine( a1.Number + " " + a2.Number + " " + ag.Number + ":" + resp + " *" );
							next.Add( resp );
						}
					}
				}
			}
			Console.WriteLine( "Gen2*Gen2 total: " + next.Count );

			for ( int i = 0 ; i < 256 ; i++ )
			{
				var a = new AgentMap( i );
				var s = a.ToString8();
				if ( !next.Contains( s ) )
					Console.WriteLine( "FALTANDO " + i + " " + s );
			}
		}
	}
}