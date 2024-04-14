using System;
using System.ComponentModel;
using System.Linq;

public static class TelemetryBuffer
{
	private static byte GetPrefixByte(long reading)

		  => reading switch
		  {
			  >= -9_223_372_036_854_775_808 and <= -2_147_483_649 => 248,
			  >= -2_147_483_648 and <= -32_769 => 252,
			  >= -32_768 and <= -1 => 254,
			  >= 0 and <= 65_535 => 2,
			  >= 65_536 and <= 2_147_483_647 => 252,
			  >= 2_147_483_648 and <= 4_294_967_295 => 4,
			  >= 4_294_967_296 and <= 9_223_372_036_854_775_807 => 248



		  };

	private static byte[] ConcatBothArrays(long reading)
	{
		var result = Enumerable.Empty<byte>();
		var ByteArray = BitConverter.GetBytes(reading);

		result = result.Append(GetPrefixByte(reading));

		return result.Concat(ByteArray).ToArray();
	}

	private static byte[] CleanedArrayOfBytes(long reading)
	{
		var arrayOfBites = ConcatBothArrays(reading);

		var prefixByte = arrayOfBites[0];
		var usedBytes = prefixByte > 8 ? 256 - prefixByte : prefixByte;

		for (int i = usedBytes + 1; i < arrayOfBites.Length; i++)
		{
			arrayOfBites[i] = 0;
		}
		return arrayOfBites;

	}
	public static byte[] ToBuffer(long reading) => CleanedArrayOfBytes(reading);



	public static long FromBuffer(byte[] buffer) => buffer[0] switch
	{
		256 - 8 or 4 or 2 => BitConverter.ToInt64(buffer, 1),
		256 - 4 => BitConverter.ToInt32(buffer, 1),
		256 - 2 => BitConverter.ToInt16(buffer, 1),
		_ => 0
	};
}
