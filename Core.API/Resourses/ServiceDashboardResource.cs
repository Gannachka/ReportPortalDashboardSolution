﻿using Core.API.Domain.Resourses;

namespace Core.API.Resourses
{
    public class ServiceDashboardResource : ServiceBaseResource, IDashboardResource
    {
        public ServiceDashboardResource(HttpClient httpClient, string projectName) : base(httpClient, projectName)
        { }

        public async Task<CreateDashboardResponse> CreateAsync(CreateDashboardRequest createDashboardRequest) =>
            await PostAsJsonAsync<CreateDashboardResponse, CreateDashboardRequest>(
                $"{ProjectName}/dashboard", createDashboardRequest, CancellationToken.None).ConfigureAwait(false);

        public async Task<UpdateDashboardResponse> UpdateAsync(int dashboardId, UpdateDashboardRequest updateDashboardRequest) =>
            await PutAsJsonAsync<UpdateDashboardResponse, UpdateDashboardRequest>(
                $"{ProjectName}/dashboard/{dashboardId}", updateDashboardRequest, CancellationToken.None).ConfigureAwait(false);

        public async Task DeleteAsync(int dashboardId) =>
            await DeleteAsJsonAsync<string>(
                $"{ProjectName}/dashboard/{dashboardId}", CancellationToken.None).ConfigureAwait(false);
    }
}
