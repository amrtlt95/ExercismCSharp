using System;

static class Badge
{
	public static string Print(int? id, string name, string? department)
	{
		//string[] = {id,name,department}
		//string result = "";
		//if (id is not null)
		//	result += $"[{id}] - ";
		//result += $"{name} - {department?.ToUpperInvariant() ?? "OWNER"}";
		//return result ;
		//return $"{(id == null ? "" : $"[{id}] - ")}{name} - {department?.ToUpper() ?? "OWNER"}";

		return $"{(id is null ? "" : $"[{id}] - ")}{name} - {(department is null ? "OWNER" : department.ToUpperInvariant())}";

	}
}
