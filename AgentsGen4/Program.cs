using System;
using System.Collections.Generic;

namespace AgentsGen4
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
			var agents = new List<AgentMap>();
			agents.Add( new AgentMap( 3 ) );
			agents.Add( new AgentMap( 6 ) );
			agents.Add( new AgentMap( 9 ) );
			agents.Add( new AgentMap( 12 ) );
			agents.Add( new AgentMap( 18 ) );
			agents.Add( new AgentMap( 23 ) );
			agents.Add( new AgentMap( 24 ) );
			agents.Add( new AgentMap( 29 ) );
			agents.Add( new AgentMap( 33 ) );
			agents.Add( new AgentMap( 36 ) );
			agents.Add( new AgentMap( 43 ) );
			agents.Add( new AgentMap( 46 ) );
			agents.Add( new AgentMap( 48 ) );
			agents.Add( new AgentMap( 53 ) );
			agents.Add( new AgentMap( 58 ) );
			agents.Add( new AgentMap( 63 ) );
			agents.Add( new AgentMap( 66 ) );
			agents.Add( new AgentMap( 71 ) );
			agents.Add( new AgentMap( 72 ) );
			agents.Add( new AgentMap( 77 ) );
			agents.Add( new AgentMap( 83 ) );
			agents.Add( new AgentMap( 86 ) );
			agents.Add( new AgentMap( 89 ) );
			agents.Add( new AgentMap( 92 ) );
			agents.Add( new AgentMap( 96 ) );
			agents.Add( new AgentMap( 101 ) );
			agents.Add( new AgentMap( 106 ) );
			agents.Add( new AgentMap( 111 ) );
			agents.Add( new AgentMap( 113 ) );
			agents.Add( new AgentMap( 116 ) );
			agents.Add( new AgentMap( 123 ) );
			agents.Add( new AgentMap( 126 ) );
			agents.Add( new AgentMap( 129 ) );
			agents.Add( new AgentMap( 132 ) );
			agents.Add( new AgentMap( 139 ) );
			agents.Add( new AgentMap( 142 ) );
			agents.Add( new AgentMap( 144 ) );
			agents.Add( new AgentMap( 149 ) );
			agents.Add( new AgentMap( 154 ) );
			agents.Add( new AgentMap( 159 ) );
			agents.Add( new AgentMap( 163 ) );
			agents.Add( new AgentMap( 166 ) );
			agents.Add( new AgentMap( 169 ) );
			agents.Add( new AgentMap( 172 ) );
			agents.Add( new AgentMap( 178 ) );
			agents.Add( new AgentMap( 183 ) );
			agents.Add( new AgentMap( 184 ) );
			agents.Add( new AgentMap( 189 ) );
			agents.Add( new AgentMap( 192 ) );
			agents.Add( new AgentMap( 197 ) );
			agents.Add( new AgentMap( 202 ) );
			agents.Add( new AgentMap( 207 ) );
			agents.Add( new AgentMap( 209 ) );
			agents.Add( new AgentMap( 212 ) );
			agents.Add( new AgentMap( 219 ) );
			agents.Add( new AgentMap( 222 ) );
			agents.Add( new AgentMap( 226 ) );
			agents.Add( new AgentMap( 231 ) );
			agents.Add( new AgentMap( 232 ) );
			agents.Add( new AgentMap( 237 ) );
			agents.Add( new AgentMap( 243 ) );
			agents.Add( new AgentMap( 246 ) );
			agents.Add( new AgentMap( 249 ) );
			agents.Add( new AgentMap( 252 ) );

			var know = new List<string>();

			foreach ( var a in agents )
			{
				var s = a.ToString8();
				know.Add( s );
				Console.WriteLine( "0 0 " + a.Number + " " + s + " *" );
			}
			Console.WriteLine();

			foreach ( var a1 in agents )
			{
				Console.WriteLine( "runing " + a1.Number );
				foreach ( var a2 in agents )
				{
					foreach ( var a3 in agents )
					{
						foreach ( var a4 in agents )
						{
							var resp = "";
							for ( int p = 1 ; p >= 0 ; p-- )
							{
								for ( int q = 1 ; q >= 0 ; q-- )
								{
									var i = "" + p + q;                                // 11 10 01 00
									var r = a1.Map[ a2.Map[ a3.Map[ a4.Map[ i ] ] ] ]; // Fx(Fy(Fw(Fz(I))))

									resp += r;
								}
							}

							if ( !know.Contains( resp ) )
							{
								know.Add( resp );
								Console.Write( a1.Number + " " + a2.Number + " " + a3.Number + " " + a4.Number + " " + resp );
								Console.Write( " * " + know.Count );
								Console.WriteLine();
							}
						}
					}
				}
			}

			for ( int i = 0 ; i < 256 ; i++ )
			{
				var a = new AgentMap( i );
				var s = a.ToString8();
				if ( !know.Contains( s ) )
					Console.WriteLine( "FALTANDO " + i + " " + s );
			}

			System.Diagnostics.Debugger.Log( 0 , "" , "know " + know.Count );
			return;
		}
	}
}