namespace ConsoleApp.Interfaces
{
    public interface IMenuService
    {
        /// <summary>
        /// Display the menu
        /// </summary>
        /// <returns>Void</returns>
        void DisplayMenu();

        /// <summary>
        /// Takes the user input converter into a INT
        /// </summary>
        /// <returns>Returns choiec as an int</returns>
        public int GetMenuChoice();
    }
}