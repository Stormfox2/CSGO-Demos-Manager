﻿using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Collections.Specialized;
using System.Globalization;
using Core.Models.Events;
using DemoInfo;
using GalaSoft.MvvmLight.Threading;

namespace Core.Models
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
		/// Demo's tick count
		/// </summary>
		private int _ticks;

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
		/// Win status for the selected account
		/// </summary>
		private string _winStatus;

		/// <summary>
		/// Total kill
		/// </summary>
		private int _killCount;

		/// <summary>
		/// Total clutch attempt
		/// </summary>
		private int _clutchCount;

		/// <summary>
		/// Total flashbang thrown
		/// </summary>
		private int _flashbangThrownCount;

		/// <summary>
		/// Total smoke grenade thrown
		/// </summary>
		private int _smokeThrownCount;

		/// <summary>
		/// Total HE Grenade thrown
		/// </summary>
		private int _heThrownCount;

		/// <summary>
		/// Total molotov thrown
		/// </summary>
		private int _molotovThrownCount;

		/// <summary>
		/// Total incendiary thrown
		/// </summary>
		private int _incendiaryThrownCount;

		/// <summary>
		/// Total decoy thrown
		/// </summary>
		private int _decoyThrownCount;

		/// <summary>
		/// Total trade kill
		/// </summary>
		private int _tradeKillCount;

		/// <summary>
		/// Total bomb planted
		/// </summary>
		private int _bombPlantedCount;

		/// <summary>
		/// Total bomb defused
		/// </summary>
		private int _bombDefusedCount;

		/// <summary>
		/// Total bomb exploded
		/// </summary>
		private int _bombExplodedCount;

		/// <summary>
		/// Total crouch kill
		/// </summary>
		private int _crouchKillCount;

		/// <summary>
		/// Total jump kill
		/// </summary>
		private int _jumpKillCount;

		/// <summary>
		/// Total shot fired
		/// </summary>
		private int _weaponFiredCount;

		/// <summary>
		/// Total hit given
		/// </summary>
		private int _hitCount;

		/// <summary>
		/// Total clutch won
		/// </summary>
		private int _clutchWonCount;

		/// <summary>
		/// Total clutch lost
		/// </summary>
		private int _clutchLostCount;

		/// <summary>
		/// Total HS
		/// </summary>
		private int _headshotCount;

		/// <summary>
		/// Total death
		/// </summary>
		private int _deathCount;

		/// <summary>
		/// Total assist
		/// </summary>
		private int _assistCount;

		/// <summary>
		/// Total entry kill
		/// </summary>
		private int _entryKillCount;

		/// <summary>
		/// Total MVP given
		/// </summary>
		private int _mvpCount;

		/// <summary>
		/// Total knife kill
		/// </summary>
		private int _knifeKillCount;

		/// <summary>
		/// Total team kill
		/// </summary>
		private int _teamKillCount;

		/// <summary>
		/// Total damage health done
		/// </summary>
		private int _damageHealthCount;

		/// <summary>
		/// Total damage armor done
		/// </summary>
		private int _damageArmorCount;

		/// <summary>
		/// Average kill per round
		/// </summary>
		private double _killPerRound;

		/// <summary>
		/// Average assist per round
		/// </summary>
		private double _assistPerRound;

		/// <summary>
		/// Average death per round
		/// </summary>
		private double _deathPerRound;

		/// <summary>
		/// Average damage health done each round
		/// </summary>
		private double _averageHealthDamage;

		/// <summary>
		/// Average HLTV ranking (AVG players)
		/// </summary>
		private float _averageHltvRating;

		/// <summary>
		/// Average ESEA RWS (AVG players)
		/// </summary>
		private decimal _averageEseaRws;

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
		private int _oneKillCount;

		/// <summary>
		/// Number of 2K during the match
		/// </summary>
		private int _twoKillCount;

		/// <summary>
		/// Number of 3K during the match
		/// </summary>
		private int _threeKillCount;

		/// <summary>
		/// Number of 4K during the match
		/// </summary>
		private int _fourKillCount;

		/// <summary>
		/// Number of 5K during the match
		/// </summary>
		private int _fiveKillCount;

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
		private Team _surrender;

		/// <summary>
		/// Winner of the match
		/// </summary>
		private Team _winner;

		/// <summary>
		/// List of rounds during the match
		/// </summary>
		private ObservableCollection<Round> _rounds;

		/// <summary>
		/// List of players who played during the match
		/// </summary>
		private ObservableCollection<Player> _players;

		/// <summary>
		/// Infos on bomb planted during the match
		/// </summary>
		private ObservableCollection<BombPlantedEvent> _bombPlanted;

		/// <summary>
		/// Infos on bomb defused during the match
		/// </summary>
		private ObservableCollection<BombDefusedEvent> _bombDefused;

		/// <summary>
		/// Infos on bomb exploded during the match
		/// </summary>
		private ObservableCollection<BombExplodedEvent> _bombExploded;

		/// <summary>
		/// Infos about players hurted event
		/// </summary>
		private ObservableCollection<PlayerHurtedEvent> _playersHurted;

		/// <summary>
		/// All kills during the match
		/// </summary>
		private ObservableCollection<KillEvent> _kills;

		/// <summary>
		/// All shots fired during the match
		/// </summary>
		private ObservableCollection<WeaponFireEvent> _weaponFired;

		/// <summary>
		/// Contains data about flashbangs which had blinded players
		/// </summary>
		private ObservableCollection<PlayerBlindedEvent> _playerBlinded;

		/// <summary>
		/// Demo's overtimes
		/// </summary>
		private ObservableCollection<Overtime> _overtimes;

		/// <summary>
		/// Contains all PositionPoint for overview generation
		/// </summary>
		private ObservableCollection<PositionPoint> _positionPoints;

		/// <summary>
		/// Decoy started events data
		/// </summary>
		private ObservableCollection<DecoyStartedEvent> _decoysStarted;

		/// <summary>
		/// Molotov fire started events data
		/// </summary>
		private ObservableCollection<MolotovFireStartedEvent> _molotovsFireStarted;

		/// <summary>
		/// Player with the best HS ratio
		/// </summary>
		private Player _mostHeadshotPlayer;

		/// <summary>
		/// Player with the most bomb planted
		/// </summary>
		private Player _mostBombPlantedPlayer;

		/// <summary>
		/// Player with the most entry kill
		/// </summary>
		private Player _mostEntryKillPlayer;

		/// <summary>
		/// Weapon with the most kills
		/// </summary>
		private Weapon _mostKillingWeapon;

		/// <summary>
		/// Counter-Terrorist team
		/// </summary>
		private Team _teamCt;

		/// <summary>
		/// Terrorit team
		/// </summary>
		private Team _teamT;

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

		[JsonProperty("source")]
		public string SourceName
		{
			get { return _sourceName; }
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

		[JsonProperty("ticks")]
		public int Ticks
		{
			get { return _ticks; }
			set { Set(() => Ticks, ref _ticks, value); }
		}

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

		[JsonProperty("score_team1")]
		public int ScoreTeam1
		{
			get { return _scoreTeam1; }
			set { Set(() => ScoreTeam1, ref _scoreTeam1, value); }
		}

		[JsonProperty("score_team2")]
		public int ScoreTeam2
		{
			get { return _scoreTeam2; }
			set { Set(() => ScoreTeam2, ref _scoreTeam2, value); }
		}

		[JsonProperty("score_half1_team1")]
		public int ScoreFirstHalfTeam1
		{
			get { return _scoreFirstHalfTeam1; }
			set { Set(() => ScoreFirstHalfTeam1, ref _scoreFirstHalfTeam1, value); }
		}

		[JsonProperty("score_half1_team2")]
		public int ScoreFirstHalfTeam2
		{
			get { return _scoreFirstHalfTeam2; }
			set { Set(() => ScoreFirstHalfTeam2, ref _scoreFirstHalfTeam2, value); }
		}

		[JsonProperty("score_half2_team1")]
		public int ScoreSecondHalfTeam1
		{
			get { return _scoreSecondHalfTeam1; }
			set { Set(() => ScoreSecondHalfTeam1, ref _scoreSecondHalfTeam1, value); }
		}

		[JsonProperty("score_half2_team2")]
		public int ScoreSecondHalfTeam2
		{
			get { return _scoreSecondHalfTeam2; }
			set { Set(() => ScoreSecondHalfTeam2, ref _scoreSecondHalfTeam2, value); }
		}

		[JsonProperty("5k_count")]
		public int FiveKillCount
		{
			get { return _fiveKillCount; }
			set { Set(() => FiveKillCount, ref _fiveKillCount, value); }
		}

		[JsonProperty("4k_count")]
		public int FourKillCount
		{
			get { return _fourKillCount; }
			set { Set(() => FourKillCount, ref _fourKillCount, value); }
		}

		[JsonProperty("3k_count")]
		public int ThreeKillCount
		{
			get { return _threeKillCount; }
			set { Set(() => ThreeKillCount, ref _threeKillCount, value); }
		}

		[JsonProperty("2k_count")]
		public int TwoKillCount
		{
			get { return _twoKillCount; }
			set { Set(() => TwoKillCount, ref _twoKillCount, value); }
		}

		[JsonProperty("1k_count")]
		public int OneKillCount
		{
			get { return _oneKillCount; }
			set { Set(() => OneKillCount, ref _oneKillCount, value); }
		}

		[JsonProperty("team_ct", IsReference = false)]
		public Team TeamCT
		{
			get { return _teamCt; }
			set { Set(() => TeamCT, ref _teamCt, value); }
		}

		[JsonProperty("team_t", IsReference = false)]
		public Team TeamT
		{
			get { return _teamT; }
			set { Set(() => TeamT, ref _teamT, value); }
		}

		[JsonProperty("team_surrender", IsReference = true)]
		public Team Surrender
		{
			get { return _surrender; }
			set
			{
				Set(() => Surrender, ref _surrender, value);
				RaisePropertyChanged(() => Surrender);
			}
		}

		[JsonProperty("team_winner", IsReference = true)]
		public Team Winner
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
		public ObservableCollection<Player> Players
		{
			get { return _players; }
			set { Set(() => Players, ref _players, value); }
		}

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

		[JsonProperty("most_headshot_player", IsReference = true)]
		public Player MostHeadshotPlayer
		{
			get { return _mostHeadshotPlayer; }
			set { Set(() => MostHeadshotPlayer, ref _mostHeadshotPlayer, value); }
		}

		[JsonProperty("most_bomb_planted_player", IsReference = true)]
		public Player MostBombPlantedPlayer
		{
			get { return _mostBombPlantedPlayer; }
			set { Set(() => MostBombPlantedPlayer, ref _mostBombPlantedPlayer, value); }
		}

		[JsonProperty("most_entry_kill", IsReference = true)]
		public Player MostEntryKillPlayer
		{
			get { return _mostEntryKillPlayer; }
			set { Set(() => MostEntryKillPlayer, ref _mostEntryKillPlayer, value); }
		}

		[JsonProperty("bomb_planted", IsReference = false)]
		public ObservableCollection<BombPlantedEvent> BombPlanted
		{
			get { return _bombPlanted; }
			set { Set(() => BombPlanted, ref _bombPlanted, value); }
		}

		[JsonProperty("bomb_defused", IsReference = false)]
		public ObservableCollection<BombDefusedEvent> BombDefused
		{
			get { return _bombDefused; }
			set { Set(() => BombDefused, ref _bombDefused, value); }
		}

		[JsonProperty("bomb_exploded", IsReference = false)]
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

		[JsonProperty("weapon_fired", IsReference = false)]
		public ObservableCollection<WeaponFireEvent> WeaponFired
		{
			get { return _weaponFired; }
			set { Set(() => WeaponFired, ref _weaponFired, value); }
		}

		[JsonProperty("player_blinded_events", IsReference = false)]
		public ObservableCollection<PlayerBlindedEvent> PlayerBlinded
		{
			get { return _playerBlinded; }
			set { Set(() => PlayerBlinded, ref _playerBlinded, value); }
		}

		[JsonProperty("player_hurted", IsReference = false)]
		public ObservableCollection<PlayerHurtedEvent> PlayersHurted
		{
			get { return _playersHurted; }
			set { Set(() => PlayersHurted, ref _playersHurted, value); }
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

		[JsonIgnore]
		public string DurationTime => TimeSpan.FromSeconds(_duration).ToString(@"hh\:mm\:ss");

		[JsonProperty("kill_count")]
		public int KillCount {
			get { return _killCount; }
			set
			{
				Set(() => KillCount, ref _killCount, value);
			}
		}

		[JsonProperty("clutch_count")]
		public int ClutchCount
		{
			get { return _clutchCount; }
			set { Set(() => ClutchCount, ref _clutchCount, value); }
		}

		[JsonProperty("trade_kill_count")]
		public int TradeKillCount
		{
			get { return _tradeKillCount; }
			set { Set(() => TradeKillCount, ref _tradeKillCount, value); }
		}

		[JsonProperty("bomb_defused_count")]
		public int BombDefusedCount
		{
			get { return _bombDefusedCount; }
			set { Set(() => BombDefusedCount, ref _bombDefusedCount, value); }
		}

		[JsonProperty("bomb_planted_count")]
		public int BombPlantedCount
		{
			get { return _bombPlantedCount; }
			set { Set(() => BombPlantedCount, ref _bombPlantedCount, value); }
		}

		[JsonProperty("bomb_exploded_count")]
		public int BombExplodedCount
		{
			get { return _bombExplodedCount; }
			set { Set(() => BombExplodedCount, ref _bombExplodedCount, value); }
		}

		[JsonProperty("flashbang_thrown_count")]
		public int FlashbangThrownCount
		{
			get { return _flashbangThrownCount; }
			set { Set(() => FlashbangThrownCount, ref _flashbangThrownCount, value); }
		}

		[JsonProperty("smoke_thrown_count")]
		public int SmokeThrownCount
		{
			get { return _smokeThrownCount; }
			set { Set(() => SmokeThrownCount, ref _smokeThrownCount, value); }
		}

		[JsonProperty("he_thrown_count")]
		public int HeThrownCount
		{
			get { return _heThrownCount; }
			set { Set(() => HeThrownCount, ref _heThrownCount, value); }
		}

		[JsonProperty("decoy_thrown_count")]
		public int DecoyThrownCount
		{
			get { return _decoyThrownCount; }
			set { Set(() => DecoyThrownCount, ref _decoyThrownCount, value); }
		}

		[JsonProperty("molotov_thrown_count")]
		public int MolotovThrownCount
		{
			get { return _molotovThrownCount; }
			set { Set(() => MolotovThrownCount, ref _molotovThrownCount, value); }
		}

		[JsonProperty("incendiary_thrown_count")]
		public int IncendiaryThrownCount
		{
			get { return _incendiaryThrownCount; }
			set { Set(() => IncendiaryThrownCount, ref _incendiaryThrownCount, value); }
		}

		[JsonIgnore]
		public string WinStatus
		{
			get { return _winStatus; }
			set { Set(() => WinStatus, ref _winStatus, value); }
		}

		[JsonIgnore]
		public ObservableCollection<PositionPoint> PositionPoints
		{
			get { return _positionPoints; }
			set { Set(() => PositionPoints, ref _positionPoints, value); }
		}

		[JsonProperty("decoys")]
		public ObservableCollection<DecoyStartedEvent> DecoyStarted
		{
			get { return _decoysStarted; }
			set { Set(() => DecoyStarted, ref _decoysStarted, value); }
		}

		[JsonProperty("molotovs")]
		public ObservableCollection<MolotovFireStartedEvent> MolotovsFireStarted
		{
			get { return _molotovsFireStarted; }
			set { Set(() => MolotovsFireStarted, ref _molotovsFireStarted, value); }
		}

		[JsonProperty("damage_health_count")]
		public int DamageHealthCount
		{
			get { return _damageHealthCount; }
			set { Set(() => DamageHealthCount, ref _damageHealthCount, value); }
		}

		[JsonProperty("damage_armor_count")]
		public int DamageArmorCount
		{
			get { return _damageArmorCount; }
			set { Set(() => DamageArmorCount, ref _damageArmorCount, value); }
		}

		[JsonIgnore]
		public Weapon MostDamageWeapon
		{
			get
			{
				Dictionary<Weapon, int> weapons = new Dictionary<Weapon, int>();

				foreach (PlayerHurtedEvent playerHurtedEvent in Rounds.SelectMany(round => round.PlayersHurted))
				{
					if (!weapons.ContainsKey(playerHurtedEvent.Weapon))
						weapons[playerHurtedEvent.Weapon] = playerHurtedEvent.HealthDamage + playerHurtedEvent.ArmorDamage;
					else
						weapons[playerHurtedEvent.Weapon] += playerHurtedEvent.HealthDamage + playerHurtedEvent.ArmorDamage;
				}

				return weapons.OrderByDescending(x => x.Value).FirstOrDefault().Key;
			}
		}

		[JsonProperty("average_health_damage")]
		public double AverageHealthDamage
		{
			get { return _averageHealthDamage; }
			set { Set(() => AverageHealthDamage, ref _averageHealthDamage, value); }
		}

		[JsonProperty("kill_per_round")]
		public double KillPerRound
		{
			get { return _killPerRound; }
			set { Set(() => KillPerRound, ref _killPerRound, value); }
		}

		[JsonProperty("assist_per_round")]
		public double AssistPerRound
		{
			get { return _assistPerRound; }
			set { Set(() => AssistPerRound, ref _assistPerRound, value); }
		}

		[JsonProperty("jump_kill_count")]
		public int JumpKillCount
		{
			get { return _jumpKillCount; }
			set { Set(() => JumpKillCount, ref _jumpKillCount, value); }
		}

		[JsonProperty("crouch_kill_count")]
		public int CrouchKillCount
		{
			get { return _crouchKillCount; }
			set { Set(() => CrouchKillCount, ref _crouchKillCount, value); }
		}

		[JsonProperty("headshot_count")]
		public int HeadshotCount
		{
			get { return _headshotCount; }
			set { Set(() => HeadshotCount, ref _headshotCount, value); }
		}

		[JsonProperty("death_count")]
		public int DeathCount
		{
			get { return _deathCount; }
			set { Set(() => DeathCount, ref _deathCount, value); }
		}

		[JsonProperty("assist_count")]
		public int AssistCount
		{
			get { return _assistCount; }
			set { Set(() => AssistCount, ref _assistCount, value); }
		}

		[JsonProperty("entry_kill_count")]
		public int EntryKillCount
		{
			get { return _entryKillCount; }
			set { Set(() => EntryKillCount, ref _entryKillCount, value); }
		}

		[JsonProperty("knife_kill_count")]
		public int KnifeKillCount
		{
			get { return _knifeKillCount; }
			set { Set(() => KnifeKillCount, ref _knifeKillCount, value); }
		}

		[JsonProperty("mvp_count")]
		public int MvpCount
		{
			get { return _mvpCount; }
			set { Set(() => MvpCount, ref _mvpCount, value); }
		}

		[JsonProperty("teamkill_count")]
		public int TeamKillCount
		{
			get { return _teamKillCount; }
			set { Set(() => TeamKillCount, ref _teamKillCount, value); }
		}

		[JsonProperty("death_per_round")]
		public double DeathPerRound
		{
			get { return _deathPerRound; }
			set { Set(() => DeathPerRound, ref _deathPerRound, value); }
		}

		[JsonProperty("clutch_lost_count")]
		public int ClutchLostCount
		{
			get { return _clutchLostCount; }
			set { Set(() => ClutchLostCount, ref _clutchLostCount, value); }
		}

		[JsonProperty("clutch_won_count")]
		public int ClutchWonCount
		{
			get { return _clutchWonCount; }
			set { Set(() => ClutchWonCount, ref _clutchWonCount, value); }
		}

		[JsonProperty("shot_count")]
		public int WeaponFiredCount
		{
			get { return _weaponFiredCount; }
			set { Set(() => WeaponFiredCount, ref _weaponFiredCount, value); }
		}

		[JsonProperty("hit_count")]
		public int HitCount
		{
			get { return _hitCount; }
			set { Set(() => HitCount, ref _hitCount, value); }
		}

		[JsonProperty("average_hltv_rating")]
		public float AverageHltvRating
		{
			get { return _averageHltvRating; }
			set { Set(() => AverageHltvRating, ref _averageHltvRating, value); }
		}

		[JsonProperty("average_esea_rws")]
		public decimal AverageEseaRws
		{
			get { return _averageEseaRws; }
			set { Set(() => AverageEseaRws, ref _averageEseaRws, value); }
		}

		#endregion

		public Demo()
		{
			Kills =new ObservableCollection<KillEvent>();
			Players = new ObservableCollection<Player>();
			Rounds = new ObservableCollection<Round>();
			MolotovsFireStarted = new ObservableCollection<MolotovFireStartedEvent>();
			DecoyStarted = new ObservableCollection<DecoyStartedEvent>();
			WeaponFired = new ObservableCollection<WeaponFireEvent>();
			PlayersHurted = new ObservableCollection<PlayerHurtedEvent>();
			PositionPoints = new ObservableCollection<PositionPoint>();
			BombExploded = new ObservableCollection<BombExplodedEvent>();
			BombPlanted = new ObservableCollection<BombPlantedEvent>();
			BombDefused = new ObservableCollection<BombDefusedEvent>();
			PlayerBlinded = new ObservableCollection<PlayerBlindedEvent>();
			Overtimes = new ObservableCollection<Overtime>();

			_teamCt = new Team
			{
				Name = "Team 1"
			};
			_teamT = new Team
			{
				Name = "Team 2"
			};
			Kills.CollectionChanged += OnKillsCollectionChanged;
			BombExploded.CollectionChanged += OnBombExplodedCollectionChanged;
			BombDefused.CollectionChanged += OnBombDefusedCollectionChanged;
			BombPlanted.CollectionChanged += OnBombPlantedCollectionChanged;
			Rounds.CollectionChanged += OnRoundsCollectionChanged;
			PlayersHurted.CollectionChanged += OnPlayersHurtedCollectionChanged;
			WeaponFired.CollectionChanged += OnWeaponFireCollectionChanged;
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
			DispatcherHelper.CheckBeginInvokeOnUI(delegate
				{
					AverageHealthDamage = 0;
					AverageHltvRating = 0;
					AverageEseaRws = 0;
					AssistPerRound = 0;
					DeathPerRound = 0;
					KillPerRound = 0;
					DamageHealthCount = 0;
					DamageArmorCount = 0;
					MvpCount = 0;
					KillCount = 0;
					KnifeKillCount = 0;
					TeamKillCount = 0;
					HeadshotCount = 0;
					AssistCount = 0;
					DeathCount = 0;
					SmokeThrownCount = 0;
					FlashbangThrownCount = 0;
					HeadshotCount = 0;
					DecoyThrownCount = 0;
					MolotovThrownCount = 0;
					IncendiaryThrownCount = 0;
					HitCount = 0;
					WeaponFiredCount = 0;
					AssistPerRound = 0;
					DeathPerRound = 0;
					OneKillCount = 0;
					TwoKillCount = 0;
					ThreeKillCount = 0;
					FourKillCount = 0;
					FiveKillCount = 0;
					ScoreTeam1 = 0;
					ScoreTeam2 = 0;
					ScoreFirstHalfTeam1 = 0;
					ScoreFirstHalfTeam2 = 0;
					ScoreSecondHalfTeam1 = 0;
					ScoreSecondHalfTeam2 = 0;
					Rounds.Clear();
					WeaponFired.Clear();
					Kills.Clear();
					Overtimes.Clear();
					PositionPoints.Clear();
					MolotovsFireStarted.Clear();
					DecoyStarted.Clear();
					BombPlanted.Clear();
					BombDefused.Clear();
					BombExploded.Clear();
					BombPlanted.Clear();
					BombDefused.Clear();
					BombExploded.Clear();
					ClutchCount = 0;
					ClutchLostCount = 0;
					ClutchWonCount = 0;
					EntryKillCount = 0;
					MostBombPlantedPlayer = null;
					MostEntryKillPlayer = null;
					MostHeadshotPlayer = null;
					MostKillingWeapon = null;
					HasCheater = false;
					PlayersHurted.Clear();
					PlayerBlinded.Clear();
					Winner = null;
					Surrender = null;
					if (resetTeams)
					{
						Players.Clear();
						TeamCT.Clear();
						TeamT.Clear();
					}
					else
					{
						foreach (Player playerExtended in Players)
						{
							playerExtended.ResetStats();
						}
					}
				});
		}

		/// <summary>
		/// Return the path to the demo's .vdm file
		/// </summary>
		/// <returns></returns>
		public string GetVdmFilePath()
		{
			return Path.Substring(0, Path.Length - 3) + "vdm";
		}

		#region Handler collections changed

		private void OnKillsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			KillCount = Kills.Count;
			DeathCount = Kills.Count;
			TradeKillCount = Kills.Count(k => k.IsTradeKill);
			HeadshotCount = Kills.Count(k => k.IsHeadshot);
			EntryKillCount = Players.Sum(p => p.EntryKills.Count);
			CrouchKillCount = Players.Sum(p => p.CrouchKillCount);
			AssistCount = Kills.Count(k => k.AssisterSteamId != 0);
			JumpKillCount = Kills.Count(killEvent => killEvent.KillerVelocityZ > 0);
			KnifeKillCount = Kills.Count(killEvent => killEvent.Weapon.Element == EquipmentElement.Knife);
			TeamKillCount = Players.Sum(p => p.TeamKillCount);
		}

		private void OnBombExplodedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			BombExplodedCount = BombExploded.Count;
		}

		private void OnBombDefusedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			BombDefusedCount = BombDefused.Count;
		}

		private void OnBombPlantedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			BombPlantedCount = BombPlanted.Count;
		}

		private void OnRoundsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			RaisePropertyChanged(() => MostDamageWeapon);
			RaisePropertyChanged(() => WinStatus);

			ClutchWonCount = Players.Sum(p => p.ClutchWonCount);
			ClutchCount = Players.Sum(p => p.ClutchCount);
			ClutchLostCount = Players.Sum(p => p.ClutchLostCount);

			if (Rounds.Any())
			{
				KillPerRound = GetKillPerRound();
				DeathPerRound = GetKillPerRound();
				AssistPerRound = GetAssistPerRound();
				MvpCount = Players.Sum(p => p.RoundMvpCount);
				DeathPerRound = Math.Round((double)DeathCount / Rounds.Count, 2);
			}

			if (Players.Any())
			{
				float totalHltv = Players.Sum(player => player.RatingHltv);
				AverageHltvRating = totalHltv / Players.Count;
				decimal totalEseaRws = Players.Sum(player => player.EseaRws);
				AverageEseaRws = Math.Round(totalEseaRws / Players.Count, 2);
			}
		}

		private void OnPlayersHurtedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			DamageArmorCount = PlayersHurted.Sum(h => h.ArmorDamage);
			DamageHealthCount = PlayersHurted.Sum(h => h.HealthDamage);
			HitCount = PlayersHurted.Count;
			if (Rounds.Any())
			{
				AverageHealthDamage = GetAverageHealthDamage();
			}
		}

		private void OnWeaponFireCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			WeaponFiredCount = WeaponFired.Count;
			FlashbangThrownCount = WeaponFired.Count(w => w.Weapon.Element == EquipmentElement.Flash);
			SmokeThrownCount = WeaponFired.Count(w => w.Weapon.Element == EquipmentElement.Smoke);
			HeThrownCount = WeaponFired.Count(w => w.Weapon.Element == EquipmentElement.HE);
			DecoyThrownCount = WeaponFired.Count(w => w.Weapon.Element == EquipmentElement.Decoy);
			MolotovThrownCount = WeaponFired.Count(w => w.Weapon.Element == EquipmentElement.Molotov);
			IncendiaryThrownCount = WeaponFired.Count(w => w.Weapon.Element == EquipmentElement.Incendiary);
		}

		#endregion

		private double GetKillPerRound()
		{
			double total = Rounds.Aggregate<Round, double>(0, (current, round) => current + round.KillCount);
			total = Math.Round(total / Rounds.Count, 2);
			if (Math.Abs(total) < 0.1) return total;
			return total;
		}

		private double GetAssistPerRound()
		{
			double total = Rounds.Aggregate<Round, double>(0, (current, round) => current + round.Kills.Count(k => k.AssisterSteamId != 0));
			total = Math.Round(total / Rounds.Count, 2);
			if (Math.Abs(total) < 0.1) return total;
			return total;
		}

		private double GetAverageHealthDamage()
		{
			double total = Rounds.Where(round => round.PlayersHurted.Any()).SelectMany(
						round => round.PlayersHurted).Aggregate<PlayerHurtedEvent, double>(0, (current, playerHurtedEvent) =>
						current + playerHurtedEvent.HealthDamage);

			if (Math.Abs(total) < 0.1) return total;
			total = Math.Round(total / Rounds.Count, 1);
			return total;
		}
	}
}
