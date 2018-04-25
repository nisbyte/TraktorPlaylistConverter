using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC.Enums
{
	public enum Headings
	{
		[Description("Num.")]
		Num,
		Title,
		Artist,
		Time,
		BPM,
		Track,
		Release,
		Label,
		Genre,
		[Description("Key Text")]
		KeyText,
		Key,
		Comment,
		Lyrics,
		Rating,
		File,
		[Description("Analyzed (Peak, Perceived)")]
		AnalyzedPeakPerceived,
		Remixer,
		Producer,
		[Description("Release Date")]
		ReleaseDate,
		Bitrate,
		Comment2,
		[Description("Play Count")]
		PlayCount,
		[Description("Last Played")]
		LastPlayed,
		[Description("Import Date")]
		ImportDate,
		[Description("Start Time")]
		StartTime,
		Duration,
		Deck,
		[Description("Played Public")]
		PlayedPublic
	}
}
