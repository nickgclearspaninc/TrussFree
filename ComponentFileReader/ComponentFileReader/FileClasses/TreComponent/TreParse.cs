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
            // Determine if can proceed with member parsing
            if(!_parsingPrerequisites(_memberInfoIndex))
            {
                return;
            }

            TreMemberInfo treMemberInfo = new TreMemberInfo();

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

            // Parse line 26 (see MiTek's documentation file for the TRE file format)
            // Line 26 == Contents[_memberInfoIndex + 2]
            string[] line26 = Contents[_memberInfoIndex + 2].Trim().Split(' ');
            if (line25.Length < 12)
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

            // Parse line 27 (see MiTek's documentation file for the TRE file format)
            // Line 27 == Contents[_memberInfoIndex + 3]
            string[] line27 = Contents[_memberInfoIndex + 3].Trim().Split(' ');
            if (line25.Length < 62)
            {
                throw new Exception("Problem while parsing Member Info in TRE file (third line in Member Info section): too few items");
            }
            treMemberInfo.MemberCounter = line27[0];
            treMemberInfo.MemberLabel = line27[1];
            treMemberInfo.MemberType = line27[2];
            treMemberInfo.LineType = line27[3];
            treMemberInfo.LineLocation = line27[4];
            treMemberInfo.MemberExistFlag = line27[5];
            treMemberInfo.InfiniteEnd = line27[6];
            treMemberInfo.WebInputFlag = line27[7];
            treMemberInfo.DefMaterial = line27[8];
            treMemberInfo.CurrentMaterialIndex = line27[9];
            treMemberInfo.OriginalMaterialIndex = line27[10];
            treMemberInfo.LumberFixity = line27[11];
            treMemberInfo.StructuralFlag = line27[12];
            treMemberInfo.CreatedByAnalogIndicatorFlag = line27[13];
            treMemberInfo.PosiIndicatorFlag = line27[14];
            treMemberInfo.PosiType = line27[15];
            treMemberInfo.PosiTopSide = line27[16];
            treMemberInfo.MemberZOrdering = line27[17];
            treMemberInfo.InventoryGuid = line27[18];
            treMemberInfo.HeelMemberFlag = line27[19];
            treMemberInfo.OriginalSpliceMember = line27[20];
            treMemberInfo.ShowSatusFlag = line27[21];
            treMemberInfo.PartNumber = line27[22];
            treMemberInfo.PurlinSpacing = line27[23];
            treMemberInfo.ParentLabel = line27[24];
            treMemberInfo.PosiId = line27[25];
            treMemberInfo.StackMemberFlag = line27[26];
            treMemberInfo.RemovedMember = line27[27];
            treMemberInfo.LeftTowCutFlag = line27[28];
            treMemberInfo.RightTowCutFlag = line27[29];
            treMemberInfo.ManuallyTurbowebbedFlag = line27[30];
            treMemberInfo.WebOptimizedFlag = line27[31];
            treMemberInfo.VerticalCutCorrectedForTowFlag = line27[32];
            treMemberInfo.TowApexVerticalFlag = line27[33];
            treMemberInfo.LeftTowCuttingCorrectedFlag = line27[34];
            treMemberInfo.RightTowCuttingCorrectedFlag = line27[35];
            treMemberInfo.LeftTowSquareFlag = line27[36];
            treMemberInfo.RightTowSquareFlag = line27[37];
            treMemberInfo.TrimmableEndFlag = line27[38];
            treMemberInfo.WhichEnd = line27[39];
            treMemberInfo.NotAlignedFlag = line27[40];
            treMemberInfo.FixityMaximumWidth = line27[41];
            treMemberInfo.FixityMaximumDepth = line27[42];
            treMemberInfo.FixityMinimumWidth = line27[43];
            treMemberInfo.FixityMinimumDepth = line27[44];
            treMemberInfo.SquareCutStatus = line27[45];
            treMemberInfo.CreateForRoofSquareCutFlag = line27[46];
            treMemberInfo.EndCutType = line27[47];
            treMemberInfo.ManuallySelectedBracing = line27[48];
            treMemberInfo.VersaModifiedFlag = line27[49];
            treMemberInfo.DefMaterialManuallyAdjustedFlag = line27[50];
            treMemberInfo.CreatedAsBearingBlockFlag = line27[51];
            treMemberInfo.CutForOutlookersFlag = line27[52];
            treMemberInfo.RepairScabFlag = line27[53];
            treMemberInfo.ManuallyHatchedMember = line27[54];
            treMemberInfo.FieldInstalledMember = line27[55];
            treMemberInfo.UserModifiedPartNumber = line27[56];
            treMemberInfo.UserModifiedHatch = line27[57];
            treMemberInfo.UserModifiedFieldInstallMember = line27[58];
            treMemberInfo.ShipLooseMember = line27[59];
            treMemberInfo.PlyThisMemberAppliesTo = line27[60];
            treMemberInfo.LumberEdgeFlatFlag = line27[61];

            // Set truss members
            for (int i = 0; i < treMemberInfo.NumberOfMembers.Length; i++)
            {
                TreMember treMember = new TreMember();



                treMemberInfo.TreMembers.Add(treMember);
            }
        }
    }
}
