using BitsTask.Contracts;
using CsvHelper.Configuration;

namespace BitsTask.Mappings;

public class CsvDataDtoMap : ClassMap<CsvDataDto>
{
    public CsvDataDtoMap()
    {
        Map(m => m.Name);
        Map(m => m.DateOfBirth);
        Map(m => m.Married);
        Map(m => m.Phone);
        Map(m => m.Salary);
    }
}