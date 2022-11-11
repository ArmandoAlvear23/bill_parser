using System.Text;

public partial class Program
{
    public class DateCorrector
    {
        public string CorrectedDate { get; private set; }

        public DateCorrector(string date)
        {
            CorrectDate(date);
        }

        // Corrects the month section of the input date string
        private void CorrectDate(string date)
        {
            StringBuilder correctDate = new StringBuilder();

            // Iterate through each month of the year abbreviation
            foreach (string name in Enum.GetNames(typeof(MonthAbbreviations)))
            {
                // Check if month value of input date contains any
                // of the MonthAbbreviations enum values
                if(date.Substring(0, date.IndexOf('-')).Contains(name))
                {
                    // Substitue the month value in the input date
                    // to the value of the MonthAbbreviations enum value
                    correctDate.Append($"{name}{date.Substring(date.IndexOf("-"))}");
                }
            }

            // Set the corrected date string to the object property CorrectedDate
            CorrectedDate = correctDate.ToString();
        }
    }

}