namespace WebAT.Classes
{
    public struct performanceResult
    {
        public double frontendPerformance { get; set; }
        public double backendPerformance { get; set; }

        public override string ToString() {
            return $"Load time: { this.frontendPerformance }";   
        }
    }
}