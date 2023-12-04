namespace Sorting_Visualization
{
    internal static class Program
    {
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int[] ints = { 51, 42, 93, 14, 80, 67, 49, 72, 4, 23, 11, 98 };
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var sortVisualizer = new SortVisualizer(ints);
            Sorter<int> sorter = new InsertionSorter<int>(sortVisualizer);
            sortVisualizer.sorter = sorter;
            Application.Run(sortVisualizer);
        }
    }
}