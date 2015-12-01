using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentFileReader.FileClasses.TreComponent
{
    public partial class TreComponent
    {
        // Section index variables
        private int _memberInfoIndex = -1;
        private int _roofTrussIndex = -1;
        private int _floorTrussIndex = -1;
        private int _detailInfoIndex = -1;
        private int _webbingInfoIndex = -1;
        private int _sheathingInfoIndex = -1;
        private int _plateInfoIndex = -1;

        /// <summary>
        /// Entrance point for parsing Tre data
        /// </summary>
        private void _parseTreData()
        {
            _parseLine1();
            _parseLine2();
            _parseLine3();
            _parseLine5();
            if(this.RoofOrFloorTruss.Equals("ROOF BASICS"))
            {
                _parseLine6Roof();
                _parseLine7Roof();
                _parseLine8Roof();
                _parseLine9Roof();
                _parseLine10Roof();
                _parseLine11Roof();
                _parseLine12Roof();
                _parseLine13Roof();
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
            }
        }

        private void _parseLine1()
        {
            string[] contentsLine1 = Contents[0].Split(' ');
            this.InternalUnits = contentsLine1[0].Trim();
            this.DisplayUnits = contentsLine1[1].Trim();
        }

        private void _parseLine2()
        {
            string[] contentsLine2 = Contents[1].Split(' ');
            this.GeoconvertFailure = contentsLine2[0].Trim();

            char[] charValues = contentsLine2[1].ToCharArray();
            string[] boolValues = charValues.Select(x => x.ToString()).ToArray();
            this.AllJointsArePlated = boolValues[0];
            this.TrussUnstable = boolValues[1];
            this.EstimateHasBeenDone = boolValues[2];
            this.TrussDeflectionFailure = boolValues[3];
            this.CamberStatus = boolValues[4];
            this.ReactionFailure = boolValues[5];
            this.HorizontalTotalDeflectionFailure = boolValues[6];
            this.HorizontalLiveDeflectionFailure = boolValues[7];
            this.BearingOutOfScarf = boolValues[8];
            this.WedgeFailure = boolValues[9];
            this.HeelFailure = boolValues[10];
            this.FloorSpliceJointFailure = boolValues[11];
            this.BearingNotAtJointFailure = boolValues[12];
            this.BirdsmouthHeelFailure = boolValues[13];
            this.LSLFailure = boolValues[14];
            this.MinChordGradeFailureCanada = boolValues[15];
            this.Span2x3ExceededCanada = boolValues[16];
            this.Min2x3WebGradeFailureCanada = boolValues[17];
            this.Min2x4WebGradeFailureCanada = boolValues[18];
            this.DryLbrWithMetalWebFailCanada = boolValues[19];
            this.MaxAllowedSpanExceedCanada = boolValues[20];
            this.NailingPatternFailureCanada = boolValues[21];
            this.MissedLoadingCanada = boolValues[22];
            this.UnspecifiedDesignFailCanada = boolValues[23];
            this.ChangedRequirementsCanada = boolValues[24];
            this.PanelRackingDeflectionFailure = boolValues[25];
            this.AnalysisResult = boolValues[26];

            this.TreVersionNumber = contentsLine2[2].Trim();
        }

        private void _parseLine3()
        {
            string[] contentsLine3 = Contents[2].Split(' ');
            this.TypeOfTruss = contentsLine3[0].Trim();
            this.ProgramMode = contentsLine3[1].Trim();
        }

        private void _parseLine4()
        {
            //ToDo: Facility Info, to TrussID=[String]???
        }

        private void _parseLine5()
        {
            this.RoofOrFloorTruss = Contents[4].Trim();
        }

        private void _parseLine6Roof()
        {
            string[] contentsLine6 = Contents[5].Split(' '); 
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
        }

        private void _parseLine6Floor()
        {
            string[] contentsLine6 = Contents[5].Split(' ');
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
        }

        private void _parseLine7Roof()
        {
            string[] contentsLine7 = Contents[6].Split(' ');
            this.LeftHeelHeight = contentsLine7[0];
            this.RightHeelHeight = contentsLine7[1];
            this.LeftSeatCut = contentsLine7[2];
            this.LeftBearingSize = contentsLine7[3];
            this.RightSeatCut = contentsLine7[4];
            this.RightBearingSize = contentsLine7[5];
        }
        
        private void _parseLine7Floor()
        {
            string[] contentsLine7 = Contents[6].Split(' ');
            this.GirderTrussIndicator = contentsLine7[0];
            this.LoadingFileName = contentsLine7[1];
        }

        private void _parseLine8Roof()
        {
            string[] contentsLine8 = Contents[7].Split(' ');
            this.LeftButtCut = contentsLine8[0];
            this.RightButtCut = contentsLine8[1];
            this.Spacing = contentsLine8[2];
        }

        private void _parseLine8Floor()
        {
            string[] contentsLine8 = Contents[7].Split(' ');
            this.TrussDepth = contentsLine8[0];
            this.NumberOfTopChords = contentsLine8[1];
            this.NumberOfBottomChords = contentsLine8[2];
            this.Bearing1Size = contentsLine8[3];
            this.Bearing2Size = contentsLine8[4];
            this.TopChordRibbon1 = contentsLine8[5];
            this.TopChordRibbon2 = contentsLine8[6];
            this.BottomChordRibbon1 = contentsLine8[7];
            this.BottomChordRibbon2 = contentsLine8[8];
        }

        private void _parseLine9Roof()
        {
            string[] contentsLine9 = Contents[8].Split(' ');
            this.LeftHeelMatch = contentsLine9[0];
            this.RightHeelMatch = contentsLine9[1];
        }

        private void _parseLine9Floor()
        {
            this.IdentificationString = Contents[8];
        }

        private void _parseLine10Roof()
        {
            string[] contentsLine10 = Contents[9].Split(' ');
            this.LeftOverhangType = contentsLine10[0];
            this.RightOverhangType = contentsLine10[1];
        }

        private void _parseLine10Floor()
        {
            this.NumberOfDetails = Contents[9];
        }

        private void _parseLine11Roof()
        {
            string[] contentsLine11 = Contents[10].Split(' ');
            this.GirderTrussIndicator = contentsLine11[0];
            this.LoadingFileName = contentsLine11[1];
        }

        private void _parseLine11Floor()
        {
            this.DetailType = Contents[10];
        }

        private void _parseLine12Roof()
        {
            string[] contentsLine12 = Contents[11].Split(' ');
            this.UserLevel = contentsLine12[0];
            this.AtticVersatruss = contentsLine12[1];
        }

        private void _parseLine12Floor()
        {
            string[] contentsLine12 = Contents[11].Split(' ');
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

            }
            else if (this.DetailType.Equals("7"))
            {

            }
            else if (this.DetailType.Equals("8"))
            {

            }
            else if (this.DetailType.Equals("9"))
            {

            }
            else if (this.DetailType.Equals("10"))
            {

            }
            else if (this.DetailType.Equals("11"))
            {

            }
            else if (this.DetailType.Equals("12"))
            {

            }
            else if (this.DetailType.Equals("13"))
            {

            }
            else if (this.DetailType.Equals("14"))
            {

            }
        }

        private void _parseLine13Roof()
        {
            string[] contentsLine13 = Contents[12].Split(' ');
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
        }

        /// <summary>
        /// Check that can proceed with parsing
        /// </summary>
        /// <param name="index">The variable that is supposed to be an index to a section</param>
        /// <returns></returns>
        private bool _parsingPrerequisites(int index)
        {
            // If there are no file contents, we cannot parse members
            if (Contents == null)
            {
                return false;
            }

            // If indices have not yet been determined, that needs to happen
            if (index == -1)
            {
                _obtainIndices();
            }

            return true;
        }

        /// <summary>
        /// Set the line indices for different sections
        /// </summary>
        private void _obtainIndices()
        {
            for (int i = 0; i < Contents.Length; i++)
            {
                switch (Contents[i].Trim())
                {
                    case "ROOF BASICS":
                        _roofTrussIndex = i;
                        break;
                    case "FLOOR BASICS":
                        _floorTrussIndex = i;
                        break;
                    case "DETAIL INFO":
                        _detailInfoIndex = i;
                        break;
                    case "WEBBING INFO":
                        _webbingInfoIndex = i;
                        break;
                    case "SHEATHING INFORMATION":
                        _sheathingInfoIndex = i;
                        break;
                    case "MEMBER INFO":
                        _memberInfoIndex = i;
                        break;
                    case "[Plate Info V4000]":
                        _plateInfoIndex = i;
                        break;
                }
            }
        }

        /// <summary>
        /// From the Contents build a List<TreMember> and set _treMemberInfo, the backing property for TreMemberInfo
        /// </summary>
        private void _parseMemberInfo()
        {
            if(!_parsingPrerequisites(_memberInfoIndex)) //Return if we cannot parse member
            {
                return;
            }
            TreMemberInfo treMemberInfo = new TreMemberInfo();

            // The line numbers should not be understood as concrete, but as pointers to the line specified in the Mitek documentation
            _parseLine25(treMemberInfo);
            _parseLine26(treMemberInfo);

            // Set truss members
            for (int i = 0; i < treMemberInfo.NumberOfMembers.Length; i++)
            {
                TreMember treMember = new TreMember();

                // Parse the five lines that make up a truss member
                // The line numbers should not be understood as concrete, but as pointers to the line specified in the Mitek documentation
                _parseLine27(treMember, i);
                _parseLine28(treMember, i);
                _parseLine31(treMember, i);
                _parseLine32(treMember, i);
                _parseLine33(treMember, i);

                treMemberInfo.TreMembers.Add(treMember);
            }
        }
        

        private void _parseLine25(TreMemberInfo treMemberInfo)
        {
            // Parse line 25 (see MiTek's documentation file for the TRE file format)
            // Line 25 == Contents[_memberInfoIndex + 1]
            string[] line25 = Contents[_memberInfoIndex + 1].Trim().Split(' ');
            if (line25.Length < 4)
            {
                throw new Exception("Problem while parsing Member Info in TRE file (first line in Member Info section): too few items");
            }
            treMemberInfo.TrussHighestVerticalPoint = line25[0];
            treMemberInfo.TopChordLumberSize = line25[1];
            treMemberInfo.BottomChordLumberSize = line25[2];
            treMemberInfo.WebLumberSize = line25[3];
        }

        private void _parseLine26(TreMemberInfo treMemberInfo)
        {
            // Parse line 26 (see MiTek's documentation file for the TRE file format)
            // Line 26 == Contents[_memberInfoIndex + 2]
            string[] line26 = Contents[_memberInfoIndex + 2].Trim().Split(' ');
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
        }

        private void _parseLine27(TreMember treMember, int memberNumber)
        {
            // Parse line 27 (see MiTek's documentation file for the TRE file format)
            // Line 27 is the first line of member data for each member
            // So go to the first line of the first member (_memberInfoIndex + 3)
            // And then adjust based on which member we're on ( + i * 5) (5 lines per member)
            var line27Index = _memberInfoIndex + 3 + memberNumber * 5;
            var itemsOnLine27 = 62;
            string[] line27 = Contents[line27Index].Trim().Split(' ');
            if (line27.Length < itemsOnLine27)
            {
                throw new Exception("Problem while parsing a member in TRE file line " + line27Index + ": should be " + itemsOnLine27 + " items but found only " + line27.Length);
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
        }

        private void _parseLine28(TreMember treMember, int memberNumber)
        {
            // Parse line 28 (see MiTek's documentation file for the TRE file format)
            // Line 28 is the second line of member data for each member
            // So go to the second line of the first member (_memberInfoIndex + 4)
            // And then adjust based on which member we're on ( + i * 5) (5 lines per member)
            var line28Index = _memberInfoIndex + 4 + memberNumber * 5;
            var itemsOnLine28 = 2;
            string[] line28 = Contents[line28Index].Trim().Split(' ');
            if (line28.Length < itemsOnLine28)
            {
                throw new Exception("Problem while parsing a member in TRE file line " + line28Index + ": should be " + itemsOnLine28 + " items but found only " + line28.Length);
            }
            treMember.OriginalLumberIndex = line28[0];
            treMember.GableStudFlag = line28[1];
        }

        private void _parseLine31(TreMember treMember, int memberNumber)
        {
            // Parse line 31 (see MiTek's documentation file for the TRE file format)
            // Line 31 is the third line of member data for each member
            // So go to the third line of the first member (_memberInfoIndex + 5)
            // And then adjust based on which member we're on ( + i * 5) (5 lines per member)
            var line31Index = _memberInfoIndex + 5 + memberNumber * 5;
            var itemsOnLine31 = 14;
            string[] line31 = Contents[line31Index].Trim().Split(' ');
            if (line31.Length < itemsOnLine31)
            {
                throw new Exception("Problem while parsing a member in TRE file line " + line31Index + ": should be " + itemsOnLine31 + " items but found only " + line31.Length);
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
        }

        private void _parseLine32(TreMember treMember, int memberNumber)
        {
            // Parse line 32 (see MiTek's documentation file for the TRE file format)
            // Line 32 is the fourth line of member data for each member
            // So go to the fourth line of the first member (_memberInfoIndex + 5)
            // And then adjust based on which member we're on ( + i * 5) (5 lines per member)
            var line32Index = _memberInfoIndex + 6 + memberNumber * 5;
            string[] line32 = Contents[line32Index].Trim().Split(','); // Split on comma, these are points
            if (line32.Length % 2 != 0)
            {
                throw new Exception("Problem while parsing a member in TRE file line " + line32Index + ": there is an odd number of numbers - should be even because represents points, which are in pairs (x,y)");
            }
            List<TrePoint> points = new List<TrePoint>();
            for (int j = 0; j < line32.Length; j = j + 2) // Advance by two because we're going point by point
            {
                TrePoint point = new TrePoint();
                point.X = line32[j].Trim();
                point.Y = line32[j + 1].Trim();
                points.Add(point);
            }
        }

        private void _parseLine33(TreMember treMember, int memberNumber)
        {
            // Parse line 33 (see MiTek's documentation file for the TRE file format)
            // Line 33 is the fifth line of member data for each member
            // So go to the fifth line of the first member (_memberInfoIndex + 5)
            // And then adjust based on which member we're on ( + i * 5) (5 lines per member)
            var line33Index = _memberInfoIndex + 7 + memberNumber * 5;
            var itemsOnLine33 = 4;
            string[] line33 = Contents[line33Index].Trim().Split(' ');
            if (line33.Length < itemsOnLine33)
            {
                throw new Exception("Problem while parsing a member in TRE file line " + line33Index + ": should be " + itemsOnLine33 + " items but found only " + line33.Length);
            }
            treMember.leftBevelType = line33[0];
            treMember.rightBevelType = line33[1];
            treMember.leftBevelAngle = line33[2];
            treMember.rightBevelAngle = line33[3];
        }
    }
}
