using System.ComponentModel.DataAnnotations;

namespace InspectionAPI
{
    public class InspectionTyp
    {
        public int id { get; set; }

        [StringLength(20)]
        public string InspectionName { get; set; } = string.Empty;

    }
}
