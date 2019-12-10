using DamageCalculator.Util;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Data;
using DamageCalculator.Entity;
using System.Windows.Input;
using System.Windows.Controls;
using System;

namespace DamageCalculator.ViewModel
{
    public class MainPageVM : NotificationBase
    {
        #region private atk_Status
        private string atkName = "";
        private string atkType1 = "";
        private string atkType2 = "";
        private string atkType1_Color = "";
        private string atkType2_Color = "";
        private int atkLV = ConstDef.LV50;
        private bool atkLV50 = true;
        private int atknatureIndex = 1;

        private string atkH_Width = "0";
        private string atkA_Width = "0";
        private string atkB_Width = "0";
        private string atkC_Width = "0";
        private string atkD_Width = "0";
        private string atkS_Width = "0";

        private int atkH_Base = 0;
        private int atkA_Base = 0;
        private int atkB_Base = 0;
        private int atkC_Base = 0;
        private int atkD_Base = 0;
        private int atkS_Base = 0;

        private int atkH;
        private int atkA;
        private int atkB;
        private int atkC;
        private int atkD;
        private int atkS;
        #endregion
        #region private atk_EV
        private int atkH_EV = ConstDef.EV;
        private int atkA_EV = ConstDef.EV;
        private int atkB_EV = ConstDef.EV;
        private int atkC_EV = ConstDef.EV;
        private int atkD_EV = ConstDef.EV;
        private int atkS_EV = ConstDef.EV;
        #endregion
        #region private atk_Rank
        private int atkA_Rank;
        private int atkB_Rank;
        private int atkC_Rank;
        private int atkD_Rank;
        private int atkS_Rank;
        private List<int> atkA_RankList;
        private List<int> atkB_RankList;
        private List<int> atkC_RankList;
        private List<int> atkD_RankList;
        private List<int> atkS_RankList;
        private int atkA_RankIndex = 6;
        private int atkB_RankIndex = 6;
        private int atkC_RankIndex = 6;
        private int atkD_RankIndex = 6;
        private int atkS_RankIndex = 6;
        #endregion
        #region private def_Status
        private string defName = "";
        private string defType1 = "";
        private string defType2 = "";
        private string defType1_Color = "";
        private string defType2_Color = "";
        private int defLV = ConstDef.LV50;
        private bool defLV50 = true;
        private int defnatureIndex = 4;

        private string defH_Width = "0";
        private string defA_Width = "0";
        private string defB_Width = "0";
        private string defC_Width = "0";
        private string defD_Width = "0";
        private string defS_Width = "0";

        private int defH_Base = 0;
        private int defA_Base = 0;
        private int defB_Base = 0;
        private int defC_Base = 0;
        private int defD_Base = 0;
        private int defS_Base = 0;

        private int defH;
        private int defA;
        private int defB;
        private int defC;
        private int defD;
        private int defS;
        #endregion
        #region private def_EV
        private int defH_EV = ConstDef.EV;
        private int defA_EV = ConstDef.EV;
        private int defB_EV = ConstDef.EV;
        private int defC_EV = ConstDef.EV;
        private int defD_EV = ConstDef.EV;
        private int defS_EV = ConstDef.EV;
        #endregion
        #region private def_Rank
        private int defA_Rank;
        private int defB_Rank;
        private int defC_Rank;
        private int defD_Rank;
        private int defS_Rank;
        private List<int> defA_RankList;
        private List<int> defB_RankList;
        private List<int> defC_RankList;
        private List<int> defD_RankList;
        private List<int> defS_RankList;
        private int defA_RankIndex = 6;
        private int defB_RankIndex = 6;
        private int defC_RankIndex = 6;
        private int defD_RankIndex = 6;
        private int defS_RankIndex = 6;
        #endregion
        #region private Move
        private string moveName = "";
        private string moveType = "";
        private string moveType_Color = "";
        private int movePow = 0;
        private string moveCat = "";
        private string affinity = "";
        private bool isDM = false;
        private int beforePow = 0;
        #endregion
        #region private Damage
        private string dmgtext = "";
        private string critext = "";
        private string dmgDMtext = "";
        private string criDMtext = "";

        private string minDmgWidth = "250";
        private string maxDmgWidth = "250";
        private string minCriWidth = "250";
        private string maxCriWidth = "250";
        private string minDmgDMWidth = "250";
        private string maxDmgDMWidth = "250";
        private string minCriDMWidth = "250";
        private string maxCriDMWidth = "250";

        private string minDmgColor = "#228B22";
        private string maxDmgColor = "#32CD32";
        private string minCriColor = "#228B22";
        private string maxCriColor = "#32CD32";
        private string minDmgDMColor = "#228B22";
        private string maxDmgDMColor = "#32CD32";
        private string minCriDMColor = "#228B22";
        private string maxCriDMColor = "#32CD32";
        #endregion

        public Dictionary<string, Pokemon> PokeDic { get; set; }
        public Dictionary<string, Nature> ATKNatureDic { get; set; }
        public Dictionary<string, Nature> DEFNatureDic { get; set; }
        public Dictionary<string, Move> MoveDic { get; set; }

        #region public ATK_Status
        public string ATKName
        {
            get { return this.atkName; }
            set
            {
                if (this.PokeDic.ContainsKey(value))
                {
                    this.SetProperty(ref this.atkName, value);
                    SetATKStatus(this.ATKName);
                }
                else
                {
                    this.SetProperty(ref this.atkName, this.atkName);
                }
            }
        }
        public string ATKType1
        {
            get { return this.atkType1; }
            set 
            {
                this.SetProperty(ref this.atkType1, value);
                this.ATKType1_Color = GetTypeColor(value);
            }
        }
        public string ATKType2
        {
            get { return this.atkType2; }
            set 
            {
                this.SetProperty(ref this.atkType2, value); 
                this.ATKType2_Color = GetTypeColor(value);
            }
        }
        public string ATKType1_Color
        {
            get { return this.atkType1_Color; }
            set { this.SetProperty(ref this.atkType1_Color, value); }
        }
        public string ATKType2_Color
        {
            get { return this.atkType2_Color; }
            set { this.SetProperty(ref this.atkType2_Color, value); }
        }
        public int ATKLV
        {
            get { return this.atkLV; }
            set
            {
                this.SetProperty(ref this.atkLV, value);
                SetATKStatus(this.ATKName);
            }
        }
        public bool ATKLV50
        {
            get { return this.atkLV50; }
            set
            {
                this.SetProperty(ref this.atkLV50, value);
                if (this.atkLV50 == true)
                {
                    this.ATKLV = 50;
                }
                else
                {
                    this.ATKLV = 100;
                }
            }
        }
        public int ATKNatureIndex
        {
            get { return this.atknatureIndex; }
            set 
            {
                this.SetProperty(ref this.atknatureIndex, value);
                SetATKStatus(this.ATKName);
            }
        }
        
        public string ATKH_Width
        {
            get { return this.atkH_Width; }
            set { this.SetProperty(ref this.atkH_Width, value); }
        }
        public string ATKA_Width
        {
            get { return this.atkA_Width; }
            set { this.SetProperty(ref this.atkA_Width, value); }
        }
        public string ATKB_Width
        {
            get { return this.atkB_Width; }
            set { this.SetProperty(ref this.atkB_Width, value); }
        }
        public string ATKC_Width
        {
            get { return this.atkC_Width; }
            set { this.SetProperty(ref this.atkC_Width, value); }
        }
        public string ATKD_Width
        {
            get { return this.atkD_Width; }
            set { this.SetProperty(ref this.atkD_Width, value); }
        }
        public string ATKS_Width
        {
            get { return this.atkS_Width; }
            set { this.SetProperty(ref this.atkS_Width, value); }
        }

        public int ATKH_Base
        {
            get { return this.atkH_Base; }
            set { this.SetProperty(ref this.atkH_Base, value); }
        }
        public int ATKA_Base
        {
            get { return this.atkA_Base; }
            set { this.SetProperty(ref this.atkA_Base, value); }
        }
        public int ATKB_Base
        {
            get { return this.atkB_Base; }
            set { this.SetProperty(ref this.atkB_Base, value); }
        }
        public int ATKC_Base
        {
            get { return this.atkC_Base; }
            set { this.SetProperty(ref this.atkC_Base, value); }
        }
        public int ATKD_Base
        {
            get { return this.atkD_Base; }
            set { this.SetProperty(ref this.atkD_Base, value); }
        }
        public int ATKS_Base
        {
            get { return this.atkS_Base; }
            set { this.SetProperty(ref this.atkS_Base, value); }
        }

        public int ATKH
        {
            get { return this.atkH; }
            set 
            {
                this.SetProperty(ref this.atkH, value);
                this.ATKH_Width = CalcHWidth(this.ATKLV, value);
            }
        }
        public int ATKA
        {
            get { return this.atkA; }
            set
            {
                this.SetProperty(ref this.atkA, value);
                this.ATKA_Width = CalcABCDSWidth(this.ATKLV, value);
            }
        }
        public int ATKB
        {
            get { return this.atkB; }
            set 
            {
                this.SetProperty(ref this.atkB, value); 
                this.ATKB_Width = CalcABCDSWidth(this.ATKLV, value);
            }
        }
        public int ATKC
        {
            get { return this.atkC; }
            set
            {
                this.SetProperty(ref this.atkC, value);
                this.ATKC_Width = CalcABCDSWidth(this.ATKLV, value);
            }
        }
        public int ATKD
        {
            get { return this.atkD; }
            set 
            {
                this.SetProperty(ref this.atkD, value); 
                this.ATKD_Width = CalcABCDSWidth(this.ATKLV, value);
            }
        }
        public int ATKS
        {
            get { return this.atkS; }
            set 
            {
                this.SetProperty(ref this.atkS, value); 
                this.ATKS_Width = CalcABCDSWidth(this.ATKLV, value);
            }
        }
        #endregion
        #region public ATK_EV
        public int ATKH_EV
        {
            get { return this.atkH_EV; }
            set
            {
                if (0 <= value && value <= 252 && value % 4 == 0)
                {
                    this.SetProperty(ref this.atkH_EV, value);
                    SetATKStatus(this.ATKName);
                }
                else
                {
                    this.SetProperty(ref this.atkH_EV, this.atkH_EV);
                }
            }
        }
        public int ATKA_EV
        {
            get { return this.atkA_EV; }
            set
            {
                if (0 <= value && value <= 252 && value % 4 == 0)
                {
                    this.SetProperty(ref this.atkA_EV, value);
                    SetATKStatus(this.ATKName);
                }
                else
                {
                    this.SetProperty(ref this.atkA_EV, this.atkA_EV);
                }
            }
        }
        public int ATKB_EV
        {
            get { return this.atkB_EV; }
            set
            {
                if (0 <= value && value <= 252 && value % 4 == 0)
                {
                    this.SetProperty(ref this.atkB_EV, value);
                    SetATKStatus(this.ATKName);
                }
                else
                {
                    this.SetProperty(ref this.atkB_EV, this.atkB_EV);
                }
            }
        }
        public int ATKC_EV
        {
            get { return this.atkC_EV; }
            set
            {
                if (0 <= value && value <= 252 && value % 4 == 0)
                {
                    this.SetProperty(ref this.atkC_EV, value);
                    SetATKStatus(this.ATKName);
                }
                else
                {
                    this.SetProperty(ref this.atkC_EV, this.atkC_EV);
                }
            }
        }
        public int ATKD_EV
        {
            get { return this.atkD_EV; }
            set
            {
                if (0 <= value && value <= 252 && value % 4 == 0)
                {
                    this.SetProperty(ref this.atkD_EV, value);
                    SetATKStatus(this.ATKName);
                }
                else
                {
                    this.SetProperty(ref this.atkD_EV, this.atkD_EV);
                }
            }
        }
        public int ATKS_EV
        {
            get { return this.atkS_EV; }
            set
            {
                if (0 <= value && value <= 252 && value % 4 == 0)
                {
                    this.SetProperty(ref this.atkS_EV, value);
                    SetATKStatus(this.ATKName);
                }
                else
                {
                    this.SetProperty(ref this.atkS_EV, this.atkS_EV);
                }
            }
        }
        #endregion
        #region public ATK_Rank
        public int ATKA_Rank
        {
            get { return this.atkA_Rank; }
            set
            {
                this.SetProperty(ref this.atkA_Rank, value);
                SetATKStatus(this.ATKName);
            }
        }
        public int ATKB_Rank
        {
            get { return this.atkB_Rank; }
            set
            {
                this.SetProperty(ref this.atkB_Rank, value);
                SetATKStatus(this.ATKName);
            }
        }
        public int ATKC_Rank
        {
            get { return this.atkC_Rank; }
            set
            {
                this.SetProperty(ref this.atkC_Rank, value);
                SetATKStatus(this.ATKName);
            }
        }
        public int ATKD_Rank
        {
            get { return this.atkD_Rank; }
            set
            {
                this.SetProperty(ref this.atkD_Rank, value);
                SetATKStatus(this.ATKName);
            }
        }
        public int ATKS_Rank
        {
            get { return this.atkS_Rank; }
            set
            {
                this.SetProperty(ref this.atkS_Rank, value);
                SetATKStatus(this.ATKName);
            }
        }
        public List<int> ATKA_RankList
        {
            get { return this.atkA_RankList; }
            set { this.SetProperty(ref this.atkA_RankList, value); }
        }
        public List<int> ATKB_RankList
        {
            get { return this.atkB_RankList; }
            set { this.SetProperty(ref this.atkB_RankList, value); }
        }
        public List<int> ATKC_RankList
        {
            get { return this.atkC_RankList; }
            set { this.SetProperty(ref this.atkC_RankList, value); }
        }
        public List<int> ATKD_RankList
        {
            get { return this.atkD_RankList; }
            set { this.SetProperty(ref this.atkD_RankList, value); }
        }
        public List<int> ATKS_RankList
        {
            get { return this.atkS_RankList; }
            set { this.SetProperty(ref this.atkS_RankList, value); }
        }
        public int ATKA_RankIndex
        {
            get { return this.atkA_RankIndex; }
            set
            {
                this.SetProperty(ref this.atkA_RankIndex, value);
                var rank = 6 - value;
                this.ATKA_Rank = rank;
            }
        }
        public int ATKB_RankIndex
        {
            get { return this.atkB_RankIndex; }
            set
            {
                this.SetProperty(ref this.atkB_RankIndex, value);
                var rank = 6 - value;
                this.ATKB_Rank = rank;
            }
        }
        public int ATKC_RankIndex
        {
            get { return this.atkC_RankIndex; }
            set
            {
                this.SetProperty(ref this.atkC_RankIndex, value);
                var rank = 6 - value;
                this.ATKC_Rank = rank;
            }
        }
        public int ATKD_RankIndex
        {
            get { return this.atkD_RankIndex; }
            set
            {
                this.SetProperty(ref this.atkD_RankIndex, value);
                var rank = 6 - value;
                this.ATKD_Rank = rank;
            }
        }
        public int ATKS_RankIndex
        {
            get { return this.atkS_RankIndex; }
            set
            {
                this.SetProperty(ref this.atkS_RankIndex, value);
                var rank = 6 - value;
                this.ATKS_Rank = rank;
            }
        }
        #endregion
        #region public DEF_Status
        public string DEFName
        {
            get { return this.defName; }
            set
            {
                if (this.PokeDic.ContainsKey(value))
                {
                    this.SetProperty(ref this.defName, value);
                    SetDEFStatus(this.DEFName);
                }
                else
                {
                    this.SetProperty(ref this.defName, this.defName);
                }
            }
        }
        public string DEFType1
        {
            get { return this.defType1; }
            set 
            {
                this.SetProperty(ref this.defType1, value); 
                this.DEFType1_Color = GetTypeColor(value);
            }
        }
        public string DEFType2
        {
            get { return this.defType2; }
            set
            {
                this.SetProperty(ref this.defType2, value); 
                this.DEFType2_Color = GetTypeColor(value);
            }
        }
        public string DEFType1_Color
        {
            get { return this.defType1_Color; }
            set { this.SetProperty(ref this.defType1_Color, value); }
        }
        public string DEFType2_Color
        {
            get { return this.defType2_Color; }
            set { this.SetProperty(ref this.defType2_Color, value); }
        }
        public int DEFLV
        {
            get { return this.defLV; }
            set
            {
                this.SetProperty(ref this.defLV, value);
                SetDEFStatus(this.DEFName);
            }
        }
        public bool DEFLV50
        {
            get { return this.defLV50; }
            set
            {
                this.SetProperty(ref this.defLV50, value);
                if (this.defLV50 == true)
                {
                    this.DEFLV = 50;
                }
                else
                {
                    this.DEFLV = 100;
                }
            }
        }
        public int DEFNatureIndex
        {
            get { return this.defnatureIndex; }
            set
            {
                this.SetProperty(ref this.defnatureIndex, value);
                SetDEFStatus(this.DEFName);
            }
        }

        public string DEFH_Width
        {
            get { return this.defH_Width; }
            set { this.SetProperty(ref this.defH_Width, value); }
        }
        public string DEFA_Width
        {
            get { return this.defA_Width; }
            set { this.SetProperty(ref this.defA_Width, value); }
        }
        public string DEFB_Width
        {
            get { return this.defB_Width; }
            set { this.SetProperty(ref this.defB_Width, value); }
        }
        public string DEFC_Width
        {
            get { return this.defC_Width; }
            set { this.SetProperty(ref this.defC_Width, value); }
        }
        public string DEFD_Width
        {
            get { return this.defD_Width; }
            set { this.SetProperty(ref this.defD_Width, value); }
        }
        public string DEFS_Width
        {
            get { return this.defS_Width; }
            set { this.SetProperty(ref this.defS_Width, value); }
        }

        public int DEFH_Base
        {
            get { return this.defH_Base; }
            set { this.SetProperty(ref this.defH_Base, value); }
        }
        public int DEFA_Base
        {
            get { return this.defA_Base; }
            set { this.SetProperty(ref this.defA_Base, value); }
        }
        public int DEFB_Base
        {
            get { return this.defB_Base; }
            set { this.SetProperty(ref this.defB_Base, value); }
        }
        public int DEFC_Base
        {
            get { return this.defC_Base; }
            set { this.SetProperty(ref this.defC_Base, value); }
        }
        public int DEFD_Base
        {
            get { return this.defD_Base; }
            set { this.SetProperty(ref this.defD_Base, value); }
        }
        public int DEFS_Base
        {
            get { return this.defS_Base; }
            set { this.SetProperty(ref this.defS_Base, value); }
        }

        public int DEFH
        {
            get { return this.defH; }
            set
            {
                this.SetProperty(ref this.defH, value);
                this.DEFH_Width = CalcHWidth(this.DEFLV, value);
            }
        }
        public int DEFA
        {
            get { return this.defA; }
            set 
            {
                this.SetProperty(ref this.defA, value); 
                this.DEFA_Width = CalcABCDSWidth(this.DEFLV, value);
            }
        }
        public int DEFB
        {
            get { return this.defB; }
            set
            {
                this.SetProperty(ref this.defB, value); 
                this.DEFB_Width = CalcABCDSWidth(this.DEFLV, value);
            }
        }
        public int DEFC
        {
            get { return this.defC; }
            set 
            {
                this.SetProperty(ref this.defC, value); 
                this.DEFC_Width = CalcABCDSWidth(this.DEFLV, value);
            }
        }
        public int DEFD
        {
            get { return this.defD; }
            set
            {
                this.SetProperty(ref this.defD, value); 
                this.DEFD_Width = CalcABCDSWidth(this.DEFLV, value);
            }
        }
        public int DEFS
        {
            get { return this.defS; }
            set 
            {
                this.SetProperty(ref this.defS, value);
                this.DEFS_Width = CalcABCDSWidth(this.DEFLV, value);
            }
        }
        #endregion
        #region public DEF_EV
        public int DEFH_EV
        {
            get { return this.defH_EV; }
            set
            {
                if (0 <= value && value <= 252 && value % 4 == 0)
                {
                    this.SetProperty(ref this.defH_EV, value);
                    SetDEFStatus(this.DEFName);
                }
                else
                {
                    this.SetProperty(ref this.defH_EV, this.defH_EV);
                }
            }
        }
        public int DEFA_EV
        {
            get { return this.defA_EV; }
            set
            {
                if (0 <= value && value <= 252 && value % 4 == 0)
                {
                    this.SetProperty(ref this.defA_EV, value);
                    SetDEFStatus(this.DEFName);
                }
                else
                {
                    this.SetProperty(ref this.defA_EV, this.defA_EV);
                }
            }
        }
        public int DEFB_EV
        {
            get { return this.defB_EV; }
            set
            {
                if (0 <= value && value <= 252 && value % 4 == 0)
                {
                    this.SetProperty(ref this.defB_EV, value);
                    SetDEFStatus(this.DEFName);
                }
                else
                {
                    this.SetProperty(ref this.defB_EV, this.defB_EV);
                }
            }
        }
        public int DEFC_EV
        {
            get { return this.defC_EV; }
            set
            {
                if (0 <= value && value <= 252 && value % 4 == 0)
                {
                    this.SetProperty(ref this.defC_EV, value);
                    SetDEFStatus(this.DEFName);
                }
                else
                {
                    this.SetProperty(ref this.defC_EV, this.defC_EV);
                }
            }
        }
        public int DEFD_EV
        {
            get { return this.defD_EV; }
            set
            {
                if (0 <= value && value <= 252 && value % 4 == 0)
                {
                    this.SetProperty(ref this.defD_EV, value);
                    SetDEFStatus(this.DEFName);
                }
                else
                {
                    this.SetProperty(ref this.defD_EV, this.defD_EV);
                }
            }
        }
        public int DEFS_EV
        {
            get { return this.defS_EV; }
            set
            {
                if (0 <= value && value <= 252 && value % 4 == 0)
                {
                    this.SetProperty(ref this.defS_EV, value);
                    SetDEFStatus(this.DEFName);
                }
                else
                {
                    this.SetProperty(ref this.defS_EV, this.defS_EV);
                }
            }
        }
        #endregion
        #region public DEF_Rank
        public int DEFA_Rank
        {
            get { return this.defA_Rank; }
            set
            {
                this.SetProperty(ref this.defA_Rank, value);
                SetDEFStatus(this.DEFName);
            }
        }
        public int DEFB_Rank
        {
            get { return this.defB_Rank; }
            set
            {
                this.SetProperty(ref this.defB_Rank, value);
                SetDEFStatus(this.DEFName);
            }
        }
        public int DEFC_Rank
        {
            get { return this.defC_Rank; }
            set
            {
                this.SetProperty(ref this.defC_Rank, value);
                SetDEFStatus(this.DEFName);
            }
        }
        public int DEFD_Rank
        {
            get { return this.defD_Rank; }
            set
            {
                this.SetProperty(ref this.defD_Rank, value);
                SetDEFStatus(this.DEFName);
            }
        }
        public int DEFS_Rank
        {
            get { return this.defS_Rank; }
            set
            {
                this.SetProperty(ref this.defS_Rank, value);
                SetDEFStatus(this.DEFName);
            }
        }
        public List<int> DEFA_RankList
        {
            get { return this.defA_RankList; }
            set { this.SetProperty(ref this.defA_RankList, value); }
        }
        public List<int> DEFB_RankList
        {
            get { return this.defB_RankList; }
            set { this.SetProperty(ref this.defB_RankList, value); }
        }
        public List<int> DEFC_RankList
        {
            get { return this.defC_RankList; }
            set { this.SetProperty(ref this.defC_RankList, value); }
        }
        public List<int> DEFD_RankList
        {
            get { return this.defD_RankList; }
            set { this.SetProperty(ref this.defD_RankList, value); }
        }
        public List<int> DEFS_RankList
        {
            get { return this.defS_RankList; }
            set { this.SetProperty(ref this.defS_RankList, value); }
        }
        public int DEFA_RankIndex
        {
            get { return this.defA_RankIndex; }
            set
            {
                this.SetProperty(ref this.defA_RankIndex, value);
                var rank = 6 - value;
                this.DEFA_Rank = rank;
            }
        }
        public int DEFB_RankIndex
        {
            get { return this.defB_RankIndex; }
            set
            {
                this.SetProperty(ref this.defB_RankIndex, value);
                var rank = 6 - value;
                this.DEFB_Rank = rank;
            }
        }
        public int DEFC_RankIndex
        {
            get { return this.defC_RankIndex; }
            set
            {
                this.SetProperty(ref this.defC_RankIndex, value);
                var rank = 6 - value;
                this.DEFC_Rank = rank;
            }
        }
        public int DEFD_RankIndex
        {
            get { return this.defD_RankIndex; }
            set
            {
                this.SetProperty(ref this.defD_RankIndex, value);
                var rank = 6 - value;
                this.DEFD_Rank = rank;
            }
        }
        public int DEFS_RankIndex
        {
            get { return this.defS_RankIndex; }
            set
            {
                this.SetProperty(ref this.defS_RankIndex, value);
                var rank = 6 - value;
                this.DEFS_Rank = rank;
            }
        }
        #endregion
        #region public Move
        public string MoveName
        {
            get { return this.moveName; }
            set 
            {
                if (this.MoveDic.ContainsKey(value))
                {
                    this.SetProperty(ref this.moveName, value);
                    SetMoves(value);
                }
                else
                {
                    this.SetProperty(ref this.moveName, this.moveName);
                }
            }
        }
        public string MoveType
        {
            get { return this.moveType; }
            set 
            {
                this.SetProperty(ref this.moveType, value); 
                this.MoveType_Color = GetTypeColor(value);
            }
        }
        public string MoveType_Color
        {
            get { return this.moveType_Color; }
            set { this.SetProperty(ref this.moveType_Color, value); }
        }
        public int MovePow
        {
            get { return this.movePow; }
            set 
            {
                this.SetProperty(ref this.movePow, value); 
                CalcDamage(this.MoveName, this.MovePow, this.MoveCat);
            }
        }
        public string MoveCat
        {
            get { return this.moveCat; }
            set { this.SetProperty(ref this.moveCat, value); }
        }
        public string Affinity
        {
            get { return this.affinity; }
            set { this.SetProperty(ref this.affinity, value); }
        }
        public bool IsDM
        {
            get { return this.isDM; }
            set 
            {
                this.SetProperty(ref this.isDM, value);
                if (value)
                {
                    SetDM(this.MoveName, this.MoveType, this.MovePow);
                }
                else
                {
                    this.MovePow = this.beforePow;
                }
            }
        }
        #endregion
        #region public Damage
        public string Dmgtext
        {
            get { return this.dmgtext; }
            set { this.SetProperty(ref this.dmgtext, value); }
        }
        public string Critext
        {
            get { return this.critext; }
            set { this.SetProperty(ref this.critext, value); }
        }
        public string DmgDMtext
        {
            get { return this.dmgDMtext; }
            set { this.SetProperty(ref this.dmgDMtext, value); }
        }
        public string CriDMtext
        {
            get { return this.criDMtext; }
            set { this.SetProperty(ref this.criDMtext, value); }
        }

        public string MinDmgWidth
        {
            get { return this.minDmgWidth; }
            set { this.SetProperty(ref this.minDmgWidth, value); }
        }
        public string MaxDmgWidth
        {
            get { return this.maxDmgWidth; }
            set { this.SetProperty(ref this.maxDmgWidth, value); }
        }
        public string MinCriWidth
        {
            get { return this.minCriWidth; }
            set { this.SetProperty(ref this.minCriWidth, value); }
        }
        public string MaxCriWidth
        {
            get { return this.maxCriWidth; }
            set { this.SetProperty(ref this.maxCriWidth, value); }
        }
        public string MinDmgDMWidth
        {
            get { return this.minDmgDMWidth; }
            set { this.SetProperty(ref this.minDmgDMWidth, value); }
        }
        public string MaxDmgDMWidth
        {
            get { return this.maxDmgDMWidth; }
            set { this.SetProperty(ref this.maxDmgDMWidth, value); }
        }
        public string MinCriDMWidth
        {
            get { return this.minCriDMWidth; }
            set { this.SetProperty(ref this.minCriDMWidth, value); }
        }
        public string MaxCriDMWidth
        {
            get { return this.maxCriDMWidth; }
            set { this.SetProperty(ref this.maxCriDMWidth, value); }
        }

        public string MinDmgColor
        {
            get { return this.minDmgColor; }
            set { this.SetProperty(ref this.minDmgColor, value); }
        }
        public string MaxDmgColor
        {
            get { return this.maxDmgColor; }
            set { this.SetProperty(ref this.maxDmgColor, value); }
        }
        public string MinCriColor
        {
            get { return this.minCriColor; }
            set { this.SetProperty(ref this.minCriColor, value); }
        }
        public string MaxCriColor
        {
            get { return this.maxCriColor; }
            set { this.SetProperty(ref this.maxCriColor, value); }
        }
        public string MinDmgDMColor
        {
            get { return this.minDmgDMColor; }
            set { this.SetProperty(ref this.minDmgDMColor, value); }
        }
        public string MaxDmgDMColor
        {
            get { return this.maxDmgDMColor; }
            set { this.SetProperty(ref this.maxDmgDMColor, value); }
        }
        public string MinCriDMColor
        {
            get { return this.minCriDMColor; }
            set { this.SetProperty(ref this.minCriDMColor, value); }
        }
        public string MaxCriDMColor
        {
            get { return this.maxCriDMColor; }
            set { this.SetProperty(ref this.maxCriDMColor, value); }
        }
        #endregion

        public MainPageVM()
        {
            var rankList = new List<int>();
            for (int j = 6; j >= -6; j--)
            {
                rankList.Add(j);
            }
            this.atkA_RankList = rankList;
            this.atkB_RankList = rankList;
            this.atkC_RankList = rankList;
            this.atkD_RankList = rankList;
            this.atkS_RankList = rankList;
            this.defA_RankList = rankList;
            this.defB_RankList = rankList;
            this.defC_RankList = rankList;
            this.defD_RankList = rankList;
            this.defS_RankList = rankList;

            var readPokemon = ReadPokemon();
            var readNature = ReadNature();
            var readMoves = ReadMoves();
        }
        private bool ReadPokemon()
        {
            var result = true;
            var exePath = Assembly.GetEntryAssembly().Location;
            var dirName = Directory.GetParent(exePath).ToString();
            var csvPath = Path.Combine(dirName, "src", "pokemon.csv");

            var sr = new StreamReader(csvPath);
            var pokeDic = new Dictionary<string, Pokemon>();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] values = line.Split(',');
                if (values[0] == "NAME")
                    continue;

                var typeList = values[1].Split("/");
                var pokemon = new Pokemon()
                {
                    Name = values[0],
                    Types = typeList,
                    Kg = double.Parse(values[2]),
                    H = int.Parse(values[3]),
                    A = int.Parse(values[4]),
                    B = int.Parse(values[5]),
                    C = int.Parse(values[6]),
                    D = int.Parse(values[7]),
                    S = int.Parse(values[8]),
                    //Img = values[9],
                    //Moves = values[10]
                };
                pokeDic.Add(values[0], pokemon);
            }
            this.PokeDic = pokeDic;
            return result;
        }
        private bool ReadNature()
        {
            var result = true;
            var exePath = Assembly.GetEntryAssembly().Location;
            var dirName = Directory.GetParent(exePath).ToString();
            var csvPath = Path.Combine(dirName, "src", "nature.csv");

            var sr = new StreamReader(csvPath);
            var natureDic = new Dictionary<string, Nature>();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] values = line.Split(',');
                if (values[0] == "NAME")
                    continue;

                var nature = new Nature()
                {
                    Name = values[0],
                    Up = values[1],
                    Down = values[2]
                };
                natureDic.Add(values[0], nature);
            }
            this.ATKNatureDic = natureDic;
            this.DEFNatureDic = natureDic;
            return result;
        }
        private bool ReadMoves()
        {
            var result = true;
            var exePath = Assembly.GetEntryAssembly().Location;
            var dirName = Directory.GetParent(exePath).ToString();
            var csvPath = Path.Combine(dirName, "src", "moves.csv");

            var sr = new StreamReader(csvPath);
            var moveDic = new Dictionary<string, Move>();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] values = line.Split(',');
                if (values[0] == "NAME")
                    continue;

                var move = new Move()
                {
                    Name = values[0],
                    Type = values[1],
                    Power = int.Parse(values[2]),
                    Category = values[3]
                };
                moveDic.Add(values[0], move);
            }
            this.MoveDic = moveDic;
            return result;
        }
        private void SetATKStatus(string name)
        {
            if (this.PokeDic.ContainsKey(name))
            {
                var pokemon = this.PokeDic[name];

                var types = pokemon.Types;
                this.ATKType1 = types[0];
                this.ATKType2 = "";
                if (types.Length == 2)
                    this.ATKType2 = types[1];

                this.ATKH_Base = pokemon.H;
                this.ATKA_Base = pokemon.A;
                this.ATKB_Base = pokemon.B;
                this.ATKC_Base = pokemon.C;
                this.ATKD_Base = pokemon.D;
                this.ATKS_Base = pokemon.S;

                this.ATKH = ((ATKH_Base * 2) + 31 + (this.ATKH_EV / 4)) * this.ATKLV / 100 + this.ATKLV + 10;

                var proA = ((ATKA_Base * 2) + 31 + (this.ATKA_EV / 4)) * this.ATKLV / 100 + 5;
                var proB = ((ATKB_Base * 2) + 31 + (this.ATKB_EV / 4)) * this.ATKLV / 100 + 5;
                var proC = ((ATKC_Base * 2) + 31 + (this.ATKC_EV / 4)) * this.ATKLV / 100 + 5;
                var proD = ((ATKD_Base * 2) + 31 + (this.ATKD_EV / 4)) * this.ATKLV / 100 + 5;
                var proS = ((ATKS_Base * 2) + 31 + (this.ATKS_EV / 4)) * this.ATKLV / 100 + 5;

                var proA2 = 0;
                var proB2 = 0;
                var proC2 = 0;
                var proD2 = 0;
                var proS2 = 0;
                switch (this.ATKNatureIndex)
                {
                    case 0:
                        proA2 = proA * 11 / 10;
                        proB2 = proB * 9 / 10;
                        proC2 = proC;
                        proD2 = proD;
                        proS2 = proS;
                        break;
                    case 1:
                        proA2 = proA * 11 / 10;
                        proB2 = proB;
                        proC2 = proC * 9 / 10;
                        proD2 = proD;
                        proS2 = proS;
                        break;
                    case 2:
                        proA2 = proA * 11 / 10;
                        proB2 = proB;
                        proC2 = proC;
                        proD2 = proD * 9 / 10;
                        proS2 = proS;
                        break;
                    case 3:
                        proA2 = proA * 11 / 10;
                        proB2 = proB;
                        proC2 = proC;
                        proD2 = proD;
                        proS2 = proS * 9 / 10;
                        break;
                    case 4:
                        proA2 = proA * 9 / 10;
                        proB2 = proB * 11 / 10;
                        proC2 = proC;
                        proD2 = proD;
                        proS2 = proS;
                        break;
                    case 5:
                        proA2 = proA;
                        proB2 = proB * 11 / 10;
                        proC2 = proC * 9 / 10;
                        proD2 = proD;
                        proS2 = proS;
                        break;
                    case 6:
                        proA2 = proA;
                        proB2 = proB * 11 / 10;
                        proC2 = proC;
                        proD2 = proD * 9 / 10;
                        proS2 = proS;
                        break;
                    case 7:
                        proA2 = proA;
                        proB2 = proB * 11 / 10;
                        proC2 = proC;
                        proD2 = proD;
                        proS2 = proS * 9 / 10;
                        break;
                    case 8:
                        proA2 = proA * 9 / 10;
                        proB2 = proB;
                        proC2 = proC * 11 / 10;
                        proD2 = proD;
                        proS2 = proS;
                        break;
                    case 9:
                        proA2 = proA;
                        proB2 = proB * 9 / 10;
                        proC2 = proC * 11 / 10;
                        proD2 = proD;
                        proS2 = proS;
                        break;
                    case 10:
                        proA2 = proA;
                        proB2 = proB;
                        proC2 = proC * 11 / 10;
                        proD2 = proD * 9 / 10;
                        proS2 = proS;
                        break;
                    case 11:
                        proA2 = proA;
                        proB2 = proB;
                        proC2 = proC * 11 / 10;
                        proD2 = proD;
                        proS2 = proS * 9 / 10;
                        break;
                    case 12:
                        proA2 = proA * 9 / 10;
                        proB2 = proB;
                        proC2 = proC;
                        proD2 = proD * 11 / 10;
                        proS2 = proS;
                        break;
                    case 13:
                        proA2 = proA;
                        proB2 = proB * 9 / 10;
                        proC2 = proC;
                        proD2 = proD * 11 / 10;
                        proS2 = proS;
                        break;
                    case 14:
                        proA2 = proA;
                        proB2 = proB;
                        proC2 = proC * 9 / 10;
                        proD2 = proD * 11 / 10;
                        proS2 = proS;
                        break;
                    case 15:
                        proA2 = proA;
                        proB2 = proB;
                        proC2 = proC;
                        proD2 = proD * 11 / 10;
                        proS2 = proS * 9 / 10;
                        break;
                    case 16:
                        proA2 = proA * 9 / 10;
                        proB2 = proB;
                        proC2 = proC;
                        proD2 = proD;
                        proS2 = proS * 11 / 10;
                        break;
                    case 17:
                        proA2 = proA;
                        proB2 = proB * 9 / 10;
                        proC2 = proC;
                        proD2 = proD;
                        proS2 = proS * 11 / 10;
                        break;
                    case 18:
                        proA2 = proA;
                        proB2 = proB;
                        proC2 = proC * 9 / 10;
                        proD2 = proD;
                        proS2 = proS * 11 / 10;
                        break;
                    case 19:
                        proA2 = proA;
                        proB2 = proB;
                        proC2 = proC;
                        proD2 = proD * 9 / 10;
                        proS2 = proS * 11 / 10;
                        break;
                }

                this.ATKA = proA2;
                this.ATKB = proB2;
                this.ATKC = proC2;
                this.ATKD = proD2;
                this.ATKS = proS2;
            }
        }
        private void SetDEFStatus(string name)
        {
            if (this.PokeDic.ContainsKey(name))
            {
                var pokemon = this.PokeDic[name];

                var types = pokemon.Types;
                this.DEFType1 = types[0];
                this.DEFType2 = "";
                if (types.Length == 2)
                    this.DEFType2 = types[1];

                this.DEFH_Base = pokemon.H;
                this.DEFA_Base = pokemon.A;
                this.DEFB_Base = pokemon.B;
                this.DEFC_Base = pokemon.C;
                this.DEFD_Base = pokemon.D;
                this.DEFS_Base = pokemon.S;

                this.DEFH = ((DEFH_Base * 2) + 31 + (this.DEFH_EV / 4)) * this.DEFLV / 100 + this.DEFLV + 10;

                var proA = ((DEFA_Base * 2) + 31 + (this.DEFA_EV / 4)) * this.DEFLV / 100 + 5;
                var proB = ((DEFB_Base * 2) + 31 + (this.DEFB_EV / 4)) * this.DEFLV / 100 + 5;
                var proC = ((DEFC_Base * 2) + 31 + (this.DEFC_EV / 4)) * this.DEFLV / 100 + 5;
                var proD = ((DEFD_Base * 2) + 31 + (this.DEFD_EV / 4)) * this.DEFLV / 100 + 5;
                var proS = ((DEFS_Base * 2) + 31 + (this.DEFS_EV / 4)) * this.DEFLV / 100 + 5;

                var proA2 = 0;
                var proB2 = 0;
                var proC2 = 0;
                var proD2 = 0;
                var proS2 = 0;
                switch (this.DEFNatureIndex)
                {
                    case 0:
                        proA2 = proA * 11 / 10;
                        proB2 = proB * 9 / 10;
                        proC2 = proC;
                        proD2 = proD;
                        proS2 = proS;
                        break;
                    case 1:
                        proA2 = proA * 11 / 10;
                        proB2 = proB;
                        proC2 = proC * 9 / 10;
                        proD2 = proD;
                        proS2 = proS;
                        break;
                    case 2:
                        proA2 = proA * 11 / 10;
                        proB2 = proB;
                        proC2 = proC;
                        proD2 = proD * 9 / 10;
                        proS2 = proS;
                        break;
                    case 3:
                        proA2 = proA * 11 / 10;
                        proB2 = proB;
                        proC2 = proC;
                        proD2 = proD;
                        proS2 = proS * 9 / 10;
                        break;
                    case 4:
                        proA2 = proA * 9 / 10;
                        proB2 = proB * 11 / 10;
                        proC2 = proC;
                        proD2 = proD;
                        proS2 = proS;
                        break;
                    case 5:
                        proA2 = proA;
                        proB2 = proB * 11 / 10;
                        proC2 = proC * 9 / 10;
                        proD2 = proD;
                        proS2 = proS;
                        break;
                    case 6:
                        proA2 = proA;
                        proB2 = proB * 11 / 10;
                        proC2 = proC;
                        proD2 = proD * 9 / 10;
                        proS2 = proS;
                        break;
                    case 7:
                        proA2 = proA;
                        proB2 = proB * 11 / 10;
                        proC2 = proC;
                        proD2 = proD;
                        proS2 = proS * 9 / 10;
                        break;
                    case 8:
                        proA2 = proA * 9 / 10;
                        proB2 = proB;
                        proC2 = proC * 11 / 10;
                        proD2 = proD;
                        proS2 = proS;
                        break;
                    case 9:
                        proA2 = proA;
                        proB2 = proB * 9 / 10;
                        proC2 = proC * 11 / 10;
                        proD2 = proD;
                        proS2 = proS;
                        break;
                    case 10:
                        proA2 = proA;
                        proB2 = proB;
                        proC2 = proC * 11 / 10;
                        proD2 = proD * 9 / 10;
                        proS2 = proS;
                        break;
                    case 11:
                        proA2 = proA;
                        proB2 = proB;
                        proC2 = proC * 11 / 10;
                        proD2 = proD;
                        proS2 = proS * 9 / 10;
                        break;
                    case 12:
                        proA2 = proA * 9 / 10;
                        proB2 = proB;
                        proC2 = proC;
                        proD2 = proD * 11 / 10;
                        proS2 = proS;
                        break;
                    case 13:
                        proA2 = proA;
                        proB2 = proB * 9 / 10;
                        proC2 = proC;
                        proD2 = proD * 11 / 10;
                        proS2 = proS;
                        break;
                    case 14:
                        proA2 = proA;
                        proB2 = proB;
                        proC2 = proC * 9 / 10;
                        proD2 = proD * 11 / 10;
                        proS2 = proS;
                        break;
                    case 15:
                        proA2 = proA;
                        proB2 = proB;
                        proC2 = proC;
                        proD2 = proD * 11 / 10;
                        proS2 = proS * 9 / 10;
                        break;
                    case 16:
                        proA2 = proA * 9 / 10;
                        proB2 = proB;
                        proC2 = proC;
                        proD2 = proD;
                        proS2 = proS * 11 / 10;
                        break;
                    case 17:
                        proA2 = proA;
                        proB2 = proB * 9 / 10;
                        proC2 = proC;
                        proD2 = proD;
                        proS2 = proS * 11 / 10;
                        break;
                    case 18:
                        proA2 = proA;
                        proB2 = proB;
                        proC2 = proC * 9 / 10;
                        proD2 = proD;
                        proS2 = proS * 11 / 10;
                        break;
                    case 19:
                        proA2 = proA;
                        proB2 = proB;
                        proC2 = proC;
                        proD2 = proD * 9 / 10;
                        proS2 = proS * 11 / 10;
                        break;
                }

                this.DEFA = proA2;
                this.DEFB = proB2;
                this.DEFC = proC2;
                this.DEFD = proD2;
                this.DEFS = proS2;
            }
        }
        private void SetMoves(string name)
        {
            if (this.MoveDic.ContainsKey(name))
            {
                var move = this.MoveDic[name];
                this.MoveType = move.Type;
                this.MoveCat = move.Category;
                this.MovePow = move.Power;
            }
        }
        private void SetDM(string name, string type, int pow)
        {
            this.beforePow = pow;

            var result = 0;
            switch (name)
            {
                #region 例外技
                case "アシストパワー":
                    result = 130;
                    break;
                case "つけあがる":
                    result = 130;
                    break;
                case "ウェザーボール":
                    result = 130;
                    break;
                case "ダイマックスほう":
                    result = 140;
                    break;
                case "マルチアタック":
                    result = 95;
                    break;
                #endregion
                #region 連続技
                case "つっぱり":
                    result = 70;
                    break;
                case "トリプルキック":
                    result = 80;
                    break;
                case "にどげり":
                    result = 80;
                    break;
                case "みずしゅりけん":
                    result = 90;
                    break;
                case "みだれひっかき":
                    result = 100;
                    break;
                case "ふくろだたき":
                    result = 100;
                    break;
                case "ダブルアタック":
                    result = 120;
                    break;
                case "ミサイルばり":
                    result = 130;
                    break;
                case "ボーンラッシュ":
                    result = 130;
                    break;
                case "タネマシンガン":
                    result = 130;
                    break;
                case "つららばり":
                    result = 130;
                    break;
                case "スイープビンタ":
                    result = 130;
                    break;
                case "ダブルチョップ":
                    result = 130;
                    break;
                case "ギアソーサー":
                    result = 130;
                    break;
                case "ドラゴンアロー":
                    result = 130;
                    break;
                case "ダブルパンツァー":
                    result = 140;
                    break;
                #endregion
                #region 変動技
                case "きしかいせい":
                    result = 100;
                    break;
                case "けたぐり":
                    result = 100;
                    break;
                case "プレゼント":
                    result = 100;
                    break;
                case "はきだす":
                    result = 100;
                    break;
                case "なげつける":
                    result = 100;
                    break;
                case "じたばた":
                    result = 130;
                    break;
                case "くさむすび":
                    result = 130;
                    break;
                case "ジャイロボール":
                    result = 130;
                    break;
                case "エレキボール":
                    result = 130;
                    break;
                case "ヘビーボンバー":
                    result = 130;
                    break;
                case "ヒートスタンプ":
                    result = 130;
                    break;
                #endregion
                #region 固定技
                case "カウンター":
                    result = 75;
                    break;
                case "ちきゅうなげ":
                    result = 75;
                    break;
                case "ナイトヘッド":
                    result = 100;
                    break;
                case "サイコウェーブ":
                    result = 100;
                    break;
                case "ミラーコート":
                    result = 100;
                    break;
                case "メタルバースト":
                    result = 100;
                    break;
                case "いのちがけ":
                    result = 100;
                    break;
                case "ハサミギロチン":
                    result = 130;
                    break;
                case "つのドリル":
                    result = 130;
                    break;
                case "じわれ":
                    result = 130;
                    break;
                case "ぜったいれいど":
                    result = 130;
                    break;
                case "いかりのまえば":
                    result = 130;
                    break;
                case "がむしゃら":
                    result = 130;
                    break;
                #endregion
                default:
                    if (10 <= pow && pow <= 40)
                    {
                        switch (type)
                        {
                            case "かくとう":
                            case "どく":
                                result = 70;
                                break;
                            default:
                                result = 90;
                                break;
                        }
                    }
                    if (45 <= pow && pow <= 50)
                    {
                        switch (type)
                        {
                            case "かくとう":
                            case "どく":
                                result = 75;
                                break;
                            default:
                                result = 100;
                                break;
                        }
                    }
                    if (55 <= pow && pow <= 60)
                    {
                        switch (type)
                        {
                            case "かくとう":
                            case "どく":
                                result = 80;
                                break;
                            default:
                                result = 110;
                                break;
                        }
                    }
                    if (65 <= pow && pow <= 70)
                    {
                        switch (type)
                        {
                            case "かくとう":
                            case "どく":
                                result = 85;
                                break;
                            default:
                                result = 120;
                                break;
                        }
                    }
                    if (75 <= pow && pow <= 100)
                    {
                        switch (type)
                        {
                            case "かくとう":
                            case "どく":
                                result = 90;
                                break;
                            default:
                                result = 130;
                                break;
                        }
                    }
                    if (110 <= pow && pow <= 140)
                    {
                        switch (type)
                        {
                            case "かくとう":
                            case "どく":
                                result = 95;
                                break;
                            default:
                                result = 140;
                                break;
                        }
                    }
                    if (150 <= pow && pow <= 250)
                    {
                        switch (type)
                        {
                            case "かくとう":
                            case "どく":
                                result = 100;
                                break;
                            default:
                                result = 150;
                                break;
                        }
                    }
                    break;
            }
            this.MovePow = result;
        }
        private string GetTypeColor(string name)
        {
            var result = "";
            switch (name)
            {
                case "ノーマル":
                    result = "#D3D3D3";
                    break;
                case "ほのお":
                    result = "#FF4500";
                    break;
                case "みず":
                    result = "#4169E1";
                    break;
                case "でんき":
                    result = "#FFD700";
                    break;
                case "くさ":
                    result = "#9ACD32";
                    break;
                case "こおり":
                    result = "#00CED1";
                    break;
                case "かくとう":
                    result = "#CD5C5C";
                    break;
                case "どく":
                    result = "#9370DB";
                    break;
                case "じめん":
                    result = "#CD853F";
                    break;
                case "ひこう":
                    result = "#00BFFF";
                    break;
                case "エスパー":
                    result = "#FF69B4";
                    break;
                case "むし":
                    result = "#5F9EA0";
                    break;
                case "いわ":
                    result = "#DAA520";
                    break;
                case "ゴースト":
                    result = "#483D8B";
                    break;
                case "ドラゴン":
                    result = "#6A5ACD";
                    break;
                case "あく":
                    result = "#191970";
                    break;
                case "はがね":
                    result = "#696969";
                    break;
                case "フェアリー":
                    result = "#DB7093";
                    break;
            }
            return result;
        }
        private string CalcHWidth(int LV, int H)
        {
            var result = 0;
            switch (LV)
            {
                case 50:
                    result = H * 156 / 362;
                    break;
                case 100:
                    result = H * 156 / 714;
                    break;
            }
            return result.ToString();
        }
        private string CalcABCDSWidth(int LV, int ABCDS)
        {
            var result = 0;
            switch (LV)
            {
                case 50:
                    result = ABCDS * 156 / 310;
                    break;
                case 100:
                    result = ABCDS * 156 / 614;
                    break;
            }
            return result.ToString();
        }
        private double CalcAffinity(string moveType, List<string> types)
        {
            var result = 1.0;
            for (int i = 0; i < types.Count; i++)
            {
                var type = types[i];
                switch (moveType)
                {
                    #region ノーマル
                    case "ノーマル":
                        switch (type) 
                        {
                            case "いわ":
                            case "はがね":
                                result *= 0.5;
                                break;
                            case "ゴースト":
                                result = 0.0;
                                break;
                        }
                        break;
                    #endregion
                    #region ほのお
                    case "ほのお":
                        switch (type)
                        {
                            case "くさ":
                            case "こおり":
                            case "むし":
                            case "はがね":
                                result *= 2.0;
                                break;
                            case "ほのお":
                            case "みず":
                            case "いわ":
                            case "ドラゴン":
                                result *= 0.5;
                                break;
                        }
                        break;
                    #endregion
                    #region みず
                    case "みず":
                        switch (type)
                        {
                            case "ほのお":
                            case "じめん":
                            case "いわ":
                                result *= 2.0;
                                break;
                            case "みず":
                            case "くさ":
                            case "ドラゴン":
                                result *= 0.5;
                                break;
                        }
                        break;
                    #endregion
                    #region でんき
                    case "でんき":
                        switch (type)
                        {
                            case "みず":
                            case "ひこう":
                                result *= 2.0;
                                break;
                            case "でんき":
                            case "くさ":
                            case "ドラゴン":
                                result *= 0.5;
                                break;
                            case "じめん":
                                result = 0;
                                break;
                        }
                        break;
                    #endregion
                    #region くさ
                    case "くさ":
                        switch (type)
                        {
                            case "みず":
                            case "じめん":
                            case "いわ":
                                result *= 2.0;
                                break;
                            case "ほのお":
                            case "くさ":
                            case "どく":
                            case "ひこう":
                            case "むし":
                            case "ドラゴン":
                            case "はがね":
                                result *= 0.5;
                                break;
                        }
                        break;
                    #endregion
                    #region こおり
                    case "こおり":
                        switch (type)
                        {
                            case "くさ":
                            case "じめん":
                            case "ひこう":
                            case "ドラゴン":
                                result *= 2.0;
                                break;
                            case "ほのお":
                            case "みず":
                            case "こおり":
                            case "はがね":
                                result *= 0.5;
                                break;
                        }
                        break;
                    #endregion
                    #region かくとう
                    case "かくとう":
                        switch (type)
                        {
                            case "ノーマル":
                            case "こおり":
                            case "いわ":
                            case "あく":
                            case "はがね":
                                result *= 2.0;
                                break;
                            case "どく":
                            case "ひこう":
                            case "エスパー":
                            case "むし":
                            case "フェアリー":
                                result *= 0.5;
                                break;
                            case "ゴースト":
                                result = 0;
                                break;
                        }
                        break;
                    #endregion
                    #region どく
                    case "どく":
                        switch (type)
                        {
                            case "くさ":
                            case "フェアリー":
                                result *= 2.0;
                                break;
                            case "どく":
                            case "じめん":
                            case "いわ":
                            case "ゴースト":
                                result *= 0.5;
                                break;
                            case "はがね":
                                result = 0;
                                break;
                        }
                        break;
                    #endregion
                    #region じめん
                    case "じめん":
                        switch (type)
                        {
                            case "ほのお":
                            case "でんき":
                            case "どく":
                            case "いわ":
                            case "はがね":
                                result *= 2.0;
                                break;
                            case "くさ":
                            case "むし":
                                result *= 0.5;
                                break;
                            case "ひこう":
                                result = 0;
                                break;
                        }
                        break;
                    #endregion
                    #region ひこう
                    case "ひこう":
                        switch (type) 
                        {
                            case "くさ":
                            case "かくとう":
                            case "むし":
                                result *= 2.0;
                                break;
                            case "でんき":
                            case "いわ":
                            case "はがね":
                                result *= 0.5;
                                break;
                        }
                        break;
                    #endregion
                    #region エスパー
                    case "エスパー":
                        switch (type)
                        {
                            case "かくとう":
                            case "どく":
                                result *= 2.0;
                                break;
                            case "エスパー":
                            case "はがね":
                                result *= 0.5;
                                break;
                            case "あく":
                                result = 0;
                                break;
                        }
                        break;
                    #endregion
                    #region むし
                    case "むし":
                        switch (type)
                        {
                            case "くさ":
                            case "エスパー":
                            case "あく":
                                result *= 2.0;
                                break;
                            case "ほのお":
                            case "かくとう":
                            case "どく":
                            case "ひこう":
                            case "ゴースト":
                            case "はがね":
                            case "フェアリー":
                                result *= 0.5;
                                break;
                        }
                        break;
                    #endregion
                    #region いわ
                    case "いわ":
                        switch (type)
                        {
                            case "ほのお":
                            case "こおり":
                            case "ひこう":
                            case "むし":
                                result *= 2.0;
                                break;
                            case "かくとう":
                            case "じめん":
                            case "はがね":
                                result *= 0.5;
                                break;
                        }
                        break;
                    #endregion
                    #region ゴースト
                    case "ゴースト":
                        switch (type)
                        {
                            case "エスパー":
                            case "ゴースト":
                                result *= 2.0;
                                break;
                            case "あく":
                                result *= 0.5;
                                break;
                            case "ノーマル":
                                result = 0;
                                break;
                        }
                        break;
                    #endregion
                    #region ドラゴン
                    case "ドラゴン":
                        switch (type)
                        {
                            case "ドラゴン":
                                result *= 2.0;
                                break;
                            case "はがね":
                                result *= 0.5;
                                break;
                            case "フェアリー":
                                result = 0;
                                break;
                        }
                        break;
                    #endregion
                    #region あく
                    case "あく":
                        switch (type)
                        {
                            case "エスパー":
                            case "ゴースト":
                                result *= 2.0;
                                break;
                            case "かくとう":
                            case "あく":
                            case "フェアリー":
                                result *= 0.5;
                                break;
                        }
                        break;
                    #endregion
                    #region はがね
                    case "はがね":
                        switch (type)
                        {
                            case "こおり":
                            case "いわ":
                            case "フェアリー":
                                result *= 2.0;
                                break;
                            case "ほのお":
                            case "みず":
                            case "でんき":
                            case "はがね":
                                result *= 0.5;
                                break;
                        }
                        break;
                    #endregion
                    #region フェアリー
                    case "フェアリー":
                        switch (type)
                        {
                            case "かくとう":
                            case "ドラゴン":
                            case "あく":
                                result *= 2.0;
                                break;
                            case "ほのお":
                            case "どく":
                            case "はがね":
                                result *= 0.5;
                                break;
                        }
                        break;
                        #endregion
                }
            }
            this.Affinity = string.Format("×{0}", result);
            return result;
        }
        private void CalcDamage(string name, int pow, string cat)
        {
            var dmg = 1;
            var dmgList = new List<int>();
            var H = this.DEFH;
            var ATK = 1;
            var DEF = 1;
            switch (cat)
            {
                case "物理":
                    ATK = this.ATKA;
                    DEF = this.DEFB;
                    break;
                case "特殊":
                    ATK = this.ATKC;
                    DEF = this.DEFD;
                    break;
            }
            var types = new List<string>()
            {
                this.DEFType1, this.DEFType2 
            };
            var aff = CalcAffinity(this.MoveType, types);
            if (pow == 1)
            {

            }
            else
            {
                switch (name)
                {
                    default:
                        dmg = (((this.ATKLV * 2 / 5 + 2) * pow * ATK / DEF) / 50 + 2);
                        break;
                }
                for (int i = 85; i <= 100; i++)
                {
                    dmgList.Add(dmg * i / 100);
                }
            }

            #region Dmg
            var minDmg = dmgList[0];
            var maxDmg = dmgList[15];
            var minDmgPer = Math.Round(100 - ((H - minDmg) * 100.0 / H), 2, MidpointRounding.AwayFromZero);
            var maxDmgPer = Math.Round(100 - ((H - maxDmg) * 100.0 / H), 2, MidpointRounding.AwayFromZero);
            var dmgTimes = CalcTimes(dmgList, H);
            this.Dmgtext = string.Format("{0}~{1} ({2}~{3}%) [{4}]", minDmg, maxDmg, minDmgPer, maxDmgPer, dmgTimes);

            this.MinDmgWidth = GetHPWidth(H, minDmg);
            this.MaxDmgWidth = GetHPWidth(H, maxDmg);
            this.MinDmgColor = GetHPColor(int.Parse(this.MinDmgWidth), "min");
            this.MaxDmgColor = GetHPColor(int.Parse(this.MinDmgWidth), "max");
            #endregion
            #region Cri
            #endregion
            #region DmgDM
            var minDmgDM = dmgList[0];
            var maxDmgDM = dmgList[15];
            var minDmgDMPer = Math.Round(100 - ((H * 2 - minDmg) * 100.0 / (H * 2)), 2, MidpointRounding.AwayFromZero);
            var maxDmgDMPer = Math.Round(100 - ((H * 2 - maxDmg) * 100.0 / (H * 2)), 2, MidpointRounding.AwayFromZero);
            var dmgDMTimes = CalcTimes(dmgList, H * 2);
            this.DmgDMtext = string.Format("{0}~{1} ({2}~{3}%) [{4}]", minDmgDM, maxDmgDM, minDmgDMPer, maxDmgDMPer, dmgDMTimes);

            this.MinDmgDMWidth = GetHPWidth(H * 2, minDmg);
            this.MaxDmgDMWidth = GetHPWidth(H * 2, maxDmg);
            this.MinDmgDMColor = GetHPColor(int.Parse(this.MinDmgDMWidth), "min");
            this.MaxDmgDMColor = GetHPColor(int.Parse(this.MinDmgDMWidth), "max");
            #endregion
            #region CriDM
            #endregion
        }
        private string CalcTimes(List<int> dmgList, int H)
        {
            var result = "";
            var roop = 20;
            for (int j = 1; j < roop; j++)
            {
                var diffs = new List<bool>();
                var true_count = 0;
                var false_count = 0;
                for (int i = 0; i < dmgList.Count; i++)
                {
                    var dmg = dmgList[i] * j; 
                    if (H <= dmg)
                    {
                        diffs.Add(true);
                        true_count++;
                    }
                    else
                    {
                        diffs.Add(false);
                        false_count++;
                    }
                }
                if (!diffs.Contains(false))
                {
                    if (j == roop)
                        result = string.Format("確定{0}発以上", j);
                    if (j < roop)
                        result = string.Format("確定{0}発", j);
                    break;
                }
                else if (!diffs.Contains(true))
                {
                    continue;
                }
                else
                {
                    double per = Math.Round(true_count * 100.0 / (true_count + false_count), 2, MidpointRounding.AwayFromZero);
                    if (j == roop)
                        result = string.Format("乱数{0}発以上({1}%)", j, per);
                    if (j < roop)
                        result = string.Format("乱数{0}発({1}%)", j, per);
                    break;
                }
            }
            
            return result;
        }
        private string GetHPWidth(int H, int dmg)
        {
            var result = 0;
            if (H > dmg)
                result = (H - dmg) * 250 / H;
            return result.ToString();
        }
        private string GetHPColor(int minWidth, string cat)
        {
            var result = "";
            switch (cat)
            {
                case "min":
                    if (0 <= minWidth && minWidth <= 83)
                        result = "#8B0000";
                    if (84 <= minWidth && minWidth <= 166)
                        result = "#DAA520";
                    if (167 <= minWidth && minWidth <= 250)
                        result = "#228B22";
                    break;
                case "max":
                    if (0 <= minWidth && minWidth <= 83)
                        result = "#FF0000";
                    if (84 <= minWidth && minWidth <= 166)
                        result = "#FFD5D228";
                    if (167 <= minWidth && minWidth <= 250)
                        result = "#32CD32";
                    break;
            }
            return result;
        }
        public void OnATKNameTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var tb = (TextBox)e.Source;
                var name = tb.Name;
                var text = tb.Text;
                switch (name)
                {
                    case "ATKName":
                        if (this.PokeDic.ContainsKey(text))
                        {
                            this.ATKName = text;
                        }
                        else
                        {
                            tb.Clear();
                            tb.Text = this.ATKName;
                        }
                        break;
                    case "DEFName":
                        if (this.PokeDic.ContainsKey(text))
                        {
                            this.DEFName = text;
                        }
                        else
                        {
                            tb.Clear();
                            tb.Text = this.DEFName;
                        }
                        break;
                    case "MoveName":
                        if (this.MoveDic.ContainsKey(text))
                        {
                            this.MoveName = text;
                        }
                        else
                        {
                            tb.Clear();
                            tb.Text = this.MoveName;
                        }
                        break;
                }
            }
        }
    }
}