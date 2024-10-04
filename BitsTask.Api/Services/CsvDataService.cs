using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BitsTask.Context;
using BitsTask.Contracts;
using BitsTask.Mappings;
using BitsTask.Models;
using CsvHelper;
using Microsoft.AspNetCore.Http;

public class CsvDataService
{
    private readonly CsvDbContext _dbContext;

    public CsvDataService(CsvDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ProcessCsvData(IFormFile file)
    {
        using (var reader = new StreamReader(file.OpenReadStream()))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            
            csv.Context.RegisterClassMap<CsvDataDtoMap>();

            var csvDataDtos = csv.GetRecords<CsvDataDto>()
                .Where(dto => !string.IsNullOrWhiteSpace(dto.Name) && dto.DateOfBirth != default && !string.IsNullOrWhiteSpace(dto.Phone))
                .ToList();

            // видалення існуючих записів(якщо потрібно)
            var existingData = _dbContext.CsvData.ToList();
            _dbContext.CsvData.RemoveRange(existingData);
            await _dbContext.SaveChangesAsync();

            var newData = csvDataDtos.Select(dto => new CsvData
            {
                Id = Guid.NewGuid(), 
                Name = dto.Name,
                DateOfBirth = dto.DateOfBirth,
                Married = dto.Married,
                Phone = dto.Phone,
                Salary = dto.Salary
            }).ToList();

            _dbContext.CsvData.AddRange(newData);
            await _dbContext.SaveChangesAsync();
        }
    }

    public IEnumerable<CsvDataDto> GetCsvData()
    {
        return _dbContext.CsvData
            .Select(c => new CsvDataDto
            {
                Id = c.Id,
                Name = c.Name,
                DateOfBirth = c.DateOfBirth,
                Married = c.Married,
                Phone = c.Phone,
                Salary = c.Salary
            })
            .ToList();
    }
}