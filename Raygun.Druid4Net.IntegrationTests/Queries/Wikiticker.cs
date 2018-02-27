namespace Raygun.Druid4Net.IntegrationTests.Queries
{
  public class Wikiticker
  {
    public static string DataSource = "wikiticker";

    public class Dimensions
    {
      public static string Channel = "channel";
      public static string CityName = "cityName";
      public static string Comment = "comment";
      public static string CountryCode = "countryIsoCode";
      public static string CountryName = "countryName";
      public static string IsAnonymous = "isAnonymous";
      public static string IsMinor = "isMinor";
      public static string IsNew = "isNew";
      public static string IsRobot = "isRobot";
      public static string IsUnpatrolled = "isUnpatrolled";
      public static string MetroCode = "metroCode";
      public static string Namespace = "namespace";
      public static string Page = "page";
      public static string RegionCode = "regionIsoCode";
      public static string RegionName = "regionName";
      public static string User = "user";
    }

    public class Metrics
    {
      public static string Count = "count";
      public static string Added = "added";
      public static string Deleted = "deleted";
      public static string Delta = "delta";
      public static string UserUnique = "user_unique";
    }
  }
}