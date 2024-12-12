using SummaryService.Data.Interfaces;
using SummaryService.Data.Provider;

namespace SummaryService.Data;

public class SummaryRepository(IDataProvider provider) : ISummaryRepository
{
}
