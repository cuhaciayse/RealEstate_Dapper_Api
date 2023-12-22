namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int ProductCount();
        int ApartmentCount();    // Apartman sayısı
        string EmployeeNameByMaxProductCount();
        string CategoryNameByMaxProductCount();   
        decimal AverageProductPriceByRent();     // Kiralık evlerin ortalama fiyatı
        decimal AverageProductPriceBySale();    // Satılık evlerin ortalama fiyatı
        string CityNameByMaxProductCount();   // En fazla ilanın olduğu şehir
        int DifferentCityCount();
        decimal LastProductPrice();
        string NewestBuildingYear();   // En yeni bina
        string OldestBuildingYear();   // En eski bina
        int ActiveEmployeeCount();    // Aktif çalışan sayısı
        int AvereageRoomCount();   // Ortalama oda sayısı
    }
}
