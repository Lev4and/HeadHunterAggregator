﻿using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.HeadHunter
{
    public interface IIndustriesHttpClient
    {
        Task<ResponseModel<Industry[]>> GetIndustriesAsync();
    }
}