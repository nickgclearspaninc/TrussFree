using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentFileReader.FileClasses.TreComponent
{
    public partial class TreComponent 
    {
        #region _variables and Properties
        private int currentLine; //Pointer to keep track of where in the file we are
        #endregion

        #region _sectionParsing
        private void _parseTreData()
        {
            currentLine = 0;

            _parseHeaderInfo();
            _parseSheathingInfo();
            _parseMaterialDefaults();
            _parseMemberInfo();
            //ToDo: Parse info between MEMBER INFO and BEARING INFO
            _parseBearingInfo();
            _parseNotes();
        }

        private void _parseHeaderInfo()
        {
            //HEADER INFO
            _parseLine1();
            _parseLine2();
            _parseLine3();
            _parseLine4();
            _parseLine5();
            if (this.RoofOrFloorTruss.Equals("ROOF BASICS"))
            {
                _parseLine6Roof();
                _parseLine7Roof();
                _parseLine8Roof();
                _parseLine9Roof();
                _parseLine10Roof();
                _parseLine11Roof();
                _parseLine12Roof();
                _parseLine13Roof();
                _parseLine14Roof();
                _parseLine15Roof();
                _parseLine16Roof();
            }
            else
            {
                _parseLine6Floor();
                _parseLine7Floor();
                _parseLine8Floor();
                _parseLine9Floor();
                _parseLine10Floor();
                _parseLine11Floor();
                _parseLine12Floor();
                _parseWebbingInfo();
            }
        }

        private void _parseWebbingInfo()
        {
            //ToDo: implement
            throw new NotImplementedException();
        }

        private void _parseSheathingInfo()
        {
            this.SheathingInfo = new List<TreSheathing>();
            currentLine += 2;
            string[] contentsToParse = Contents[currentLine].Split(' ');
            while(contentsToParse[0].Equals("HD") == false)
            {
                this.SheathingInfo.Add(new TreSheathing(contentsToParse));
                currentLine++;
                contentsToParse = Contents[currentLine].Split(' ');
            }
        }

        private void _parseMaterialDefaults()
        {
            //MATERIAL DEFAULTS
            this.DefaultMaterials = new List<TreMaterial>();
            currentLine = 24; //ToDo: Make relative
            string[] contentsToParse = Contents[currentLine].Split(' ');
            while (contentsToParse.Length > 1)
            {
                DefaultMaterials.Add(new TreMaterial(contentsToParse));
                currentLine++;
                contentsToParse = Contents[currentLine].Split(' ');
            }

            //MATERIAL DEFAULTS MAP
            currentLine += 2;
            this.DefaultMaterialsMap = new List<TreMaterialMap>();
            contentsToParse = Contents[currentLine].Split(',');
            while (contentsToParse.Length > 1)
            {
                this.DefaultMaterialsMap.Add(new TreMaterialMap(contentsToParse));
                currentLine++;
                contentsToParse = Contents[currentLine].Split(',');
            }
        }
        
        private void _parseMemberInfo()
        {
            TreMemberInfo treMemberInfo = new TreMemberInfo();
            treMemberInfo.TreMembers = new List<TreMember>();
            // The line numbers should not be understood as concrete, but as pointers to the line specified in the Mitek documentation

            currentLine = 107;
            _parseLine25(treMemberInfo);
            _parseLine26(treMemberInfo);
            // Set truss members
            for (int i = 0; i < Convert.ToInt32(treMemberInfo.NumberOfMembers); i++)
            {
                TreMember treMember = new TreMember();

                // Parse the five lines that make up a truss member
                // The line numbers should not be understood as concrete, but as pointers to the line specified in the Mitek documentation
                _parseLine27(treMember);
                _parseLine28(treMember);
                _parseLine31(treMember);
                _parseLine32(treMember);
                _parseLine33(treMember);

                treMemberInfo.TreMembers.Add(treMember);
            }
        }

        private void _parseBearingInfo()
        {
            currentLine = 550;
            _parseLine43();
            this.Bearings = new List<TreBearing>();
            for(int i = 0; i < Convert.ToInt32(this.NumberOfBearings); i++)
            {
                string[] contentsToParse = Contents[currentLine].Split(' ');
                this.Bearings.Add(new TreBearing(contentsToParse));
                currentLine++;
            }
            _parseLine45();
            string[] pointToParse = Contents[currentLine].Split(' ');
            this.BearingPoints = new List<TrePoint>();
            do
            {
                TrePoint pointToAdd = new TrePoint();
                pointToAdd.X = pointToParse[0];
                pointToAdd.Y = pointToParse[1];
                currentLine++;
                pointToParse = Contents[currentLine].Split(' ');
                this.BearingPoints.Add(pointToAdd);
            }
            while (pointToParse.Length > 1);
            //Lines 47 & 48
            this.NumberOfSegments = pointToParse[0];
            if (Convert.ToInt32(NumberOfSegments) > 0)
            {
                currentLine++;
                string[] panelsToParse = Contents[currentLine].Split(' ');
                this.NumberOfPanelsForSegmentAtIndex = new List<string>();
                for (int i = 0; i < Convert.ToInt32(NumberOfSegments); i++)
                {
                    this.NumberOfPanelsForSegmentAtIndex.Add(panelsToParse[i]);
                }
            }
            currentLine++;
            //Hip Extensions
            this.HipExtensions = new List<TreHipExension>();
            this.NumberOfCalHipExtensions = Contents[currentLine].Split(' ')[0];
            currentLine++;
            for (int i = 0; i < Convert.ToInt32(NumberOfCalHipExtensions); i++)
            {
                string[] hipExtensionToParse = Contents[currentLine].Split(' ');
                this.HipExtensions.Add(new TreHipExension(hipExtensionToParse));
                currentLine++;
            }
            //Drop Tops
            this.DropTops = new List<TreDropTop>();
            this.NumberOfDropTops = Contents[currentLine].Split(' ')[0];
            currentLine++;
            for (int i = 0; i < Convert.ToInt32(NumberOfCalHipExtensions); i++)
            {
                string[] hipExtensionToParse = Contents[currentLine].Split(' ');
                this.HipExtensions.Add(new TreHipExension(hipExtensionToParse));
                currentLine++;
            }
        }
        
        private void _parseNotes()
        {
            currentLine = 583;
            string shopNotesToRead = Contents[currentLine];
            //Shop notes
            this.ShopNotes = "";
            while(shopNotesToRead.Trim().Equals("<E>") == false)
            {
                this.ShopNotes += shopNotesToRead;
                currentLine++;
                shopNotesToRead = Contents[currentLine];
            }
            currentLine++;
            //Truss notes
            currentLine = 586;
            _parseLine60();
            currentLine++;
            _parseLine62();
            //Load Information
            currentLine = 591;
            this.LiveLoads = new TreLoadInformation(Contents[currentLine].Split(',', ';'));
            currentLine++;
            this.TotalLoad = new TreLoadInformation(Contents[currentLine].Split(',', ';'));
            currentLine++;
            this.WindLive = new TreLoadInformation(Contents[currentLine].Split(',', ';'));
            currentLine++;
            this.WindTotal = new TreLoadInformation(Contents[currentLine].Split(',', ';'));
            currentLine++;
            //Reaction Info
            //this.NumberOfReactionInfoCases = Contents[currentLine].Trim();

        }
        #endregion

        #region _lineParsing
        private void _parseLine1()
        {
            string[] contentsLine1 = Contents[currentLine].Split(' ');
            this.InternalUnits = contentsLine1[0].Trim();
            this.DisplayUnits = contentsLine1[1].Trim();

            currentLine++;
        }

        private void _parseLine2()
        {
            string[] contentsLine2 = Contents[currentLine].Split(' ');
            this.SummaryResultOfAnalyze = contentsLine2[0].Trim();

            char[] charValues = contentsLine2[1].ToCharArray();
            string[] boolValues = charValues.Select(x => x.ToString()).ToArray();
            this.CSIFailure = boolValues[0];
            this.SSIFailure = boolValues[1];
            this.GeoconvertFailure = boolValues[2];
            this.AllJointsArePlated = boolValues[3];
            this.TrussUnstable = boolValues[4];
            this.EstimateHasBeenDone = boolValues[5];
            this.TrussDeflectionFailure = boolValues[6];
            this.CamberStatus = boolValues[7];
            this.ReactionFailure = boolValues[8];
            this.HorizontalTotalDeflectionFailure = boolValues[9];
            this.HorizontalLiveDeflectionFailure = boolValues[10];
            this.BearingOutOfScarf = boolValues[11];
            this.WedgeFailure = boolValues[12];
            this.HeelFailure = boolValues[13];
            this.FloorSpliceJointFailure = boolValues[14];
            this.BearingNotAtJointFailure = boolValues[15];
            this.BirdsmouthHeelFailure = boolValues[16];
            this.LSLFailure = boolValues[17];
            this.MinChordGradeFailureCanada = boolValues[18];
            this.Span2x3ExceededCanada = boolValues[19];
            this.Min2x3WebGradeFailureCanada = boolValues[20];
            this.Min2x4WebGradeFailureCanada = boolValues[21];
            this.DryLbrWithMetalWebFailCanada = boolValues[22];
            this.MaxAllowedSpanCanada = boolValues[23];
            this.NailingPatternFailureCanada = boolValues[24];
            this.MissedLoadingCanada = boolValues[25];
            this.UnspecifiedDesignFailCanada = boolValues[26];
            this.ChangedRequirementsCanada = boolValues[27];
            this.PanelRackingDeflectionFailure = boolValues[28];
            this.AnalysisResult = boolValues[29];

            this.TreVersionNumber = contentsLine2[2].Trim();
            currentLine++;
        }

        private void _parseLine3()
        {
            string[] contentsLine3 = Contents[currentLine].Split(' ');
            this.TypeOfTruss = contentsLine3[0].Trim();
            this.ProgramMode = contentsLine3[1].Trim();
            currentLine++;
        }

        private void _parseLine4()
        {
            currentLine++;
            //ToDo: Facility Info, to TrussID=[String]???
        }

        private void _parseLine5()
        {
            this.RoofOrFloorTruss = Contents[currentLine].Trim();
            currentLine++;
        }

        private void _parseLine6Roof()
        {
            string[] contentsLine6 = Contents[currentLine].Split(' '); 
            this.Quantity = contentsLine6[0];
            this.TrussSpan = contentsLine6[1];
            this.TopSlope = contentsLine6[2];
            this.BottomSlope = contentsLine6[3];
            this.LeftOverhangLength = contentsLine6[4];
            this.RightOverhangLength = contentsLine6[5];
            this.RoofSetupTrusses = contentsLine6[6];
            this.LeftTopChordOverhang = contentsLine6[7];
            this.RightTopChordOverhang = contentsLine6[8];
            this.DesignConnectionStatus = contentsLine6[9];
            currentLine++;
        }

        private void _parseLine6Floor()
        {
            string[] contentsLine6 = Contents[currentLine].Split(' ');
            this.Quantity = contentsLine6[0];
            this.TrussSpan = contentsLine6[1];
            this.LeftOverhangLength = contentsLine6[2]; //ToDo: Verify this is length
            this.RightOverhangLength = contentsLine6[2]; //ToDo: Verify this is length
            this.Spacing = contentsLine6[3];
            this.FloorSetupTrusses = contentsLine6[4];
            this.UserLevel = contentsLine6[5];
            this.PosiRoof = contentsLine6[6];
            this.RoofFloorPosi = contentsLine6[7];
            this.UseMitekAutomatedMach = contentsLine6[8];
            this.ShowTrimmableIcon = contentsLine6[9];
            this.TrimmableEnd = contentsLine6[10];
            this.UseFullMetalWebOnly = contentsLine6[11];
            this.DesignConnectionStatus = contentsLine6[12];
            currentLine++;
        }

        private void _parseLine7Roof()
        {
            string[] contentsLine7 = Contents[currentLine].Split(' ');
            this.LeftHeelHeight = contentsLine7[0];
            this.RightHeelHeight = contentsLine7[1];
            this.LeftSeatCut = contentsLine7[2];
            this.LeftBearingSize = contentsLine7[3];
            this.RightSeatCut = contentsLine7[4];
            this.RightBearingSize = contentsLine7[5];
            currentLine++;
        }
        
        private void _parseLine7Floor()
        {
            string[] contentsLine7 = Contents[currentLine].Split(' ');
            this.GirderTrussIndicator = contentsLine7[0];
            this.LoadingFileName = contentsLine7[1];
            currentLine++;
        }

        private void _parseLine8Roof()
        {
            string[] contentsLine8 = Contents[currentLine].Split(' ');
            this.LeftButtCut = contentsLine8[0];
            this.RightButtCut = contentsLine8[1];
            this.Spacing = contentsLine8[2];
            currentLine++;
        }

        private void _parseLine8Floor()
        {
            string[] contentsLine8 = Contents[currentLine].Split(' ');
            this.TrussDepth = contentsLine8[0];
            this.NumberOfTopChords = contentsLine8[1];
            this.NumberOfBottomChords = contentsLine8[2];
            this.Bearing1Size = contentsLine8[3];
            this.Bearing2Size = contentsLine8[4];
            this.TopChordRibbon1 = contentsLine8[5];
            this.TopChordRibbon2 = contentsLine8[6];
            this.BottomChordRibbon1 = contentsLine8[7];
            this.BottomChordRibbon2 = contentsLine8[8];
            currentLine++;
        }

        private void _parseLine9Roof()
        {
            string[] contentsLine9 = Contents[currentLine].Split(' ');
            this.LeftHeelMatch = contentsLine9[0];
            this.RightHeelMatch = contentsLine9[1];
            currentLine++;
        }

        private void _parseLine9Floor()
        {
            this.IdentificationString = Contents[currentLine];
            currentLine++;
        }

        private void _parseLine10Roof()
        {
            string[] contentsLine10 = Contents[currentLine].Split(' ');
            this.LeftOverhangType = contentsLine10[0];
            this.RightOverhangType = contentsLine10[1];
            currentLine++;
        }

        private void _parseLine10Floor()
        {
            this.NumberOfDetails = Contents[currentLine];
            currentLine++;
        }

        private void _parseLine11Roof()
        {
            string[] contentsLine11 = Contents[currentLine].Split(' ');
            this.GirderTrussIndicator = contentsLine11[0];
            this.LoadingFileName = contentsLine11[1];
            currentLine++;
        }

        private void _parseLine11Floor()
        {
            this.DetailType = Contents[currentLine];
            currentLine++;
        }

        private void _parseLine12Roof()
        {
            string[] contentsLine12 = Contents[currentLine].Split(' ');
            this.UserLevel = contentsLine12[0];
            this.AtticVersatruss = contentsLine12[1];
            currentLine++;
        }

        private void _parseLine12Floor()
        {
            string[] contentsLine12 = Contents[currentLine].Split(' ');
            if(this.DetailType.Equals("1"))
            {
                this.XCoordinateLocation = contentsLine12[0];
                this.NumberOfFullEndVertical = contentsLine12[1];
                this.NumberOfShortEndVertical = contentsLine12[2];
                this.TopRibbonDepth = contentsLine12[3];
            }
            else if(this.DetailType.Equals("2"))
            {
                this.XCoordinateLocation = contentsLine12[0];
                this.NumberOfFullEndVertical = contentsLine12[1];
                this.NumberOfShortEndVertical = contentsLine12[2];
                this.TopRibbonDepth = contentsLine12[3];
                this.BottomRibbonDepth = contentsLine12[4];
            }
            else if (this.DetailType.Equals("3"))
            {
                this.XCoordinateLocation = contentsLine12[0];
                this.NumberOfEndVerticals = contentsLine12[1];
            }
            else if (this.DetailType.Equals("4"))
            {
                this.XCoordinateLocation = contentsLine12[0];
                this.NumberOfEndVerticals = contentsLine12[1];
                this.FireCutOffset = contentsLine12[2];
            }
            else if (this.DetailType.Equals("5"))
            {
                this.XCoordinateLocation = contentsLine12[0];
                this.NumberOfEndVerticals = contentsLine12[1];
                this.BearingSize = contentsLine12[2];
                this.GapDistance = contentsLine12[3];
                this.NumberOfTopPlies = contentsLine12[4];
            }
            else if (this.DetailType.Equals("6"))
            {
                this.XCoordinateLocation = contentsLine12[0];
                this.BearingSize = contentsLine12[1];
                this.GapDistance = contentsLine12[2];
                this.NumberOfTopPlies = contentsLine12[3];
                this.BottomChordHoldBack = contentsLine12[4];
                this.FortyFiveDegreeFirstWeb = contentsLine12[5];
                this.WhichEnd = contentsLine12[6];
                this.NumberOfWebsFortyFiveDegreeCase = contentsLine12[7];
                this.LengthOfExtraTcPlies = contentsLine12[8];
            }
            else if (this.DetailType.Equals("7"))
            {
                this.XCoordinateLocation = contentsLine12[0];
                this.BearingSize = contentsLine12[1];
                this.BottomChordHoldBack = contentsLine12[2];
                this.NumberOfTopPlies = contentsLine12[3];
                this.MeasureFromTop = contentsLine12[4];
                this.BlockLocation = contentsLine12[5];
                this.MaterialListIndex = contentsLine12[6];
            }
            else if (this.DetailType.Equals("8"))
            {
                this.XCoordinateLocation = contentsLine12[0];
                this.NumberOfEndVerticals = contentsLine12[1];
                this.BearingSize = contentsLine12[2];
                this.BottomChordHoldBack = contentsLine12[3];
                this.NumberOfTopPlies = contentsLine12[4];
                this.MeasureFromTop = contentsLine12[5];
                this.BlockLocation = contentsLine12[6];
                this.MaterialListIndex = contentsLine12[7];
                this.RecutBottomChordByNumberOfEndVerticals = contentsLine12[8];
                this.DoubleTopChordLength = contentsLine12[9];
                this.AddAdditionalVerticalAtEndOfTopChord = contentsLine12[10];
                this.HorizontalLengthOfFirstWeb = contentsLine12[11];
            }
            else if (this.DetailType.Equals("9"))
            {
                this.XCoordinateLocation = contentsLine12[0];
                this.NumberOfVerticals = contentsLine12[1];
                this.NumberOfDrops = contentsLine12[2];
                this.SideMeasuredFrom = contentsLine12[3];
                this.LapDistance = contentsLine12[4];
                this.BearingCondition = contentsLine12[5];
                this.NotUsed = contentsLine12[6];
                this.WhichSideIsDropped = contentsLine12[7];
                this.RibbonBlockWidthIfUsed = contentsLine12[8];
            }
            else if (this.DetailType.Equals("10"))
            {
                this.XCoordinateLocation = contentsLine12[0];
                this.SideMeasuredFrom = contentsLine12[1];
                this.BearingCondition = contentsLine12[2];
            }
            else if (this.DetailType.Equals("11"))
            {
                this.XCoordinateLocation = contentsLine12[0];
                this.NumberOfVerticals = contentsLine12[1];
                this.SideMeasuredFrom = contentsLine12[2];
                this.BearingCondition = contentsLine12[3];
            }
            else if (this.DetailType.Equals("12"))
            {
                this.XCoordinateLocation = contentsLine12[0];
                this.Width = contentsLine12[1];
                this.NumberOfLeftVerticals = contentsLine12[2];
                this.NumberOfRightVerticals = contentsLine12[3];
                this.SideMeasuredFrom = contentsLine12[4];
            }
            else if (this.DetailType.Equals("13"))
            {
                this.XCoordinateLocation = contentsLine12[0];
                this.Width = contentsLine12[1];
                this.NumberOfTopPlies = contentsLine12[2];
                this.NumberOfLeftVerticals = contentsLine12[3];
                this.NumberOfRightVerticals = contentsLine12[4];
                this.ContinuousBottomChordFlag = contentsLine12[5];
                this.SideMeasuredFrom = contentsLine12[6];
                this.BearingCondition = contentsLine12[7];
            }
            else if (this.DetailType.Equals("14"))
            {
                this.XCoordinateLocation = contentsLine12[0];
                this.Width = contentsLine12[1];
                this.Height = contentsLine12[2];
                this.NumberOfTopPlies = contentsLine12[3];
                this.NumberOfLeftVerticals = contentsLine12[4];
                this.NumberOfRightVerticals = contentsLine12[5];
                this.ContinuousBottomChordFlag = contentsLine12[6];
                this.SideMeasuredFrom = contentsLine12[7];
                this.BearingCondition = contentsLine12[8];
            }
            currentLine++;
        }

        private void _parseLine13Roof()
        {
            string[] contentsLine13 = Contents[currentLine].Split(' ');
            this.LeftHeelReductionType = contentsLine13[0];
            this.RightHeelReductionType = contentsLine13[1];
            this.TrussApplicationType = contentsLine13[2];
            this.TurboWeb = contentsLine13[3];
            this.TurboWebSquare = contentsLine13[4];
            this.PosiRoof = contentsLine13[5];
            this.RoofDetailMode = contentsLine13[6];
            this.OptimizeTurbo = contentsLine13[7];
            this.TOWDoNotMoveVerticals = contentsLine13[8];
            this.TOWKeepVerticalsVertical = contentsLine13[9];
            this.TOWOptimizeApexVerts = contentsLine13[10];
            this.TOWOptimizeNonApexVerts = contentsLine13[11];
            this.SquareCutRoofWebs = contentsLine13[12];
            currentLine++;
        }

        private void _parseLine14Roof()
        {
            string[] contentsLine14 = Contents[currentLine].Split(' ');
            this.SecondAlternateSpacing = contentsLine14[0];
            this.FirstAlternateSpacing = contentsLine14[1];
            this.UseAlternateSpacing = contentsLine14[2];
            currentLine++;
        }
        
        private void _parseLine15Roof()
        {
            string[] contentsLine15 = Contents[currentLine].Split(' ');
            PiggybackFlag = contentsLine15[2];
            PiggybackStyle = contentsLine15[3];
            PiggybackGableFlag = contentsLine15[4];
            PiggybackBottomChordOffset = contentsLine15[5];
            PiggybackTailOffset = contentsLine15[6];
            PiggybackTopChordButtCutFlag = contentsLine15[7];
            PiggybackTopChordButtCutLength = contentsLine15[8];
            PiggybackBottomChordButtCutFlag = contentsLine15[9];
            PiggybackBottomChordButtCutLength = contentsLine15[10];
            currentLine++;
        }

        private void _parseLine16Roof()
        {
            string[] contentsLine16 = Contents[currentLine].Split(' ');
            PiggybackMinimumStudLength = contentsLine16[2];
            PiggybackStudSpacing = contentsLine16[3];
            PiggybackGableStudLayout = contentsLine16[4];
            PiggybackStringIdentifier = contentsLine16[5];
            currentLine++;
        }

        private void _parseLine25(TreMemberInfo treMemberInfo)
        {
            string[] line25 = Contents[currentLine].Trim().Split(','); 
            if (line25.Length < 4)
            {
                throw new Exception("Problem while parsing Member Info in TRE file (first line in Member Info section): too few items");
            }
            treMemberInfo.TrussHighestVerticalPoint = line25[0];
            treMemberInfo.TopChordLumberSize = line25[1];
            treMemberInfo.BottomChordLumberSize = line25[2];
            treMemberInfo.WebLumberSize = line25[3];
            currentLine++;
        }

        private void _parseLine26(TreMemberInfo treMemberInfo)
        {
            // Parse line 26 (see MiTek's documentation file for the TRE file format)
            // Line 26 == Contents[_memberInfoIndex + 2]
            string[] line26 = Contents[currentLine].Trim().Split(' ');
            if (line26.Length < 12)
            {
                throw new Exception("Problem while parsing Member Info in TRE file (second line in Member Info section): too few items");
            }
            treMemberInfo.NumberOfMembers = line26[0];
            treMemberInfo.OriginLineMemberNumber = line26[1];
            treMemberInfo.AlwaysSetTo0 = line26[2];
            treMemberInfo.InitialReferenceLineV0 = line26[3];
            treMemberInfo.InitialReferenceLineH0 = line26[4];
            treMemberInfo.InitialReferenceLineV99 = line26[5];
            treMemberInfo.InitialReferenceLineOHL = line26[6];
            treMemberInfo.InitialReferenceLineOHR = line26[7];
            treMemberInfo.InitialReferenceLineSCL = line26[8];
            treMemberInfo.InitialReferenceLineSCR = line26[9];
            treMemberInfo.InitialReferenceLineOH1 = line26[10];
            treMemberInfo.InitialReferenceLineOH2 = line26[11];
            currentLine++;
        }

        private void _parseLine27(TreMember treMember)
        {
            //Parse line 27 (see MiTek's documentation file for the TRE file format)
            //Line 27 is the first line of member data for each member
            //So go to the first line of the first member (_memberInfoIndex + 3)
            //And then adjust based on which member we're on ( + i * 5) (5 lines per member)
            var itemsOnLine27 = 62;
            string[] line27 = Contents[currentLine].Trim().Split(' ');
            if (line27.Length < itemsOnLine27)
            {
                throw new Exception("Problem while parsing a member in TRE file line " + 109 + ": should be " + itemsOnLine27 + " items but found only " + line27.Length);
            }
            treMember.MemberCounter = line27[0];
            treMember.MemberLabelLine27 = line27[1];
            treMember.MemberType = line27[2];
            treMember.LineType = line27[3];
            treMember.LineLocation = line27[4];
            treMember.MemberExistFlag = line27[5];
            treMember.InfiniteEnd = line27[6];
            treMember.WebInputFlag = line27[7];
            treMember.DefMaterial = line27[8];
            treMember.CurrentMaterialIndex = line27[9];
            treMember.OriginalMaterialIndex = line27[10];
            treMember.LumberFixity = line27[11];
            treMember.StructuralFlag = line27[12];
            treMember.CreatedByAnalogIndicatorFlag = line27[13];
            treMember.PosiIndicatorFlag = line27[14];
            treMember.PosiType = line27[15];
            treMember.PosiTopSide = line27[16];
            treMember.MemberZOrdering = line27[17];
            treMember.InventoryGuid = line27[18];
            treMember.HeelMemberFlag = line27[19];
            treMember.OriginalSpliceMember = line27[20];
            treMember.ShowSatusFlag = line27[21];
            treMember.PartNumber = line27[22];
            treMember.PurlinSpacing = line27[23];
            treMember.ParentLabel = line27[24];
            treMember.PosiId = line27[25];
            treMember.StackMemberFlag = line27[26];
            treMember.RemovedMember = line27[27];
            treMember.LeftTowCutFlag = line27[28];
            treMember.RightTowCutFlag = line27[29];
            treMember.ManuallyTurbowebbedFlag = line27[30];
            treMember.WebOptimizedFlag = line27[31];
            treMember.VerticalCutCorrectedForTowFlag = line27[32];
            treMember.TowApexVerticalFlag = line27[33];
            treMember.LeftTowCuttingCorrectedFlag = line27[34];
            treMember.RightTowCuttingCorrectedFlag = line27[35];
            treMember.LeftTowSquareFlag = line27[36];
            treMember.RightTowSquareFlag = line27[37];
            treMember.TrimmableEndFlag = line27[38];
            treMember.WhichEnd = line27[39];
            treMember.NotAlignedFlag = line27[40];
            treMember.FixityMaximumWidth = line27[41];
            treMember.FixityMaximumDepth = line27[42];
            treMember.FixityMinimumWidth = line27[43];
            treMember.FixityMinimumDepth = line27[44];
            treMember.SquareCutStatus = line27[45];
            treMember.CreateForRoofSquareCutFlag = line27[46];
            treMember.EndCutType = line27[47];
            treMember.ManuallySelectedBracing = line27[48];
            treMember.VersaModifiedFlag = line27[49];
            treMember.DefMaterialManuallyAdjustedFlag = line27[50];
            treMember.CreatedAsBearingBlockFlag = line27[51];
            treMember.CutForOutlookersFlag = line27[52];
            treMember.RepairScabFlag = line27[53];
            treMember.ManuallyHatchedMember = line27[54];
            treMember.FieldInstalledMember = line27[55];
            treMember.UserModifiedPartNumber = line27[56];
            treMember.UserModifiedHatch = line27[57];
            treMember.UserModifiedFieldInstallMember = line27[58];
            treMember.ShipLooseMember = line27[59];
            treMember.PlyThisMemberAppliesTo = line27[60];
            treMember.LumberEdgeFlatFlag = line27[61];
            currentLine++; 
        }

        private void _parseLine28(TreMember treMember)
        {
            // Parse line 28 (see MiTek's documentation file for the TRE file format)
            // Line 28 is the second line of member data for each member
            // So go to the second line of the first member (_memberInfoIndex + 4)
            // And then adjust based on which member we're on ( + i * 5) (5 lines per member)
            var itemsOnLine28 = 2;
            string[] line28 = Contents[currentLine].Trim().Split(' ');
            if (line28.Length < itemsOnLine28)
            {
                throw new Exception("Problem while parsing a member in TRE file line " + 110 + ": should be " + itemsOnLine28 + " items but found only " + line28.Length);
            }
            treMember.OriginalLumberIndex = line28[0];
            treMember.GableStudFlag = line28[1];
            currentLine++;
        }

        private void _parseLine31(TreMember treMember)
        {
            // Parse line 31 (see MiTek's documentation file for the TRE file format)
            // Line 31 is the third line of member data for each member
            // So go to the third line of the first member (_memberInfoIndex + 5)
            // And then adjust based on which member we're on ( + i * 5) (5 lines per member)
            var itemsOnLine31 = 16;
            string[] line31 = Contents[currentLine].Trim().Split(',');
            if (line31.Length < itemsOnLine31)
            {
                throw new Exception("Problem while parsing a member in TRE file line " + 111 + ": should be " + itemsOnLine31 + " items but found only " + line31.Length);
            }
            treMember.MemberSize = line31[0];
            treMember.MemberGrade = line31[1];
            treMember.MemberSpecies = line31[2];
            treMember.MemberThickness = line31[3];
            treMember.MemberWidth = line31[4];
            treMember.MemberShortLength = line31[5];
            treMember.MemberCenterLength = line31[6];
            treMember.MemberLongLength = line31[7];
            treMember.MemberOverallLength = line31[8];
            treMember.PointsOnMember = line31[9];
            treMember.MemberLabelLine31 = line31[10];
            treMember.PointsOnLeftEndOfMember = line31[11];
            treMember.MemberStockLength = line31[12];
            treMember.MemberCost = line31[13];
            currentLine++;
        }

        private void _parseLine32(TreMember treMember)
        {
            // Parse line 32 (see MiTek's documentation file for the TRE file format)
            // Line 32 is the fourth line of member data for each member
            // So go to the fourth line of the first member (_memberInfoIndex + 5)
            // And then adjust based on which member we're on ( + i * 5) (5 lines per member)
            string[] line32 = Contents[currentLine].Trim().Split(','); // Split on comma, these are points
            if (line32.Length % 2 != 0)
            {
                throw new Exception("Problem while parsing a member in TRE file line " + 111 + ": there is an odd number of numbers - should be even because represents points, which are in pairs (x,y)");
            }
            List<TrePoint> points = new List<TrePoint>();
            for (int j = 0; j < line32.Length; j = j + 2) // Advance by two because we're going point by point
            {
                TrePoint point = new TrePoint();
                point.X = line32[j].Trim();
                point.Y = line32[j + 1].Trim();
                points.Add(point);
            }
            currentLine++;
        }

        private void _parseLine33(TreMember treMember)
        {
            var itemsOnLine33 = 4;
            string[] line33 = Contents[currentLine].Trim().Split(' ');
            if (line33.Length < itemsOnLine33)
            {
                throw new Exception("Problem while parsing a member in TRE file line " + 112 + ": should be " + itemsOnLine33 + " items but found only " + line33.Length);
            }
            treMember.leftBevelType = line33[0];
            treMember.rightBevelType = line33[1];
            treMember.leftBevelAngle = line33[2];
            treMember.rightBevelAngle = line33[3];
            currentLine++;
        }

        private void _parseLine43()
        {
            string[] contentsLine43 = Contents[currentLine].Split(' ');
            this.NumberOfBearings = contentsLine43[0];
            this.WallLength = contentsLine43[1];
            currentLine++;
        }

        private void _parseLine45()
        {
            string[] contentsLine45 = Contents[currentLine].Split(' ');
            this.NumberOfProfile = contentsLine45[0];
            this.RHPoint = contentsLine45[1];
            this.CaliforniaHipIndicator = contentsLine45[2];
            this.CaliforniaHipExtension1 = contentsLine45[3];
            this.CaliforniaHipExtension2 = contentsLine45[4];
            this.DropHipIndicator = contentsLine45[5];
            this.DropHipAngle = contentsLine45[6];
            this.DropHipThickness = contentsLine45[7];
            this.CaliforniaHipCornerThickness = contentsLine45[8];
            this.CaliforniaHipFrontAngle = contentsLine45[9];
            this.CornerRafterIndicator = contentsLine45[10];
            this.MoveVertWebsTrussIndicator = contentsLine45[11];
            this.ApplyDropToAllIndicator = contentsLine45[12];
            currentLine++;
        }

        private void _parseLine60()
        {
            string[] contentsLine60 = Contents[currentLine].Split(' ');
            this.PartNumber = contentsLine60[0];
            this.TrussType = contentsLine60[1];
            this.StudSpacing = contentsLine60[2];
            this.OptimizeDuringAnalysis = contentsLine60[3];
            this.WebEndCutType = contentsLine60[4];
            this.TrussDifficultyFactor = contentsLine60[5];
            currentLine++;
        }

        private void _parseLine62() //ToDo: 112 Elements????????
        {
            string[] contentsLine62 = Contents[currentLine].Split(' ');
            this.DesignMethodSelected = contentsLine62[0];
            this.BuildingCode = contentsLine62[1];
            this.BuildingType = contentsLine62[2];
            this.ContinuityCode = contentsLine62[3];
            this.SheathTopChord = contentsLine62[4];
            this.SheathBottomChord = contentsLine62[5];
            this.DesignDeflection = contentsLine62[6];
            this.MaximumPlies = contentsLine62[7];
            this.MinimumPlies = contentsLine62[8];
            this.MaximumBraces = contentsLine62[9];
            this.TopChordPurlinSpacing = contentsLine62[10];
            this.BottomChordPurlinSpacing = contentsLine62[11];
            this.CheckStockLength = contentsLine62[12];
            this.WetService = contentsLine62[13];
            this.StepLumber = contentsLine62[14];
            this.PinnedSplices = contentsLine62[15];
            this.NumberOfPlies = contentsLine62[16];
            this.BracingType = contentsLine62[17];
            this.UseBoltHoles = contentsLine62[18];
            this.BoltHoleDiameter = contentsLine62[19];
            this.DeflnCompositeAction = contentsLine62[20];

            //ToDo: desinfo.cpp
            this.TwoAnalogNodesForDado = contentsLine62[22];
            this.FlatTopChordSheathingMaterialIndex = contentsLine62[23];
            this.Index = contentsLine62[24];
            this.BottomChordSheathingMaterial = contentsLine62[25];
            this.TopChordSheathingGroup = contentsLine62[26];
            this.FlatTopChordSheathingGroup = contentsLine62[27];
            this.BottomChordSheathingGroup = contentsLine62[28];
            this.CreepFactorDryLumber = contentsLine62[29];
            this.CreepFactorWetLumber = contentsLine62[30];
            this.HeelDesignMethodSelected = contentsLine62[31];
            this.UseVerticalMembersForMultiPlyNails = contentsLine62[32];
            this.FirstPreferenceBearingDesignOption = contentsLine62[33];
            this.SecondPreferenceBearingDesignOption = contentsLine62[34];
            this.ThirdPreferenceBearingDesignOption = contentsLine62[35];

            this.TrussSheathingMaterial = contentsLine62[36];
            this.TrussSheathingInventoryID = contentsLine62[37];
            this.NailTrussSymmetrically = contentsLine62[38];
            this.BearingMaterialConsiderList = contentsLine62[39];
            this.BearingMaterialIndex = contentsLine62[40];
            this.GussetRepairCheckGrainDirection = contentsLine62[41];
            this.GussetRepairIncrementMaterial = contentsLine62[42];
            this.GussetRepairDoubleLayer = contentsLine62[43];
            this.GussetRepairOption1 = contentsLine62[44];
            this.GussetRepairOption2 = contentsLine62[45];
            this.GussetRepairOption3 = contentsLine62[46];
            this.RepairSheathingMaterialIndex = contentsLine62[47];
            this.GussetRepairInventoryID = contentsLine62[48];
            this.AnalogMethod = contentsLine62[49];
            this.MinSliderLength = contentsLine62[50];
            this.MinSliderPercent = contentsLine62[51];

            this.FirstAndThirdLength = contentsLine62[52];
            this.TwoAnalogNodesForDado = contentsLine62[53];
            this.BearingCapacity = contentsLine62[54];
            this.UseModifyBendingCapacityFactor = contentsLine62[55];
            this.ForintekTrussOverride = contentsLine62[56];
            this.LatBracingMaterialInventoryID = contentsLine62[57];
            this.LatBracingStartMaterial = contentsLine62[58];
            this.BracingMaterialFixity = contentsLine62[59];
            this.IgnoreFlatRoofPart9Factor = contentsLine62[60];
            this.UseBearingSizeKzpFactor = contentsLine62[61];
            this.BearingSupportDepth = contentsLine62[62];
            this.PlyToPlyCompositeDesign = contentsLine62[63];
            currentLine++;
        }
        
        #endregion
    }
}
