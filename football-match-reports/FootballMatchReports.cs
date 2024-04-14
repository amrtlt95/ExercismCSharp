using System;
using System.Globalization;
using System.Net.Security;
public static class PlayAnalyzer
{
	public static string AnalyzeOnField(int shirtNum) => shirtNum switch
	{
		1 => "goalie",
		2 => "left back",
		3 or 4 => "center back",
		5 => "right back",
		>= 6 and <= 8 => "midfielder",
		9 => "left wing",
		10 => "striker",
		11 => "right wing",
		_ => throw new ArgumentOutOfRangeException()
	};

	public static string AnalyzeOffField(object report) => report switch
	{
		int  => $"There are {report} supporters at the match.",
		string  => report.ToString(),
		Injury i => $"Oh no! {i.GetDescription()} Medics are on the field.",
		Incident incident => incident.GetDescription(),
		
		Manager manager => $"{manager.Name}{(manager.Club is not null ? $" ({manager.Club})" : "")}",
		_ => throw new ArgumentException()

	};
}
//public class Incident
//{
//	public string Description { get; set; } = null!;
//	public Incident(string Description) => this.Description = Description;
//}

//public class Foul : Incident
//{
//	public Foul() : base("The referee deemed a foul.")
//	{
//	}
//}

//public class Injury : Incident
//{
//	public Injury(int PlayerNumber) : base($"Oh no! Player {PlayerNumber} is injured. Medics are on the field.")
//	{
//	}
//}

//public class Manager
//{
//	public string Description { get; set; } = null!;



//	public Manager(string Name, string ClubName)
//	{
//		Description = $"{Name}{(ClubName is not null ? $" ({ClubName})" : "")}";
//	}
