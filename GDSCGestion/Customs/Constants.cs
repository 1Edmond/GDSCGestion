namespace GDSCGestion.Customs;

public static class Constants
{
    private static readonly string DBNAME = "GDSCGestion.db3";
    public static readonly string database = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DBNAME);
}
