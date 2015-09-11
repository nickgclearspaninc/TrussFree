using UnitClassLibrary;

namespace ComponentFileReader.LumberClass
{
    /// <summary>
    /// Contains all the information related to a piece of woods, Distances.
    /// This includes it's nominal and physical sizes
    /// 
    /// Lumber Distances

    ///2x4s are not actually 2 inches by 4 inches. When the board is first rough sawn from the log, it is a true 2x4,
    ///but the drying process and planing of the board reduce it to the finished 1.5x3.5 size. 
    ///
    /// Here are the common sizes of lumber, and their actual sizes.
    ///
    ///   Nominal	         Actual	        Actual - Metric
    ///   1" x 2"	      3/4" x 1-1/2"	      19 x 38  mm
    ///   1" x 3"	      3/4" x 2-1/2"	      19 x 64  mm
    ///   1" x 4"	      3/4" x 3-1/2"	      19 x 89  mm
    ///   1" x 5"	      3/4" x 4-1/2"	      19 x 114 mm
    ///   1" x 6"	      3/4" x 5-1/2"	      19 x 140 mm
    ///   1" x 7"	      3/4" x 6-1/4"	      19 x 159 mm
    ///   1" x 8"	      3/4" x 7-1/4"	      19 x 184 mm
    ///   1" x 10"	      3/4" x 9-1/4"	      19 x 235 mm
    ///   1" x 12"	      3/4" x 11-1/4"	  19 x 286 mm
    ///   1-1/4" x 4"	  1" x 3-1/2"	      25 x 89  mm
    ///   1-1/4" x 6"	  1" x 5-1/2"	      25 x 140 mm
    ///   1-1/4" x 8"	  1" x 7-1/4"	      25 x 184 mm
    ///   1-1/4" x 10"	  1" x 9-1/4"	      25 x 235 mm
    ///   1-1/4" x 12"	  1" x 11-1/4"	      25 x 286 mm
    ///   1-1/2" x 4"	  1-1/4" x 3-1/2"	  32 x 89  mm
    ///   1-1/2" x 6"	  1-1/4" x 5-1/2"	  32 x 140 mm
    ///   1-1/2" x 8"	  1-1/4" x 7-1/4"	  32 x 184 mm
    ///   1-1/2" x 10"	  1-1/4" x 9-1/4"	  32 x 235 mm
    ///   1-1/2" x 12"	  1-1/4" x 11-1/4"	  32 x 286 mm
    ///   2" x 2"	      1-1/2" x 1-1/2"	  38 x 38  mm
    ///   2" x 4"	      1-1/2" x 3-1/2"	  38 x 89  mm
    ///   2" x 6"	      1-1/2" x 5-1/2"	  38 x 140 mm
    ///   2" x 8"	      1-1/2" x 7-1/4"	  38 x 184 mm
    ///   2" x 10"	      1-1/2" x 9-1/4"	  38 x 235 mm
    ///   2" x 12"	      1-1/2" x 11-1/4"	  38 x 286 mm
    ///   3" x 6"	      2-1/2" x 5-1/2"	  64 x 140 mm
    ///   4" x 4"	      3-1/2" x 3-1/2"	  89 x 89  mm
    ///   4" x 6"	      3-1/2" x 5-1/2"	  89 x 140 mm
    ///
    /// implicitly assumes height by width by length to be thought of where the 2 in 2X4 is thickness the 4 is width and the length of the lumber is obviously length
    /// a 10 foot 2X4 looks like the image below when stood vertically (Not to scale)
    /// 
    /// 
    /// 
    ///                                 , ..,$~ ..........................IO.  ___
    ///                                 . N, ...                     .. =+8       |
    ///                             ... $+.   .                     ..,$ .8 .     |
    ///                       . .  .,Z.                         .   + . . O .     |
    ///                     ...   .8,..                        .  .:,   . O .     |
    ///                     .   +7 ..,                         ..O... .,. O .     |
    ///                   .  ,8. .                  . . . . . =~ ..     . O .     |
    ///                   ..O:....                  . ...  ..?.         . O .     |
    ///                 .ID,.   ..                   .  .  8+...  ..    . O .     |
    ///             ...I... . ...                       D7..    . .     . O .     |
    ///          .. .Z ......................... . . .~O                . O .     |
    ///       . ,,~,  .......................... ,..D..                 . O .     | 
    ///       .O~?++?+++++++++++++++++++++++++++I?N ..                  . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |   --- Length = 10
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                  .O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                 . O .     |
    ///      .  8                               . .D...                  .O .  ___|
    ///      .  8                               . .D...                   O ,
    ///      .  8                               . .D...                  ,Z..  ___
    ///      .  8                               . .D...                  ~ ..   / 
    ///      .  8                               . .D...             ..  Z ,    /
    ///      .  8                               . .D...             .,~8      /
    ///      .  8                               . .D...            . +.      /
    ///      .  8                               . .D...       .  . +..      / 
    ///      .  8                               . .D...       . . Z:,      /  
    ///      .  8                               . .D...        .?Z.,      /   
    ///      .  8                               . .D...       ~8         / 
    ///      .  8                               . .D...  .....8        /  Width = 4 nominal inches
    ///      .  8                               . .D...   . 8.        / 
    ///      .  8                               . .D...  .8.         /
    ///      .  8                               . .D . ..=O         /     
    ///      .  8                               . .D. . O,         /     
    ///      .  8                               . .D. $,          /     
    ///      .  8                               . .D=O.       ___/    
    ///        .Z                             . ,N..0                       
    ///      ... ................................                       
    ///         |___________________________________|
    ///                          |
    ///                 Thickness = 2 nominal Inches   
    ///                 
    /// </summary>
    public partial class Lumber
    {

        public string NominalWidth
        {
            get
            {
                Distance nominal = new Distance(DistanceType.Inch, ConvertActualInchesToDecimalNominal(Width.Inches));
                return nominal.Architectural;
            }
        }

        public string NominalHeight
        {
            get
            {
                Distance nominal = new Distance(DistanceType.Inch, ConvertActualInchesToDecimalNominal(Thickness.Inches));
                return nominal.Architectural;
            }
        }


        /// <summary>
        /// A strange standard of the wood industry for refering to the volume of wood.
        /// </summary>
        /// <returns>Only returns a string because we want to discourage this standard as much as possible.</returns>
        public string NominalCubicBoardFeet()
        {
            //the formula is NominalWidthInches * NominalHeightInches * LengthInches / 144
            double nominalWidthInches = ConvertActualInchesToDecimalNominal(this.Width.Inches);
            double nominalHeightInches = ConvertActualInchesToDecimalNominal(this.Thickness.Inches);

            return (nominalWidthInches * nominalHeightInches * this.Length.Inches / 144).ToString();
        }

        public static double ConvertActualInchesToDecimalNominal(double realInches)
        {
            double nominalInches = 0.0;
            if (realInches >= 6.25)
            {
                nominalInches = realInches + .75;
            }
            else if (realInches >= 1.49 && realInches < 6.25)
            {
                nominalInches = realInches + .5;
            }
            //less than 1.49
            else
            {
                nominalInches = realInches + .25;
            }

            return nominalInches;
        }

        public static double ConvertNominalInchesToActual(double nominalInches)
        {
            double realInches = 0.0;

            if (nominalInches >= 7)
            {
                realInches = nominalInches - .75;

            }
            else if (nominalInches >= 2 && nominalInches < 7)
            {

                realInches = nominalInches - .5;

            }
            //less than 2
            else
            {
                realInches = nominalInches - .25;
            }

            return realInches;
        }
    }


}
