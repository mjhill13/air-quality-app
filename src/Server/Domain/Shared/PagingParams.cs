using AirQualityApp.Shared.Models;
using Flurl;

namespace AirQualityApp.Server.Domain.Shared;

public record PagingParams(string OrderBy = "", int Limit = 100, int Page = 1, int Offset = 0,
    SortOrder Sort = SortOrder.Asc)
{
    public QueryParamCollection AsQueryParams =>
        new()
        {
            { "order_by", OrderBy },
            { "limit", Limit },
            { "page", Page },
            { "offset", Offset },
            { "sort", Sort.ToString().ToLowerInvariant() },
        };
}