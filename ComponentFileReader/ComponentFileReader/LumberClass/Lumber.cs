using System.ComponentModel;
using Newtonsoft.Json;
using UnitClassLibrary;

namespace ComponentFileReader.LumberClass
{
    /// <summary>
    /// This class represents a specific piece lumber as it flows through the different stages of component production.
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class Lumber
    {
        [JsonProperty]
        public string Mill { get; set; }

        [JsonProperty]
        public string Species { get; set; }

        [JsonProperty]
        public string Grade { get; set; }

        /// <summary>
        /// The Height, sometimes called the Depth
        /// The 2 in 2x4
        /// </summary>
        [JsonProperty]
        public virtual Distance Thickness { get; set; }

        /// <summary>
        /// The Width
        /// The 4 in 2x4
        /// </summary>
        [JsonProperty]
        public virtual Distance Width { get; set; }

        /// <summary>
        /// The Length
        /// The 10 in a 10ft 2x4
        /// </summary>
        [JsonProperty]
        public virtual Distance Length { get; set; }

        [JsonProperty]
        public string TreatmentType { get; set; }

        /// <summary>
        /// Space for misc. notes about the lumber
        /// </summary>
        [JsonProperty]
        public string Other { get; set; }

        public Area CrossSectionalArea
        {
            get
            {
                return new Area(AreaType.InchesSquared, Thickness.Inches * Width.Inches);
            }
        }

        /// <summary>
        /// complete constructor
        /// </summary>
        /// <param name="thickness">The depth; the 2 in 2x4 10ft</param>
        /// <param name="width">the 4 in 2x4 10ft</param>
        /// <param name="length">the 10 in 2x4 10ft</param>
        /// <param name="grade">as in SelectStructural or Number 1</param>
        /// <param name="species">as in Southern Yellow Pine (SYP)</param>
        /// <param name="treatmentType">what the lumber is treated with</param>
        /// <param name="mill">the place the lumber was originally cut into boards</param>
        /// <param name="passedBundle">the group of boards the lumber was delivered in</param>
        /// <param name="other">other information</param>
        [JsonConstructor]
        public Lumber(Distance thickness, Distance width, Distance length, string grade = "", string species = "", string treatmentType = "", string mill = "", string passedBundle = "", string other = "")
        {
            this.Thickness = thickness;
            this.Width = width;
            this.Length = length;
            this.Grade = grade;
            this.Species = species;
            this.TreatmentType = treatmentType;
            this.Mill = mill;
            this.Other = other;
        }

        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="passedLumber">lumber object to be copied</param>
        public Lumber(Lumber passedLumber)
        {
            if (passedLumber != null)
            {
                this.Thickness = passedLumber.Thickness;
                this.Width = passedLumber.Width;
                this.Length = passedLumber.Length;
                this.Grade = passedLumber.Grade;
                this.Mill = passedLumber.Mill;
                this.Species = passedLumber.Species;
                this.TreatmentType = passedLumber.TreatmentType;
                this.Other = passedLumber.Other;
            }
        }

        public override string ToString()
        {
            return Species + " " + NominalHeight + "X" + NominalWidth + ", Length = " + Length.Architectural;
        }
    }
}
