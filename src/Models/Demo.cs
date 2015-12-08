﻿using CSGO_Demos_Manager.Models.Events;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Threading.Tasks;
using CSGO_Demos_Manager.Properties;
using DemoInfo;

namespace CSGO_Demos_Manager.Models
{
	public class Demo : ObservableObject
	{
		#region Properties

		/// <summary>
		/// Unique demo's ID
		/// </summary>
		private string _id;
		
		/// <summary>
		/// Name of the demo's file
		/// </summary>
		private string _name = "";

		/// <summary>
		/// Demo's date
		/// </summary>
		private DateTime _date;

		/// <summary>
		/// Demo's source (MM, ESEA, FaceIt)
		/// </summary>
		private Source.Source _source;

		/// <summary>
		/// Used for Json
		/// </summary>
		private string _sourceName;

		/// <summary>
		/// Client's name
		/// </summary>
		private string _clientName = "";

		/// <summary>
		/// Hostname
		/// </summary>
		private string _hostname = "";

		/// <summary>
		/// Type (POV or GOTV)
		/// </summary>
		private string _type = "GOTV";

		/// <summary>
		/// Demo's tickrate (16 usually)
		/// </summary>
		private float _tickrate;

		/// <summary>
		/// Server's tickrate (64 or 128 usually)
		/// </summary>
		private float _serverTickrate;

		/// <summary>
		/// Demo duration
		/// </summary>
		private float _duration;

		/// <summary>
		/// Demo's map name
		/// </summary>
		private string _mapName;

		/// <summary>
		/// Path on Windows
		/// </summary>
		private string _path;

		/// <summary>
		/// Indicates if there are at least 1 banned player (OW / VAC)
		/// </summary>
		private bool _hasCheater;

		/// <summary>
		/// Team 1 score
		/// </summary>
		private int _scoreTeam1;

		/// <summary>
		/// Team 2 Score
		/// </summary>
		private int _scoreTeam2;

		/// <summary>
		/// First half team 1 score
		/// </summary>
		private int _scoreFirstHalfTeam1;

		/// <summary>
		/// First half team 2 score
		/// </summary>
		private int _scoreFirstHalfTeam2;

		/// <summary>
		/// Second half team 1 score
		/// </summary>
		private int _scoreSecondHalfTeam1;

		/// <summary>
		/// Second half team 2 score
		/// </summary>
		private int _scoreSecondHalfTeam2;

		/// <summary>
		/// Number of 1K during the match
		/// </summary>
		private int _onekillCount;

		/// <summary>
		/// Number of 2K during the match
		/// </summary>
		private int _twokillCount;

		/// <summary>
		/// Number of 3K during the match
		/// </summary>
		private int _threekillCount;

		/// <summary>
		/// Number of 4K during the match
		/// </summary>
		private int _fourkillCount;

		/// <summary>
		/// Number of 5K during the match
		/// </summary>
		private int _fivekillCount;

		/// <summary>
		/// User's comment
		/// </summary>
		private string _comment = "";

		/// <summary>
		/// User's custom status (none, to watch, watched)
		/// </summary>
		private string _status = "None";

		/// <summary>
		/// Ref to handle surrended match
		/// </summary>
		private TeamExtended _surrender;

		/// <summary>
		/// Winner of the match
		/// </summary>
		private TeamExtended _winner;

		/// <summary>
		/// List of rounds during the match
		/// </summary>
		private ObservableCollection<Round> _rounds = new ObservableCollection<Round>();

		/// <summary>
		/// List of players who played during the match
		/// </summary>
		private ObservableCollection<PlayerExtended> _players = new ObservableCollection<PlayerExtended>();

		/// <summary>
		/// Infos on bomb planted during the match
		/// </summary>
		private ObservableCollection<BombPlantedEvent> _bombPlanted = new ObservableCollection<BombPlantedEvent>();

		/// <summary>
		/// Infos on bomb defused during the match
		/// </summary>
		private ObservableCollection<BombDefusedEvent> _bombDefused = new ObservableCollection<BombDefusedEvent>();

		/// <summary>
		/// Infos on bomb exploded during the match
		/// </summary>
		private ObservableCollection<BombExplodedEvent> _bombExploded = new ObservableCollection<BombExplodedEvent>();

		/// <summary>
		/// Infos about players hurted event
		/// </summary>
		private ObservableCollection<PlayerHurtedEvent> _playersHurted = new ObservableCollection<PlayerHurtedEvent>();

		/// <summary>
		/// All kills during the match
		/// </summary>
		private ObservableCollection<KillEvent> _kills = new ObservableCollection<KillEvent>();

		/// <summary>
		/// Demo's overtimes
		/// </summary>
		private ObservableCollection<Overtime> _overtimes = new ObservableCollection<Overtime>();

		/// <summary>
		/// Player with the best HS ratio
		/// </summary>
		private PlayerExtended _mostHeadshotPlayer;

		/// <summary>
		/// Player with the most bomb planted
		/// </summary>
		private PlayerExtended _mostBombPlantedPlayer;

		/// <summary>
		/// Player with the most entry kill
		/// </summary>
		private PlayerExtended _mostEntryKillPlayer;

		/// <summary>
		/// Weapon with the most kills
		/// </summary>
		private Weapon _mostKillingWeapon;

		/// <summary>
		/// Counter-Terrorist team
		/// </summary>
		private TeamExtended _teamCt;

		/// <summary>
		/// Terrorit team
		/// </summary>
		private TeamExtended _teamT;

		/// <summary>
		/// Contains data about flashbangs which had blinded players
		/// </summary>
		private ObservableCollection<PlayerBlindedEvent> _playerBlindedEvents = new ObservableCollection<PlayerBlindedEvent>();

		#endregion

		#region Accessors

		[JsonProperty("id")]
		public string Id
		{
			get { return _id; }
			set { Set(() => Id, ref _id, value); }
		}

		[JsonProperty("name")]
		public string Name
		{
			get { return _name; }
			set { Set(() => Name, ref _name, value); }
		}

		[JsonProperty("date")]
		public DateTime Date
		{
			get { return _date; }
			set { Set(() => Date, ref _date, value); }
		}

		[JsonIgnore]
		public string DateAsString => _date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

		[JsonIgnore]
		public Source.Source Source
		{
			get { return _source; }
			set
			{
				Set(() => Source, ref _source, value);
				SourceName = value.Name;
			}
		}

		[JsonProperty("source")]
		public string SourceName
		{
			get { return _sourceName;}
			set { Set(() => SourceName, ref _sourceName, value); }
		}
		[JsonProperty("comment")]
		public string Comment
		{
			get { return _comment; }
			set { Set(() => Comment, ref _comment, value); }
		}

		[JsonProperty("status")]
		public string Status
		{
			get { return _status; }
			set { Set(() => Status, ref _status, value); }
		}

		[JsonProperty("client_name")]
		public string ClientName
		{
			get { return _clientName; }
			set { Set(() => ClientName, ref _clientName, value); }
		}

		[JsonProperty("hostname")]
		public string Hostname
		{
			get { return _hostname; }
			set { Set(() => Hostname, ref _hostname, value); }
		}

		[JsonProperty("type")]
		public string Type
		{
			get { return _type; }
			set { Set(() => Type, ref _type, value); }
		}

		[JsonProperty("tickrate")]
		public float Tickrate
		{
			get { return _tickrate; }
			set { Set(() => Tickrate, ref _tickrate, value); }
		}

		[JsonProperty("server_tickrate")]
		public float ServerTickrate
		{
			get { return _serverTickrate; }
			set { Set(() => ServerTickrate, ref _serverTickrate, value); }
		}

		[JsonProperty("duration")]
		public float Duration
		{
			get { return _duration; }
			set
			{
				Set(() => Duration, ref _duration, value);
				RaisePropertyChanged(() => DurationTime);
			}
		}

		[JsonIgnore]
		public string DurationTime => TimeSpan.FromSeconds(_duration).ToString(@"hh\:mm\:ss");

		[JsonProperty("map_name")]
		public string MapName
		{
			get { return _mapName; }
			set { Set(() => MapName, ref _mapName, value); }
		}

		[JsonProperty("path")]
		public string Path
		{
			get { return _path; }
			set { Set(() => Path, ref _path, value); }
		}


		[JsonProperty("has_cheater")]
		public bool HasCheater
		{
			get { return _hasCheater; }
			set { Set(() => HasCheater, ref _hasCheater, value); }
		}

		[JsonProperty("score_team_1")]
		public int ScoreTeam1
		{
			get { return _scoreTeam1; }
			set { Set(() => ScoreTeam1, ref _scoreTeam1, value); }
		}

		[JsonProperty("score_team_2")]
		public int ScoreTeam2
		{
			get { return _scoreTeam2; }
			set { Set(() => ScoreTeam2, ref _scoreTeam2, value); }
		}

		[JsonProperty("score_first_half_team_1")]
		public int ScoreFirstHalfTeam1
		{
			get { return _scoreFirstHalfTeam1; }
			set { Set(() => ScoreFirstHalfTeam1, ref _scoreFirstHalfTeam1, value); }
		}

		[JsonProperty("score_first_half_team_2")]
		public int ScoreFirstHalfTeam2
		{
			get { return _scoreFirstHalfTeam2; }
			set { Set(() => ScoreFirstHalfTeam2, ref _scoreFirstHalfTeam2, value); }
		}

		[JsonProperty("score_second_half_team_1")]
		public int ScoreSecondHalfTeam1
		{
			get { return _scoreSecondHalfTeam1; }
			set { Set(() => ScoreSecondHalfTeam1, ref _scoreSecondHalfTeam1, value); }
		}

		[JsonProperty("score_second_half_team_2")]
		public int ScoreSecondHalfTeam2
		{
			get { return _scoreSecondHalfTeam2; }
			set { Set(() => ScoreSecondHalfTeam2, ref _scoreSecondHalfTeam2, value); }
		}

		[JsonProperty("five_kill_count")]
		public int FiveKillCount
		{
			get { return _fivekillCount; }
			set { Set(() => FiveKillCount, ref _fivekillCount, value); }
		}

		[JsonProperty("four_kill_count")]
		public int FourKillCount
		{
			get { return _fourkillCount; }
			set { Set(() => FourKillCount, ref _fourkillCount, value); }
		}

		[JsonProperty("three_kill_count")]
		public int ThreeKillCount
		{
			get { return _threekillCount; }
			set { Set(() => ThreeKillCount, ref _threekillCount, value); }
		}

		[JsonProperty("two_kill_count")]
		public int TwoKillCount
		{
			get { return _twokillCount; }
			set { Set(() => TwoKillCount, ref _twokillCount, value); }
		}

		[JsonProperty("one_kill_count")]
		public int OneKillCount
		{
			get { return _onekillCount; }
			set { Set(() => OneKillCount, ref _onekillCount, value); }
		}

		[JsonProperty("team_ct", IsReference = true)]
		public TeamExtended TeamCT
		{
			get { return _teamCt; }
			set { Set(() => TeamCT, ref _teamCt, value); }
		}

		[JsonProperty("team_t", IsReference = true)]
		public TeamExtended TeamT
		{
			get { return _teamT; }
			set { Set(() => TeamT, ref _teamT, value); }
		}

		[JsonProperty("surrender_team")]
		public TeamExtended Surrender
		{
			get { return _surrender; }
			set
			{
				Set(() => Surrender, ref _surrender, value);
				RaisePropertyChanged(() => Surrender);
			}
		}

		[JsonProperty("winner_team")]
		public TeamExtended Winner
		{
			get { return _winner; }
			set { Set(() => Winner, ref _winner, value); }
		}

		[JsonProperty("rounds", IsReference = false)]
		public ObservableCollection<Round> Rounds
		{
			get { return _rounds; }
			set { Set(() => Rounds, ref _rounds, value); }
		}

		[JsonProperty("players", IsReference = false)]
		public ObservableCollection<PlayerExtended> Players
		{
			get { return _players; }
			set { Set(() => Players, ref _players, value); }
		}

		[JsonProperty("win_status")]
		public string WinStatus
		{
			get
			{
				switch (MatchVerdictSelectedAccountCount)
				{
					case -2:
						return "lost-s";
					case -1:
						return "lost";
					case 0:
						return "draw";
					case 1:
						return "won";
					case 2:
						return "won-s";
					default:
						return string.Empty;
				}
			}
		}
		
		[JsonProperty("total_kill_count")]
		public int TotalKillCount => Kills.Count;

		[JsonProperty("bomb_defused_count")]
		public int BombDefusedCount => BombDefused.Count;

		[JsonProperty("bomb_exploded_count")]
		public int BombExplodedCount => BombExploded.Count();

		[JsonProperty("bomb_planted_count")]
		public int BombPlantedCount => BombPlanted.Count;

		[JsonProperty("most_killing_weapon")]
		public Weapon MostKillingWeapon
		{
			get { return _mostKillingWeapon; }
			set { Set(() => MostKillingWeapon, ref _mostKillingWeapon, value); }
		}

		[JsonProperty("overtimes", IsReference = false)]
		public ObservableCollection<Overtime> Overtimes
		{
			get { return _overtimes; }
			set { Set(() => Overtimes, ref _overtimes, value); }
		}

		[JsonProperty("most_headshot_player")]
		public PlayerExtended MostHeadshotPlayer
		{
			get { return _mostHeadshotPlayer; }
			set { Set(() => MostHeadshotPlayer, ref _mostHeadshotPlayer, value); }
		}

		[JsonProperty("most_bomb_planted_player")]
		public PlayerExtended MostBombPlantedPlayer
		{
			get { return _mostBombPlantedPlayer; }
			set { Set(() => MostBombPlantedPlayer, ref _mostBombPlantedPlayer, value); }
		}

		[JsonProperty("most_entry_kill_player")]
		public PlayerExtended MostEntryKillPlayer
		{
			get { return _mostEntryKillPlayer; }
			set { Set(() => MostEntryKillPlayer, ref _mostEntryKillPlayer, value); }
		}

		[JsonProperty("clutch_count")]
		public int ClutchCount
		{
			get
			{
				return Players.Sum(
					playerExtended => playerExtended.Clutch1V1Count + playerExtended.Clutch1V2Count
					+ playerExtended.Clutch1V3Count + playerExtended.Clutch1V4Count + playerExtended.Clutch1V5Count);
			}
		}

		[JsonProperty("blinded_events", IsReference = false)]
		public ObservableCollection<PlayerBlindedEvent> PlayerBlindedEvents
		{
			get { return _playerBlindedEvents; }
			set { Set(() => PlayerBlindedEvents, ref _playerBlindedEvents, value); }
		}

		[JsonProperty("bombs_planted", IsReference = false)]
		public ObservableCollection<BombPlantedEvent> BombPlanted
		{
			get { return _bombPlanted; }
			set { Set(() => BombPlanted, ref _bombPlanted, value); }
		}

		[JsonProperty("bombs_defused", IsReference = false)]
		public ObservableCollection<BombDefusedEvent> BombDefused
		{
			get { return _bombDefused; }
			set { Set(() => BombDefused, ref _bombDefused, value); }
		}

		[JsonProperty("bombs_exploded", IsReference = false)]
		public ObservableCollection<BombExplodedEvent> BombExploded
		{
			get { return _bombExploded; }
			set { Set(() => BombExploded, ref _bombExploded, value); }
		}

		[JsonProperty("kills", IsReference = false)]
		public ObservableCollection<KillEvent> Kills
		{
			get { return _kills; }
			set { Set(() => Kills, ref _kills, value); }
		}

		/// <summary>
		/// Contains all PositionPoint for overview generation 
		/// </summary>
		[JsonIgnore]
		public List<PositionPoint> PositionsPoint { get; set; } = new List<PositionPoint>();

		/// <summary>
		/// DecoyStartedEvent list used for heatmap generation
		/// </summary>
		[JsonIgnore]
		public List<DecoyStartedEvent> DecoyStarted = new List<DecoyStartedEvent>();

		/// <summary>
		/// MolotovFireStartedEvent list used for heatmap generation
		/// </summary>
		[JsonIgnore]
		public List<MolotovFireStartedEvent> MolotovFireStarted = new List<MolotovFireStartedEvent>();

		/// <summary>
		/// Contains information about all shoots occured during the match
		/// </summary>
		[JsonProperty("weapon_fired")]
		public List<WeaponFire> WeaponFired = new List<WeaponFire>();

		[JsonProperty("players_hurted")]
		public ObservableCollection<PlayerHurtedEvent> PlayersHurted
		{
			get { return _playersHurted; }
			set { Set(() => PlayersHurted, ref _playersHurted, value); }
		}

		/// <summary>
		/// Total health damage has been done during the match
		/// </summary>
		[JsonIgnore]
		public int TotalDamageHealthCount
		{
			get
			{
				return Rounds.SelectMany(round => round.PlayersHurted.ToList()).Sum(playerHurtedEvent => playerHurtedEvent.HealthDamage);
			}
		}

		/// <summary>
		/// Total armor damage has been done during the match
		/// </summary>
		[JsonIgnore]
		public int TotalDamageArmorCount
		{
			get
			{
				return Rounds.SelectMany(round => round.PlayersHurted.ToList()).Sum(playerHurtedEvent => playerHurtedEvent.ArmorDamage);
			}
		}

		/// <summary>
		/// Most damaging weapon of the match
		/// </summary>
		[JsonIgnore]
		public Weapon MostDamageWeapon
		{
			get
			{
				Dictionary<Weapon, int> weapons = new Dictionary<Weapon, int>();

				foreach (PlayerHurtedEvent playerHurtedEvent in Rounds.SelectMany(round => round.PlayersHurted))
				{
					if (!weapons.ContainsKey(playerHurtedEvent.Weapon))
					{
						weapons[playerHurtedEvent.Weapon] = playerHurtedEvent.HealthDamage + playerHurtedEvent.ArmorDamage;
					}
					else
					{
						weapons[playerHurtedEvent.Weapon] += playerHurtedEvent.HealthDamage + playerHurtedEvent.ArmorDamage;
					}
				}

				return weapons.OrderByDescending(x => x.Value).FirstOrDefault().Key;
			}
		}

		/// <summary>
		/// Average damage (health + armor) made during the game
		/// </summary>
		[JsonIgnore]
		public double AverageDamageCount
		{
			get
			{
				double total = Rounds.Where(round => round.PlayersHurted.Any()).SelectMany(
					round => round.PlayersHurted).Aggregate<PlayerHurtedEvent, double>(0, (current, playerHurtedEvent) => 
					current + (playerHurtedEvent.ArmorDamage + playerHurtedEvent.HealthDamage));
				if (total < 0.1) return 0;
				total = Math.Round(total / Rounds.Count, 1);
				return total;
			}
		}

		/// <summary>
		/// return the KPR ratio of the match
		/// It's the DPR too as 1 kill = 1 death
		/// </summary>
		[JsonIgnore]
		public double KillPerRound
		{
			get
			{
				if (!Players.Any()) return 0;
				double total = Rounds.Aggregate<Round, double>(0, (current, round) => current + round.KillsCount);
				total = Math.Round(total/Rounds.Count, 2);
				if (Math.Abs(total) < 0.1) return total;
				return total;
			}
		}

		/// <summary>
		/// return the APR ratio of the match
		/// </summary>
		[JsonIgnore]
		public double AssistPerRound
		{
			get
			{
				if (!Players.Any()) return 0;
				double total = Rounds.Aggregate<Round, double>(0, (current, round) => current + round.Kills.Count(k => k.Assister != null));
				total = Math.Round(total / Rounds.Count, 2);
				if (Math.Abs(total) < 0.1) return total;
				return total;
			}
		}

		/// <summary>
		/// Get damage formatted string => % (damage)
		/// </summary>
		/// <param name="hitGroup"></param>
		/// <param name="players"></param>
		/// <param name="rounds"></param>
		/// <returns></returns>
		public async Task<string> GetDamageAsync(Hitgroup hitGroup, List<PlayerExtended> players, List<Round> rounds)
		{
			string result = "0";
			int damageAreaCount = 0;
			int totalDamageCount = 0;

			await Task.Factory.StartNew(() =>
			{
				// get the total damage made at specific round(s) and player(s)
				totalDamageCount += (
				from round
				in rounds
				from playerHurtedEvent
				in round.PlayersHurted
				where playerHurtedEvent.Attacker != null && players.Contains(playerHurtedEvent.Attacker)
				select playerHurtedEvent.HealthDamage).Sum();

				// get the total damage made at the specific hitgroup
				switch (hitGroup)
				{
					case Hitgroup.Chest:
						damageAreaCount += (
						from round
						in rounds
						from playerHurtedEvent
						in round.PlayersHurted
						where players.Contains(playerHurtedEvent.Attacker)
						where playerHurtedEvent.HitGroup == Hitgroup.Chest
						select playerHurtedEvent.HealthDamage).Sum();
						break;
					case Hitgroup.Head:
						damageAreaCount += (
						from round
						in rounds
						from playerHurtedEvent
						in round.PlayersHurted
						where players.Contains(playerHurtedEvent.Attacker)
						where playerHurtedEvent.HitGroup == Hitgroup.Head
						select playerHurtedEvent.HealthDamage).Sum();
						break;
					case Hitgroup.LeftArm:
						damageAreaCount += (
						from round
						in rounds
						from playerHurtedEvent
						in round.PlayersHurted
						where players.Contains(playerHurtedEvent.Attacker)
						where playerHurtedEvent.HitGroup == Hitgroup.LeftArm
						select playerHurtedEvent.HealthDamage).Sum();
						break;
					case Hitgroup.RightArm:
						damageAreaCount += (
						from round
						in rounds
						from playerHurtedEvent
						in round.PlayersHurted
						where players.Contains(playerHurtedEvent.Attacker)
						where playerHurtedEvent.HitGroup == Hitgroup.RightArm
						select playerHurtedEvent.HealthDamage).Sum();
						break;
					case Hitgroup.LeftLeg:
						damageAreaCount += (
						from round
						in rounds
						from playerHurtedEvent
						in round.PlayersHurted
						where players.Contains(playerHurtedEvent.Attacker)
						where playerHurtedEvent.HitGroup == Hitgroup.LeftLeg
						select playerHurtedEvent.HealthDamage).Sum();
						break;
					case Hitgroup.RightLeg:
						damageAreaCount += (
						from round
						in rounds
						from playerHurtedEvent
						in round.PlayersHurted
						where players.Contains(playerHurtedEvent.Attacker)
						where playerHurtedEvent.HitGroup == Hitgroup.RightLeg
						select playerHurtedEvent.HealthDamage).Sum();
						break;
					case Hitgroup.Stomach:
						damageAreaCount += (
						from round
						in rounds
						from playerHurtedEvent
						in round.PlayersHurted
						where players.Contains(playerHurtedEvent.Attacker)
						where playerHurtedEvent.HitGroup == Hitgroup.Stomach
						select playerHurtedEvent.HealthDamage).Sum();
						break;
				}
			});

			if(damageAreaCount != 0) result = Math.Round((double)damageAreaCount * 100 / totalDamageCount, 2).ToString(CultureInfo.InvariantCulture);
			result += "% (" + damageAreaCount + ")";
			return result;
		}

		#endregion

		#region Selected account data accessors

		/// <summary>
		/// Return the result of the match for the selected account
		/// -3 : error
		/// -2 : loss by surrender
		/// -1 : loss
		/// 0 : draw
		/// 1 : win
		/// 2 : win by surrender
		/// </summary>
		[JsonIgnore]
		public int MatchVerdictSelectedAccountCount
		{
			get
			{
				PlayerExtended player;
				if (Surrender != null)
				{
					player = Surrender.Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
					if (player != null) return -2;
					return 2;
				}

				if (ScoreTeam1 == 0 && ScoreTeam2 == 0) return -3;

				// was in team 1 (CT)?
				player = TeamCT.Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player != null)
				{
					if (ScoreTeam1 == ScoreTeam2) return 0;
					if (ScoreTeam1 > ScoreTeam2) return 1;
					return -1;
				}

				// was in team 2 (T)?
				player = TeamT.Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player != null)
				{
					if (ScoreTeam1 == ScoreTeam2) return 0;
					if (ScoreTeam1 < ScoreTeam2) return 1;
					return -1;
				}

				return -3;
			}
		}

		[JsonIgnore]
		public int HeadshotSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.HeadshotCount;
			}
		}

		[JsonIgnore]
		public int DeathSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.DeathCount;
			}
		}

		[JsonIgnore]
		public int AssistSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.AssistCount;
			}
		}

		[JsonIgnore]
		public int EntryKillSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.EntryKills.Count;
			}
		}

		[JsonIgnore]
		public int KnifeKillSelectedAccountCount
		{
			get
			{
				IEnumerable<KillEvent> kills = Kills.Where(k => k.Killer != null && k.Killer.SteamId == Settings.Default.SelectedStatsAccountSteamID).ToList();
				if (!kills.Any()) return 0;
				return kills.Count(k => k.Weapon.Name == "Knife");
			}
		}

		[JsonIgnore]
		public int TotalKillSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.KillsCount;
			}
		}

		[JsonIgnore]
		public int MvpSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.RoundMvpCount;
			}
		}

		[JsonIgnore]
		public int OneKillSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.OnekillCount;
			}
		}

		[JsonIgnore]
		public int TwoKillSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.TwokillCount;
			}
		}

		[JsonIgnore]
		public int ThreeKillSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.ThreekillCount;
			}
		}

		[JsonIgnore]
		public int FourKillSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.FourKillCount;
			}
		}

		[JsonIgnore]
		public int FiveKillSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.FiveKillCount;
			}
		}

		[JsonIgnore]
		public int BombExplodedSelectedAccountCount
		{
			get { return BombExploded.Count(b => b.Player != null && b.Player.SteamId == Settings.Default.SelectedStatsAccountSteamID); }
		}

		[JsonIgnore]
		public int BombDefusedSelectedAccountCount
		{
			get { return BombDefused.Count(b => b.Player != null && b.Player.SteamId == Settings.Default.SelectedStatsAccountSteamID); }
		}

		[JsonIgnore]
		public int BombPlantedSelectedAccountCount
		{
			get { return BombPlanted.Count(b => b.Player != null && b.Player.SteamId == Settings.Default.SelectedStatsAccountSteamID); }
		}

		[JsonIgnore]
		public int TeamKillSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.TeamKillCount;
			}
		}

		[JsonIgnore]
		public double KillPerRoundSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.KillPerRound;
			}
		}

		[JsonIgnore]
		public double AssistPerRoundSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.AssistPerRound;
			}
		}

		[JsonIgnore]
		public double DeathPerRoundSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.DeathPerRound;
			}
		}

		/// <summary>
		/// Total health damage the user made during the match
		/// </summary>
		[JsonIgnore]
		public int TotalDamageHealthSelectedAccountCount => (from round
												  in Rounds
												  where round.PlayersHurted.Any()
												  from playerHurtedEvent
												  in round.PlayersHurted
												  where playerHurtedEvent.Attacker != null && playerHurtedEvent.Attacker.SteamId == Settings.Default.SelectedStatsAccountSteamID
												  select playerHurtedEvent.HealthDamage).Sum();

		/// <summary>
		/// Total armor damage the user made during the match
		/// </summary>
		[JsonIgnore]
		public int TotalDamageArmorSelectedAccountCount => (
			from round
			in Rounds
			where round.PlayersHurted.Any()
			from playerHurtedEvent
			in round.PlayersHurted
			where playerHurtedEvent.Attacker != null && playerHurtedEvent.Attacker.SteamId == Settings.Default.SelectedStatsAccountSteamID
			select playerHurtedEvent.ArmorDamage).Sum();

		/// <summary>
		/// Average damages (health + armor) made by the user during the game
		/// </summary>
		[JsonIgnore]
		public double AverageDamageSelectedAccountCount
		{
			get
			{
				double total = (from round
								in Rounds
								where round.PlayersHurted.Any()
								from playerHurtedEvent
								in round.PlayersHurted
								where playerHurtedEvent.Attacker != null && playerHurtedEvent.Attacker.SteamId == Settings.Default.SelectedStatsAccountSteamID
								select playerHurtedEvent).Aggregate<PlayerHurtedEvent, double>(0, (current, playerHurtedEvent) =>
								current + (playerHurtedEvent.ArmorDamage + playerHurtedEvent.HealthDamage));
				if (Math.Abs(total) < 0.1) return total;
				total = Math.Round(total / Rounds.Count, 1);
				return total;
			}
		}

		[JsonIgnore]
		public int ClutchSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.ClutchCount;
			}
		}

		[JsonIgnore]
		public int ClutchLostSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.ClutchLostCount;
			}
		}

		[JsonIgnore]
		public int ClutchWinCountSelectedAccountCount
		{
			get
			{
				PlayerExtended player = Players.FirstOrDefault(p => p.SteamId == Settings.Default.SelectedStatsAccountSteamID);
				if (player == null) return 0;
				return player.Clutch1V1Count + player.Clutch1V2Count + player.Clutch1V3Count + player.Clutch1V4Count + player.Clutch1V5Count;
			}
		}

		#endregion

		public Demo()
		{
			_teamCt = new TeamExtended
			{
				Name = "Team 1"
			};
			_teamT = new TeamExtended
			{
				Name = "Team 2"
			};
			Kills.CollectionChanged += OnKillsCollectionChanged;
			BombExploded.CollectionChanged += OnBombExplodedCollectionChanged;
			BombDefused.CollectionChanged += OnBombDefusedCollectionChanged;
			BombPlanted.CollectionChanged += OnBombPlantedCollectionChanged;
			Rounds.CollectionChanged += OnRoundsCollectionChanged;
		}

		public override bool Equals(object obj)
		{
			var item = obj as Demo;

			return item != null && Id.Equals(item.Id);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public void ResetStats(bool resetTeams = true)
		{
			DispatcherHelper.CheckBeginInvokeOnUI(
				() =>
				{
					_onekillCount = 0;
					_twokillCount = 0;
					_threekillCount = 0;
					_fourkillCount = 0;
					_fivekillCount = 0;
					_scoreTeam1 = 0;
					_scoreTeam2 = 0;
					_scoreFirstHalfTeam1 = 0;
					_scoreFirstHalfTeam2 = 0;
					_scoreSecondHalfTeam1 = 0;
					_scoreSecondHalfTeam2 = 0;
					if (resetTeams)
					{
						_players.Clear();
						_teamCt.Clear();
						_teamT.Clear();
					}
					else
					{
						foreach (PlayerExtended playerExtended in Players)
						{
							playerExtended.ResetStats();
						}
					}
					_rounds.Clear();
					WeaponFired.Clear();
					_kills.Clear();
					_overtimes.Clear();
					PositionsPoint.Clear();
					MolotovFireStarted.Clear();
					DecoyStarted.Clear();
					_bombPlanted.Clear();
					_bombDefused.Clear();
					_bombExploded.Clear();
					_bombPlanted.Clear();
					_bombDefused.Clear();
					_bombExploded.Clear();
					_mostBombPlantedPlayer = null;
					_mostEntryKillPlayer = null;
					_mostHeadshotPlayer = null;
					_mostKillingWeapon = null;
					_hasCheater = false;
					_playersHurted.Clear();
					_playerBlindedEvents.Clear();
					_winner = null;
				});
		}

		#region Handler collections changed

		private void OnKillsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			RaisePropertyChanged(() => TotalKillCount);
			RaisePropertyChanged(() => TotalKillSelectedAccountCount);
			RaisePropertyChanged(() => OneKillSelectedAccountCount);
			RaisePropertyChanged(() => TwoKillSelectedAccountCount);
			RaisePropertyChanged(() => ThreeKillSelectedAccountCount);
			RaisePropertyChanged(() => FourKillSelectedAccountCount);
			RaisePropertyChanged(() => FiveKillSelectedAccountCount);
			RaisePropertyChanged(() => ClutchCount);
			RaisePropertyChanged(() => ClutchSelectedAccountCount);
		}

		private void OnBombExplodedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			RaisePropertyChanged(() => BombExplodedCount);
			RaisePropertyChanged(() => BombExplodedSelectedAccountCount);
		}

		private void OnBombDefusedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			RaisePropertyChanged(() => BombDefusedCount);
			RaisePropertyChanged(() => BombDefusedSelectedAccountCount);
		}

		private void OnBombPlantedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			RaisePropertyChanged(() => BombPlantedCount);
			RaisePropertyChanged(() => BombPlantedSelectedAccountCount);
		}

		private void OnRoundsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (Settings.Default.SelectedStatsAccountSteamID != 0)
			{
				RaisePropertyChanged(() => TotalDamageHealthSelectedAccountCount);
				RaisePropertyChanged(() => TotalDamageArmorSelectedAccountCount);
				RaisePropertyChanged(() => AverageDamageSelectedAccountCount);
			}
			else
			{
				RaisePropertyChanged(() => TotalDamageHealthCount);
				RaisePropertyChanged(() => TotalDamageArmorCount);
				RaisePropertyChanged(() => AverageDamageCount);
			}
			RaisePropertyChanged(() => MostDamageWeapon);
			RaisePropertyChanged(() => WinStatus);
		}

		#endregion
	}
}
