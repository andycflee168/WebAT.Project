namespace WebAT.Interfaces
{
    public interface IWebAutomation {
        bool ReadConfig(string filePath);
        void PreformActions();
    }
}