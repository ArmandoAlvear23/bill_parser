public partial class Program
{
    public abstract class Report
    {
        protected abstract string GenerateHeader();
        protected abstract string GenerateBody();
        public abstract string GenerateReport();
    }

}