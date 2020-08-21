﻿using NhatDaiShop.Data.Infrastructure;
using NhatDaiShop.Data.Repositories;
using NhatDaiShop.Model.Models;
using System;

namespace NhatDaiShop.Service
{
    public interface IErrorService
    {
        Error Create(Error error);

        void Save();
    }

    public class ErrorService : IErrorService
    {
        private IErrorRepository _errorRepository;
        private IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}